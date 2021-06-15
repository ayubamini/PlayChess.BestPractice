using System;
using System.Collections.Generic;

namespace PlayChess
{
    public class Board
    {
        private readonly Dictionary<Position, string> _cells;
        private readonly PieceMovementValidator _pieceMovementValidator;

        public Board()
        {
            _cells = new Dictionary<Position, string>();
            _pieceMovementValidator = new PieceMovementValidator(this);
            InitialBaord();
        }

        public void AddPiece(string position, string color)
        {
            var coordinator = new Position(position);
            _cells[coordinator] = color;
        }

        public string GetPiece(string position)
        {
            return _cells[new Position(position)];
        }

        public void Move(string source, string destination)
        {
            _pieceMovementValidator.ValidateMove(source, destination);
        }

        private void InitialBaord()
        {
            for (var horizontal = 'A'; horizontal <= 'H'; horizontal++)
            {
                for (var vertical = 0; vertical <= 7; vertical++)
                {
                    _cells.Add(new Position(horizontal.ToString() + vertical.ToString()), null);
                }
            }
        }
    }
}