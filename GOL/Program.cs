using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I'm assuming that a square board is in play. The input board is a 2-D array. The test I'm using
// is a pulsar, which is a symmetrical image that repeats after 3 generations. 
namespace GOL
{
    class Program
    {
        static int[,] NextGen(int[,] board, int n)
        {
            int[,] newboard = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int sum = 0;
                    // try each of 8 possible neighbors to see if it's valid;
                    try { sum += board[i - 1, j - 1]; }
                    catch { }
                    try { sum += board[i - 1, j]; }
                    catch { }
                    try { sum += board[i - 1, j + 1]; }
                    catch { }
                    try { sum += board[i, j - 1]; }
                    catch { }
                    try { sum += board[i, j + 1]; }
                    catch { }
                    try { sum += board[i + 1, j - 1]; }
                    catch { }
                    try { sum += board[i + 1, j]; }
                    catch { }
                    try { sum += board[i + 1, j + 1]; }
                    catch { }
                    if (board[i, j] == 1 && (sum < 2 || sum > 3))
                    {
                        newboard[i, j] = 0;
                    }
                    if (board[i, j] == 0 && sum == 3)
                    {
                        newboard[i, j] = 1;
                    }
                    if (board[i, j] == 1 && (sum == 2 || sum == 3))
                    {
                        newboard[i, j] = 1;
                    }
                } // end for j
            } // end for i
            return newboard;
        }

        static void DrawBoard(int[,] board, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row, col] == 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        static void GenIterator(int[,] board, int n, int numgens)
        {
            for (int i = 0; i < numgens; i++)
            {
                DrawBoard(board, n);
                Console.WriteLine();
                board = NextGen(board, n);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of generations you wish to see!");
            int line = Int32.Parse(Console.ReadLine());

            int[,] board = { 
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
                           { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0}, 
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                           { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0}, 
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0},
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                           { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0}, 
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}                     
                           };
            GenIterator(board, 15, line);
        }
    }
}

