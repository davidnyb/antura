using Antura.Files;

namespace Antura
{
    class Program
    {
        private readonly string path;

        private Program(string path)
        {
            this.path = path;
        }

        private void Run()
        {
            try
            {
                var fileWrapper = new FileWrapper(path);
                var pattern     = fileWrapper.GetFileNameWithoutExtension();
                var text        = fileWrapper.ReadAllText();
                var count       = text.CountMatches(pattern);

                Console.WriteLine($"found {count} occurrences of {pattern} in {path}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void Main(string[] args)
        {
            var path = args.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(path))
                Console.WriteLine("Program needs file arg");
            else
                new Program(path).Run();

            Console.ReadLine();
        }
    }
}