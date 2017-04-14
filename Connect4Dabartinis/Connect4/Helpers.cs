using System.Windows.Forms;

namespace Connect4
{
    public static class Helpers
    {
        //pasiziureti ar yra 4 vienodi is eiles nx krw
        public static bool Check4inARow(string text,string letter)
        {
            //MessageBox.Show($"{text} {letter}");

            int lenght = text.Length;

            for (int i = 0; i < text.Length; i++)
            {
                if (i + 3 < text.Length)
                {
                    if (
                       text[i].ToString() == letter &&
                       text[i+1].ToString() == letter &&
                       text[i+2].ToString() == letter &&
                       text[i+3].ToString() == letter
                       )
                    {
                        //MessageBox.Show(text);
                        return true;
                    }

                }
                else
                {
                    return false;
                }


            }
            return false;
        }
       

    }
}
