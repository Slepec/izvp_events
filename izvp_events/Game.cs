using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izvp_events
{
    public class Game
    {
        private int sticks;
        private bool isUserFirst;

        public bool IsUserFirst { get => isUserFirst; set => isUserFirst = value; }
        public int Sticks { get => sticks; set => sticks = value; }

        public Game(int number, bool iuf)
        {
            Sticks = number;
            IsUserFirst = iuf;
        }
        public delegate void gameHandler(string message);
        public event gameHandler withdraw;
        public bool withdrawSticks(int number)
        {
            Sticks -= number;
            if (IsUserFirst)
            {
                withdraw?.Invoke($"Ви взяли {number}");
                IsUserFirst = false;
            }
            else
            {
                withdraw?.Invoke($"Компютер взяв {number}");
                IsUserFirst = true;
            }
            if (Sticks < 1)
            {
                return false;
            }
            return true;
        }
    }
}
