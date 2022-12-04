using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    public class PasswordRequirements
    {

        public PasswordRequirements(int length, int upperLettersCount, int digitsCount, int nonLettersCount)
        {
            Length = length;
            UpperLettersCount = upperLettersCount;
            DigitsCount = digitsCount;
            NonLettersCount = nonLettersCount;
        }

        public int Length { get;}
        public int UpperLettersCount { get; }
        public int DigitsCount { get; }
        public int NonLettersCount {get;}

    }
}
