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
            var grid = new StringGrid(this.GridHeight, this.GridWidth, input);



            throw new NotImplementedException();
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
    }
}
