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
            //string name = SayHi();

            //Age();

            // When we call Console here, we are actually calling it from .NET Framework library.
            // The dot after it is called a member accesser to allow us to access a member of the class. WriteLine is a member of the Console class.
            //Console.Write("Enter your birthday MM/DD: ");
            //Birthday(Console.ReadLine());

            //GuessANumber();

            CanYouReadTheSentence();

            //ArraySize();
            //Console.WriteLine("Enter two numbers. One at a time.");
            //Console.WriteLine("Enter the first number:");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the second number:");
            //int num2 = Convert.ToInt32(Console.ReadLine());
            //int sum = AddNumbers(num1, num2);
            //Console.WriteLine("Enter a last number.");
            //int num3 = Convert.ToInt32(Console.ReadLine()); 
            //int multiplication = MultiplyNumbers(sum, num3);
        }

        #region SayHi()
        /// <summary>
        /// This method takes in no parameter and returns a boolean
        /// The method takes in the user's response and lowercases the answer. Therefore, whether the user types a Y or y, they can both be processed as a yes
        /// If the user types in Y/y, print to the console "Let's play a game" and invoke the PlayGame() method
        /// If the user types in any character other than Y or y, print to the console "Alright. Maybe next time." and exit the method
        /// </summary>
        static string SayHi()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"It's very nice to meet you {name}!\n");
            Console.Write("Would you like to know your unique number based on your name (Y/N)?  ");
            string game = Console.ReadLine().ToLower();
            string message = game == "y" ? $"Your name is {name}, therefore your unique number is {UniqueNumber(name)}" : "Alright! Maybe next time.";
            Console.WriteLine(message);
            Console.ReadLine();
            return name;
        }
        #endregion

        #region UniqueNumber()
        /// <summary>
        /// This method takes in a string returns an integer
        /// The method gets the ASCII numbers of each character in name and add all the numbers together as the unique number
        /// </summary>
        static int UniqueNumber(string name)
        {
            char[] nameCharacters = name.ToCharArray();
            int uniqueNumber = 0;
            foreach (char character in nameCharacters)
            {
                uniqueNumber += char.ToUpper(character); // Use char.ToUpper to get each character's ASCII code
            }
            return uniqueNumber;
        }
        #endregion

        #region Age()
        /// <summary>
        /// This method takes in no parameter and returns nothing
        /// It asks the user to enter his/her age and print to the console how many months and how many days they have lived.
        /// To prevent the user enters an incorrect data type, use try and catch clause to avoid the program from breaking
        /// </summary>
        static void Age()
        {
            Console.Write("Enter your age: ");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"You have lived {age * 12} months or {age * 365} days!");
            }
            catch
            {
                Console.WriteLine("You did not enter a valid answer.");
            };
            Console.ReadLine();
        }
        #endregion

        #region Birthday()
        /// <summary>
        /// This method takes in a string format of the user's birthday MM/DD
        /// Concatenate the user's birthday with the current year in a string format
        /// Convert the complete birthday date to a DateTime data type then deduct today's date to determine how many days are left until the user's next birthday
        /// The result above is converted and stored as a string. Then use IndexOf() pre-determined method to get the days only from the result
        /// When the result is 0 days away from the next birthday, the result does not have a . and therefore it will be set to -1 by default but this will crash the program
        /// To avoid crashing the program, set the index to be 1
        /// Convert the days in the string data type to an int data type
        /// Based on how many days to the next birthday, print different message to the console window
        /// If the birthday has already passed for this year, concatenate the user's birthday with the next year's string
        /// Calculate how many days are there until the next birthday using the next year's birthday date
        /// Print the result to the console window
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        static bool Birthday(string birthday)
        {
            try
            {
                string thisYear = "/2020";
                string nextYear = "/2021";
                string daysUntilNextBirthday = (Convert.ToDateTime(birthday + thisYear) - DateTime.Today).ToString();
                // When there's more than 0 days until the next birthday, the calculation result would be in this format: {3.00:00:00}
                // If there's 0 day until the next birthday, the calculation result would be {00:00:00}
                // Therefore, a default index 1 is set to prevent the program from breaking
                int index = (daysUntilNextBirthday.IndexOf(".") >= 0) ? daysUntilNextBirthday.IndexOf(".") : 1 ;

                int days = Convert.ToInt32(daysUntilNextBirthday.Substring(0, index));
                if (days >= 0)
                {
                    string message = $"Your next birthday is {daysUntilNextBirthday.Substring(0, index)}";
                    if (days >= 2)
                    {
                        Console.WriteLine(message + " days away.");
                        return true;
                    }
                    if (days > 0)
                    {
                        Console.WriteLine(message + " day away.");
                        return true;
                    }
                    if (days == 0)
                    {
                        Console.WriteLine($"Your next birthday is today!");
                        return true;
                    }
                }
                else
                {
                    daysUntilNextBirthday = (Convert.ToDateTime(birthday + nextYear) - DateTime.Today).ToString();
                    int index2 = daysUntilNextBirthday.IndexOf(".");
                    Console.WriteLine($"Your next birthday is {daysUntilNextBirthday.Substring(0, index2)} days away");
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("You did not enter a valid answer.");
                return false;
            };
        }
        #endregion

        #region GuessANumber()
        /// <summary>
        /// Practice for loop. This method takes in no parameter and does not return anything
        /// Use Random class and .Next() method to generate a number between 1 to 10 and store the answer in the answer variable
        /// Iterate a for loop three times and check if the user's guess matches with the answer
        /// If yes, print the message to the console and break out from the for loop
        /// If no, let the user know how many times they have left to guess the right answer
        /// If the user guess a number that is out of the range of 1 to 10, notify them and let them guess again
        /// Once the user uses up three chances, break out from the for loop and tell the the correct answer
        /// If the user enters an invalid character, let them know and terminate the program
        /// </summary>
        static void GuessANumber()
        {
            Console.WriteLine("Guess a number between 1 to 10. You have 3 chances. ");
            try
            {
                Random random = new Random();
                int answer = random.Next(11);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Enter a number: ");
                    int guess = Convert.ToInt32(Console.ReadLine());
                    if (guess == answer)
                    {
                        Console.WriteLine($"You guess it right!");
                        break;
                    }
                    else if (guess < 1 || guess > 10)
                    {
                        Console.WriteLine("Please enter a number between 1 and 10.");
                        Console.WriteLine($"You have {2 - i} more chance.\n");
                    }
                    else
                    {
                        Console.WriteLine($"Wrong answer. You have {2-i} more chance.\n");
                    }
                }
                Console.WriteLine($"The correct answer is {answer}.");
            }
            catch
            {
                Console.WriteLine("You did not enter a valid number.");
            }
        }
        #endregion

        #region CanYouReadTheSentence()
        /// <summary>
        /// 
        /// </summary>
        static void CanYouReadTheSentence()
        {
            Console.WriteLine("Can you reverse one of the sentences below and type out the right sentence?");
            Console.WriteLine("Example: .saedi ssucsid sdnim taerG");
            Console.WriteLine("Answer: Great minds discuss ideas.\n");
            Console.WriteLine("Please reverse:");
            Console.WriteLine("1) ; deeccus ot deirt evah ot reven esrow si ti tub ,liaf ot drah si tI");
            Console.WriteLine();
            Console.WriteLine();

            string answer = Console.ReadLine();
            char[] sentenceChar = new char[] { };
            // The logic here is if selection is not "1" and not "2" and not "3", run the code
            // Conditional logical operator || cannot be used here because if selection is not "1" or not "2" or not "3", run the code
            // This does not work because if the user selects "1", it satisfy the two other conditions selection is not "2" or not "3", the code will run
            // You want to run the code only when the selection is not "1" and not "2" and not "3"
            if (selection != "1" && selection != "2" && selection != "3")
            {
                Console.WriteLine("You did not enter a valid number");
            }
            else
            {
                switch (selection)
                {
                    case "1":
                        sentenceChar = sentence2.ToCharArray();
                        break;
                    case "2":
                        sentenceChar = sentence2.ToCharArray();
                        break;
                    case "3":
                        sentenceChar = sentence2.ToCharArray();
                        break;
                    default:
                        break;
                }
            }
            Array.Reverse(sentenceChar);
            Console.WriteLine("Reversed sentence:");
            Console.Write(sentenceChar);
            Console.WriteLine();
        }
        #endregion

        #region ArraySize()
        //Array with size specified and without size specified
        /// <summary>
        /// Pracitce pre-defined array methods including .Length, Array.Reverse(), and Array.Sort()
        /// </summary>
        static void ArraySize()
        {
            int[] array1 = new int[5];
            int[] array2 = new int[] { 0, 5, 10, 15, 20, 25 };
            int[] array3 = { 13, 11, 9, 7, 5, 3, 1 };
            string[] array4 = { "Jeff", "Cindy", "Mark", "Eva", "Andy", "Lily", "Jason", "Anderson", "Nicole" };
            // assign array1 index position 0 to be value of integer 1
            array1[0] = 1;
            // assign array1 index position 1 to be value of integer 2
            array1[1] = 2;
            Console.WriteLine($"Array1's length: {array1.Length}");
            PrintIntArray(array1);

            Console.WriteLine($"Array2's length: {array2.Length}");
            PrintIntArray(array2);

            Console.WriteLine($"Array3's length: {array3.Length}");
            PrintIntArray(array3);

            Array.Sort(array3);
            PrintIntArray(array3);

            Console.WriteLine($"Array4's length: {array4.Length}");
            PrintStringArray(array4);

            Array.Sort(array4);
            PrintStringArray(array4);
        }

        // Use foreach to print out values from an int array
        static void PrintIntArray(int[] intArray)
        {
            Console.WriteLine("Array values:");
            foreach (int value in intArray)
            {
                Console.Write($"{value} -> ");
            }
            Console.WriteLine("x");
            Console.WriteLine();
        }

        // Use foreach to print out values from an string array
        static void PrintStringArray(string[] stringArray)
        {
            foreach (string value in stringArray)
            {
                Console.Write($"{value} -> ");
            }
            Console.WriteLine("x");
            Console.WriteLine();
        }

        #endregion

        #region AddNumbers()
        /// <summary>
        /// This method takes in two numbers (int) and returns the sum (int) of the two numbers
        /// </summary>
        /// <param name="num1">The first number you want to add together</param>
        /// <param name="num2">The second number you want to add together</param>
        /// <returns>The sum of the two numbers</returns>
        static int AddNumbers(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine($"The sum of {num1} and {num2} is {sum}");
            return sum;
        }
        #endregion

        #region MultiplyNumbers()
        /// <summary>
        /// This method takes in two numbers (int) and returns the multiplication (int) of the two numbers
        /// </summary>
        /// <param name="num1">The first number you want to multiply together</param>
        /// <param name="num2">The second number you want to multiply together</param>
        /// <returns>The multiplication of the two numbers</returns>
        static int MultiplyNumbers(int num1, int num2)
        {
            int sum = num1 * num2;
            Console.WriteLine($"The multiplication of {num1} and {num2} is {sum}");
            return sum;
        }
        #endregion
    }
}
