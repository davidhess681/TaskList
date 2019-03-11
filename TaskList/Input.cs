using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    class Input
    {
        static void Invalid()
        {
            Console.Write("Invalid input. Try again: ");
        }

        public static int ValidInt(int startParam, int endParam)
        {
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= startParam && input <= endParam)
                    {
                        return input;
                    }
                }
                Invalid();
            }
        }
        public static DateTime ValidDate()
        {
            while (true)
            {
                if(DateTime.TryParse(Console.ReadLine(), out DateTime input))
                {
                    return input;
                }
                Invalid();
            }
        }

        public static bool YesOrNo()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                if (input == "n")
                {
                    return false;
                }
                Invalid();
            }
        }
    }
}
