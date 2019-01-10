using System;
using System.Collections.Generic;
using System.Text;

namespace DailyProgrammer_361_362
{
    /// <summary>
    /// An interface for performing a 2 way encryption process on a string.
    /// Intended for simple ciphers like transposition.
    /// </summary>
    public interface IEncryptStrings
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
