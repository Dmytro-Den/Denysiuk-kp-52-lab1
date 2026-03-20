using System;
using lab1.UI;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Menu appMenu = new Menu();
            appMenu.Run();
        }
    }
}