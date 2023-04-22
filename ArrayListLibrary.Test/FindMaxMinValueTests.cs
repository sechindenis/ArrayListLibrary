namespace ArrayListLibrary.Test
{
    public class FindMaxMinValueTests
    {
        // looking for the maximum value
        // list length >= 2
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 10, 100, 1000, 10000 }, 10000)]
        [TestCase(new int[] { -1, -2, 5 }, 5)]
        [TestCase(new int[] { 1, 1, 1 }, 1)]
        [TestCase(new int[] { -1, -2, -3 }, -1)]
        [TestCase(new int[] { -10, 0, -3 }, 0)]
        public void FindMaxValueInSeveralElementsListTest(int[] ints, int expected)
        {
            ArrayList list = new ArrayList(ints);
            int actual = list.FindMaxValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FindMaxValueInOneElementListTest(int expected)
        {
            ArrayList list = new ArrayList(expected);
            int actual = list.FindMaxValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // empty list
        [Test]
        public void FindMaxValueInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMaxValue());
        }

        // looking for the minimum value
        // list length >= 2
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 10, 100, 1000, 10000 }, 10)]
        [TestCase(new int[] { -1, -2, 5 }, -2)]
        [TestCase(new int[] { 1, 1, 1 }, 1)]
        [TestCase(new int[] { -1, -2, -3 }, -3)]
        [TestCase(new int[] { 10, 0, 3 }, 0)]
        public void FindMinValueInSeveralElementsListTest(int[] ints, int expected)
        {
            ArrayList list = new ArrayList(ints);
            int actual = list.FindMinValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FindMinValueInOneElementListTest(int expected)
        {
            ArrayList list = new ArrayList(expected);
            int actual = list.FindMinValue();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // empty list
        [Test]
        public void FindMinValueInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMinValue());
        }
    }
}