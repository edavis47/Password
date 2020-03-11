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
                    User user = new User();
                    Console.Clear();
                    Console.WriteLine("ENTER key continues.");
                    Console.Write("Enter your name or a username: ");
                    user.userName = Console.ReadLine();
                    account.userNames.Add(user.userName);
                    Console.Write("Enter a password (DO NOT FORGET IT!): ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter to continue.");
                    password = hasher.MakeHash(password);
                    user.hashedPass = password;
                    account.userInformation.Add(user.hashedPass, user);
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
                        Console.WriteLine($"Your user information is\nUser Name: {userInfo.userName}; Password: {userEntry}.\nYour hashed password is: {userInfo.hashedPass}");
                        Console.WriteLine("ENTER to return to menu.");
                    }
                    else
                    {
                        Console.WriteLine("An account with that password could not be found.");
                    }
                    Console.ReadLine();
                    break;
                case "3": //TODO
                    foreach (User item in account.userInformation.Values)
                    {
                        Console.WriteLine($"User: {item.userName}; hashed password: {item.hashedPass}");
                        Console.WriteLine("ENTER key to continue.");
                    }
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(PrintMenu());
            MenuOptions(Console.ReadLine());
        }
        public string PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("--------------------------------------------------------------------\n\n");
            menu.Append("PASSWORD AUTHENTICATION SYSTEM\n\n");
            menu.Append("Please select one option:");
            menu.Append("\n1. Establish an account");
            menu.Append("\n2. Authenticate a user");
            menu.Append("\n3. Exit the system");
            menu.Append("\n\nEnter selection:");
            menu.Append("\n\n--------------------------------------------------------------------");
            return menu.ToString();
        }
    }
}
