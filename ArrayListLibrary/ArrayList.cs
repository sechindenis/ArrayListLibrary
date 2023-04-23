namespace ArrayListLibrary
{
    public class ArrayList
    {
        private int[] _array;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[2];
            _array[0] = value;
        }

        public ArrayList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            Length = values.Length;
            _array = values;
            UpSize();
        }

        public int Length { get; private set; }

        // 1. Adding a value to the end
        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            
            _array[Length] = value;
            Length++;
        }

        // 2. Adding an array of values to the end
        public void Add(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }
            
            int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

            if (_array.Length < requiredLength)
            {
                ChangeLength(requiredLength);
            }

            InsertArrayAtIndex(Length, values);
            Length += values.Length;
        }

        // 3. Inserting a value by index (to the beginning - by index 0)
        public void InsertAt(int index, int value)
        {
            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                if (Length == _array.Length)
                {
                    UpSize();
                }

                MoveRightFromIndexByNumber(index, 1);
                _array[index] = value;
                Length++;
            }
            else
            {
                Length = 1;

                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                _array[index] = value;
            }
        }

        // 4. Inserting an array of values by index (to the beginning - by index 0)
        public void InsertAt(int index, int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

                if (_array.Length < requiredLength)
                {
                    ChangeLength(requiredLength);
                }

                MoveRightFromIndexByNumber(index, values.Length);
                InsertArrayAtIndex(index, values);
                Length += values.Length;
            }
            else
            {
                if (index != 0)
                {
                    throw new IndexOutOfRangeException("index");
                }

                Length = values.Length;
                int requiredLength = (int)((Length + values.Length) * 1.33d + 1);

                if (_array.Length < requiredLength)
                {
                    ChangeLength(requiredLength);
                }

                InsertArrayAtIndex(index, values);
            }
        }

        // 5. Removing one element from the end
        public bool Remove()
        {
            if (Length == 0)
            {
                return false;
            }

            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 6. Removing N elements from the end
        public bool Remove(int number)
        {
            if (number < 0 || number > Length)
            {
                //throw new ArgumentOutOfRangeException("number > Length");
                return false;
            }

            if (Length == 0)
            {
                return false;
            }

            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 7. Removing one element by index (in the beginning - by index 0)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            MoveLeftFromIndexByNumber(index + 1, 1);
            Length--;

            if (Length == _array.Length / 2 - 1)
            {
                DownSize();
            }

            return true;
        }

        // 8. Removing N elements by index (in the beginning - by index 0)
        public bool RemoveAt(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            if (number > Length - index || number < 1)
            {
                return false;
            }

            MoveLeftFromIndexByNumber(index + number, number);
            Length -= number;

            if (Length <= _array.Length / 2 - 1)
            {
                int newLength = (int)(Length * 1.33d + 1);
                ChangeLength(newLength);
            }

            return true;
        }

        // 9. The first index by value
        public int GetIndexByValue(int value)
        {
            int index = -1;
            int i = 0;

            while (i < Length)
            {
                if (_array[i] == value)
                {
                    index = i; 
                    break;
                }

                i++;
            }

            return index;
        }

        // 10. Reverse
        public void Reverse()
        {
            int i = 0;

            while (i < Length / 2)
            {
                int tmp = _array[i];
                _array[i] = _array[Length - 1 - i];
                _array[Length - 1 - i] = tmp;
                i++;
            }
        }

        // 11. Search for the maximum value
        public int FindMaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }
            
            int maxValue = _array[0];
            int i = 1;

            while (i < Length)
            { 
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                }

                i++;
            }

            return maxValue;
        }

        // 12. Search for the minimum value
        public int FindMinValue()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            int minValue = _array[0];
            int i = 1;

            while (i < Length)
            { 
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                }

                i++;
            }

            return minValue;
        }

        // 13. Search for the index of the maximum value
        public int FindMaxValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            int maxIndex = 0;
            int i = 1;

            while (i < Length)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }

                i++;
            }

            return maxIndex;
        }

        // 14. Search for the index of the minimum value
        public int FindMinValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("ArrayList object is empty");
            }

            int minIndex = 0;
            int i = 1;

            while (i < Length)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }

                i++;
            }

            return minIndex;
        }

        // 15. Up Sort
        // up sort bubble
        public void UpSortBubble()
        {
            int i = 0;

            while (i < Length)
            {
                int j = Length - 1;

                while (j > i)
                {
                    if (_array[i] > _array[j])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }

                    j--;
                }

                i++;
            }
        }

        // up sort insertions
        public void UpSortInsertions()
        {
            int tmp;
            int i = 1;

            while (i < Length)
            {
                int j = i - 1;
                tmp = _array[i];

                while (j >= 0 && _array[j] > tmp)
                {
                    _array[j + 1] = _array[j];
                    _array[j] = tmp;
                    j--;
                }

                i++;
            }
        }

        // 16. Down Sort
        public void DownSort()
        {
            int i = 0;

            while (i < Length)
            {
                int j = Length - 1;

                while (j > i)
                {
                    if (_array[i] < _array[j])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }

                    j--;
                }

                i++;
            }
        }

        // 21. Removing the first one with a value
        public int RemoveFirstWithValue(int value)
        {
            int index = -1;
            int i = 0;

            while (i < Length)
            {
                if (_array[i] == value)
                {
                    index = i;
                    MoveLeftFromIndexByNumber(index + 1, 1);
                    Length--;
                    break;
                }

                i++;
            }

            return index;
        }

        // 22. Removing each with a value
        public int RemoveAllWithValue(int value)
        {
            int[] tmp = new int[0];
            int count = 0;
            int i = 0;

            while (i < Length)
            {
                if (_array[i] == value)
                {
                    count++;
                }
                else
                {
                    Array.Resize<int>(ref tmp, tmp.Length + 1);
                    tmp[tmp.Length - 1] = _array[i];
                }

                i++;
            }

            _array = tmp;
            Length -= count;

            return count;
        }

        // Overriding standard methods
        public override bool Equals(object? obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }

            int i = 0;
 
            while (i < Length)
            {
                if (_array[i] != arrayList._array[i])
                {
                    return false;
                }

                i++;
            }

            return true;
        }

        public override string ToString()
        {
            string s = string.Empty; ;
            int i = 0;

            while (i < Length)
            {
                s += string.Concat(_array[i].ToString(), " ");
                i++;
            }

            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Privates
        private void ChangeLength(int newLength)
        {
            int[] tmpArray = new int[newLength];
            int i = 0;

            while (i < Length)
            {
                tmpArray[i] = _array[i];
                i++;
            }

            _array = tmpArray;
        }

        private void UpSize()
        {
            int newLength = (int)(_array.Length * 1.33d + 1);
            ChangeLength(newLength);
        }

        private void DownSize()
        {
            int newLength = (int)(_array.Length * 0.67d);
            ChangeLength(newLength);
        }

        private void MoveRightFromIndexByNumber(int index, int number)
        {
            int i = Length - 1;

            while (i >= index)
            {
                _array[i + number] = _array[i];
                i--;
            }
        }

        private void MoveLeftFromIndexByNumber(int index, int number)
        {
            int i = index;

            while (i < Length)
            {
                _array[i - number] = _array[i];
                i++;
            }
        }

        private void InsertArrayAtIndex(int index, int[] values)
        {
            int i = 0;

            while (i < values.Length)
            {
                _array[i + index] = values[i];
                i++;
            }
        }

        public int[] GetIntArray()
        {
            int[] ints = _array;
            Array.Resize(ref ints, Length);            
            
            return ints;
        }
    }
}