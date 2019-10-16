using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace romansNumberGenerator
{
   public class Program
    {
        static void Main(string[] args)
        {
            var rnc=new RomanNumberGenerator();
            var res = rnc.generateRomanNumber("19845");
            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
