using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private static class PrimeHelper
		{
			private static readonly int[] Primes = new int[72]
			{
				3, 7, 11, 17, 23, 29, 37, 47, 59, 71,
				89, 107, 131, 163, 197, 239, 293, 353, 431, 521,
				631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
				4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023,
				25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363,
				156437, 187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403,
				968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559,
				5999471, 7199369
			};

			private static bool IsPrime(int candidate)
			{
				if ((candidate & 1) != 0)
				{
					int num = (int)Math.Sqrt(candidate);
					for (int i = 3; i <= num; i += 2)
					{
						if (candidate % i == 0)
						{
							return false;
						}
					}
					return true;
				}
				return candidate == 2;
			}

			public static int GetPrime(int min)
			{
				if (min < 0)
				{
					throw new ArgumentException("min < 0");
				}
				for (int i = 0; i < Primes.Length; i++)
				{
					int num = Primes[i];
					if (num >= min)
					{
						return num;
					}
				}
				for (int j = min | 1; j < int.MaxValue; j += 2)
				{
					if (IsPrime(j) && (j - 1) % 101 != 0)
					{
						return j;
					}
				}
				return min;
			}

			public static int ExpandPrime(int oldSize)
			{
				int num = 2 * oldSize;
				if (num > 2146435069 && 2146435069 > oldSize)
				{
					return 2146435069;
				}
				return GetPrime(num);
			}
		}

		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private readonly MyDictionary<TKey, TValue> _dictionary;

			private readonly int _Version;

			private int _index;

			public KeyValuePair<TKey, TValue> Current { get; private set; }

			object IEnumerator.Current => Current;

			internal Enumerator(MyDictionary<TKey, TValue> dictionary)
			{
				this = default(Enumerator);
				_dictionary = dictionary;
				_Version = dictionary._version;
				Current = default(KeyValuePair<TKey, TValue>);
				_index = 0;
			}

			public bool MoveNext()
			{
				if (_Version != _dictionary._version)
				{
					throw new InvalidOperationException($"Enumerator version {_Version} != Dictionary version {_dictionary._version}");
				}
				while (_index < _dictionary._count)
				{
					if (_dictionary._hashCodes[_index] >= 0)
					{
						Current = new KeyValuePair<TKey, TValue>(_dictionary._keys[_index], _dictionary._values[_index]);
						_index++;
						return true;
					}
					_index++;
				}
				_index = _dictionary._count + 1;
				Current = default(KeyValuePair<TKey, TValue>);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (_Version != _dictionary._version)
				{
					throw new InvalidOperationException($"Enumerator version {_Version} != Dictionary version {_dictionary._version}");
				}
				_index = 0;
				Current = default(KeyValuePair<TKey, TValue>);
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		[HideInInspector]
		private int[] _buckets;

		[SerializeField]
		[HideInInspector]
		private int[] _hashCodes;

		[SerializeField]
		[HideInInspector]
		private int[] _next;

		[SerializeField]
		[HideInInspector]
		private int _count;

		[SerializeField]
		[HideInInspector]
		private int _version;

		[SerializeField]
		[HideInInspector]
		private int _freeList;

		[SerializeField]
		[HideInInspector]
		private int _freeCount;

		[SerializeField]
		[HideInInspector]
		private TKey[] _keys;

		[SerializeField]
		[HideInInspector]
		private TValue[] _values;

		private readonly IEqualityComparer<TKey> _comparer;

		public Dictionary<TKey, TValue> AsDictionary => new Dictionary<TKey, TValue>(this);

		public int Count => _count - _freeCount;

		public TValue this[TKey key, TValue defaultValue]
		{
			get
			{
				int num = FindIndex(key);
				if (num >= 0)
				{
					return _values[num];
				}
				return defaultValue;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				int num = FindIndex(key);
				if (num >= 0)
				{
					return _values[num];
				}
				throw new KeyNotFoundException(key.ToString());
			}
			set
			{
				Insert(key, value, add: false);
			}
		}

		public ICollection<TKey> Keys => _keys.Take(Count).ToArray();

		public ICollection<TValue> Values => _values.Take(Count).ToArray();

		public bool IsReadOnly => false;

		public MyDictionary()
			: this(0, (IEqualityComparer<TKey>)null)
		{
		}

		public MyDictionary(int capacity)
			: this(capacity, (IEqualityComparer<TKey>)null)
		{
		}

		public MyDictionary(IEqualityComparer<TKey> comparer)
			: this(0, comparer)
		{
		}

		public MyDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			Initialize(capacity);
			_comparer = comparer ?? EqualityComparer<TKey>.Default;
		}

		public MyDictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, (IEqualityComparer<TKey>)null)
		{
		}

		public MyDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
			: this(dictionary?.Count ?? 0, comparer)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				Add(item.Key, item.Value);
			}
		}

		public bool ContainsValue(TValue value)
		{
			if (value == null)
			{
				for (int i = 0; i < _count; i++)
				{
					if (_hashCodes[i] >= 0 && _values[i] == null)
					{
						return true;
					}
				}
			}
			else
			{
				EqualityComparer<TValue> equalityComparer = EqualityComparer<TValue>.Default;
				for (int j = 0; j < _count; j++)
				{
					if (_hashCodes[j] >= 0 && equalityComparer.Equals(_values[j], value))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return FindIndex(key) >= 0;
		}

		public void Clear()
		{
			if (_count > 0)
			{
				for (int i = 0; i < _buckets.Length; i++)
				{
					_buckets[i] = -1;
				}
				Array.Clear(_keys, 0, _count);
				Array.Clear(_values, 0, _count);
				Array.Clear(_hashCodes, 0, _count);
				Array.Clear(_next, 0, _count);
				_freeList = -1;
				_count = 0;
				_freeCount = 0;
				_version++;
			}
		}

		public void Add(TKey key, TValue value)
		{
			Insert(key, value, add: true);
		}

		private void Resize(int newSize, bool forceNewHashCodes)
		{
			int[] array = new int[newSize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			TKey[] array2 = new TKey[newSize];
			TValue[] array3 = new TValue[newSize];
			int[] array4 = new int[newSize];
			int[] array5 = new int[newSize];
			Array.Copy(_values, 0, array3, 0, _count);
			Array.Copy(_keys, 0, array2, 0, _count);
			Array.Copy(_hashCodes, 0, array4, 0, _count);
			Array.Copy(_next, 0, array5, 0, _count);
			if (forceNewHashCodes)
			{
				for (int j = 0; j < _count; j++)
				{
					if (array4[j] != -1)
					{
						array4[j] = _comparer.GetHashCode(array2[j]) & 0x7FFFFFFF;
					}
				}
			}
			for (int k = 0; k < _count; k++)
			{
				int num = array4[k] % newSize;
				array5[k] = array[num];
				array[num] = k;
			}
			_buckets = array;
			_keys = array2;
			_values = array3;
			_hashCodes = array4;
			_next = array5;
		}

		private void Resize()
		{
			Resize(PrimeHelper.ExpandPrime(_count), forceNewHashCodes: false);
		}

		public bool Remove(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			int num = _comparer.GetHashCode(key) & 0x7FFFFFFF;
			int num2 = num % _buckets.Length;
			int num3 = -1;
			for (int num4 = _buckets[num2]; num4 >= 0; num4 = _next[num4])
			{
				if (_hashCodes[num4] == num && _comparer.Equals(_keys[num4], key))
				{
					if (num3 < 0)
					{
						_buckets[num2] = _next[num4];
					}
					else
					{
						_next[num3] = _next[num4];
					}
					_hashCodes[num4] = -1;
					_next[num4] = _freeList;
					_keys[num4] = default(TKey);
					_values[num4] = default(TValue);
					_freeList = num4;
					_freeCount++;
					_version++;
					return true;
				}
				num3 = num4;
			}
			return false;
		}

		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (_buckets == null)
			{
				Initialize(0);
			}
			int num = _comparer.GetHashCode(key) & 0x7FFFFFFF;
			int num2 = num % _buckets.Length;
			for (int num3 = _buckets[num2]; num3 >= 0; num3 = _next[num3])
			{
				if (_hashCodes[num3] == num && _comparer.Equals(_keys[num3], key))
				{
					if (add)
					{
						TKey val = key;
						throw new ArgumentException("Key already exists: " + val);
					}
					_values[num3] = value;
					_version++;
					return;
				}
			}
			int num4;
			if (_freeCount > 0)
			{
				num4 = _freeList;
				_freeList = _next[num4];
				_freeCount--;
			}
			else
			{
				if (_count == _keys.Length)
				{
					Resize();
					num2 = num % _buckets.Length;
				}
				num4 = _count;
				_count++;
			}
			_hashCodes[num4] = num;
			_next[num4] = _buckets[num2];
			_keys[num4] = key;
			_values[num4] = value;
			_buckets[num2] = num4;
			_version++;
		}

		private void Initialize(int capacity)
		{
			int prime = PrimeHelper.GetPrime(capacity);
			_buckets = new int[prime];
			for (int i = 0; i < _buckets.Length; i++)
			{
				_buckets[i] = -1;
			}
			_keys = new TKey[prime];
			_values = new TValue[prime];
			_hashCodes = new int[prime];
			_next = new int[prime];
			_freeList = -1;
		}

		private int FindIndex(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (_buckets != null)
			{
				int num = _comparer.GetHashCode(key) & 0x7FFFFFFF;
				for (int num2 = _buckets[num % _buckets.Length]; num2 >= 0; num2 = _next[num2])
				{
					if (_hashCodes[num2] == num && _comparer.Equals(_keys[num2], key))
					{
						return num2;
					}
				}
			}
			return -1;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			int num = FindIndex(key);
			if (num >= 0)
			{
				value = _values[num];
				return true;
			}
			value = default(TValue);
			return false;
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			int num = FindIndex(item.Key);
			if (num >= 0)
			{
				return EqualityComparer<TValue>.Default.Equals(_values[num], item.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException($"index = {index} array.Length = {array.Length}");
			}
			if (array.Length - index < Count)
			{
				throw new ArgumentException($"The number of elements in the dictionary ({Count}) is greater than the available space from index to the end of the destination array {array.Length}.");
			}
			for (int i = 0; i < _count; i++)
			{
				if (_hashCodes[i] >= 0)
				{
					array[index++] = new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
				}
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
