using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new RealConsole();
            ProgamUI program = new ProgamUI(console);
            program.Run();

        }
    }
}
