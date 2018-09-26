using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_17611708_Muller_A
{
    public enum Direction { North, East, South, West }
    public abstract class Unit
    {
        protected int xPoS, yPos, health, speed, attack, attackRange, faction;
        protected string symbol, name;

        public Unit()
        {

        }

        abstract public void Save();
        abstract public void MovePos(Direction direction);
        abstract public void Fight(Unit u);
        abstract public bool WithinRange(Unit unit);
        abstract public Unit NearestUnit(Unit[] units);
        abstract public bool IsDeath();
        abstract public string ToString();


    }
}
