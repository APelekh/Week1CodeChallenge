using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //loops for FizzBuzz
            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            for (int i = 92; i >= 79; i--)
            {
                Console.WriteLine(FizzBuzz(i));
            }

            //testing Yodaizer and TextStats
            Console.WriteLine(Yodaizer("I like code"));
            Console.WriteLine(Yodaizer("I really like to code"));
            TextStats("I like to code very much! Really? Why? Because it is awesome!!!");

            //test loop for IsPrime
            for (int i = 1; i < 26; i+=2)
            {
                bool checker = IsPrime(i);
                if (checker)
                {
                    Console.WriteLine("{0} is a prime number", i);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            //checking DashInsert
            Console.WriteLine(DashInsert(454793));
            Console.WriteLine(DashInsert(8675309));

            Console.ReadKey();
        }
        /// <summary>
        /// Returns Fizz or Buzz if the number is divisible by 5 or 3, and FizzBuzz if divisible by both 3 and 5
        /// </summary>
        /// <param name="number">number to test</param>
        /// <returns>returns Fizz, Buzz or FizzBuzz or the number if it's not divisible by 3 or 5</returns>
        public static string FizzBuzz(int number)
        {
            //checking for negative number for extra test
            if (number <= 0)
            {
                return String.Empty;
            }
            //checking if number is divisible by 5 and 3
            else if (number % 5 == 0 && number % 3 == 0){
                return "FizzBuzz";
            }
            //checking if number is divisible by 5
            else if (number % 5 == 0){
                return "Fizz";
            }
            //checking if number is divisible by 3
            else if (number % 3 == 0)
            {
                return "Buzz";
            }
            //returns number as string if the number is not divisible by either 3 or 5
            return number.ToString();
        }
        /// <summary>
        /// Takes a string and reverse its words in opposite order
        /// </summary>
        /// <param name="text">string to be reversed</param>
        /// <returns>reversed string</returns>
        public static string Yodaizer(string text)
        {
            //splitting the input string by space and saving it in into array
            string[] wordsArray = text.Split(' ');
            //converting array into list
            List<string> testingList = wordsArray.ToList();
            //creating new string for storing the output reversed string
            string reversedString = String.Empty;
            //extra credit tast
            //checking if list has only 3 words
            if (testingList.Count == 3)
            {
                //creating a temp variable to store the last word
                string storage = testingList[2] + ",";
                //inserting the last word at the beginning of a list
                testingList.Insert(0, storage);
                //removing the original last word from a list
                testingList.RemoveAt(3);
                //looping through list and adding its elements into new string
                for (int i = 0; i < testingList.Count; i++)
                {
                    reversedString = reversedString + testingList[i] + " ";
                }
            }
            else
            {
                //reversing the list order
                testingList.Reverse();
                //looping through list and adding its reversed elements into new string
                for (int i = 0; i < testingList.Count; i++)
                {
                    reversedString = reversedString + testingList[i] + " ";
                }
            }
            //returning reversed string and removing irrelevant white spaces at the end
            return reversedString.Trim();
        }

        /// <summary>
        /// Counts how many characters, words, vowels, consonants and special characters are in the input string
        /// </summary>
        /// <param name="input">string to be processed</param>
        static void TextStats(string input)
        {
            //creating counters for storing the amounts of characters, words, vowels, consonants and special characters
            int letterCounter = 0;
            List<string> wordsCounter = new List<string>();
            int vowelCounter = 0;
            int consonantCounter = 0;
            int specCharCounter = 0;
            //creating variables for extra credit task
            string longestWord = String.Empty;
            string secondLongestWord = String.Empty;
            string shortestWord = "a";
            //splitting input string into words and converting it into a list
            string[] wordsArray = input.Split(' ');
            wordsCounter = wordsArray.ToList();
            //saving the original text for final output before converting it into lowercase
            string origString = input;
            input = input.ToLower();
            //extra credit task
            //looking for shortest and longest words in the words list
            for (int i = 0; i < wordsCounter.Count; i++)
            {
                if (wordsCounter[i].Length > longestWord.Length)
                {
                    longestWord = wordsCounter[i];
                }
                if (wordsCounter[i].Length <= shortestWord.Length)
                {
                    shortestWord = wordsCounter[i];
                }
            }
            //removing the longest word from the words list
            wordsCounter.Remove(longestWord);

            //looking for the second longest word in the words list
            for (int i = 0; i < wordsCounter.Count; i++)
            {
                if (wordsCounter[i].Length > secondLongestWord.Length)
                {
                    secondLongestWord = wordsCounter[i];
                }
            }
            
             //looping though each character in the input string
            for (int i = 0; i < input.Length; i++)
            {
                //checking if the character is a letter
                if (CharOk(input[i]))
                {
                    letterCounter++;
                }
                //checking if the character is a vowel
                if ("aeiou".Contains(input[i].ToString()))
                {
                    vowelCounter++;
                }
                //checking if the character is a consonant
                if (!("aeiou .?,!".Contains(input[i].ToString())))
                {
                    consonantCounter++;
                }
                //checking if the character is a special character
                if ((" .?,!".Contains(input[i].ToString())))
                {
                    specCharCounter++;
                }
                
            }
            //printing out the results
            Console.WriteLine("In text \"{0}\" are: ", origString);
            Console.WriteLine("{0} characters", letterCounter);
            Console.WriteLine("{0} vowels", vowelCounter);
            Console.WriteLine("{0} consonants", consonantCounter);
            Console.WriteLine("{0} special characters", specCharCounter);
            Console.WriteLine("{0} words", wordsCounter.Count);
            Console.WriteLine("{0} is the longest word", longestWord);
            Console.WriteLine("{0} is the second word", secondLongestWord);
            Console.WriteLine("{0} is the shortest word", shortestWord);
               
        }
        /// <summary>
        /// Additional function for TextStats to check if a specific character is a letter between a and z
        /// </summary>
        /// <param name="ch">character to be checked</param>
        /// <returns>returns if a character is a letter between a and z or not</returns>
        static bool CharOk(char ch)
        {
            return (ch >= 'a' && ch <= 'z'); 
        }
        
        
        /// <summary>
        /// Checking if the number is a prime number or not
        /// </summary>
        /// <param name="number">Number to be checked</param>
        /// <returns>Returns whether number is prime or not</returns>
        public static bool IsPrime(int number)
        {
            //creating a checker for processed number
            bool checker = true;
            //looping through numbers and testing the input number
            for (int i = 2, j = 0; i * i <= number && j != 1;)
            {
                if (number % i == 0)
                {
                    j = 1;
                    checker = false;
                }
                else
                {
                    i++;
                }
            }
            return checker;
                
        }

        /// <summary>
        /// Takes a number and inserts a dash between digits if they both are odd
        /// </summary>
        /// <param name="number">Number to be processed</param>
        /// <returns>Returns number with dashes</returns>
        public static string DashInsert(int number)
        {
            //converting an input number into a string
            string numberToString = number.ToString();
            //creating a string for final output
            string outputString = String.Empty;
            //creating a list for holding all numbers and dashes
            List<string> holdingList = new List<string>();
            //creating a char varible with dash value and converting it into string
            char charDash = '-';
            string dashToBeAdded = charDash.ToString();
            
            //looping through an input number that was converted into a string, and checking each digit
            for (int i = 0; i < numberToString.Length;)
            {
                //converting each digit into type integer 
                //and checking if it is odd and if it is not equal to zero
                if (int.Parse(numberToString[i].ToString()) != 0 && int.Parse(numberToString[i].ToString()) % 2 != 0)
                {
                    //adding the digit into the list
                    holdingList.Add(numberToString[i].ToString());
                    //checking if it is the last digit in the string or not
                    if (i != (numberToString.Length-1))
                        //checking if the second digit is also odd and if it is not equal to zero
                        if (int.Parse(numberToString[i+1].ToString()) != 0 && int.Parse(numberToString[i+1].ToString()) % 2 != 0)
                        {
                            //adding dash into the list if second digit is also odd
                            holdingList.Add(dashToBeAdded);
                        }
                    i++;
                    
                }
                //if digit is even then else part is processed
                else
                {
                    //adding the digit into list
                    holdingList.Add(numberToString[i].ToString());
                    i++;
                }
            }
            
            //saving all list items into the final string for output
            for (int i = 0; i < holdingList.Count; i++)
            {
                outputString = outputString + holdingList[i];
            }

            return outputString;
        }

    }
}
