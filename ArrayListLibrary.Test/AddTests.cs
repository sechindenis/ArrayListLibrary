namespace ArrayListLibrary.Test
{
    public class AddTests
    {
        // value to the end
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_WhenAddValueToEmptyList_ShouldAddValueToTheEnd(int value)
        {
            ArrayList actual = new ArrayList();
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_WhenAddValueToOneElementList_ShouldAddValueToTheEnd(int value)
        {
            ArrayList actual = new ArrayList(5);
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { 5, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add__WhenAddValueToSeveralElementsList_ShouldAddValueToTheEnd(int value)
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.Add(value);
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // array of values to the end
        // positive
        [Test]
        public void Add_WhenAddArrayOfValuesToEmptyList_ShouldAddArrayOfValuesToTheEnd()
        {
            ArrayList actual = new ArrayList();
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WhenAddArrayOfValuesToOneElementList_ShouldAddArrayOfValuesToTheEnd()
        {
            ArrayList actual = new ArrayList(5);
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 5, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WhenAddArrayOfValuesToSeveralElementsList_ShouldAddArrayOfValuesToTheEnd()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            actual.Add(new int[] { 4, 5, 6 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // negative
        [Test]
        public void Add_WhenAddNullArrayToEmptyList_ShouldThrowNullReferenceException()
        {
            ArrayList actual = new ArrayList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_WhenAddNullArrayToOneElementList_ShouldThrowNullReferenceException()
        {
            ArrayList actual = new ArrayList(6);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_WhenAddNullArrayToOfSeveralElementsList_ShouldThrowNullReferenceException()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }
    }
}
