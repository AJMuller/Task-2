using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_17611708_Muller_A
{
    public partial class Form1 : Form
    {
        Map map = new Map(20, 20, 20,4);
        const int START_X = 20;
        const int START_Y = 20;
        const int SPACING = 20;
        const int SIZE = 20;
        Random r = new Random();
        int turn = 0;
        public Form1()

        {

            InitializeComponent();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            DisplayMap();
        }

        private void DisplayMap()
        {
            mapBox.Controls.Clear();
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Melee_Unit m = (Melee_Unit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }
                else
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    Ranged_Unit m = (Ranged_Unit)u;
                    Button b = new Button();
                    b.Size = new Size(SIZE, SIZE);
                    b.Location = new Point(start_x + (m.XPos * SIZE), start_y + (m.YPos * SIZE));
                    b.Text = m.Symbol;
                    if (m.Faction == 1)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    if (m.IsDeath())
                    {
                        b.ForeColor = Color.Black;
                    }

                    b.Click += new EventHandler(button_click);
                    mapBox.Controls.Add(b);
                }



            }

            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    FactoryBuilding fb = (FactoryBuilding)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (fb.XPos * SIZE), start_y + (fb.YPos * SIZE));
                    btn.Text = fb.Symbol;
                    if (fb.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }
                    mapBox.Controls.Add(btn);

                }
                else
                {
                    int start_x, start_y;
                    start_x = mapBox.Location.X;
                    start_y = mapBox.Location.Y;
                    ResourceBuilding rb = (ResourceBuilding)b;
                    Button btn = new Button();
                    btn.Size = new Size(SIZE, SIZE);
                    btn.Location = new Point(start_x + (rb.XPos * SIZE), start_y + (rb.YPos * SIZE));
                    btn.Text = rb.Symbol;
                    if (rb.Faction == 1)
                    {
                        btn.ForeColor = Color.Red;
                    }
                    else
                    {
                        btn.ForeColor = Color.Blue;
                    }

                    mapBox.Controls.Add(btn);
                }



            }
        }

        private void UpdateMap()
        {
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;
                    if (m.IsDeath())
                    {

                    }
                    if (m.Health < 25)
                    {
                        switch (r.Next(0, 4))
                        {
                            case 0: m.MovePos(Direction.North); break;
                            case 1: m.MovePos(Direction.East); break;
                            case 2: m.MovePos(Direction.South); break;
                            case 3: m.MovePos(Direction.West); break;
                        }
                    }
                    else
                    {
                        bool inCombat = false;
                        foreach (Unit e in map.Units)
                        {

                            if (m.WithinRange(e))
                            {
                                m.Fight(e);
                                inCombat = true;
                            }
                        }
                        if (!inCombat)
                        {
                            Unit c = m.NearestUnit(map.Units);
                            m.MovePos(m.DirectionTo(c));
                        }
                    }


                }
            }
        }

       
        private void button_click(object sender, EventArgs e)
        {
            
            int x = (((Button)sender).Location.X - mapBox.Location.X) / SIZE;
            int y = (((Button)sender).Location.Y - mapBox.Location.Y) / SIZE;
            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }
                }
                else
                {
                    Ranged_Unit m = (Ranged_Unit)u;
                    if ((m.XPos == x) && (m.YPos == y))
                    {
                        txtDisplay.Text = "Button Clicked At: " + m.ToString();
                    }
                }
            }
        }

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            UpdateMap();
            DisplayMap();
            turn++;
            labTime.Text = turn + "";

        }

        private void butStart_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void butStop_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter rstrm = File.CreateText("RangedUnit.txt");
            rstrm.Flush();
            rstrm.Close();
            StreamWriter mstrm = File.CreateText("MeleeUnit.txt");
            mstrm.Flush();
            mstrm.Close();
            StreamWriter fbstrm = File.CreateText("FactoryBuilding.txt");
            fbstrm.Flush();
            fbstrm.Close();
            StreamWriter rbstrm = File.CreateText("ResourceBuilding.txt");
            rbstrm.Flush();
            rbstrm.Close();

            foreach (Unit u in map.Units)
            {
                if (u.GetType() == typeof(Melee_Unit))
                {
                    Melee_Unit m = (Melee_Unit)u;

                    m.Save();
                }//end if
                else
                {
                    Ranged_Unit m = (Ranged_Unit)u;

                    m.Save();

                }//end else



            }//end foreach
            foreach (Building b in map.Buildings)
            {
                if (b.GetType() == typeof(FactoryBuilding))
                {
                    FactoryBuilding f = (FactoryBuilding)b;

                    f.Save();
                }//end if
                else
                {
                    ResourceBuilding r = (ResourceBuilding)b;

                    r.Save();

                }//end else



            }//end foreach
        }// clears previous saves and calls methods to create new saves 

        private void btnLoad_Click(object sender, EventArgs e)
        {
      
            map.Read(20,4);
            DisplayMap();
        }//calls Read and DisplayMap Methods.
    }
}
