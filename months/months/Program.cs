using System;
using System.Globalization;

namespace months
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ett program som tar en emot inmatad siffra (1-12)
            // och konverterar siffran till ett månadsnamn på svenska
            // programmet skall kasta ett fel om den inmatade siffran är något annat än 1-12.
            CultureInfo cultureInfo = new CultureInfo("sv-SE");

            Console.WriteLine("Skriv en siffra 1-12");
            var userInput = Console.ReadLine();
            int number = int.Parse(userInput);
           
            
            if (number < 1 || number > 12)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(number);
                Console.WriteLine(monthName);
                Console.WriteLine("Your input was incorrect.");
            }
            else 
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(number);
                Console.WriteLine(monthName);
            }
        }
    }
}
