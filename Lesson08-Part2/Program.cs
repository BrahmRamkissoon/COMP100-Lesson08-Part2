using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/**
* Nested loops & diagnostics -  Improving Loop performance
* exclude uncessary calculations
* compare to 0 , --note-- on my machine this was slower by a lot !
* consider order of evaluation for short-circuit , test for most likely condition first
*/
namespace Lesson08_Part2
{
    class Program
    {
        static void Main ( string [] args )
        {
            double loop1Total = 0;
            double loop2Total = 0;
            double loop3Total = 0;
            double loop4Total = 0;
            double loop1Avg = 0;
            double loop2Avg = 0;
            double loop3Avg = 0;
            double loop4Avg = 0;

            for (int outer = 0; outer < 60; outer++)
            {
                Console.WriteLine(" \n+++++++++++++LOOP 1 - Slow+++++++++++++++\n\n");
                Stopwatch loop1 = Stopwatch.StartNew();
                // First Method to print out chessboard - SLOW
                // the if statement is checking 4 times per column
                for ( int row = 0 ; row < 8 ; row++ )           // 15 Lines
                {
                    for ( int col = 0 ; col < 4 ; col++ )
                    {
                        Console.Write(row % 2 != 0 ? " B W" : " W B");
                    } // Inner loop
                    Console.WriteLine();
                } // outer loop
                loop1.Stop();   // stop count 

                Console.WriteLine(" \n+++++++++++++LOOP 2 - Fast+++++++++++++++\n\n");
                Stopwatch loop2 = Stopwatch.StartNew();
                // Second method to print out chessboard - FAST
                // the if statement is checking 1 time per row
                for ( int row = 0 ; row < 8 ; row++ )       // 17 lines
                {
                    string pattern = "";

                    pattern = row % 2 != 0 ? (" B W") : (" W B");

                    for ( int col = 0 ; col < 4 ; col++ )
                    {
                        if ( row % 2 != 0 )       // Odd row
                        {
                            Console.Write(pattern);
                        }
                    } // Inner loop
                    Console.WriteLine();
                } // outer loop
                loop2.Stop();   // Stop count

                Console.WriteLine(" \n+++++++++++++LOOP 1b - Check against 0 +++++++++++++++\n\n");
                Stopwatch loop3 = Stopwatch.StartNew();
                // First Method to print out chessboard - SLOW
                // the if statement is checking 4 times per column
                for ( int row = 8 ; row > 0 ; row-- )           // 15 Lines
                {
                    for ( int col = 4 ; col > 0 ; col-- )
                    {
                        Console.Write(row % 2 != 0 ? " B W" : " W B");
                    } // Inner loop
                    Console.WriteLine();
                } // outer loop
                loop3.Stop();   // stop count 

                Console.WriteLine(" \n+++++++++++++LOOP 2b - Check against 0 +++++++++++++++\n\n");
                Stopwatch loop4 = Stopwatch.StartNew();
                // Second method to print out chessboard - FAST
                // the if statement is checking 1 time per row
                for ( int row = 8 ; row > 0 ; row-- )       // 17 lines
                {
                    string pattern = "";

                    pattern = row % 2 != 0 ? (" B W") : (" W B");

                    for ( int col = 4 ; col > 0 ; col-- )
                    {
                        if ( row % 2 != 0 )       // Odd row
                        {
                            Console.Write(pattern);
                        }
                    } // Inner loop
                    Console.WriteLine();
                } // outer loop
                loop4.Stop();   // Stop count


                // output diagnotic results
                Console.WriteLine();
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                Console.WriteLine($"Loop 1: {loop1.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine($"Loop 2: {loop2.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine($"Loop 1b: {loop3.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine($"Loop 2b: {loop4.Elapsed.TotalMilliseconds} ms");
                Console.WriteLine("+++++++++++++++++++++++++++++++++");

                // calc totals
                loop1Total += loop1.Elapsed.TotalMilliseconds;
                loop2Total += loop2.Elapsed.TotalMilliseconds;
                loop3Total += loop3.Elapsed.TotalMilliseconds;
                loop4Total += loop4.Elapsed.TotalMilliseconds;

                // output totals
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++");
                Console.WriteLine($"Loop 1: {loop1Total} ms");
                Console.WriteLine($"Loop 2: {loop2Total} ms");
                Console.WriteLine($"Loop 1b: {loop3Total} ms");
                Console.WriteLine($"Loop 2b: {loop4Total} ms");
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++");

                // calc Averages
                loop1Avg = loop1Total / outer +1 ;
                loop2Avg = loop2Total / outer +1 ;
                loop3Avg = loop3Total / outer +1;
                loop4Avg = loop4Total / outer +1;

                // output avgs
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++");
                Console.WriteLine($"Loop 1 Average: {loop1Avg} ms");
                Console.WriteLine($"Loop 2 Average: {loop2Avg} ms");
                Console.WriteLine($"Loop 1b Average: {loop3Avg} ms");
                Console.WriteLine($"Loop 2b Average: {loop4Avg} ms");
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++");

            } // outer outer loop
           

            
            // better to test for row instead of column, so we make a variable
            /* Desired output for chessboard
            W B W B W B W B 
            B W B W B W B W
            W B W B W B W B
            B W B W B W B W
            W B W B W B W B
            B W B W B W B W
            W B W B W B W B
            B W B W B W B W
            */

            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            
        }
    }
}
