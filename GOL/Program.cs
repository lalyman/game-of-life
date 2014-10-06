using System;

// I'm assuming that a square board is in play. The input board is a 2-D array. The test I'm using
// is a pulsar, which is a symmetrical image that repeats after 3 generations. 
using NUnit.Framework;

namespace GOL
{
    class Program
    {
        public static int [,] NextGen(int[,] board)
        {
            int n = board.GetUpperBound(0)+1;
            var newboard = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int sum = 0;
                    // try each of 8 possible neighbors to see if it's valid;


                    sum += GetBoardValueIfPossible(board, i - 1, j - 1);


                    sum += GetBoardValueIfPossible(board, i - 1, j);

                    sum += GetBoardValueIfPossible(board, i - 1, j + 1);

                    sum += GetBoardValueIfPossible(board, i, j - 1);

                    sum += GetBoardValueIfPossible(board, i, j + 1);

                    sum += GetBoardValueIfPossible(board, i + 1, j - 1);

                    sum += GetBoardValueIfPossible(board, i + 1, j);

                    sum += GetBoardValueIfPossible(board, i + 1, j + 1); 
                   
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

        private static int GetBoardValueIfPossible(int[,] board, int index0, int index1)
        {
            if (index0 > board.GetUpperBound(0) || index1 > board.GetUpperBound(1) || index1< 0 || index0 < 0)
            {
                return 0;
            }
            return board[index0, index1];
        }

        static void DrawBoard(int[,] board)
        {
            int n = board.GetUpperBound(0) + 1;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(board[row, col] == 1 ? "X" : " ");
                }
                Console.Write("\n");
            }
        }

        public static void GenIterator(int[,] board, int numgens)
        {
            for (int i = 0; i < numgens; i++)
            {
                DrawBoard(board);
                Console.WriteLine();
                board = NextGen(board);
            }
        }

        static void Main()
        {
            string readLine = String.Empty;
            while (String.IsNullOrEmpty(readLine))
            {
                Console.WriteLine("Enter the number of generations you wish to see!");
                readLine = Console.ReadLine();
            }
            int line = Int32.Parse(readLine);

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
            GenIterator(board, line);
        }
    }

    [TestFixture]
    public class GameOfLifeTest
    {
        [Test]
        public void EmptyBoard()
        {
            int[,] board = { 
                           { 0 }
            };
            Assert.That(Program.NextGen(board),Is.EquivalentTo(board));
 
        }
        [Test]
        public void ShouldDie()
        {
            int[,] board = { 
                           { 1 }
            };
            int[,] expected = { 
                           { 0 }
            };
            
            Assert.That(Program.NextGen(board),Is.EquivalentTo(expected));
 
        }
        [Test]
        public void Stable()
        {
            int[,] board = { 
                           { 0,1,0 }, 
                           {1,0,1},
                           {0,1,0}
                           };
           
            
            Assert.That(Program.NextGen(board),Is.EquivalentTo(board));
 
        }
        [Test]
        public void Line()
        {
            int[,] board = { 
                           { 0,0,0 }, 
                           {1,1,1},
                           {0,0,0}
                           };
            int[,] expected = { 
                           { 0,1,0 }, 
                           {0,1,0},
                           {0,1,0}
                           };
           
            
            Assert.That(Program.NextGen(board),Is.EquivalentTo(expected)); 
            Assert.That(Program.NextGen(expected),Is.EquivalentTo(board));
 
        }
    }
}

