using System;
using System.Linq;

namespace PlayChess
{
    public class Position  : IEquatable<Position>
    {
        public Position(string position)
        {
            InvalidArgument(position);
            
            ParseHorizontal(position);
            ParseVertical(position);
        }
        
        public int HorizontalIndex { get; private set; }
        public int VerticalIndex { get; private set; }

        public bool Equals(Position other)
        {
            return HorizontalIndex == other?.HorizontalIndex &&
                   VerticalIndex == other.VerticalIndex;
        }
        public override int GetHashCode()
        {
            return (VerticalIndex + "::" + HorizontalIndex).GetHashCode();
        }

        private void ParseHorizontal(string position)
        {
            var horizontal = position.First();
            HorizontalIndex = horizontal - 'A';

            ValidateHorizontalPosition(horizontal);
        }

        private void ParseVertical(string position)
        {
            if (!char.IsDigit(position.Last()))
            {
                throw new InvalidMoveException();
            }

            VerticalIndex = int.Parse(position.Last().ToString());

            ValidateVerticalPosition();
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
            if (VerticalIndex < 0 || VerticalIndex > 7)
            {
                throw new InvalidMoveException();
            }
        }

        private void ValidateHorizontalPosition(char horizontal)
        {
            if (horizontal < 'A' || horizontal > 'H')
            {
                throw new InvalidMoveException();
            }
        }


    }
}