namespace draughts
{
    public class Board
    {
        private static Board _instance;
        private static readonly object Padlock = new();
        public Pawn[,] Fields = new Pawn[10, 10];
        private int Size { get; set; } = 10;

        private Board()
        {
            PlacePawns();
        }

        private void PlacePawns()
        {
            int x = 0;
            int y = 1;
            for (int i = 0; i < 2 * Size; i++)
            {
                if (y > 9)
                {
                    x += 1;
                    y -= 9;
                }
                Fields[x, y] = new Pawn {Coordinates = (x, y), IsWhite = false, IsCrowned = false};
                if (y >= 9)
                {
                    x += 1;
                    y -= 9;
                }
                else
                {
                    y += 2;
                }
                
            }

            x += 3;
            y = 1;
            
            for (int i = 0; i < 2 * Size; i++)
            {
                if (y > 9)
                {
                    x += 1;
                    y -= 9;
                }
                Fields[x, y] = new Pawn {Coordinates = (x, y), IsWhite = true, IsCrowned = false};
                if (y >= 9)
                {
                    x += 1;
                    y -= 9;
                }
                else
                {
                    y += 2;
                }
                
            }

        }

        public static Board GetInstance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Board();
                    }

                    return _instance;
                }
            }
        }
    }
}