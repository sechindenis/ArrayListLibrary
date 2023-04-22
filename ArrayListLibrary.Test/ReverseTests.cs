namespace ArrayListLibrary.Test
{
    public class ReverseTests
    {
        // list length >= 2
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void ReverseNotEmptyListTest(int mockParametr, int mockExpected)
        {
            ArrayList actual = new ArrayList(ReverseMock.GetMockParametr(mockParametr));
            actual.Reverse();
            ArrayList expected = new ArrayList(ReverseMock.GetMockExpected(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [Test]
        public void ReverseOneElementListTest()
        {
            ArrayList actual = new ArrayList(5);
            actual.Reverse();
            ArrayList expected = new ArrayList(5);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // empty list
        [Test]
        public void ReverseEmptyListTest()
        {
            ArrayList actual = new ArrayList();
            actual.Reverse();
            ArrayList expected = new ArrayList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public static class ReverseMock
    {
        public static int[] GetMockParametr(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 1000, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -1, -2, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -1, -2, -3 };
                    break;

                case 6:
                    parametr = new int[] { -10, 0, -3 };
                    break;

                case 7:
                    parametr = new int[] { 10, 0, 3 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpected(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 5, 4, 3, 2, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10000, 1000, 100, 10 };
                    break;

                case 3:
                    parametr = new int[] { 5, -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }
    }
}