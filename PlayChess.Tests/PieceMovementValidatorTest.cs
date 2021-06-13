using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayChess.Tests
{
    [TestClass]
    public class PieceMovementValidatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidVerticalPosition_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove("A9", "C3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidHorizontalPosition_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove("J3", "C3");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void NullPosition_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void EmptyPosition_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove("", string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void InvalidLengthOfPosition_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove("A", "B25");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void VerticalPositionIsNotDigit_ThrowException()
        {
            var validator = new PieceMovementValidator();
            validator.ValidateMove("2A", "22");
        }
    }


}
