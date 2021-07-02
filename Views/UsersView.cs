using SandboxGame.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxGame.Views
{
    public static class UsersView
    {
        public static void RenderUserMenu()
        {
            Console.WriteLine("Users");
            Console.WriteLine("1: Create user");
            Console.WriteLine("2: List of users");
            Console.WriteLine("3: Edit user");
            Console.WriteLine("4: Back");

            bool isBackToMainMenu = false;
            string command = Console.ReadLine();

            UserService userService = new UserService();

            while (!isBackToMainMenu)
            {
                switch (command)
                {
                    case "1":
                        InsertUserMenu(userService);                        
                        break;
                    case "2":
                        //UserLists()
                        break;
                    case "3":
                        //EditUsers();
                        break;
                    case "4":
                        isBackToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }

        private static void InsertUserMenu(UserService userService)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter role:");
            string role = Console.ReadLine();

            userService.InserUser(username, role, password);
        }
    }
}
