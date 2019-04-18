using System;
using System.Collections;
using System.Collections.Generic;
using Palindrome;

namespace Palindrome
{
    public class Detection
    {

        public string[] Find(string phrase, SearchOptions options)
        {
            List<string> result = new List<string>();

            WordsIterator wordsIterator =
                new WordsIterator(
                    phrase, new IteratorOptions
                    {
                        IgnoredChars = " .,",
                        Length = options.MinimumLength
                    });

            Text text = wordsIterator.First();

            while(text != null)
            {
                if (text.Short.Length >= options.MinimumLength && text.Short.IsPalindrome(options.IgnoreCase))
                {
                    result.Add(text.Full);
                    if (options.FirstOnly) break;
                }

                text = wordsIterator.Next();
            }

            return result.ToArray();
        }
    }


    public class SearchOptions
    {
        public int MinimumLength { get; set; }
        public bool IgnoreCase { get; set; }
        public bool FirstOnly { get; set; }
    }

    class IteratorOptions
    {
        public int Length { get; set; }
        public string IgnoredChars { get; set; }
    }


    public class Text
    {
        public string Full;
        public string Short;
    }


    class WordsIterator : IWordsIterator
    {
        private string text;
        private int index = 0;
        private int length = 0;
        private int textLength = 0;
        private IteratorOptions options;

        public WordsIterator(string _text, IteratorOptions _options)
        {
            index = -1;
            text = _text;
            options = _options;
            length = options.Length;
            textLength = text.Length;
        }

        public Text First()
        {
            index = 0;
            length = options.Length;
            if (index + length > textLength)
            {
                throw new Exception("The length or index is too large");
            }

            string subText = text.Substring(index, length);
            return new Text
            {
                Short = subText.RemoveIgnored(options.IgnoredChars),
                Full = subText
            };
                
        }

        public Text Next()
        {
            if (++index > textLength - length)
            {
                index = 0;
                if (++length > textLength)
                {
                    return null; // no more options
                }
            }

            string subText = text.Substring(index, length);
            return new Text
            {
                Short = subText.RemoveIgnored(options.IgnoredChars),
                Full = subText
            };
        }


    }

}
