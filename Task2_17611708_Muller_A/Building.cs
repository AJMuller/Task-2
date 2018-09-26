using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_17611708_Muller_A
{
    public abstract class Building
    {
        protected int xPoS, yPos, health, faction;
        protected string symbol;

        public Building()
        {

        }

        abstract public void Save();
        abstract public bool IsDestroyed();
        abstract public string ToString();
        

    }
}
