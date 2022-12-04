using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    class Program
    {

        private const char ArgSeparator = '='; 

        static void Main(string[] args)
        {


            var pass = PasswordGenerator.GetPassword(new PasswordRequirements(10, 2, 2, 2));
            Console.WriteLine(pass);
            PrintStatistic(pass);

            Console.ReadLine();
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
