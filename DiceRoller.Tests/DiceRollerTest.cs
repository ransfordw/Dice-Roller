using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRoller.Tests
{
    [TestClass]
    public class DiceRollerTest
    {
        DiceRollerRepository _diceRepo;
        [TestInitialize]
        public void Arrange()
        {
            _diceRepo = new DiceRollerRepository();
        }

        [TestMethod]
        public void DiceRollerRepository_ReturnBoolean_ShouldReturnTrue()
        {
            string response = "";

            var actual = _diceRepo.ReturnBoolean(response);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("y")]
        [DataRow("Y")]
        public void DiceRollerRepository_ReturnBoolean_ShouldReturnFalse(string response)
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

            var actual = _diceRepo.GetResults(num,choice).Count;
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DiceRollerRepository_GetRandomNumber_ShouldReturnNumberInCorrectRange()
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
    }
}
