namespace ArrayListLibrary.Test
{
    public class FindMaxMinValueIndexTests
    {
        // looking for the maximum value index
        // list length >= 2
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 10, 100, 100000, 100 }, 2)]
        [TestCase(new int[] { -1, -2, 5 }, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 0)]
        [TestCase(new int[] { -10, -2, -3 }, 1)]
        [TestCase(new int[] { -10, 0, -3 }, 1)]
        public void FindMaxValueIndexISeveralElementsListTest(int[] ints, int expected)
        {
            ArrayList list = new ArrayList(ints);
            int actual = list.FindMaxValueIndex();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FindMaxValueIndexInSeveralElementsListTest(int number)
        {
            ArrayList list = new ArrayList(number);
            int actual = list.FindMaxValueIndex();

            Assert.That(actual, Is.EqualTo(0));
        }

        // empty list
        [Test]
        public void FindMaxValueIndexInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMaxValueIndex());
        }

        // looking for the minimum value index
        // list length >= 2
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1000, 100, 1000, 10000 }, 1)]
        [TestCase(new int[] { -1, -2, -5 }, 2)]
        [TestCase(new int[] { 1, 1, 1 }, 0)]
        [TestCase(new int[] { -1, -2, -3 }, 2)]
        [TestCase(new int[] { 10, 0, 3 }, 1)]
        public void FindMinValueIndexInSeveralElementsListTest(int[] ints, int expected)
        {
            ArrayList list = new ArrayList(ints);
            int actual = list.FindMinValueIndex();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void FindMinValueIndexInOneElementListTest(int number)
        {
            ArrayList list = new ArrayList(number);
            int actual = list.FindMinValueIndex();

            Assert.That(actual, Is.EqualTo(0));
        }

        // empty list
        [Test]
        public void FindMinValueIndexInEmptyListTest()
        {
            ArrayList list = new ArrayList();

            Assert.Throws<Exception>(() => list.FindMinValueIndex());
        }
    }
}