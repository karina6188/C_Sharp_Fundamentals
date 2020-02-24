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

            SayHi();
            //Age();
            //Console.WriteLine("Enter your favorite number between 1 to 100 (an integer)");
            //// Here we use another built-in method from .NET framework Convert.ToInt32 to convert a string to a integer
            //// because Console.ReadLine is a string data type, and DataType() method takes only an integer data type
            //int number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(DataType(number));            
            //ForIteration(number);
            //Arrays();
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
        static void SayHi()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"It's very nice to meet you {name}!\n");
            Console.Write("Would you like to know your unique number based on your name (Y/N)?  ");
            string game = Console.ReadLine().ToLower();
            string message = game == "y"? $"Your name is {name}, therefore your unique number is {UniqueNumber(name)}":"Alright! Maybe next time.";
            Console.WriteLine(message);
            Console.ReadLine();
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
            // The symbol || here is called a conditional logical OR operator
            // This evaluates the first condition. If the first condition is true, then it skips the rest operands. If the first condition is false, only then it checks the second operand.
            if (number < 1 || number > 100)
            {
                return "You did not enter an integer from 1 to 100";
            }
            else
            {
                // The symbol % here is called modulus operator. It means to find the remainder after dividing the first operand by the second
                // The + symbol here is to add the variable number's value and 5 together. This + symbol is a arithmetic operator
                int luckyNumber = (number + 11) * 7 % 9;
                // The + symbol here means to concatenate strings and a variable together. This + is different from the previous + mathematical/arithmetic symbol
                // Another way to concatenate this is to use string interpolation. It will be written like this: return $"Your lucky number is {number}!";
                return "Your lucky number is " + luckyNumber + "!";
            }
        }
        #endregion

        #region ForIteration()
        /// <summary>
        /// Practice for loop. This method takes in a parameter of a double data type
        /// Then the for loop iterates for 5 times starting from 0 until it reaches to 4
        /// Use built-in method Math.Pow to power the number i times
        /// Each time the for loop iterates, i changes, therefore the number changes to the i-th power
        /// Print the result to the console
        /// </summary>
        /// <param name="number"></param>
        static void ForIteration(double number)
        {
            for (double i = 0; i < 5; i++)
            {
                double changingNumber = Math.Pow(number, i);
                Console.WriteLine(changingNumber);
            }

            Console.WriteLine("Print out 6 random numbers:");
            int[] numbers = new int[] { 52, 87, 6, 23, 19, 67};
            foreach (int numeric in numbers)
            {
                Console.WriteLine(numeric);
            }
        }
        #endregion

        #region Arrays()
        /// <summary>
        /// This method gives the user 3 sentences to choose from. The user's selection is stored in a variable.
        /// If the selection is neither 1, 2, or 3, print to the console that the user did not enter a valid number.
        /// Use switch statement to process the codes based on the user's selection.
        /// If the user selects either 1, 2, or 3, take the sentence and use built-in method ToCharArray() to convert the string sentence to an array of characters.
        /// Then store the characters into a char array. Use the built-in method Array.Reverse() to reverse the array.
        /// Print the characters in the array to the console in the same line to show the reversed sentence.
        /// </summary>
        static void Arrays()
        {
            Console.WriteLine("Please choose a sentence below to reverse it.");
            string sentence1 = "Great minds discuss ideas; average minds discuss events; small minds discuss people.";
            string sentence2 = "It is hard to fail, but it is worse never to have tried to succeed.";
            string sentence3 = "It is our choices, that show what we truly are, far more than our abilities.";
            Console.WriteLine($"1) {sentence1}");
            Console.WriteLine($"2) {sentence2}");
            Console.WriteLine($"3) {sentence3}");
            string selection = Console.ReadLine();
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
                        sentenceChar = sentence1.ToCharArray();
                        break;
                    case "2":
                        sentenceChar = sentence2.ToCharArray();
                        break;
                    case "3":
                        sentenceChar = sentence3.ToCharArray();
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
            string[] array4 = { "Jeff", "Cindy", "Mark", "Eva", "Andy", "Lily", "Jason", "Anderson", "Nicole"};
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
