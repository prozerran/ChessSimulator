using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Writting my own ChessLib, forget extending from ChessLib
// Therefore, ChessLib is NOT needed.

namespace ChessLibEx
{
    public abstract class ChessPeice
    {
        abstract public int[,] Moves { get; }
        abstract public string Name { get; }
        
        public Position CurrentPosition { get; set; }

        public ChessPeice(Position pos)
        {
            CurrentPosition = pos;
        }

        private bool IsPositionOccupied(List<Position> occupiedPos, int newX, int newY)
        {
            var isOccupied = occupiedPos.Where(o => o.X == newX && o.Y == newY).ToList();

            if (isOccupied.Count > 0)
                return true;

            return false;
        }

        public virtual IEnumerable<Position> ValidMovesFor(Position pos, List<Position> occupiedPos)
        {
            for (var i = 0; i <= Moves.GetUpperBound(0); i++)
            {
                var newX = pos.X + Moves[i, 0];
                var newY = pos.Y + Moves[i, 1];

                // determine if within borders
                if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
                    continue;

                // determine if position is already occupied, if so, choose another position
                if (IsPositionOccupied(occupiedPos, newX, newY))
                    continue;

                CurrentPosition = new Position(newX, newY);
                yield return CurrentPosition;
            }
        }
    }
}
