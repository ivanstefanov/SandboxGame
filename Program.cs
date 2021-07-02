using System;

namespace SandboxGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderMainMenu();

            bool isExit = false;

            while (!isExit)
            {
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":                        
                        break;
                    case "2":
                        Views.UsersView.RenderUserMenu();
                        break;
                    ///.......
                    case "5":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        RenderMainMenu();
                        break;
                }
            }
        }

        private static void RenderMainMenu()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Users");
            Console.WriteLine("3: Heroes");
            Console.WriteLine("4: Battles");
            Console.WriteLine("5: Logout");
        }

       
    }
}
