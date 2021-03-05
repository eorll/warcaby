using System;

namespace draughts
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = Board.GetInstance;
            var boardFields = board.Fields;

            int rowLength = boardFields.GetLength(0);
            int colLength = boardFields.GetLength(1);
            
            
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (boardFields[i, j] == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        if (boardFields[i, j].IsWhite)
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.Write("#");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}