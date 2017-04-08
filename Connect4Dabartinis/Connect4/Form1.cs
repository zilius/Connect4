using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Connect4
{
    public partial class GameWindow : Form
    {
       
        public GameWindow()
        {
            InitializeComponent();
        }


        string[,] ejimai = new string[8, 7];

        List<List<Button>> _mygtukai = new List<List<Button>>();
        
        private void GameWindow_Load(object sender, EventArgs e)
        {
      
            for (int i = 0; i < 7; i++)
            {
                _mygtukai.Add(new List<Button>());

                for (int j = 0; j < 8; j++)
                {
                    _mygtukai[i].Add(new Button
                    {
                        Parent = panel1,
                        Location = new Point(25 * i + 5, 25 * j + 5),
                        Height = 25,
                        Width = 25,
                        Tag = $"{i + 1}{j + 1}",
                    });
                    
                    _mygtukai[i][j].Click += Button_Click;
                    
                    
                }
            }
            
            foreach (var sublist in _mygtukai)
            {
                foreach (var mygtukas in sublist)
                {
                    if (mygtukas.Tag.ToString()[1] != '1')
                    {
                        mygtukas.Enabled = false;
                    }
                }
            }
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
                                  
            var btn = (Button)sender;
            string tag = btn.Tag.ToString();
            int cell = (int)char.GetNumericValue(tag[0]);
            PlayerTurn(cell);
            CpuTurn();
            GameRules.CheckForVictory(ejimai);
        }

        private void PlayerTurn(int cell)
        {
            
            try
            {
                int lenght = _mygtukai[cell - 1].Count;

                var btnTochange = _mygtukai[cell - 1][lenght - 1];

                btnTochange.BackColor = Color.Brown;

                ProcessTurn(cell, lenght, "R");



            }
            catch (Exception)
            {
                MessageBox.Show("Cell full");
            }
             
        }

        private void CpuTurn()
        {
            var rnd = new Random();
            var cell = rnd.Next(1, 7); 

            try
            {
                int lenght = _mygtukai[cell - 1].Count;

                var btnTochange = _mygtukai[cell - 1][lenght - 1];

                btnTochange.BackColor = Color.Yellow;

                ProcessTurn(cell, lenght, "G");
                                                
            }
            catch (Exception)
            {
                MessageBox.Show("Cell full");
            }
        }

        private void LogEjimai()
        {
            textBox1.Text = "";//09632224

            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            for(int i = 0; i<rowLength; i++)
            {
                for(int j = 0; j< colLength;j++)
                {
                    if(string.IsNullOrEmpty(ejimai[i, j]))
                    {
                        textBox1.Text += "0";
                    }
                    else
                    {
                        textBox1.Text += ejimai[i,j];
                    }
                }
                textBox1.Text += Environment.NewLine;
            }
        }  
         
        private void Button1_Click(object sender, EventArgs e)
        {
            LogEjimai();
        }

        private void ProcessTurn(int cell,int lenght,string color)
        {
            _mygtukai[cell - 1].RemoveAt(lenght - 1);

            ejimai[lenght - 1, cell - 1] = color;
        }

        
    }
}
