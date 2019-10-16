using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace romansNumberGenerator
{
    public class RomanNumberGenerator
    {

        enum RomanNumbs
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000,
        }
        private readonly Dictionary<(int, int), RomanNumbs> dic;

        public RomanNumberGenerator()
        {
            this.dic=new Dictionary<(int, int), RomanNumbs>();
            dic.Add((1,1), RomanNumbs.I);
            dic.Add((1, 2), RomanNumbs.V);
            dic.Add((2, 1), RomanNumbs.X);
            dic.Add((2, 2), RomanNumbs.L);
            dic.Add((3, 1), RomanNumbs.C);
            dic.Add((3, 2), RomanNumbs.D);
            dic.Add((4, 1), RomanNumbs.M);
        }

        private string getRomanNumeral(int order, char digit)
        {
           
            if (order < 0)
                throw new Exception("Non positive order");
            if (order >= 4)
                return new StringBuilder().Then(sb =>
                    {
                        sb.AppendJoin(String.Empty,Enumerable.Repeat(RomanNumbs.M.ToString(), 
                            (int)Char.GetNumericValue(digit) *(int) Math.Pow(10, order - 4)));
                        return sb.ToString();
                    });
               
            if (digit == '9')
            {
                return string.Concat(dic[(order++, 1)].ToString(), dic[(order++, 1)].ToString());
            }
            if (digit == '8')
            {
                return string.Concat(dic[(order, 2)].ToString(), string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(),3)));
            }
            if (digit == '7')
            {
                return string.Concat(dic[(order, 2)].ToString(), string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(), 2)));
            }
            if (digit == '6')
            {
                return string.Concat(dic[(order, 2)].ToString(), string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(), 1)));
            }
            if (digit == '5')
            {
                return dic[(order, 2)].ToString();
            }
            if (digit == '4')
            {
                return string.Concat(dic[(order, 1)].ToString(), dic[(order, 2)].ToString());
            }
            if (digit == '3')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(), 3));
            }
            if (digit == '2')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(), 2));
            }
            if (digit == '1')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, 1)].ToString(), 3));
            }
            if (digit == '0')
            {
                return string.Empty;
            }

            return string.Empty;
        }
        public string generateRomanNumber(string inputNumber)
        {

            var result = new StringBuilder();
            inputNumber.ForEach(
                (val, i) =>
                    {
                        var res = this.getRomanNumeral(inputNumber.Length - i, val);
                        result.Append(res);
                    });
            return result.ToString();
        }
    }
}
