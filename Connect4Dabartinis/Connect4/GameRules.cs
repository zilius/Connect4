namespace Connect4
{
    public static class GameRules
    {
        public static bool HaveAWinner(string[,] ejimai)
        {                  
            int rowLength = ejimai.GetLength(0);
            int colLength = ejimai.GetLength(1);

            if(CheckHorizontal(ejimai, rowLength, colLength) != "*" || CheckVertical(ejimai, rowLength, colLength) != "*")
            {
                return true;
            }
            return false;
            
        }

        private static string CheckHorizontal(string[,] ejimai,int rowCount,int colCount)
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
                //MessageBox.Show($"{eilute} eilute");
                if (Helpers.Check4inARow(eilute, "G"))
                {
                    return "R";
                }
                else if (Helpers.Check4inARow(eilute, "R"))
                {
                    return "R";
                }
               
            }
            return "*";

        }

        private static string CheckVertical(string[,] ejimai, int rowCount, int colCount) //po viena karta kviecia
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
                //MessageBox.Show($"{eilute} stulpelis");
                if (Helpers.Check4inARow(eilute, "R"))
                {
                    return "R";
                }
                else if (Helpers.Check4inARow(eilute, "G"))
                {
                    return "G";
                }
               
            }
            return "*";

        }
        
    }
}




