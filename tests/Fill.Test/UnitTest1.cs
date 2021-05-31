using NUnit.Framework;

using System;

using Fill;

namespace Fill.Test
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

        [Test]
        public void FillTest01()
        {
            var f = new Fill();
            var data = new int[,] {{11,12}, {11,14}, {11,11}, {17,11}};
            var new_data = f.fill(data, 0, 1, 14, 21);
            var expected = new int[,] {{11,12}, {11,21}, {11,11}, {17,11}};
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], new_data[y, x]);
                }
            }
        }
    }
}
