using System;
using System.Threading;

namespace DiceRoller
{
    public class ProgamUI
    {
        public void Run()
        {
            DiceRollerRepository diceRepo = new DiceRollerRepository();
            bool isRunning = true;
            int numOfDice = 1;
            while (isRunning)
            {
                Console.WriteLine($"Which dice would you like to roll?\n" +
                    $"1. 1d4\t2. 1d6\t3. 1d8\t4. 1d10\t5. 1d12\t6. 1d20\t7. 1d100");
                var diceChoice = int.Parse(Console.ReadLine());

                Console.WriteLine($"Would you like to roll more than one? y/n");
                var multipleResponse = Console.ReadLine();
                var isMultiple = diceRepo.ReturnBoolean(multipleResponse);
                if (isMultiple)
                {
                    Console.WriteLine("How many dice do you want to roll?");
                    numOfDice = int.Parse(Console.ReadLine());
                }
                var results = diceRepo.GetResults(numOfDice, diceChoice);
                Console.Clear();
                Console.WriteLine("Your Results:");
                foreach(var i in results)
                {
                    Console.WriteLine(i);
                }
                Thread.Sleep(25);
                Console.WriteLine("Would you like to roll again? y/n");
                var cont = Console.ReadLine();
                isRunning = diceRepo.ReturnBoolean(cont);
            }
            Console.WriteLine("Have a nice day!");
            Thread.Sleep(1045);
        }
    }
}