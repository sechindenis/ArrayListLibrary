namespace ArrayListLibrary.Test
{
    public class RemoveAllWithValue
    { 
        // direct, list length > 0
        [TestCase(1, 3)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        public void RemoveAllWithValue_WhenRemoveAllWithValueInNotEmptyList_ShouldReturnAmount(int value, int expected)
        {
            ArrayList list = new ArrayList(RemoveAllWithValueMock.GetMockParametrForRemoveAllByValue(value));
            int actual = list.RemoveAllWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        //  direct, empty list
        [Test]
        public void RemoveAllWithValue_WhenRemoveAllWithValueInEmptyList_ShouldReturnZero()
        {
            ArrayList list = new ArrayList();
            int actual = list.RemoveAllWithValue(1);

            Assert.That(actual, Is.EqualTo(0));
        }

        // indirect, not empty list in and out
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 6)]
        public void RemoveAllWithValue_WhenRemoveAllWithValueInNotEmptyList_ShouldLeftNewNotEmptyList(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(RemoveAllWithValueMock.GetMockParametrForRemoveAllByValue(mockParametr));
            actual.RemoveAllWithValue(mockParametr);
            ArrayList expected = new ArrayList(RemoveAllWithValueMock.GetMockExpectedForRemoveAllByValue(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, not empty list in, empty list out
        [Test]
        public void RemoveAllWithValue_WhenRemoveAllWithValueInNotEmptyList_ShouldLeftNewEmptyList_Test()
        {
            ArrayList actual = new ArrayList(new int[] { 1, 1, 1, 1 });
            actual.RemoveAllWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, empty list in and out
        [Test]
        public void RemoveAllWithValue_WhenRemoveAllWithValueInEmptyList_ShouldLeftNewEmptyList_Test()
        {
            ArrayList actual = new ArrayList();
            actual.RemoveAllWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public static class RemoveAllWithValueMock
    {
        public static int[] GetMockParametrForRemoveAllByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 1, 4, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 2, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, 3, 3 };
                    break;

                case 4:
                    parametr = new int[] { 0, 0, 0 };
                    break;

                case 5:
                    parametr = new int[] { 9, 5, 7, 5, 2, 5, 3, 5, 2 };
                    break;

                case 6:
                    parametr = new int[] { 9, 6, 7, 6, 2, 6, 3, 6, 6 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForRemoveAllByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 2, 4 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2 };
                    break;

                case 5:
                    parametr = new int[] { 9, 7, 2, 3, 2 };
                    break;

                case 6:
                    parametr = new int[] { 9, 7, 2, 3 };
                    break;
            }

            return parametr;
        }
    }
}