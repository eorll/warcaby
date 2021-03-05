using System;
using System.Threading;

namespace draughts
{
    public class Game
    {
        private static Game _instance;
        private static readonly object Padlock = new();
        public static Game GetInstance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Game();
                    }

                    return _instance;
                }
            }
        }

        private Game()
        {
            
        }
        public bool MoveAllowed(Pawn pawn, (int x, int y) newCoordinates, Pawn[,] boardFields)
        {
            // START Spaghetti!!!!!!!!!!!!
            var xDirection = pawn.Coordinates.x - newCoordinates.x;
            var yDirection = pawn.Coordinates.y - newCoordinates.y;
            if (newCoordinates.x < 0 ^ newCoordinates.x > 9 ^ newCoordinates.y < 0 ^ newCoordinates.y > 9)
            {
                return false;
            }
            if (pawn.IsWhite)
            {
                if (pawn.Coordinates.x - newCoordinates.x != 1)
                {
                    return false;
                }
            }
            else
            {
                if (pawn.Coordinates.x - newCoordinates.x != -1)
                {
                    return false;
                }
            }
            if (newCoordinates.y > pawn.Coordinates.y + 1 ^ newCoordinates.y < pawn.Coordinates.y - 1)
            {
                return false;
            }
            if (boardFields[newCoordinates.x, newCoordinates.y] != null)
            {
                if (boardFields[newCoordinates.x, newCoordinates.y].IsWhite & pawn.IsWhite)
                {
                    return false;
                }
                if (boardFields[newCoordinates.x - xDirection, newCoordinates.y - yDirection] != null)
                {
                    return false;
                }
                
                boardFields[pawn.Coordinates.x, pawn.Coordinates.y] = null;
                pawn.ChangeCoordinates((newCoordinates.x - xDirection, newCoordinates.y - yDirection));
                boardFields[newCoordinates.x, newCoordinates.y] = null;
                boardFields[newCoordinates.x - xDirection, newCoordinates.y - yDirection ] = pawn;
                return true;
            }
            boardFields[pawn.Coordinates.x, pawn.Coordinates.y] = null;
            pawn.ChangeCoordinates((newCoordinates.x, newCoordinates.y));
            boardFields[newCoordinates.x, newCoordinates.y] = pawn;
            
            return true;
        }
    }
}