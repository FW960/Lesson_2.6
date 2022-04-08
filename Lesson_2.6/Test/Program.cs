using System;
using System.Text;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String unicodeString =
          "This unicode string contains two characters " +
          "with codes outside the ASCII code range, " +
          "Pi (\u03a0) and Sigma (\u03a3).";
            Console.WriteLine("Original string:");
            Console.WriteLine(unicodeString);
        }
    }
}
