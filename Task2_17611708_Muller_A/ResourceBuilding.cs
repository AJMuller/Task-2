using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_17611708_Muller_A
{
    public class ResourceBuilding : Building
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

        private int ResourceType;

        public int resourceType
        {
            get { return ResourceType; }
            set { ResourceType = value; }
        }

        private int ResourcesPerGameTick;

        public int resourcesPerGameTick
        {
            get { return ResourcesPerGameTick; }
            set { ResourcesPerGameTick = value; }
        }

        private int ResourcesRemaining;

        public int resourcesRemaining
        {
            get { return ResourcesRemaining; }
            set { ResourcesRemaining = value; }
        }

        void ResourceGenerator()
        {

        }


        public ResourceBuilding(int health, int xPos, int yPos, int faction, string symbol)
        {
            Health = health;
            XPos = xPos;
            YPos = yPos;
            Faction = faction;
            Symbol = symbol;


        }// constructor
        public override bool IsDestroyed()
        {
            if (health >0)
            {
                return true;
            }//end if
            else
            {
                return false;
            }//end else

        }// checks if health is 0 or below 

        public override string ToString()
        {
            return "Resource Building," + health + "," + XPos + "," + YPos + "," + Faction + "," + Symbol;
        }// creates a string

        public override void Save()
        {

            using (StreamWriter rbsw = new StreamWriter("ResourceBuilding.txt", true))
            {
                try
                {

                    rbsw.WriteLine(ToString());

                }//end try
                catch (Exception e)
                {
                    MessageBox.Show(("Exception: " + e.Message));

                }//end catch

            }//end using

        }// writes information of object to textfile


    }
}
