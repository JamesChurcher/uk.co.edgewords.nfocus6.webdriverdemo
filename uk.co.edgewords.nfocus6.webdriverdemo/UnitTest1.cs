namespace uk.co.edgewords.nfocus6.webdriverdemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test, Category("BadTest")]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}