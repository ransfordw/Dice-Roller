using System;

namespace DiceRoller
{
    public class ProgamUI
    {
        public void Run()
        {
            DiceRollerRepository diceRepo = new DiceRollerRepository();
            bool isRunning = true;
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
                    var numOfDice = int.Parse(Console.ReadLine());
                }


            }

            throw new NotImplementedException();
        }
    }
}