using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRoller.Tests
{
    [TestClass]
    public class DiceRollerRepositoryTests
    {
        DiceRollerRepository _diceRepo;
        [TestInitialize]
        public void Arrange()
        {
            _diceRepo = new DiceRollerRepository();
        }

        [TestMethod]
        public void DiceRollerRepository_ReturnBoolean_ShouldReturnFalse()
        {
            string response = "";

            var actual = _diceRepo.ReturnBoolean(response);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("y")]
        [DataRow("Y")]
        public void DiceRollerRepository_ReturnBoolean_ShouldReturnTrue(string response)
        {
            var actual = _diceRepo.ReturnBoolean(response);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiceRollerRepository_GetResults_ShouldReturnCorrectCount()
        {
            int num = 2;
            int choice = 4;

            var actual = _diceRepo.GetResultsList(num,choice).Count;
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d4()
        {
            int input = 1;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 4 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d6()
        {
            int input = 2;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 6 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d8()
        {
            int input = 3;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 8 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d10()
        {
            int input = 4;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 10 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d12()
        {
            int input = 5;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 12 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d20()
        {
            int input = 6;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 20 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange1d100()
        {
            int input = 7;
            var random = _diceRepo.GetRandomNumber(input);
            bool actual;

            if (random <= 100 && random >= 1)
                actual = true;
            else
                actual = false;
            var expected = true;

            Assert.AreEqual(actual, expected);
        }

        [DataTestMethod]
        [DataRow(1, "1d4")]
        [DataRow(2, "1d6")]
        [DataRow(3, "1d8")]
        [DataRow(4, "1d10")]
        [DataRow(5, "1d12")]
        [DataRow(6, "1d20")]
        [DataRow(7, "1d100")]
        public void DiceRollerRepository_GetDiceType_ShouldReturnCorrectString(int diceChoice, string correctDiceType)
        {
            var actual = _diceRepo.GetDiceType(diceChoice);
            var expected = correctDiceType;

            Assert.AreEqual(expected, actual);
        }
    }
}
