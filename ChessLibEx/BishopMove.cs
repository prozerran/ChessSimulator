using ChessLib;
using System.Collections.Generic;

namespace ChessLibEx
{
    public class BishopMove : ChessPeice
    {
        private string name = "Bishop";

        private int[,] moves = new[,] {
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 }, { 8, 8 },
            { -1, 1 }, { -2, 2 }, { -3, 3 }, { -4, 4 }, { -5, 5 }, { -6, 6 }, { -7, 7 }, { -8, 8 },
            { 1, -1 }, { 2, -2 }, { 3, -3 }, { 4, -4 }, { 5, -5 }, { 6, -6 }, { 7, -7 }, { 8, -8 },
            { -1, -1 }, { -2, -2 }, { -3, -3 }, { -4, -4 }, { -5, -5 }, { -6, -6 }, { -7, -7 }, { -8, -8 } 
        };

        public override int[,] Moves { get => moves; }
        public override string Name { get => name; }

        public BishopMove(Position pos) : base(pos)
        { }
    }
}
