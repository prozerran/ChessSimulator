using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChessLib;
using ChessLibEx;

// Applicant: Tim Hsu
// I haven't "changed" the original ChessLib library, but I did create another one and refactor a bunch of code to fit the need

namespace SampleProgram
{
    public class ComplexGame
    {
        private readonly Random _rnd = new Random();
        private readonly Random _peice = new Random();
        private readonly Random _moves = new Random();

        private ChessPeice knight;
        private ChessPeice bishop;
        private ChessPeice queen;

        // maybe Dictionary will suffice, in case threading is involved.
        private ConcurrentDictionary<ChessPeice, Position> occupiedPos = new ConcurrentDictionary<ChessPeice, Position>();

        //public void Play(int moves)
        //{
        //    while (true)
        //    {
        //        // get the peice to move, 0=K, 1=B, 2=Q
        //        var peice =_peice.Next(3);

        //        if (peice == 0)
        //            MoveChessPeice(moves, knight);
        //        else if (peice == 1)
        //            MoveChessPeice(moves, bishop); 
        //        else
        //            MoveChessPeice(moves, queen);

        //        Console.Write("Continue? (y/n): ");
        //        var line = Console.ReadLine();

        //        if (line.Equals("n"))
        //            break;
        //    }
        //}

        public void Play(int moves)
        {
            for (var move = 1; move <= moves; move++)
            {
                // get the peice to move, 0=K, 1=B, 2=Q
                var peice = _peice.Next(3);

                if (peice == 0)
                    MoveChessPeice(1, move, knight);
                else if (peice == 1)
                    MoveChessPeice(1, move, bishop);
                else
                    MoveChessPeice(1, move, queen);
            }
        }

        public void Setup()
        {
            knight = new ChessLibEx.KnightMove(new Position(3, 3));
            bishop = new ChessLibEx.BishopMove(new Position(4, 4));
            queen = new ChessLibEx.QueenMove(new Position(5, 4));

            occupiedPos.TryAdd(knight, knight.CurrentPosition);
            occupiedPos.TryAdd(bishop, bishop.CurrentPosition);
            occupiedPos.TryAdd(queen, queen.CurrentPosition);
        }

        private IEnumerable<Position> GetOccupiedPositions()
        {
            var occupiedList = (from op in occupiedPos select op.Value);
            return occupiedList;
        }

        private void MoveChessPeice(int moves, int move_num, ChessPeice peice)
        {
            var pos = peice.CurrentPosition;
            var occPos = GetOccupiedPositions();

            for (var move = 1; move <= moves; move++)
            {
                var possibleMoves = peice.ValidMovesFor(pos, occPos.ToList()).ToArray();
                pos = possibleMoves[_rnd.Next(possibleMoves.Length)];

                // set this new position as occupied
                occupiedPos.TryUpdate(peice, pos, peice.CurrentPosition);

                Console.WriteLine($"[{move_num}]: {peice.Name} position move to {pos}");
            }
        }
    }
}
