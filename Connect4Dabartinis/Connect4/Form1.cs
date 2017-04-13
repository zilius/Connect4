using Connect4.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Connect4
{
    public partial class GameWindow : Form
    {
       
        public GameWindow()
        {
            InitializeComponent();
        }

        int gameId;

        int ejimas = 1;
                
        List<List<Button>> _mygtukai = new List<List<Button>>();

        List<Ejimai> _ejimai = new List<Ejimai>();

        string[,] VisiEjimai = new string[8, 7];
            
        bool gameOn = true;

        DataBaseWriter writer = new DataBaseWriter();

        Game zaidimas = new Game();

        List<Ejimai> _enemyTurns = new List<Ejimai>();


        private void SetUpGame(object sender, EventArgs e)
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

            gameId = writer.WriteGameAndGetId(zaidimas); // irasomas zaidimas ir jo id
                    
            
        }

        private void Button_Click(object sender, EventArgs e)//Gameloop
        {
                                  
            var btn = (Button)sender;
            string tag = btn.Tag.ToString();
            int cell = (int)char.GetNumericValue(tag[0]);
            PlayerTurn(cell);
            CpuTurn();

            if (GameRules.HaveAWinner(VisiEjimai))
            {
                MessageBox.Show("Gg");
                gameOn = false;
            }
            if(gameOn == false)
            {
                writer.WriteData(_ejimai);

                panel1.Enabled = false;
                
            }

            
        }

        private void PlayerTurn(int cell)
        {
            
            int lenght = _mygtukai[cell - 1].Count;

            if(lenght == _mygtukai[cell-1].Count)
            {
                _mygtukai[cell - 1][lenght-1].Enabled = false;
            }
                      
            var btnTochange = _mygtukai[cell - 1][lenght - 1];

            btnTochange.BackColor = Color.Brown;

            ProcessTurn(cell, lenght, "R");
                         
             
        }

        private void CpuTurn()
        {
            int cell;

            //Jeigu crashins tada reikes randomizinti ir atjungti db

            if(writer.GetBestMove(ejimas) == null)
            {
                var rnd = new Random();
                cell = rnd.Next(1, 8);
            }
            else
            {
                try
                {
                    cell = writer.GetBestMove(ejimas)[0].EjimasX;
                }
                catch
                {
                    var rnd = new Random();
                    cell = rnd.Next(1, 8);
                }
            }
            
            //back here
                

            int lenght = _mygtukai[cell - 1].Count;


            while (lenght == 0/*(lenght +1 == _mygtukai[cell].Count)*/)
            {
                cell = new Random().Next(1, 8);
                lenght = _mygtukai[cell - 1].Count;
            }
            //MessageBox.Show($"X: cell {cell}, Y: lenght {lenght}");

            var btnTochange = _mygtukai[cell - 1][lenght - 1];

            if (btnTochange == _mygtukai[cell - 1][_mygtukai[cell - 1].Count - 1])
            {
                btnTochange.Enabled = false; // kad useris nepaspaustu
            }

            btnTochange.BackColor = Color.Yellow;

            ProcessTurn(cell, lenght, "G");

            _ejimai.Add(new Ejimai
            {
                GameId = gameId,
                EjimoNr = ejimas,
                EjimasX = cell
            });
            
            
        ejimas++;

        //try
        //{
        //    int lenght = _mygtukai[cell - 1].Count;

        //    var btnTochange = _mygtukai[cell - 1][lenght - 1];

        //    btnTochange.BackColor = Color.Yellow;

        //    ProcessTurn(cell, lenght, "G");

        //}
        //catch (Exception)
        //{
        //    MessageBox.Show("Cell full");
        //}
        }

        private void LogEjimai()
        {
            textBox1.Text = "";//09632224

            int rowLength = VisiEjimai.GetLength(0);
            int colLength = VisiEjimai.GetLength(1);

            for(int i = 0; i<rowLength; i++)
            {
                for(int j = 0; j< colLength;j++)
                {
                    if(string.IsNullOrEmpty(VisiEjimai[i, j]))
                    {
                        textBox1.Text += "0";
                    }
                    else
                    {
                        textBox1.Text += VisiEjimai[i,j];
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

            VisiEjimai[lenght - 1, cell - 1] = color;
        }
              

        
    }
}
