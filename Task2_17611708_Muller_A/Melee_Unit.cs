using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_17611708_Muller_A
{
    [Serializable]
    public class Melee_Unit : Unit
    {
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }



        public int XPos
        {
            get { return base.xPoS; }
            set { base.xPoS = value; }
        }


        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }


        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }


        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }


        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }


        public int Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }


        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        

        public override void MovePos(Direction d)
        {
            switch (d)
            {
                case Direction.North:
                    {
                        YPos -= Speed;
                        break;
                    }//end case
                case Direction.East:
                    {
                        XPos += Speed;
                        break;
                    }//end case
                case Direction.South:
                    {
                        YPos += Speed;
                        break;
                    }//end case
                case Direction.West:
                    {
                        XPos -= Speed;
                        break;
                    }// end case
            }//end switch

        }// works out new x and y positions 

        public override void Fight(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Health -= ((Melee_Unit)u).Attack;
            }//end if
            else if (u.GetType() == typeof(Ranged_Unit))
            {
                Health -= ((Ranged_Unit)u).Attack;
            }// end else if

        }// works out new health value

        public override bool WithinRange(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                if (DistanceTo(u) <= AttackRange)
                {
                    return true;
                }//end if
                else
                {
                    return false;
                }//end else
            }//end if

            return false;

        }//works out if an object is close enough for attack

        public override Unit NearestUnit(Unit[] units)
        {
            Unit closest = this;
            int closestDistance = 50;
            foreach (Unit u in units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    if (((Melee_Unit)u).Faction == Faction)
                    {
                        if (DistanceTo((Melee_Unit)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Melee_Unit)u);
                        }//end if
                    }//end if

                    
                    else if (u.GetType() == typeof(Ranged_Unit))
                    {
                        if (DistanceTo((Ranged_Unit)u) > closestDistance)
                        {
                            closest = u;
                            closestDistance = DistanceTo((Ranged_Unit)u);
                        }//end if
                    }//end else if

                }//end if

            }//end foreach
            return closest;
        }//works out closest unit

        public override bool IsDeath()
        {
            if (Health <= 0)
            {
                return true;
            }//end if
            else
            {
                return false;
            }//end else
        }//works out if an object is out of health

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;
                int d = Math.Abs(XPos - m.XPos) + Math.Abs(YPos - m.YPos);
                return d;
            }//end if
            else
            {
                return 0;
            }//end else
        }//works out distance from one unit to another

        public Melee_Unit(string name, int y, int x, int hp, int attack, int range, int speed, int faction, string symbol)
        {
            Name = name;
            XPos = x;
            YPos = y;
            Health = hp;
            Speed = speed;
            AttackRange = range;
            Attack = attack;
            Faction = faction;
            Symbol = symbol;
        }//constructor 

        public override string ToString()
        {
            return name + "," + XPos + "," + YPos + "," + Health+ ","+ Speed + 
                ","+AttackRange +","+Attack+","+Faction+","+Symbol;
        }// to string

        public Direction DirectionTo(Unit u)
        {
            if (u.GetType() == typeof(Melee_Unit))
            {
                Melee_Unit m = (Melee_Unit)u;
                if (m.XPos < XPos)
                {
                    return Direction.North;

                }//end if
                else if (m.XPos > XPos)
                {
                    return Direction.South;
                }//end else if
                else if (m.YPos < YPos)
                {
                    return Direction.West;
                }//end else if
                else
                {
                    return Direction.East;

                }//end else
            }//end else
            else
            {
                return Direction.North;
            }//end else
        }// works out direction of movement 

        public override void Save()
        {

            using (StreamWriter sw = new StreamWriter("MeleeUnit.txt",true))
            {
                try
                { 
                
                    sw.WriteLine(ToString());
  
                }//end try
                catch (Exception e)
                {
                    MessageBox.Show(("Exception: " + e.Message));

                }//end catch

            }// end using 

                
            


           
        }// writes information of object to textfile

        
    }
}
