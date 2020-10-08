using System;
using System.Collections.Generic;

namespace vowelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write string of text");
            var input = Console.ReadLine();
            var letters = new HashSet<char>(input);
            letters.ExceptWith("aeiou");
            Console.WriteLine("Here is your string of text without vowels.");
            foreach (char c in letters) Console.Write(c);
            


        }
    }
}
