using System;
using System.Collections.Generic;

namespace DiceRoller
{
    public class DiceRollerRepository
    {
        public bool ReturnBoolean(string multipleResponse)
        {
            if (multipleResponse.Contains("y") || multipleResponse.Contains("Y"))
                return true;
            else
                return false;

        }

        public List<int> GetResults(int numOfDice, int diceChoice)
        {
            List<int> rollResults = new List<int>();
           for(int i=0; i<numOfDice; i++)
            {
                var randomNumber = GetRandomNumber(diceChoice);
                rollResults.Add(randomNumber);
            }
            return rollResults;
        }

        public int GetRandomNumber(int i)
        {
            Random random = new Random();
            int result;
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
    }
}