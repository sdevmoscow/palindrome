using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrome
{
    public static class Extensions
    {
        public static string RemoveIgnored(this string s, string ignoredChars)
        {
            foreach (char c in ignoredChars)
            {
                s = s.Replace(c.ToString(), "");
            }

            return s;
        }

        public static bool IsPalindrome(this string s, bool ignoreCase = false)
        {
            int len = s.Length;
            for (int i = 0; i < len / 2; i++)
            {
                if (ignoreCase)
                {
                    if (char.ToLower(s[i]) != char.ToLower(s[len - i - 1])) return false;
                }
                else
                {
                    if (s[i] != s[len - i - 1]) return false;
                }
            }

            return true;
        }

        
    }
}
