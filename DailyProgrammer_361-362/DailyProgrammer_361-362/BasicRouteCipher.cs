using System;
using System.Collections.Generic;
using System.Text;

namespace DailyProgrammer_361_362
{
    public class BasicRouteCipher : IEncryptStrings
    {
        public BasicRouteCipher(int gridHeight, int gridWidth, CipherModulation modulationOption)
        {
            this.GridHeight = gridHeight;
            this.GridWidth = gridWidth;
        }

        // private set as we don't want someone to, new one up, encrypt a string, then change this value, then try to decrypt their encrypted string
        public CipherModulation ModulationOption { get; private set; }

        public int GridHeight { get; private set; }
        public int GridWidth { get; private set; }

        public string Decrypt(string input)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string input)
        {
            var normalizedInput = this.NormalizeStringForEncrypting(input);
            var grid = new StringGrid(this.GridHeight, this.GridWidth, normalizedInput);

            ApplyRotationalTransformToGrid(grid, true);

            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="counterClockwise">If set to true will roate the grid counter-clockwise, otherwise the grid will be rotated clockwise.</param>
        /// <returns>A newly rotated StringGrid based on the input grid</returns>
        private StringGrid ApplyRotationalTransformToGrid(StringGrid grid, bool clockwise = true)
        {
            var z = @"W   E   A   R   E   D   I   S   C
                      O   V   E   R   E   D   F   L   E
                      E   A   T   O   N   C   E   +   +";
            var z2 = "CEXXECNOTAEOWEAREDISLFDEREV";

            var output = new char[grid.Length];

            var startingPoint = new Point((grid.Width - 1), 0);
            var currentPoint = new Point(startingPoint.X, startingPoint.Y);
            var incrementDirection = (clockwise ? 1 : -1);

            var maxX = grid.Width;
            var maxY = grid.Height;

            for (int i = 0; i < grid.Length; i++)
            {
                var isEndingCharacter = (i == (grid.Length - 1));
                var currentCharacter = grid[currentPoint.Y, currentPoint.X];

                if (isEndingCharacter)
                {
                    output[Get2DPointAsLinearIndex(startingPoint)] = currentCharacter;
                }
                else
                {
                    output[i] = currentCharacter;
                }

                var isAtEndOfRow = (currentPoint.X >= (maxX - 1));
                var isAtBeginningOfRow = (currentPoint.X == 0);
                var isAtEndOfColumn = (currentPoint.Y >= (maxY - 1));
                var isAtBeginningOfColumn = (currentPoint.Y == 0);

                // are we at a single point after the first row of characters in the grid (and is the grid bigger than a single row)
                var isAtASinglePointPastFirstRow = (grid.Width + 1 < grid.Length && i == grid.Width + 1);

                // Reduce the grid size by 1 so we can start a smaller loop
                if (isAtASinglePointPastFirstRow && (isAtBeginningOfRow && isAtBeginningOfColumn) || (isAtEndOfColumn && isAtEndOfRow))
                {
                    maxX--;
                    maxY--;
                }

                if (isAtEndOfRow && !isAtEndOfColumn)
                {
                    currentPoint.Y++;
                }
                else if (isAtEndOfRow && isAtEndOfColumn)
                {
                    currentPoint.X--;
                    incrementDirection = (incrementDirection * -1);
                }
                else if (isAtBeginningOfRow && !isAtBeginningOfColumn)
                {
                    currentPoint.Y--;
                }
                else if (isAtBeginningOfRow && isAtBeginningOfColumn)
                {
                    currentPoint.X++;
                    incrementDirection = (incrementDirection * -1);
                }
                else
                {
                    currentPoint.X += incrementDirection;
                }
                
            }

            throw new NotImplementedException();
        }

        private int Get2DPointAsLinearIndex(Point target)
        {
            return ((target.X * target.Y) + target.X);
        }

        private bool IsCoordinateOutOfBoundsX(StringGrid grid, int x)
        {
            return (x >= grid.Width);
        }

        private bool IsCoordinateOutOfBoundsY(StringGrid grid, int y)
        {
            return (y >= grid.Height);
        }

        private bool IsCoordinateOutOfBoundsBoth(StringGrid grid, int x, int y)
        {
            return (IsCoordinateOutOfBoundsX(grid, x) && IsCoordinateOutOfBoundsY(grid, y));
        }

        /// <summary>
        /// Takes an input string and prepares it for the <see cref="Encrypt(string)"> method
        /// </summary>
        /// <param name="input"></param>
        /// <returns>the input string with all non letter characters removed and all letters changed to uppercase.</returns>
        protected virtual string NormalizeStringForEncrypting(string input)
        {
            var sb = new StringBuilder();
            var inputCharacters = input.ToCharArray();

            foreach (var c in inputCharacters)
            {
                if (char.IsLetter(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().ToUpperInvariant();
        }

        internal struct Point
        {
            internal Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            internal int X;
            internal int Y;
        }
    }
}
