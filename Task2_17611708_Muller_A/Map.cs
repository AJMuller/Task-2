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
    public class Map
    {
        Random r = new Random();
        private Unit[] units;
       
        

        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }

        private Building[] buildings;

        public Building[] Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }



        public Map(int maxX, int maxY, int numUnits, int numBuildings)
        {
            units = new Unit[numUnits]; 
            for (int i = 0; i < numUnits / 2; i++) // creates 
            {


                Melee_Unit m = new Melee_Unit("knight", r.Next(0, maxX),
                    r.Next(0, maxY),
                    100,
                    r.Next(5, 10),
                        1,
                        1,
                        i % 2,
                        "M");
                units[i] = m;

                Ranged_Unit ranged = new Ranged_Unit("knight", r.Next(0, maxX),
                   r.Next(0, maxY),
                    100,
                    r.Next(5, 10),
                        1,
                        1,
                        i % 2,
                        "R");
                units[i + (numUnits / 2)] = ranged;

            }//end for

            buildings = new Building[numBuildings];
            for (int i = 0; i < numBuildings / 2; i++)
            {
                FactoryBuilding fb = new FactoryBuilding
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "F");

                buildings[i] = fb;

                ResourceBuilding rb = new ResourceBuilding
                    (100, r.Next(0, maxX), r.Next(0, maxY), i % 2, "S");

                buildings[i + numBuildings/2] = rb;


            }//end for



            






        }//makes objects and generates values for these objects

        public void Read( int numUnits, int numBuildings)
        {
            int counter = 0;
            

          
            string[] stringArray = File.ReadAllLines("MeleeUnit.txt");
            units = new Unit[numUnits];

            foreach (string line in stringArray)
                {
                    if( line != "")
                     {
                            
                            Melee_Unit m = new Melee_Unit(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                            Convert.ToInt32(line.Split(',')[1]),
                            Convert.ToInt32(line.Split(',')[3]),
                            Convert.ToInt32(line.Split(',')[6]),
                            Convert.ToInt32(line.Split(',')[5]),
                            Convert.ToInt32(line.Split(',')[4]),
                            Convert.ToInt32(line.Split(',')[7]),
                            line.Split(',')[8]);
                            counter++;
                            units[counter - 1] = m;

                    }//end if
                    
                    

                }//end foreach


            string[] rstringArray = File.ReadAllLines("RangedUnit.txt");

            foreach (string line in rstringArray)
            {
                if (line != "")
                {

                    
                    Ranged_Unit m = new Ranged_Unit(line.Split(',')[0], Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[6]),
                    Convert.ToInt32(line.Split(',')[5]),
                    Convert.ToInt32(line.Split(',')[4]),
                    Convert.ToInt32(line.Split(',')[7]),
                    line.Split(',')[8]);
                    counter++;
                    units[counter - 1] = m;
                } //end if 

            }// end foreach



            int bcounter = 0;
            string[] fbstringArray = File.ReadAllLines("FactoryBuilding.txt");
            buildings = new Building[numBuildings];
            foreach (string line in fbstringArray)
            {
                if (line != "")
                {
                   
                    FactoryBuilding m = new FactoryBuilding(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                } //end if   

            }//end foreach


            string[] rbstringArray = File.ReadAllLines("ResourceBuilding.txt");
            

            foreach (string line in rbstringArray)
            {
                if (line != "")
                {

                    
                    ResourceBuilding m = new ResourceBuilding(Convert.ToInt32(line.Split(',')[1]),
                    Convert.ToInt32(line.Split(',')[2]),
                    Convert.ToInt32(line.Split(',')[3]),
                    Convert.ToInt32(line.Split(',')[4]),
                    line.Split(',')[5]);

                    bcounter++;
                    buildings[bcounter - 1] = m;
                }   //end if

            } //end foreach

            


        } // reads from textfile and creates objects with the values from the textfile

        
    }
}
