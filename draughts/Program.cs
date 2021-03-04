using System;

namespace draughts
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = Board.GetInstance;
            var boardFields = board.Fields;
            foreach (var field in boardFields)
            {
                if (field != null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine("Pawn");
                }
            }
        }
    }
}