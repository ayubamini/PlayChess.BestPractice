using System.ComponentModel;
using System.Linq;

namespace PlayChess
{
    public class Position
    {
        char horizontal;
        int vertical;

        public Position(string position)
        {
            InvalidArgument(position);

            ParseVertical(position);
            horizontal = position.First();

            ValidateVerticalPosition();
            ValidateHorizontalPosition();
        }

        private void ParseVertical(string position)
        {
            if (!char.IsDigit(position.Last()))
            {
                throw new InvalidMoveException();
            }

            vertical = int.Parse(position.Last().ToString());
        }

        private static void InvalidArgument(string position)
        {
            if (position?.Length != 2)
            {
                throw new InvalidMoveException();
            }
        }

        private void ValidateVerticalPosition()
        {
            if (vertical < 1 || vertical > 8)
            {
                throw new InvalidMoveException();
            }
        }

        private void ValidateHorizontalPosition()
        {
            if (horizontal < 'A' || horizontal > 'H')
            {
                throw new InvalidMoveException();
            }
        }
    }
}