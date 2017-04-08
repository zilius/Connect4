using System.Windows.Forms;

namespace Connect4
{
    public static class GameRules
    {

        public static void CheckForVictory(string[,] ejimai)
        {
            //int reds = 0;
            //int yellows = 0;

            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (ejimai[i, j] == "G")
                    {


                    }
                    else if (ejimai[i, j] == "R")
                    {

                    }
                }
                //MessageBox.Show(ejimai[i,0]);

            }
            //MessageBox.Show($"Raudoni {reds} Geltoni {yellows}");

        }
        private static void CheckHorizontal(int rowindex, string[,] ejimai, string color)
        {
            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {

                    MessageBox.Show(ejimai[i, j]);
                    //if (string.IsNullOrEmpty(ejimai[i, j]))
                    //{

                    //}
                    //else
                    //{

                    //}
                }

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




