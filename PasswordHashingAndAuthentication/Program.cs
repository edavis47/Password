using System;
using System.Collections.Generic;

namespace PasswordHashingAndAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu = new Menu();
                Console.WriteLine(menu.PrintMenu());
                Console.SetCursorPosition(20, 9);
                menu.MenuOptions(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
