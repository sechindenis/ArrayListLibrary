namespace ArrayListLibrary.Test
{
    public class RemoveFirstWithValue
    {
        // direct, list length > 1
        [TestCase(1, 0)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        [TestCase(4, 0)]
        [TestCase(5, -1)]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInSeveralElementsList_ShouldReturnIndex(int value, int expected)
        {
            ArrayList list = new ArrayList(RemoveFirstWithValueMock.GetMockParametrForRemoveFirstByValue(value));
            int actual = list.RemoveFirstWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, list length = 1
        [TestCase(2, 2, 0)]
        [TestCase(-1, -1, 0)]
        [TestCase(0, 0, 0)]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInOneElementList_ShouldReturnZero(int value, int parametr, int expected)
        {
            ArrayList list = new ArrayList(value);
            int actual = list.RemoveFirstWithValue(parametr);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 0, -1)]
        [TestCase(-1, 1, -1)]
        [TestCase(0, 1, -1)]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInOneElementList_ShouldReturnMinusOne(int value, int parametr, int expected)
        {
            ArrayList list = new ArrayList(value);
            int actual = list.RemoveFirstWithValue(parametr);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, empty list
        [TestCase(1, -1)]
        [TestCase(2, -1)]
        [TestCase(-3, -1)]
        [TestCase(0, -1)]
        [TestCase(-100, -1)]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInEmptyList_ShouldReturnMinusOne(int value, int expected)
        {
            ArrayList list = new ArrayList();
            int actual = list.RemoveFirstWithValue(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, not empty list in and out
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInSeveralElementsList_ShouldLeftNewNotEmptyList(int value)
        {
            ArrayList actual = new ArrayList(RemoveFirstWithValueMock.GetMockParametrForRemoveFirstByValue(value));
            actual.RemoveFirstWithValue(value);
            ArrayList expected = new ArrayList(RemoveFirstWithValueMock.GetMockExpectedForRemoveFirstByValue(value));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, not empty list in, empty list out
        [Test]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInNotEmptyList_SouldLeftEmptyList()
        {
            ArrayList actual = new ArrayList(new int[] { 1 });
            actual.RemoveFirstWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, empty list in and out
        [Test]
        public void RemoveFirstWithValue_WhenRemoveFirstWithValueInEmptyList_ShouldLeftEmptyList()
        {
            ArrayList actual = new ArrayList();
            actual.RemoveFirstWithValue(1);
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public static class RemoveFirstWithValueMock
    {
        public static int[] GetMockParametrForRemoveFirstByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 2, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1, 3 };
                    break;

                case 4:
                    parametr = new int[] { 4, 4, 4 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForRemoveFirstByValue(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 4, 4 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }
    }
}