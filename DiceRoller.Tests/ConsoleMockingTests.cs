using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRoller.Tests
{
    [TestClass]
    public class ConsoleMockingTests
    {
        [DataTestMethod]
        [DataRow("1", "n","n", "one 1d4?")]
        [DataRow("3", "n","n", "one 1d8?")]
        [DataRow("6", "n","n", "one 1d20?")]
        public void DiceRollerRepository_DiceChoice_ShouldSelectCorrectOption(string input, string inputTwo, string inputThree, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { input, inputTwo, inputThree };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains(assert));
        }

        [DataTestMethod]
        [DataRow("1","y","2","n","How many")]
        [DataRow("1","Y","2","n","How many")]
        //[DataRow("1","","n","How many")]
        [TestMethod]
        public void DiceRollerRepository_MultipleDiceChoice_ShouldSelectForMoreDice(string inputOne, string inputTwo, string inputThree, string inputFour, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { inputOne, inputTwo, inputThree, inputFour };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains(assert));
        }

        [DataTestMethod]
        [DataRow("1","","n","How many")]
        [DataRow("1","ewrqnicrpo349","n","How many")]
        [TestMethod]
        public void DiceRollerRepository_MultipleDiceChoice_ShouldNotSelectForMoreDice(string inputOne, string inputTwo, string inputThree, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { inputOne, inputTwo, inputThree };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsFalse(console.Output.Contains(assert));
        }

        [TestMethod]
        public void DiceRollerRepository_RollDiceAgain_ShouldNotContainExitMessage()
        {
         
        }
    }
}
