using System;

namespace Connect4.SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "GGGGRRRR";
            Console.WriteLine(CheckIf4InARow(text,"G"));

            Console.ReadLine();
        }
        static bool CheckIf4InARow(string text,string letter)
        {
            int lenght = text.Length;

            for (int i = 0; i < text.Length; i++)
            {
                if(i + 3 < text.Length)
                {
                    if(
                       text[0].ToString() == letter && 
                       text[1].ToString() == letter &&
                       text[2].ToString() == letter &&
                       text[3].ToString() == letter
                       )
                    {
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
