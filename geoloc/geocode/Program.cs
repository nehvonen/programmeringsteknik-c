using KdTree;
using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace geocode
{
    class Program
    {
        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;
        static readonly (double Lat, double Lng) _gavlePosition;
        static readonly (double Lat, double Lng) _uppsalaPosition;
       
        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(".\\Resources\\SE.txt");
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);
            _gavlePosition = (60.674622, 17.141830);
            _uppsalaPosition = (59.858562, 17.638927);
        }

        static void Main(string[] args)
        {
            var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosition.Lat, _gavlePosition.Lng, 10);
            nearestGavle = nearestGavle.OrderBy(p => p.Name);
            foreach (var position in nearestGavle)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{position.Name}, lat = {position.Latitude}, lng = {position.Longitude} ");
            }

            Console.WriteLine("\t \n Distance to Uppsala \t \n");

            int radius = 200 * 1000;
            var nearestUppsala = _reverseGeoCodingService.RadialSearch(_uppsalaPosition.Lat, _uppsalaPosition.Lng, radius, 50);
            nearestUppsala = nearestUppsala.OrderBy(p => p.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng));
            foreach (var position in nearestUppsala)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{position.Name}, Distance to Uppsala = {position.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng)}m");
            }
        }
    }
}
