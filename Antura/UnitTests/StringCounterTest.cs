using Antura.Files;

namespace UnitTests;

    [TestClass]
    public class StringCounterTest
    {
        private const string Text = @"
            AAASSS   
            SSSAAA kkk kkk
            SSSAAASSS  SSS ddd fff  ggg
            xxx xxx www zzz ddd sss
kkk 
kkk
            AAA
            ";

        [TestMethod]
        public void FindsMatches()
        {
            Assert.AreEqual(4, Text.CountMatches("AAA"));
            Assert.AreEqual(5, Text.CountMatches("SSS"));
            Assert.AreEqual(2, Text.CountMatches("SSSAAA"));
            Assert.AreEqual(1, Text.CountMatches("kkk kkk"));
        }

        [TestMethod]
        public void IsCaseSensitive()
        {
            Assert.AreEqual(0, Text.CountMatches("aaa"));
            Assert.AreEqual(1, Text.CountMatches("sss"));
            Assert.AreEqual(0, Text.CountMatches("sSs"));
        }
    }
