using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHashingAndAuthentication
{
    class Menu
    {
        Account account = new Account();
        Password hasher = new Password();
        public void MenuOptions(string x)
        {
            
            switch (x)
            {
                case "1":
                    string input;
                    User user = new User();
                    Console.Clear();
                    Console.WriteLine("ENTER key continues.");
                    Console.Write("Enter your name or a username: ");
                    input = Console.ReadLine();
                    if (account.userNames.Contains(input) == false)
                    {
                        user.userName = input;
                        account.userNames.Add(user.userName);
                        Console.Write("Enter a password (DO NOT FORGET IT!): ");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter to continue.");
                        password = hasher.MakeHash(password);
                        user.hashedPass = password;
                        account.userInformation.Add(user.hashedPass, user);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This username already exists, please try another one.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine(); MenuOptions("1");
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Please enter your password and press ENTER: ");
                    string userEntry = Console.ReadLine();
                    string attemptedPass = hasher.MakeHash(userEntry);
                    User userInfo;
                    if (account.userInformation.ContainsKey(attemptedPass) == true)
                    {
                        userInfo = account.userInformation[attemptedPass];
                        Console.WriteLine($"Your user information is\nUser Name: {userInfo.userName} | Password: {userEntry}.\nYour hashed password is: {userInfo.hashedPass}");
                        Console.WriteLine("ENTER to return to menu.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An account with that password could not be found.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;
                case "3":
                    Console.Clear(); Console.SetCursorPosition(0,1);
                    foreach (User item in account.userInformation.Values)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"    - User : {item.userName} | Hashed password: {item.hashedPass}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(20, 9);
                    Console.WriteLine("PLEASE ENTER A VALID OPTION.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(PrintMenu());Console.SetCursorPosition(20, 9);
            MenuOptions(Console.ReadLine());
        }
        public string PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("--------------------------------------------------------------------\n\n");
            menu.Append("   PASSWORD AUTHENTICATION SYSTEM\n");
            menu.Append("   Please select one option:\n");
            menu.Append("\n    1. Establish an account");
            menu.Append("\n    2. Authenticate a user");
            menu.Append("\n    3. Exit the system");
            menu.Append("\n\n   Enter selection:");
            menu.Append("\n\n--------------------------------------------------------------------");
            return menu.ToString();
        }
    }
}
