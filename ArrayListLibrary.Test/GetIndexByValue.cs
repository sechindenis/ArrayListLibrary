namespace ArrayListLibrary.Test
{
    public class GetIndexByValue
    {
        // getting the first index by value
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(5, 4)]
        [TestCase(10, -1)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void GetIndexByValueTest(int value, int expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            int actual = list.GetIndexByValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(1, -1)]
        public void GetIndexByValueEmptyListTest(int value, int expected)
        {
            ArrayList list = new ArrayList();
            int actual = list.GetIndexByValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}