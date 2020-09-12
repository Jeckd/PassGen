using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace PassGen
{
    [Verb( "generate", HelpText = "Generate password")]
    public class CommandLineGenerateOption
    {
        [Option('l', "length",  Default = 10,  HelpText = "Password length")]
        public int Length { get; set; }

        [Option('u', "capital", Default = 2, HelpText = "Capital characters count")]
        public int UpperCharactersCount { get; set; }

        [Option('d', "digits", Default = 2, HelpText = "Digit count")]
        public int DigitsCount { get; set; }

        [Option('n', "nonLetters", Default = 2, HelpText = "Non letter characters count")]
        public int NonLettersCount { get; set; }

        [Option('s', "stat", Default = false, HelpText = "Print password statisitic")]
        public bool PrintStatistic { get; set; }

        [Option('w', "wait", Default = false, HelpText = "Wait for user input")]
        public bool WaitUserInput { get; set; }
    }
}
