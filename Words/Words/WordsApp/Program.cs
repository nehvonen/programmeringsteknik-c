using System;

namespace WordsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a sentence.");
            // Skriv en konsolapplikation som tar emot en skriven text.

            char[] vowels = new char[] { 'a', 'o', 'e', 'u', 'i', 'ä', 'ä', 'å', 'ö', 'y' };
            string enteredString = Console.ReadLine(); 
            string myLowercaseString = enteredString.ToLower();
            int vowelCount = 0;

            string[] words = myLowercaseString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int wordCount = words.Length;
            string longestWord = string.Empty;
            foreach (var character in enteredString)
            {
            
                if (vowels.Contains(myLowercaseString))
                {
                    vowelCount++;
                }

            }

            /*/ for (var i = 0; i < enteredString.Length; i++)
            {
                var character = enteredString[i];
            } /*/

            //Vi vill ha följande: 
            // Antal ord
            // Antal vokaler
            // Vilket är det längsta ordet

            Console.WriteLine(" Word count " + wordCount);
            Console.WriteLine("Vowel count " + vowelCount);
            Console.WriteLine(" Longest word " + longestWord + ", " + longestWord.Length);




        }
    }
}
