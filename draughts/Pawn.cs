using System.Dynamic;

namespace draughts
{
    public class Pawn
    {
        public bool IsWhite { get; set; }
        public (int x, int y) Coordinates { get; set; }
        public bool IsCrowned { get; set; }
        
    }
}