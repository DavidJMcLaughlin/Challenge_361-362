using System;

namespace DailyProgrammer_361_362
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new BasicRouteCipher(3, 9, CipherModulation.Clockwise);
            var output = c.Encrypt("WE ARE DISCOVERED. FLEE AT ONCE");

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
