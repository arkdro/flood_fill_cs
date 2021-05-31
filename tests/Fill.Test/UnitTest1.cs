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
            var new_data = f.fill(data, 1, 1, 14, 21);
            var expected = new int[,] {{11,12}, {11,21}, {11,11}, {17,11}};
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], new_data[y, x], $"expected: {expected[y, x]}, actual: {new_data[y, x]}, x: {x}, y: {y}");
                }
            }
        }

        [Test]
        public void FillTest02_fill_small_region()
        {
            var f = new Fill();
            var data = new int[,] {
                {11, 10, 11, 11},
                {11, 10, 13, 11},
                {11, 11, 11, 11},
                {12, 17, 17, 14},
                {12, 12, 11, 11}
            };
            var new_data = f.fill(input: data, start_x: 2, start_y: 4, target_color: 11, replacement_color: 21);
            var expected = new int[,] {
                {11, 10, 11, 11},
                {11, 10, 13, 11},
                {11, 11, 11, 11},
                {12, 17, 17, 14},
                {12, 12, 21, 21}
            };
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], new_data[y, x], $"expected: {expected[y, x]}, actual: {new_data[y, x]}, x: {x}, y: {y}");
                }
            }
        }

        [Test]
        public void FillTest03_fill_big_region()
        {
            var f = new Fill();
            var data = new int[,] {
                {11, 10, 11, 11},
                {11, 10, 13, 11},
                {11, 11, 11, 11},
                {12, 17, 17, 14},
                {12, 12, 11, 11}
            };
            var new_data = f.fill(input: data, start_x: 2, start_y: 0, target_color: 11, replacement_color: 21);
            var expected = new int[,] {
                {21, 10, 21, 21},
                {21, 10, 13, 21},
                {21, 21, 21, 21},
                {12, 17, 17, 14},
                {12, 12, 11, 11}
            };
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], new_data[y, x], $"expected: {expected[y, x]}, actual: {new_data[y, x]}, x: {x}, y: {y}");
                }
            }
        }

        [Test]
        public void FillTest04_fill_region()
        {
            var f = new Fill();
            var data = new int[,] {
                {11, 10, 11, 11, 11, 11, 11, 10},
                {11, 10, 11, 13, 13, 10, 11, 11},
                {11, 10, 11, 13, 11, 11, 10, 11},
                {11, 10, 11, 13, 13, 11, 10, 11},
                {11, 10, 11, 11, 11, 11, 10, 11},
                {11, 11, 17, 12, 12, 17, 17, 11},
                {12, 11, 11, 11, 11, 11, 11, 11}
            };
            var new_data = f.fill(input: data, start_x: 2, start_y: 0, target_color: 11, replacement_color: 21);
            var expected = new int[,] {
                {21, 10, 21, 21, 21, 21, 21, 10},
                {21, 10, 21, 13, 13, 10, 21, 21},
                {21, 10, 21, 13, 21, 21, 10, 21},
                {21, 10, 21, 13, 13, 21, 10, 21},
                {21, 10, 21, 21, 21, 21, 10, 21},
                {21, 21, 17, 12, 12, 17, 17, 21},
                {12, 21, 21, 21, 21, 21, 21, 21}
            };
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], new_data[y, x], $"expected: {expected[y, x]}, actual: {new_data[y, x]}, x: {x}, y: {y}");
                }
            }
        }

        [Test]
        public void extract_result_test()
        {
            var f = new Fill();
            var data = new Point[,] {
                {new Point(state:State.New, color: 11), new Point(state:State.New, color: 12)},
                {new Point(state:State.New, color: 11), new Point(state:State.New, color: 14)},
                {new Point(state:State.New, color: 11), new Point(state:State.New, color: 11)},
                {new Point(state:State.New, color: 17), new Point(state:State.New, color: 11)},
            };
            var extracted = f.extract_result(data);
            var expected = new int[,] {{11,12}, {11,14}, {11,11}, {17,11}};
            int height = data.GetLength(0);
            int width = data.GetLength(1);
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Assert.AreEqual(expected[y, x], extracted[y, x]);
                }
            }
        }
    }
}
