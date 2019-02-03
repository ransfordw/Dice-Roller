using System;
using System.Collections.Generic;

namespace DiceRoller
{
    public class DiceRollerRepository : IDiceRoller
    {
        //Moved my instantiation of Random outside of GetRandomNumber to generate "random" numbers off the same seed time to avoid replicating results. See https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.7.2 for more info
        Random random = new Random();

        public bool ReturnBoolean(string multipleResponse)
        {
            multipleResponse.ToLower();
            if (multipleResponse.Contains("y"))
                return true;
            else
                return false;
        }

        public List<int> GetResultsList(int numOfDice, int diceChoice)
        {
            List<int> rollResults = new List<int>();
            for (int i = 0; i < numOfDice; i++)
            {
                var randomNumber = GetRandomNumber(diceChoice);
                rollResults.Add(randomNumber);
            }
            return rollResults;
        }

        public int GetSumOfResults(List<int> results, int modifier)
        {
            int total = 0;
            foreach (int result in results)
                total += result;
            total += modifier;
            return total;
        }

        public int GetRandomNumber(int i)
        {
            //If you define Random here instead of at the top of the repository and choose multiple dice, the results will be the same for each roll.
            //Random random = new Random();
            int result = 0;
            switch (i)
            {
                case 1:
                    result = random.Next(1, 5);
                    break;
                case 2:
                    result = random.Next(1, 7);
                    break;
                case 3:
                    result = random.Next(1, 9);
                    break;
                case 4:
                    result = random.Next(1, 11);
                    break;
                case 5:
                    result = random.Next(1, 13);
                    break;
                case 6:
                    result = random.Next(1, 21);
                    break;
                case 7:
                    result = random.Next(1, 101);
                    break;
                default:
                    result = random.Next(1, 4);
                    break;
            }
            return result;
        }

        public string GetDiceType(int i)
        {
            string diceType;

            switch (i)
            {
                case 1:
                    diceType = "1d4";
                    break;
                case 2:
                    diceType = "1d6";
                    break;
                case 3:
                    diceType = "1d8";
                    break;
                case 4:
                    diceType = "1d10";
                    break;
                case 5:
                    diceType = "1d12";
                    break;
                case 6:
                    diceType = "1d20";
                    break;
                case 7:
                    diceType = "1d100";
                    break;
                default:
                    diceType = "1d3";
                    break;
            }
            return diceType;
        }
    }
}