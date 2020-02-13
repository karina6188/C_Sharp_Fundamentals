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
            Console.WriteLine("Enter your favorite number between 1 to 100 (an integer)");
            // Here we use another built-in method from .NET framework Convert.ToInt32 to convert a string to a integer
            // because Console.ReadLine is a string data type, and DataType() method takes only an integer data type
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(DataType(number));
        }

        #region SayHi()
        /// <summary>
        /// This method takes in no parameter and returns a boolean
        /// The method takes in the user's response and lowercases the answer. Therefore, whether the user types a Y or y, they can both be processed as a yes
        /// If the user types in Y/y, print to the console "Let's play a game" and invoke the PlayGame() method
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
        #endregion

        #region PlayGame()
        /// <summary>
        /// This method takes in no parameter and returns nothing
        /// The method use if statements to respond to the user with different console messages based on the selection the user makes
        /// </summary>
        static void PlayGame()
        {
            Console.WriteLine("Pick a number 1, 2, or 3");
            string number = Console.ReadLine();
            string message = "";
            if (number == "1")
            {
                message = "won a flight ticket to Tokyo, Japan!";
            }
            else if (number == "2")
            {
                message = "won a mountain bike!";
            }
            else if (number == "3")
            {
                message = "won a $50 of gift card!";
            }
            else
            {
                message = "didn't win a prize because it was not a valid option.";
            }
            // This is a replacement code. {0} and {1} are going to be replaced by the two variables number and message
            Console.WriteLine("You chose {0}, therefore you {1}", number, message);
            Console.WriteLine();
        }
        #endregion

        #region Age()
        /// <summary>
        /// This method takes in no parameter and returns nothing
        /// Similar to the if statements from the previous method PlayGame()
        /// This Age() method gives the user different console message based on the user's selection
        /// In this case, only two options for the user to choose. The condition is either true or false.
        /// So we use ?: this is called ternary conditional operator to evaluate a boolean expression and returns the result of one of the expressions
        /// </summary>
        static void Age()
        {
            Console.Write("Are you over 16 years old? Y/N ");
            string age = Console.ReadLine().ToLower();
            // This line means if age equals to "y", string bar will be assigned to be the first sentence "You are old enough....". If age does not equal to "y", string bar will be assigned to be the second sentence "You are not..."
            // ? here means if this condition is true. If yes, give the first result which is before :
            // If the condition is false, then give the second result which is after :
            // : means or
            string drive = (age == "y") ? "You are old enough to drive!" : "You cannot drive at this age.";
            Console.WriteLine(drive);
            Console.ReadLine();
        }
        #endregion


        #region DataType()
        /// <summary>
        /// This method takes in an integer number and use a if statement to check if the number is between 1 to 100
        /// The if statement checks two conditions. If either one of the condition is true, run the code inside the if statement
        /// If the number is neither less than 1 or greater than 100, run the code inside else statement
        /// The method returns a string that is to be printed out to the console
        /// </summary>
        /// <param name="number">A string to indicate if the user enters an invalid number or the result of the user's lucky number</param>
        static string DataType(int number)
        {
            // The symbol || here means OR
            if (number < 1 || number > 100)
            {
                return "You did not enter an integer from 1 to 100";
            }
            else
            {
                // The symbol % here is called modulus operator. It means to find the remainder after dividing the first operand by the second
                // The + symbol here is to add the variable number's value and 5 together. This + symbol is algorithmitic symbol
                int luckyNumber = (number + 5) * 3 % 17;
                // The + symbol here means to concatenate strings and a variable together. This + is different from the previous + mathematical/algorithmitic symbol
                return "Your lucky number is" + number + "!";
            }
        }
        #endregion
    }
}
