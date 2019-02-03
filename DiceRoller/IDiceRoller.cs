using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    public interface IDiceRoller
    {
        bool ReturnBoolean(string s);
        List<int> GetResultsList(int number, int choice);
        int GetRandomNumber(int i);
    }
}
