using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeUnitTest
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void Test_IsPalindrome_ABBA()
        {
            Assert.AreEqual(true, "ABBA".IsPalindrome());
        }

        [TestMethod]
        public void Test_IsPalindrome_ABBa()
        {
            Assert.AreEqual(true, "ABBa".IsPalindrome(ignoreCase: true));
        }

        [TestMethod]
        public void Test_IsPalindrome_ABaBA()
        {
            Assert.AreEqual(true, "ABaBa".IsPalindrome(ignoreCase: true));
        }

        [TestMethod]
        public void Test_IsPalindrome_ABA()
        {
            Assert.AreEqual(true, "ABA".IsPalindrome());
        }

        [TestMethod]
        public void Test_IsPalindrome_ABAB()
        {
            Assert.AreEqual(false, "ABAB".IsPalindrome());
        }

        [TestMethod]
        public void Test_IsPalindrome_ch()
        {
            Assert.AreEqual(false, "÷, ".IsPalindrome());
        }

    }
}
