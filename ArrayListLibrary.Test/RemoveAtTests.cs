namespace ArrayListLibrary.Test
{
    public class RemoveAtTests
    {
        // removing N elements from the end
        // direct, empty list
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void RemoveAt_WhenRemoveAtIndexOutOfRangeFromEmptyList_ShouldReturnFalse(int numberOfElements, bool expected)
        {
            ArrayList list = new ArrayList();
            bool actual = list.RemoveAt(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, not empty list
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(4, true)]
        public void RemoveAt_WhenRemoveAtIndexOutOfRangeFromNotEmptyList_ShouldReturnTrue(int numberOfElements, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void RemoveAt_WhenRemoveAtIndexOutOfRangeFromNotEmptyList_ShouldReturnFalse(int numberOfElements, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left not empty 
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        public void RemoveAt_WhenRemoveAtIndexInRangeFromNotEmptyList_ShouldLeftNewSmallerList(int[] ints, int index, int[] intsLeft)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index);
            ArrayList expected = new ArrayList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6,   new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10,  new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1,  new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -10, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveAt_WhenRemoveAtIndexOutOfRangeFromNotEmptyList_ShouldLeftSameList(int[] ints, int index, int[] intsLeft)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index);
            ArrayList expected = new ArrayList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left empty
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -1 }, 0)]
        public void RemoveAt_WhenRemoveAtIndexInRangeFromOneElementList_ShouldLeftEmptyList(int[] ints, int index)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // removing N elements by index
        // direct, not empty list
        [TestCase(0, 1, true)]
        [TestCase(1, 2, true)]
        [TestCase(4, 1, true)]
        public void RemoveAt_WhenRemoveAtIndexInRangeAndNumberIsSuitableFromNotEmptyList_ShouldReturnTrue(int index, int number, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(index, number);

            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [TestCase(0, 6, false)]
        [TestCase(1, 9, false)]
        [TestCase(4, 2, false)]
        //
        [TestCase(6, 1, false)]
        [TestCase(-1, 1, false)]
        [TestCase(-100, 1, false)]
        //
        [TestCase(6, 10, false)]
        [TestCase(-1, 10, false)]
        [TestCase(-100, 10, false)]
        public void RemoveAt_WhenRemoveAtIndexOutRangeOrNumberIsNotSuitableFromNotEmptyList_ShouldReturnFalse(int index, int number, bool expected)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.RemoveAt(index, number);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left not empty
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 1, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 2, new int[] { 1, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 1, new int[] { 1, 2, 3, 4 })]
        public void RemoveAt_WhenRemoveAtIndexInRangeAndNumberIsSuitableFromNotEmptyList_ShouldLeftNewSmallerList(int[] ints, int index, int n, int[] intsLeft)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index, n);
            ArrayList expected = new ArrayList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, 1, new int[] { 1, 2, 3, 4, 5 })]
        //
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 6,  new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, -3, new int[] { 1, 2, 3, 4, 5 })]
        //
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -4, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 8, -5,  new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveAt_WhenRemoveAtIndexOutOfRangeOrNumberIsNotSuitableFromNotEmptyList_ShouldLeftSameList(int[] ints, int index, int n, int[] intsLeft)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index, n);
            ArrayList expected = new ArrayList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left empty
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void RemoveAt_RemovesNumberOfElementsAtIndexFromNotEmptyList_NewEmptyList_Test(int[] ints, int index, int n)
        {
            ArrayList actual = new ArrayList(ints);
            actual.RemoveAt(index, n);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}