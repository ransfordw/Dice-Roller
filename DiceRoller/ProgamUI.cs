using System;
using System.Threading;

namespace DiceRoller
{
    public class ProgamUI
    {
        readonly IConsole _console;
        readonly DiceRollerRepository _diceRepo;

        public ProgamUI(IConsole console)
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
                _console.WriteLine($"Which dice would you like to roll?\n" +
                    $"1. 1d4\t2. 1d6\t3. 1d8\t4. 1d10\t5. 1d12\t6. 1d20\t7. 1d100");
                var diceChoice = int.Parse(_console.ReadLine());

                var diceType = _diceRepo.GetDiceType(diceChoice);

                _console.WriteLine($"Would you like to roll more than one {diceType}? y/n");
                var multipleResponse = _console.ReadLine();
                var isMultiple = _diceRepo.ReturnBoolean(multipleResponse);
                if (isMultiple)
                {
                    _console.WriteLine("How many dice do you want to roll?");
                    numOfDice = int.Parse(_console.ReadLine());
                }

                var results = _diceRepo.GetResults(numOfDice, diceChoice);
                _console.Clear();

                _console.WriteLine("Your Results:");
                foreach (var i in results)
                {
                    _console.WriteLine(i);
                }
                Thread.Sleep(25);

                _console.WriteLine("Would you like to roll again? y/n");
                var cont = _console.ReadLine();
                isRunning = _diceRepo.ReturnBoolean(cont);
            }
            _console.WriteLine("Have a nice day!");
            Thread.Sleep(1045);
        }
    }
}