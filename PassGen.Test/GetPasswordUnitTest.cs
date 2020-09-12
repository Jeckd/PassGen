using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassGen;
using System.Linq;

namespace PassGen.Test
{

    [TestClass]
    public class GetPasswordUnitTest
    {

        [TestMethod]
        public void GetPassword_returns_right_length_string()
        {
            var passwordLength = 20;
            Assert.AreEqual(PasswordGenerator.GetPassword(passwordLength).Length, passwordLength);
        }

        [TestMethod]
        public void GetPassword_returns_string_with_equal_or_greater_capital_letters_count_than_requred_()
        {

            var capitalLettersCount = 20;
            var requrements = new PasswordRequirements(100, capitalLettersCount, 20, 20);

            var realCapitalLettersCount = PasswordGenerator.GetPassword(requrements).Count((c) => char.IsUpper(c));

            Assert.IsTrue(realCapitalLettersCount >= capitalLettersCount);
        }

        [TestMethod]
        public void GetPassword_returns_string_with_equal_or_greater_digits_count_than_requred()
        {

            var digitsCount = 20;
            var requrements = new PasswordRequirements(100, 20, digitsCount, 20);

            var realDigitsCount = PasswordGenerator.GetPassword(requrements).Count((c) => char.IsDigit(c));

            Assert.IsTrue(realDigitsCount >= digitsCount);
        }

        [TestMethod]
        public void GetPassword_returns_string_with_equal_or_greater_non_letters_or_digits_count_than_requred()
        {

            var otherLettersCount = 20;
            var requrements = new PasswordRequirements(100, 20, 20, otherLettersCount);

            var realOtherLettersCount = PasswordGenerator.GetPassword(requrements).Count((c) => !char.IsLetterOrDigit(c));

            Assert.IsTrue(realOtherLettersCount >= otherLettersCount);
        }

    }
}
