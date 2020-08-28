using System;
// ░ och ▓
// 8x8 for loop 
// börjar på vitt 
namespace ChessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int column = 0; column < 8; column++)  
            {
                for (int row = 0; row < 8; row++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        Console.Write("▓▓");
                    }
                    else if ((row + column ) % 2 == 1)
                    {
                        Console.Write("░░");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
