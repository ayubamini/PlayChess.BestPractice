using System.Reflection.Metadata;

namespace PlayChess
{
    public class PieceMovementValidator
    {
        private readonly Board _board;

        public PieceMovementValidator(Board board)
        {
            _board = board;
        }

        public void ValidateMove(string source, string destination)
        {
            var sourcePiece = _board.GetPiece(source);
            var destinationPiece = _board.GetPiece(destination);

            CheckIfAnyPieceExistInSource(sourcePiece);
            CheckIdSameColorIsNotInDestination(sourcePiece, destinationPiece);
        }

        private static void CheckIdSameColorIsNotInDestination(string sourcePiece, string destinationPiece)
        {
            if (sourcePiece == destinationPiece)
            {
                throw new InvalidMoveException();
            }
        }

        private static void CheckIfAnyPieceExistInSource(string sourcePiece)
        {
            if (sourcePiece == null)
            {
                throw new InvalidMoveException();
            }
        }
    }
}