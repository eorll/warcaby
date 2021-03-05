using System;

namespace draughts
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = Board.GetInstance;
            var boardFields = board.Fields;
            DrawBoard(boardFields);

        }
        
        static void DrawBoard(Pawn[,] boardFields)
        {
            int rowLength = boardFields.GetLength(0);
            int colLength = boardFields.GetLength(1);
            
            
            for (int i = 0; i < rowLength; i++)
            {
                Console.Write(i);
                for (int j = 0; j < colLength; j++)
                {
                    
                    if (boardFields[i, j] == null)
                    {
                        Console.Write("|_");
                    }
                    else
                    {
                        if (boardFields[i, j].IsWhite)
                        {
                            Console.Write("|#");
                        }
                        else
                        {
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red; 
                            Console.Write("#");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Console.Write("|");
                Console.Write(Environment.NewLine);
            }
            Console.Write(" 0 1 2 3 4 5 6 7 8 9");
        }
    }
}