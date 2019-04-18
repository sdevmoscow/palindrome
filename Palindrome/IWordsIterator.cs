using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrome
{
    public interface IWordsIterator
    {
        Text First();
        Text Next();
    }
}
