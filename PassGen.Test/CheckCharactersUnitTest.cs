using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassGen;

namespace PassGen.Test
{
    [TestClass]
    public class CheckCharactersUnitTest
    {
        [TestMethod]
        public void GetDigitsCount_returns_right_count_of_digits()
        {
            Assert.IsTrue(PassGen.PasswordGenerator.GetDigitsCount(Helper.GetTestString()) == 10);
        }

        [TestMethod]
        public void GetUpperCaseCount_returns_right_count_of_capital_letters()
        {
            Assert.IsTrue(PasswordGenerator.GetUpperLettersCount(Helper.GetTestString()) == 26);
        }

        [TestMethod]
        public void GetNonLettersCount_returns_right_count_of_non_letters()
        {
            var nonLettersCount = PasswordGenerator.MaxCharNum - PasswordGenerator.MinCharNum - 10 - 26 * 2+1;
            Assert.IsTrue(PasswordGenerator.GetNonLettersCount(Helper.GetTestString()) == nonLettersCount);
        }

    }
}
