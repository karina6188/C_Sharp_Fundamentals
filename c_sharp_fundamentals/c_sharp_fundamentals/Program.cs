﻿using System;

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
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            SayHi();
        }

        /// <summary>
        /// This method takes in no parameter and does not return anything
        /// The method takes in the user's response and lowercases the answer
        /// If the user types in Y, print to the console "Let's play a game"
        /// If the user types in any character other than Y or y, print to the console "Alright. Maybe next time."
        /// </summary>
        static void SayHi()
        {
            Console.WriteLine("Hello, what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine($"It's very nice to meet you {name}");
            Console.WriteLine("Would you like to play a game with me? Y/N");
            string game = Console.ReadLine().ToLower();
            if (game == "y")
            {
                Console.WriteLine("Yay! Let's play a game");
            }
            else
            {
                Console.WriteLine("Alright! Maybe next time");
            }
        }
    }
}
