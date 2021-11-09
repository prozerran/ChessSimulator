using ChessLib;
using ChessLibEx;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProgram.Test
{
    [TestClass]
    public class TestAnswerFixture
    {
        private List<Position> occupiedPos = null;

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        { }

        [ClassInitialize()]         // calls once per instance
        public static void ClassInit(TestContext context) { }

        // Real constructor
        public TestAnswerFixture()
        {
            occupiedPos = new List<Position>();

            // preset some postions already occupied!
            occupiedPos.Add(new Position(5, 7));
            occupiedPos.Add(new Position(6, 1));
            occupiedPos.Add(new Position(4, 6));
            occupiedPos.Add(new Position(4, 1));
            occupiedPos.Add(new Position(1, 3));
        }

        [TestInitialize()]
        public void SetUp()         // calls before every test case
        { }

        [TestCleanup()]
        public void TearDown() { }  // calls after every test case

        [ClassCleanup()]            // calls once per instance
        public static void OneTimeTearDown() { }

        [DataTestMethod()]
        [DataRow(3, 3, 8)]
        [DataRow(6, 4, 8)]
        [DataRow(4, 5, 8)]
        [DataRow(2, 1, 3)]
        public void TestValidKnightMoves(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.KnightMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, new List<Position> { }).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }

        [DataTestMethod()]
        [DataRow(3, 3, 7)]
        [DataRow(6, 4, 8)]
        [DataRow(4, 5, 7)]
        [DataRow(2, 1, 2)]
        public void TestValidKnightMovesWithOccupiedSpace(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.KnightMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, occupiedPos).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }

        [DataTestMethod()]
        [DataRow(4, 4, 13)]
        [DataRow(7, 1, 7)]
        [DataRow(3, 5, 11)]
        [DataRow(2, 2, 9)]
        public void TestValidBishopMoves(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.BishopMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, new List<Position> { }).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }

        [DataTestMethod()]
        [DataRow(4, 4, 13)]
        [DataRow(7, 1, 7)]
        [DataRow(3, 5, 8)]
        [DataRow(2, 2, 8)]
        public void TestValidBishopMovesWithOccupiedSpace(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.BishopMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, occupiedPos).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }

        [DataTestMethod()]
        [DataRow(5, 5, 27)]
        [DataRow(1, 1, 21)]
        [DataRow(8, 1, 21)]
        [DataRow(1, 8, 21)]
        [DataRow(8, 8, 21)]
        [DataRow(4, 3, 25)]
        public void TestValidQueenMoves(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.QueenMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, new List<Position> { }).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }

        [DataTestMethod()]
        [DataRow(5, 5, 25)]
        [DataRow(1, 1, 18)]
        [DataRow(8, 1, 19)]
        [DataRow(1, 8, 20)]
        [DataRow(8, 8, 21)]
        [DataRow(4, 3, 21)]
        public void TestValidQueenMovesWithOccupiedSpace(int x, int y, int validmoves)
        {
            var peice = new ChessLibEx.QueenMove(new Position(x, y));

            var moves = peice.ValidMovesFor(peice.CurrentPosition, occupiedPos).ToList();

            Assert.IsNotNull(moves);
            Assert.AreEqual(validmoves, moves.Count);
        }
    }
}
