using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRoller.Tests
{
    [TestClass]
    public class ConsoleMockingTests
    {
        [DataTestMethod]
        [DataRow("2", "1", "n", "n", "total", "n", "one 1d4?")]
        [DataRow("2", "3", "n", "n", "total", "n", "one 1d8?")]
        [DataRow("2", "6", "n", "n", "total", "n", "one 1d20?")]
        public void DiceRollerRepository_DiceChoice_ShouldSelectCorrectOption(string input, string input2, string input3, string input4, string input5, string input6, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { input, input2, input3, input4, input5, input6 };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains(assert));
        }

        [DataTestMethod]
        [DataRow("2", "1", "n", "Y", "1", "total", "n", "How many")]
        [DataRow("2", "1", "n", "y", "2", "total", "n", "How many")]
        public void DiceRollerRepository_MultipleDiceChoice_ShouldSelectForMoreDice(string input, string input2, string input3, string input4, string input5, string input6, string input7, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { input, input2, input3, input4, input5,input6,input7 };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains(assert));
        }

        [DataTestMethod]
        [DataRow("2", "1", "n", "n", "total", "n", "How many")]
        [DataRow("2", "1", "n", "ewrqnicrpo349", "total", "n", "How many")]
        public void DiceRollerRepository_MultipleDiceChoice_ShouldNotSelectForMoreDice(string input, string input2, string input3, string input4, string input5, string input6, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { input, input2, input3,input4,input5,input6 };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsFalse(console.Output.Contains(assert));
        }

        [DataTestMethod]
        [DataRow("1", "", "n", "Have a nice day!")]
        [DataRow("1", "ewrqnicrpo349", "n", "Have a nice day!")]
        public void DiceRollerRepository_RollDiceAgain_ShouldContainExitMessage(string inputOne, string inputTwo, string inputThree, string assert)
        {
            //-- Arrange
            var commandList = new List<string> { inputOne, inputTwo, inputThree };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains(assert));
        }
    }
}
