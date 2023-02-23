using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordCase.Module
{
    public class PasswordGenerator
    {
        public int MinPasswordLength { get; private set; }
        public int MaxPasswordLength { get; private set; }
        public int MinLowerLetter { get; private set; }
        public int MinUpperLetter { get; private set; }
        public int MinNumericLetter { get; private set; }
        public int MinSpecialLetter { get; private set; }

        public static string AllLowerLetter { get; private set; }
        public static string AllUpperLetter { get; private set; }
        public static string AllNumericLetter { get; private set; }
        public static string AllSpecialLetter { get; private set; }
        private readonly string _allAvailableLetters;
        private int _minLetterNumbers;

        static PasswordGenerator()
        {
            AllLowerLetter = GetLetterRange('a', 'z'); //至少1個小寫字母
            AllUpperLetter = GetLetterRange('A', 'Z'); //至少1個大寫字母
            AllNumericLetter = GetLetterRange('0', '9'); //至少1個數字
            AllSpecialLetter = @"!@#$%^&*()_-+=|\:;'<>?,."; //至少一個特殊符號
        }

        public PasswordGenerator(int minPasswordLength = 7, int maxPasswordLength = 15,
            int minLowerLetter = 1, int minUpperLetter = 1, int minNumericLetter = 1, int minSpecialLetter = 1)
        {
            if (minPasswordLength < 7)
            {
                throw new ArgumentException("密碼長度不得小於7", "minPasswordLength");
            }
            if (maxPasswordLength > 15)
            {
                throw new ArgumentException("密碼長度不得大於15", "maxPasswordLength");
            }
            if (minPasswordLength > maxPasswordLength)
            {
                throw new ArgumentException("密碼長度須介於7-15之間", "minPasswordLength");
            }
            if (minLowerLetter < 0)
            {
                throw new ArgumentException("密碼須至少包含一小寫字母", "minLowerLetter");
            }
            if (minUpperLetter < 0)
            {
                throw new ArgumentException("密碼須至少包含一大寫字母", "minUpperLetter");
            }
            if (minNumericLetter < 0)
            {
                throw new ArgumentException("密碼須至少包含一數字", "minNumericLetter");
            }
            if (minSpecialLetter < 0)
            {
                throw new ArgumentException("密碼須至少包含一特殊符號", "minSpecialLetter");
            }
            MinPasswordLength = minPasswordLength;
            MaxPasswordLength = maxPasswordLength;
            MinLowerLetter = minLowerLetter;
            MinUpperLetter = minUpperLetter;
            MinNumericLetter = minNumericLetter;
            MinSpecialLetter = minSpecialLetter;

            _minLetterNumbers = minLowerLetter + minUpperLetter + minNumericLetter + minSpecialLetter;
            _allAvailableLetters = OnlyOneRequiredLetter(minLowerLetter, AllLowerLetter) +
                                   OnlyOneRequiredLetter(minUpperLetter, AllUpperLetter) +
                                   OnlyOneRequiredLetter(minNumericLetter, AllNumericLetter) +
                                   OnlyOneRequiredLetter(minSpecialLetter, AllSpecialLetter);

        }

        /// <summary>
        /// 取得密碼
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            Random rnd = new Random();
            var passwordQuery = rnd.Next(MinPasswordLength, MaxPasswordLength); //亂數取長度

            var minLetters = GetLetterRandom(AllLowerLetter, MinLowerLetter) + 
                              GetLetterRandom(AllUpperLetter, MinUpperLetter) +
                              GetLetterRandom(AllNumericLetter, MinNumericLetter) +
                              GetLetterRandom(AllSpecialLetter, MinSpecialLetter); //亂數規則參數
            var substringLetter = GetLetterRandom(_allAvailableLetters, passwordQuery - minLetters.Length); //亂數取得規則外參數
          //  var result = minLetters + substringLetter; //獲得自動產生的密碼
            var strLetter = minLetters + substringLetter;
            var result = new StringBuilder();
            for (int i = 0; i < strLetter.Length; i++)
            {
                result.Append(strLetter[rnd.Next(0, strLetter.Length)]);
            }
         //   var result = rnd.Next(realParame.Length).ToString();
            return result.ToString();
        }

        public string GetLetterRandom(string strLetter, int length)
        {
            Random rnd = new Random();
            var result = string.Empty;
            for (var lr = 0; lr < length; lr++)
            {
                var index = rnd.Next(strLetter.Length);
                result += strLetter[index];
            }
            return result;
        }

        public static string GetLetterRange(char min, char max)
        {
            var result = string.Empty;
            for (var value = min; value <= max; value++)
            {
                result += value;
            }
            return result;
        }


        private string OnlyOneRequiredLetter(int minLetter, string allLetters)
        {
            return minLetter > 0 || _minLetterNumbers >= 4 ? allLetters : string.Empty;
        }

    }
}
