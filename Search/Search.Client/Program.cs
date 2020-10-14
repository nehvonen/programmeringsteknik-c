using CommandLine;
using Elasticsearch.Net;
using Search.Client.Options;
using Search.Client.Services;
using Search.Common.Models;
using Search.Common.Services;
using System;
using System.Collections.Generic;
using Error = CommandLine.Error;

namespace Search.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<SearchOptions, IndexOptions>(args)
                          .MapResult<SearchOptions, IndexOptions, object>(Search, Index, Error);
        }

        static object Search(SearchOptions options)
        {
            RecipeClient client = SearchClientFactory.CreateClient(options);

            // Denna övning använder ElasticSearch
            // https://www.elastic.co/

            // Dokumentation över hur man ställer frågor
            // https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/writing-queries.html

            // 1. Hitta 20 recept som innehåller ordet "fisk".
            // 2. Sortera sökträffarna efter rating.
            // 3. Räkna alla recept som är upplagda av Per Morberg.
            // 4. Hitta 30 recept som tillhör kategorin Bönor.
            // 5. Räkna alla recept som har en tillagningstid på under 10 minuter (tips: TimeSpan lagras som ticks i index).

<<<<<<< HEAD
            var result = client.Search(s => s.QueryOnQueryString(options.Query)
                                                .Sort(o => o.Descending(a => a.Rating))
                                                .Take(20));
=======
            //var result = client.Search(search => search.QueryOnQueryString(options.Query)
            //                                           .Sort(order => order.Descending(field => field.Rating))
            //                                           .Take(20));

            //Fråga mot specifikt fält
            //var result = client.Count(search => search.Query(
            //                                      query => query.Match(
            //                                          match => match.Field(field => field.Author)
            //                                                        .Query("Per Morberg"))));

            var result = client.Search(search => search.QueryOnQueryString("categories:\"Bönor\""));
>>>>>>> 51cf2a2b05f9887f869fae78fa8220545ca071fc

            return 0;
        }

        static object Index(IndexOptions options)
        {
            RecipeDocument recipe;

            try
            {
                recipe = RecipeFactory.CreateFrom(options.Url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }

            RecipeClient client = SearchClientFactory.CreateClient(options);

            var response = client.Index(recipe);

            Console.WriteLine($"Index: {FormatApiCall(response.ApiCall)}");

            return 0;
        }

        static object Error(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }

            return 1;
        }

        static string FormatApiCall(IApiCallDetails details)
        {
            int? status = details.HttpStatusCode;
            bool wasSuccess = details.Success;
            string path = details.Uri.AbsolutePath;

            return $"Response for '{path}', success: {wasSuccess}, status: {status}";
        }
    }
}
