using System;
using System.Threading;

namespace DiceRoller
{
    public class ProgramUI
    {
        readonly IConsole _console;
        readonly DiceRollerRepository _diceRepo;

        public ProgramUI(IConsole console)
        {
            _console = console;
            _diceRepo = new DiceRollerRepository();
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                int numOfDice = 1;
                int bonus = 0;

                _console.WriteLine($"Which dice would you like to roll?\n" +
                    $"1. 1d4\t2. 1d6\t3. 1d8\t4. 1d10\t5. 1d12\t6. 1d20\t7. 1d100");
                var diceChoice = int.Parse(_console.ReadLine());
                var diceType = _diceRepo.GetDiceType(diceChoice);

                _console.WriteLine("Would you like to add a modifier to your roll?");
                var hasModifer = GetBool();
                if (hasModifer)
                {
                        _console.WriteLine("Please enter the value of the modifier.");
                        var bonusStr = _console.ReadLine();
                        bonus = int.Parse(bonusStr);
                }

                _console.WriteLine($"Would you like to roll more than one {diceType}? y/n");
                bool isMultiple = GetBool();
                if (isMultiple)
                {
                    _console.WriteLine("How many dice do you want to roll?");
                    numOfDice = int.Parse(_console.ReadLine());
                }

                var results = _diceRepo.GetResultsList(numOfDice, diceChoice);
                _console.Clear();

                Console.WriteLine("Would you like your results as a list, total, or both?");
                var resultStyle = _console.ReadLine().ToLower();

                switch (resultStyle)
                {
                    case "list":
                        _console.WriteLine("Your Results:");
                        foreach (var i in results)
                            _console.WriteLine(i);
                        break;
                    case "total":
                        _console.WriteLine($"Your total is: {_diceRepo.GetSumOfResults(results, bonus)}");
                        break;
                    case "both":
                        _console.WriteLine("Your Results:");
                        foreach (var i in results)
                            _console.WriteLine(i);
                        _console.WriteLine($"\nYour modifer is: {bonus}");
                        _console.WriteLine($"\nYour total is: {_diceRepo.GetSumOfResults(results, bonus)}");
                        break;
                    default:
                        _console.WriteLine("Please enter a correct response.");
                        break;
                }
                Thread.Sleep(25);

                _console.WriteLine("Would you like to roll again? y/n");
                isRunning = GetBool();
            }
            _console.WriteLine("Have a nice day!");
            Thread.Sleep(1045);
        }

        private bool GetBool()
        {
            var multipleResponse = _console.ReadLine();
            var isMultiple = _diceRepo.ReturnBoolean(multipleResponse);
            return isMultiple;
        }
    }
}