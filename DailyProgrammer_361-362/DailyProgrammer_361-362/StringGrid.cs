using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DailyProgrammer_361_362
{
    /// <summary>
    /// Handles tramsforming a normal string into a multidimensional array.
    /// For example:
    /// a b c d
    /// e f g h
    /// i j k l
    /// </summary>
    public class StringGrid
    {
        /// <summary>
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="input">string to break into a grid. needs to be smaller than or equal to the size of the grid (e.g. width * height)</param>
        public StringGrid(int height, int width, string input)
        {
            if (input.Length > (width * height))
            {
                throw new ArgumentOutOfRangeException(
                    $"The parameter '{nameof(input)}' cannot have more characters than the size of the grid. Grid size: '{width * height}', {nameof(input)} size: '{input.Length}'"
                    );
            }

            this.GridWidth = width;
            this.GridHeight = height;

            this._inputString = input;
            this._grid = CreateGrid(this.GridWidth, this.GridHeight, this._inputString);
        }

        private readonly string _inputString;
        private readonly char[,] _grid;

        public int GridWidth { get; private set; }
        public int GridHeight { get; private set; }

        public char[,] Grid => this._grid;

        protected char[,] CreateGrid(int height, int width, string input)
        {
            var gridSize = (width * height);
            var tmpGrid = new char[height, width];
            var paddedInput = PadStringForGrid(gridSize, input);

            if (paddedInput.Length != gridSize)
            {
                throw new InvalidOperationException(
                    $"Parameter {nameof(input)} was not properly padded. {nameof(paddedInput)} length: '{paddedInput.Length}' != {nameof(gridSize)}: '{gridSize}'"
                    );
            }

            int indexOfPaddedString = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tmpGrid[i, j] = paddedInput[indexOfPaddedString];
                    indexOfPaddedString++;
                }
            }

            return tmpGrid;
        }

        protected virtual string PadStringForGrid(int totalGridSize, string input, char paddingCharacter = '+')
        {
            return input.PadRight(totalGridSize, paddingCharacter);
        }
    }
}
