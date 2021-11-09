using ChessLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLibEx
{
    public class KnightMove : ChessPeice
    {
        private string name = "Knight";

        private int[,] moves = new[,] { { 1, 2 }, { 1, -2 }, { -1, 2 }, { -1, -2 }, { 2, 1 }, { -2, 1 }, { 2, -1 }, { -2, -1 } };

        public override int[,] Moves { get => moves; }
        public override string Name { get => name; }

        public KnightMove(Position pos) : base(pos)
        { }
    }
}
