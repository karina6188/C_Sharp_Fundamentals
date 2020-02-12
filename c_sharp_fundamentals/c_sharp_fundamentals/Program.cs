using System;

namespace c_sharp_fundamentals
{
    /// <summary>
    /// Program.cs is a static class that contains only one static method - Main() method which is required to start an app
    /// </summary>
    class Program
    {
        /// <summary>
        /// The Main() method is required in every C# app. It specifies where the execution point starts. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        // This {} and the codes inside are called a code block
        {
            // When we call Console here, we are actually calling it from .NET Framework library.
            // The dot after it is called a member accesser to allow us to access a member of the class. WriteLine is a member of the Console class.
            Console.WriteLine("Hello!");
            SayHi();
            Age();
        }

        /// <summary>
        /// This method takes in no parameter and returns a boolean
        /// The method takes in the user's response and lowercases the answer
        /// If the user types in Y, print to the console "Let's play a game"
        /// If the user types in any character other than Y or y, print to the console "Alright. Maybe next time." and returns false to exit the method
        /// </summary>
        static bool SayHi()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"It's very nice to meet you {name}!");
            Console.Write("Would you like to play a game with me? Y/N ");
            string game = Console.ReadLine().ToLower();
            if (game == "y")
            {
                Console.WriteLine("Yay! Let's play a game");
                PlayGame();
                return true;
            }
            else
            {
                Console.WriteLine("Alright! Maybe next time");
                return false;
            }
        }

        static void PlayGame()
        {
            Console.WriteLine("Pick a number 1, 2, or 3");
            string number = Console.ReadLine();
            string message = "";
            if (number == "1")
            {
                message = "You won a flight ticket to Tokyo, Japan!";
            }
            else if (number == "2")
            {
                message = "You won a mountain bike!";
            }
            else if (number == "3")
            {
                message = "You won a $50 of gift card!";
            }
            else
            {
                message = "Sorry you didn't choose a valid option.";
            }
            Console.WriteLine(message);
            Console.WriteLine();
        }

        static void Age()
        {
            Console.Write("Are you over 21 years old? Y/N ");
            string age = Console.ReadLine().ToLower();
            string bar = (age == "y") ? "Would you like to try out a new bar in town?" : "You are not old enough to drink alchohol";
            Console.WriteLine(bar);
            Console.ReadLine();
        }
    }
}
