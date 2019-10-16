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
       

        private int getDigitValue(char symbol)
        {
            switch (symbol)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 5;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    throw new Exception("Non digit");
            }
        }

        private int getPowTen(int power)
        {
            var result = 1;
            power.Repeat(()=> result*=10);
            return result;
        }

        private readonly int non_Change_Order = 4;
        private readonly List< RomanCharacter> romanCharacterLst;
        private readonly Dictionary<(int,bool),RomanCharacter> dic;

        public RomanNumberGenerator(params RomanCharacter[] additionalSymbols)
        {
            romanCharacterLst = new List<RomanCharacter>()
            {
                new RomanCharacter()
                    {
                        arabicSymbol = 1,
                        romanSymbol = 'I',
                        isLastSymbolInRank = false,
                        rankNumber = 1
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 5,
                        romanSymbol = 'V',
                        isLastSymbolInRank = true,
                        rankNumber = 1
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 10,
                        romanSymbol = 'X',
                        isLastSymbolInRank = false,
                        rankNumber = 2
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 50,
                        romanSymbol = 'L',
                        isLastSymbolInRank = true,
                        rankNumber = 2
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 100,
                        romanSymbol = 'C',
                        isLastSymbolInRank = false,
                        rankNumber = 3
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 500,
                        romanSymbol = 'D',
                        isLastSymbolInRank = true,
                        rankNumber = 3
                    },
                new RomanCharacter()
                    {
                        arabicSymbol = 1000,
                        romanSymbol = 'M',
                        isLastSymbolInRank = false,
                        rankNumber = 4
                    },

            };
            romanCharacterLst.AddRange(additionalSymbols);

            non_Change_Order = romanCharacterLst
                .Select(r => r.rankNumber)
                .Max();
            dic = romanCharacterLst.ToDictionary(rc => (rc.rankNumber, rc.isLastSymbolInRank));
        }

        private string getRomanNumeral(int order, char digit)
        {          
            if (order < 0)
                throw new Exception("Non positive order");
            if (order >= non_Change_Order)
                return new StringBuilder().Then(sb =>
                    {
                        sb.AppendJoin(String.Empty,Enumerable.Repeat(RomanNumbs.M.ToString(),
                                                       getDigitValue(digit) * getPowTen( order - non_Change_Order)));
                        return sb.ToString();
                    });
               
            if (digit == '9')
            {
                return string.Concat(dic[(order++, false)], dic[(order++, false)]);
            }
            if (digit == '8')
            {
                return string.Concat(dic[(order, true)], string.Concat(Enumerable.Repeat(dic[(order, false)],3)));
            }
            if (digit == '7')
            {
                return string.Concat(dic[(order, true)], string.Concat(Enumerable.Repeat(dic[(order, false)], 2)));
            }
            if (digit == '6')
            {
                return string.Concat(dic[(order, true)], string.Concat(Enumerable.Repeat(dic[(order, false)], 1)));
            }
            if (digit == '5')
            {
                return dic[(order, true)].ToString();
            }
            if (digit == '4')
            {
                return string.Concat(dic[(order, false)], dic[(order, true)]);
            }
            if (digit == '3')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, false)], 3));
            }
            if (digit == '2')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, false)], 2));
            }
            if (digit == '1')
            {
                return string.Concat(Enumerable.Repeat(dic[(order, false)], 3));
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
