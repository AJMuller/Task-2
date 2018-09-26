using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_17611708_Muller_A
{
    public class FactoryBuilding : Building 
    {
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

        private int UnitsToProduce;

        public int unitsToProduce
        {
            get { return UnitsToProduce; }
            set { UnitsToProduce = value; }
        }

        private int GameTicksPerProduction;

        public int gameTicksPerProduction
        {
            get { return UnitsToProduce; }
            set { UnitsToProduce = value; }
        }

        private int SpawnPoint;

        public int spawnPoint
        {
            get { return SpawnPoint; }
            set { SpawnPoint = value; }
        }


        public FactoryBuilding(int health, int xPos, int yPos, int faction, string symbol)
        {
            Health = health;
            XPos = xPos;
            YPos = yPos;
            Faction = faction;
            Symbol = symbol;

        }// Constructor

        public override bool IsDestroyed()
        {
            if (health > 0)
            {
                return true;
            }//end if
            else
            {
                return false;
            }//end else

        }//checks if health is 0 or below 

        public override string ToString()
        {
            return "Factory Building," + health+","+XPos+","+YPos+","+Faction+","+Symbol ;
        }// creates a string

        void SpawnNewUnits()
        {

        }

        public override void Save()
        {

            using (StreamWriter sw = new StreamWriter("FactoryBuilding.txt", true))
            {
                try
                {

                    sw.WriteLine(ToString());

                }// end try
                catch (Exception e)
                {
                    MessageBox.Show(("Exception: " + e.Message));

                }//end catch

            }//end using

        }// writes information of object to textfile
    }
}
