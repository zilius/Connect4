using System.Windows.Forms;

namespace Connect4
{
    public static class GameRules
    {

        public static void CheckForVictory(string[,] ejimai)
        { 
                        
            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            CheckHorizontal(ejimai,rowLength, colLength);
            

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
                Helpers.Check4inARow(eilute);

            }
        }

        private static void CheckVertical(int colindex, string[,] ejimai, string color)
        {
            for (int a = 0; a < 6; a++)
            {
                MessageBox.Show(ejimai[a, colindex]);
            }

            //ejimai[kintamasis,colindex];
        }
    }
}




