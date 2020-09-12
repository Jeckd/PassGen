using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

using CommandLine;

namespace PassGen
{
    class Program
    {

        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<CommandLineGenerateOption>(args)
                .MapResult((CommandLineGenerateOption o)=> Generate(o), (errs) => Error(errs));
        }

        private static int Generate(CommandLineGenerateOption option)
        {
            var requirements = new PasswordRequirements(
                    option.Length,
                    option.UpperCharactersCount,
                    option.DigitsCount,
                    option.NonLettersCount);

            var pass = PasswordGenerator.GetPassword(requirements);

            Console.WriteLine(pass);

            if (option.PrintStatistic)
            {
                PrintStatistic(pass);
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

            return 1;
        }

        private static int Error(IEnumerable<Error> errors)
        {
            Console.ReadLine();
            return 1;
        }

        private static void PrintStatistic(string s)
        {
            Console.WriteLine($"Upper letters count:\t{s.Count((c)=>char.IsUpper(c))}");
            Console.WriteLine($"Lower letters count:\t{s.Count((c)=>char.IsLower(c))}");
            Console.WriteLine($"Digits count:\t{s.Count((c)=>char.IsDigit(c))}");
            Console.WriteLine($"Non letters characters count:\t{s.Count((c)=>!char.IsLetter(c))}");
        }

    }
}
