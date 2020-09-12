using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassGen
{
    public class PasswordGenerator
    {

        private const int MinCharValue = 0x21;
        private const int MaxCharValue = 0x7E;

        public static string GetPassword(PasswordRequirements requirement)
        {
            if (!CheckPasswordReuirements(requirement))
                throw new InvalidOperationException("Wrong password requirements");

            var password = GetPassword(requirement.Length);

            while(!CheckPassword(password, requirement))
            {
                password = GetPassword(requirement.Length);
            }

            return password;
        }

        public static string GetPassword(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                sb.Append(GetRandomCharacter());
            }

            return sb.ToString();
        }

        private static char GetRandomCharacter()
        {

            var c = GetRandomPasswordChar();

            while(IsWrongChar(c))
            {
                c = GetRandomPasswordChar();

            }

            return c;
        }

        private static bool IsWrongChar(char c) => char.IsWhiteSpace(c) || char.IsControl(c) || char.IsSurrogate(c);

        private static char GetRandomPasswordChar() => Convert.ToChar(GetRandomCharCode(MinCharValue, MaxCharValue));

        public static bool CheckPasswordReuirements(PasswordRequirements r)=> r.Length >= (r.UpperLettersCount + r.DigitsCount + r.NonLettersCount);
        public static bool CheckPassword(string s, PasswordRequirements r) =>
                s.Length == r.Length
                && CheckUpperCaseCount(s, r.UpperLettersCount)
                && CheckDigitsCaseCount(s, r.DigitsCount)
                && CheckNonLettersCount(s, r.NonLettersCount);

        private static int GetRandomCharCode(int minValue, int maxValue) => GetRandom().Next(minValue, maxValue);
        private static Random GetRandom() => random.Value;
        private static Lazy<Random> random = new Lazy<Random>(() => new Random());


        private static bool CheckUpperCaseCount(string s, int count) => GetUpperLettersCount(s) >= count;
        private static bool CheckDigitsCaseCount(string s, int count) => GetDigitsCount(s) >= count;
        private static bool CheckNonLettersCount(string s, int count) => GetNonLettersCount(s) >= count;
        private static int GetUpperLettersCount(string s) => s.Count((c) => char.IsUpper(c));
        private static int GetDigitsCount(string s) => s.Count((c) => char.IsDigit(c));
        private static int GetNonLettersCount(string s) => s.Count((c) => char.IsPunctuation(c)&&(!char.IsDigit(c)));

    }
}
