using CommandLine;
using Imageflow.Fluent;
using System.IO;

namespace Resizer
{
    class Options
    {
        [Option('i', "input", Required = true, HelpText = "Path to input file.")]
        public string Input { get; set; }

        [Option('w', "width", Required = false, HelpText = "Width of output image.")]
        public uint? Width { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Skala om en bild beroende på angiven breddparameter

            // Denna övning använder imageflow
            // https://github.com/imazen/imageflow-dotnet#examples
            // (alla beroenden är installerade i projektet redan)

            // ImageJob.Decode med en System.IO.Stream som parameter laddar in en bild.
            // BuildNode.EncodeToStream (via method chain) kan användas för att skriva till fil

            // På grund av att imageflow är anpassat att köras på server, med kö-hantering,
            // behöver Finish().InProcessAsync() kallas för att beordra avslut på körningen.
            // InProcessAsync() är en asynkron metod och behöver inväntas, 
            // detta kan göras genom att lägga till .Wait(), annars avslutas programmet för tidigt.

            // Options-objektet behöver skapas från args
            // https://github.com/commandlineparser/commandline#quick-start-examples         

            Parser.Default.ParseArguments<Options>(args)
                            .WithParsed<Options>(Run);
        }

        static void Run(Options options)
        {
            using (var stream = File.OpenRead(options.Input))
            {
                var outputFileName = GetOutputFileName(options.Input);

                using (var outStream = File.OpenWrite(outputFileName))
                {
                    using (var job = new ImageJob())
                    {
                        job.Decode(stream, false)

                            .ResizerCommands("width=128&height=128&mode=crop")

                            .EncodeToStream(outStream, false, new MozJpegEncoder(90))
                            .Finish()
                            .InProcessAsync()
                            .Wait();
                    }
                }
                
            }

            
        }

        static string GetOutputFileName(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            string newFileName = $"{fileName}-resized{extension}";

            return Path.Combine(directory, newFileName);
        }
    }
}
