using System;
using System.Collections;
using System.Collections.Generic;

namespace lab5
{
    class MyMatrix
    {
        private int _m, _n, _randA, _randB;
        private List<List<int>> _matrix = new List<List<int>>();

        public MyMatrix(int m, int n)
        {
            Console.WriteLine("Enter rand range [a, b]:\na = ");
            _randA = Int32.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            _randB = Int32.Parse(Console.ReadLine());
            var rand = new Random();
            _m = m;
            _n = n;
            for (int i = 0; i < m; ++i)
            {
                _matrix.Add(new List<int>());
                for (int j = 0; j < n; ++j)
                {
                    _matrix[i].Add(rand.Next(_randA, _randB));
                }
            }
        }

        public void Fill()
        {
            var rand = new Random();
            for (int i = 0; i < _m; ++i)
            {
                for (int j = 0; j < _n; ++j)
                {
                    _matrix[i][j] = rand.Next(_randA, _randB);
                }
            }
        }

        public void ChangeSize(int m, int n)
        {
            if (m < _m)
            {
                _matrix.RemoveRange(m, _m - m);
            }
            else if (m > _m)
            {
                var rand = new Random();
                for (int i = _m; i < m; ++i)
                {
                    _matrix.Add(new List<int>(n));
                    for (int j = 0; j < n; ++j)
                    {
                        _matrix[i][j] = rand.Next(_randA, _randB);
                    }
                }
            }
            if (n < _n)
            {
                for (int i = 0; i < _m; i++)
                {
                    _matrix[i].RemoveRange(_n, _n - n);
                }
            }
            else if (n > _n)
            {
                var rand = new Random();
                for (int i = 0; i < _m; i++)
                {
                    for (int j = _n; j < n; ++j)
                    {
                        _matrix[i].Add(rand.Next(_randA, _randB));
                    }
                }
            }
            _m = m;
            _n = n;
        }

        public void ShowPartialy(int begin_m, int end_m, int begin_n, int end_n)
        {
            for (int i = begin_m; i < end_m; ++i)
            {
                for (int j = begin_n; j < end_n; ++j)
                {
                    Console.Write(_matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            for (int i = 0; i < _m; ++i)
            {
                for (int j = 0; j < _n; ++j)
                {
                    Console.Write(_matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int this[int index1, int index2]
        {
            get
            {
                if (index1 > _m || index2 > _n || index1 < 0 || index2 < 0) throw new Exception();
                return _matrix[index1][index2];
            }
            set
            {
                if (index1 > _m || index2 > _n || index1 < 0 || index2 < 0) throw new Exception();
                _matrix[index1][index2] = value;
            }
        }
    }

    class MyList<T> : IEnumerable<T>
    {
        private T[] _values = new T[1];
        private int _capacity = 1;
        public int Size { get { return _size; } }
        private int _size = 0;

        public MyList() { }

        public MyList(int n)
        {
            while (_capacity <= n)
            {
                _capacity *= 2;
            }
            _values = new T[_capacity];
            _size = n;
        }

        public void Resize(int capacity)
        {
            T[] tmp = new T[capacity];
            for (int i = 0; i < _capacity; ++i)
            {
                tmp[i] = _values[i];
            }
            _values = tmp;
        }

        public void Add(T value)
        {
            if (_size >= _capacity)
            {
                this.Resize(_capacity * 2);
                _capacity *= 2;
            }

            _values[_size] = value;
            _size++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new Exception();
                return _values[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                    throw new Exception();
                _values[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyDictionary<TKey, TValue>
    {
        private TKey[] _keys = new TKey[1];
        private TValue[] _values = new TValue[1];
        private int _size;

        public MyDictionary() { }

        public void Add(TKey key, TValue value)
        {
            if (_size < _keys.Length)
            {
                _keys[_size] = key;
                _values[_size] = value;
                _size++;
            }
            else
            {
                int newCapacity = _keys.Length * 2;
                Array.Resize(ref _keys, newCapacity);
                Array.Resize(ref _values, newCapacity);
                Add(key, value);
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < _size; i++)
                {
                    if (object.Equals(_keys[i], key))
                    {
                        return _values[i];
                    }
                }
                throw new KeyNotFoundException("Key not found");
            }
        }

        public int Size
        {
            get { return _size; }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
