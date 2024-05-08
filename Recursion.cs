using System;

namespace recursionassignment
{
    internal class Recursion
    {
        public static void Main(string[] args)
        {
            try
            {
                // Writer to write palindromes to their output text file.
                StreamWriter sw = new StreamWriter("output.txt", true);
                // StreamReader to read from the palindrome input text file.
                StreamReader sr = new StreamReader("input.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    try
                    {
                        // Parse each line to an int and pass it to the palindrome function.
                        int inputInt = int.Parse(line);
                        int palResult = DepthForPalindrome(inputInt);
                        sw.Write(palResult);
                    }
                    // Error message written to output file if given invalid input.
                    catch
                    {
                        sw.Write("Must enter a single integer!");
                    }
                    finally
                    {
                        // Creates a new line in the palindrome output text file.
                        sw.WriteLine();
                        // Reads the next line in the palindrome input text file.
                        line = sr.ReadLine();
                    }
                }
                
                // Close writer for palindrome I/O.
                sw.Close();
                sr.Close();
            }
            // Error message printed if an invalid write path was given.
            catch
            {
                Console.WriteLine("Invalid write path for palindrome input!");
            }



            try
            {
                // Writer to write wrapped strings to their output text file.
                StreamWriter sw = new StreamWriter("output.txt", true);
                // StreamReader to read from the wrap input text file.
                StreamReader sr = new StreamReader("input.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    try
                    {
                        // Gets the target character.
                        char inputChar = line[0];
                        // Gets the length of the wrapped string.
                        int inputLength = int.Parse(sr.ReadLine());
                        // Writes the wrapped string to wrap output text file.
                        sw.Write(AlphabetWrap(inputChar, inputLength));
                    }
                    // Error message written to output file if given invalid input.
                    catch
                    {
                        sw.Write("Must enter a single character and integer on separate line");
                    }
                    finally
                    {
                        // Creates a new line in the palindrome output text file.
                        sw.WriteLine();
                        // Reads the next line in the palindrome input text file.
                        line = sr.ReadLine();
                    }
                }

                // Close writer for palindrome I/O.
                sw.Close();
                sr.Close();
            }
            // Error message printed if an invalid write path was given.
            catch
            {
                Console.WriteLine("Invalid write path for wrap input!");
            }

        }

        // Recursive method that reverses its input string.
        private static string StringReverser(string inputString)
        {
            // Returns the reversed string once its length is zero.
            if (inputString.Length == 0)
            {
                return inputString;
            }
            /* Otherwise, return the input string passed into the
             * string reverser again but with its index shifted over one
             * added to the first character of the input string.
             */
            else
            {
                return StringReverser(inputString.Substring(1)) + inputString[0];
            }
        }

        // Gets the palindrome depth of a number.
        private static int DepthForPalindrome(int someNumber)
        {
            // Gets the input number and casts to string.
            string numString = someNumber.ToString();
            // Makes a copy of the number string and reverses it.
            string reversedNumString = StringReverser(numString);
            // If the number is equal to the number reversed, return 0.
            if (numString == reversedNumString)
            {
                return 0;
            }
            // Returns the input number reversed and added to the original.
            else
            {
                return 1 + DepthForPalindrome(someNumber + int.Parse(reversedNumString));
            }
        }

        // Wraps characters in alphabetical order.
        private static string AlphabetWrap(char someChar, int someNum)
        {
            // Alphabet used to get index of someChar and to retrieve characters.
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            // Gets the index of someChar by searching for it in the alphabet string.
            int charIndex = alphabet.IndexOf(someChar);
            if (someNum == 1)
            {
                return someChar.ToString();
            }
            else if (charIndex == 25)
            {
                return alphabet[charIndex] + AlphabetWrap(alphabet[0], someNum - 1);
            }
            else
            {
                return alphabet[charIndex] + AlphabetWrap(alphabet[charIndex + 1], someNum - 1);
            }
        }
        
    }
}
