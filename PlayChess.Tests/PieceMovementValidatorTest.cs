using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayChess.Tests
{
    [TestClass]
    public class PieceMovementValidatorTest
    {
        private Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidVerticalPosition_ThrowException()
        {
            _board.Move("A8", "C3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidHorizontalPosition_ThrowException()
        {
            _board.Move("J3", "C3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void NullPosition_ThrowException()
        {
            _board.Move(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void EmptyPosition_ThrowException()
        {
            _board.Move("", string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidLengthOfPosition_ThrowException()
        {
            _board.Move("A", "B25");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void VerticalPositionIsNotNumber_ThrowException()
        {
            _board.Move("2A", "22");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))] // Assert
        public void SameColorPieceInDestination_ThrowException()
        {
            // Arrange
            _board.AddPiece("B2", "Black");
            _board.AddPiece("B4", "Black");

            // Action
            _board.Move("B2", "B4");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void NoPieceExistInSource_ThrowException()
        {
            // No piece in the position
            _board.Move("B2", "B4");
        }
    }


}
