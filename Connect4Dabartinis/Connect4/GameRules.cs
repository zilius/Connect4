using System.Windows.Forms;

namespace Connect4
{
    public static class GameRules
    {

        public static void CheckForVictory(string[,] ejimai)
        { 
                        
            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            CheckHorizontal(ejimai, rowLength, colLength);
            //CheckVertical(ejimai, rowLength, colLength);
            

        }
        private static void CheckHorizontal(string[,] ejimai,int rowCount,int colCount)
        {
            string eilute = "";
            for (int i = 0; i < rowCount; i++)
            {
                eilute = "";
                for (int j = 0; j < colCount; j++)
                {
                    if (string.IsNullOrEmpty(ejimai[i, j]))
                    {
                        eilute += "*";
                    }
                    else
                    {
                        eilute += ejimai[i, j];
                    }
                    
                }
                //MessageBox.Show(eilute);
                if(Helpers.Check4inARow(eilute,"R") || Helpers.Check4inARow(eilute, "G"))
                {
                    MessageBox.Show("realiai veikia");
                }
                

            }
        }

        private static void CheckVertical(string[,] ejimai, int rowCount, int colCount)
        {
             string eilute = "";
            for (int i = 0; i < colCount; i++)
            {
                eilute = "";
                for (int j = 0; j < rowCount; j++)
                {
                    if (string.IsNullOrEmpty(ejimai[j, i]))
                    {
                        eilute += "*";
                    }
                    else
                    {
                        eilute += ejimai[j, i];
                    }
                    
                }
                MessageBox.Show(eilute);
                //Helpers.Check4inARow(eilute);

            }
        }
    }
}




