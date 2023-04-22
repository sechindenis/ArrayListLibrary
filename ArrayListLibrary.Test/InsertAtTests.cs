namespace ArrayListLibrary.Test
{
    public class InsertAtTests
    {
        // inserting value at index
        // positive (index in range)
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void InsertAt_WhenIndexInRangeAndEmptyList_ShouldInsertValueAtIndex(int value)
        {
            ArrayList actual = new ArrayList();
            actual.InsertAt(0, value);
            ArrayList expected = new ArrayList(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void InsertAt_WhenIndexInRangeAndOneElementList_ShouldInsertValueAtIndex(int value)
        {
            ArrayList actual = new ArrayList(5);
            actual.InsertAt(0, value);
            ArrayList expected = new ArrayList(new int[] { value, 5 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void InsertAt_WhenIndexInRangeAndSeveralElementsList_ShouldInsertValueAtIndex(int index, int value)
        {
            List<int> ints = new List<int> { 1, 2, 3 };
            ArrayList actual = new ArrayList(ints.ToArray());
            actual.InsertAt(index, value);
            ints.Insert(index, value);
            ArrayList expected = new ArrayList(ints.ToArray());

            Assert.That(actual, Is.EqualTo(expected));
        }

        // negative
        // index out of range
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndEmptyList_ShouldThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList();

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndOneElementList_ShouldThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList(5);

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndSeveralElementsList_ShouldThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, 1));
        }

        // inserting array of values at index
        // positive (index is in range and array of values is NOT null)
        [Test]
        public void InsertAt_WhenIndexInRangeAndArrayIsNotNullAndEmptyList_ShouldInsertArrayAtIndex()
        {
            ArrayList actual = new ArrayList();
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void InsertAt_WhenIndexInRangeAndArrayIsNotNullAndOneElementList_ShouldInsertArrayAtIndex()
        {
            ArrayList actual = new ArrayList(5);
            actual.InsertAt(0, new int[] { 1, 2, 3 });
            ArrayList expected = new ArrayList(new int[] { 1, 2, 3, 5 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void InsertAt_WhenIndexInRangeAndArrayIsNotNullAndSeveralElementsList_ShouldInsertArrayAtIndex(int index)
        {
            List<int> ints = new List<int> { 1, 2, 3 };
            ArrayList actual = new ArrayList(ints.ToArray());
            actual.InsertAt(index, new int[] { 5, 6, 7 });
            ints.InsertRange(index, new int[] { 5, 6, 7 });
            ArrayList expected = new ArrayList(ints.ToArray());

            Assert.That(actual, Is.EqualTo(expected));
        }

        // negative
        // index is OUT of range, BUT array of values is NOT null, tests for IndexOutOfRangeException
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndEmptyList_ThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndOneElementList_ThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndSeveralElementsList_ThrowIndexOutOfRangeException(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = new int[] { 1, 2, 3 };

            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(index, ints));
        }

        // negative
        // index is IN range, BUT array of values is null, tests for NullReferenceException
        [Test]
        public void InsertAt_WhenArrayIsNullAndEmptyList_ShouldThrowNullReferenceException()
        {
            ArrayList list = new ArrayList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        [Test]
        public void InsertAt_WhenArrayIsNullAndOneElementList_ShouldThrowNullReferenceException()
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        [Test]
        public void InsertAt_WhenArrayIsNullAndSeveralElementsList_ShouldThrowNullReferenceException()
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(0, ints));
        }

        // negative
        // index is OUT of range, AND array of values is null, tests for NullReferenceException
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndArrayIsNullAndEmptyList_ThrowNullReferenceException(int index)
        {
            ArrayList list = new ArrayList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndArrayIsNullAndOneElementList_ThrowNullReferenceException(int index)
        {
            ArrayList list = new ArrayList(5);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(index, ints));
        }

        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(50)]
        public void InsertAt_WhenIndexOutOfRangeAndArrayIsNullAndSeveralElementsList_ThrowNullReferenceException(int index)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => list.InsertAt(index, ints));
        }
    }
}