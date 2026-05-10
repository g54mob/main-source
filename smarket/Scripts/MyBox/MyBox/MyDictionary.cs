using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private static class PrimeHelper
		{
			private static readonly int[] Primes;

			private static bool IsPrime(int candidate)
			{
				return false;
			}

			public static int GetPrime(int min)
			{
				return 0;
			}

			public static int ExpandPrime(int oldSize)
			{
				return 0;
			}
		}

		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			private readonly MyDictionary<TKey, TValue> _dictionary;

			private readonly int _Version;

			private int _index;

			public KeyValuePair<TKey, TValue> Current { get; private set; }

			object IEnumerator.Current => null;

			internal Enumerator(MyDictionary<TKey, TValue> dictionary)
			{
				_dictionary = null;
				_Version = 0;
				_index = 0;
				Current = default(KeyValuePair<TKey, TValue>);
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
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

		public Dictionary<TKey, TValue> AsDictionary => null;

		public int Count => 0;

		public TValue this[TKey key, TValue defaultValue] => default(TValue);

		public TValue this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public bool IsReadOnly => false;

		public MyDictionary()
		{
		}

		public MyDictionary(int capacity)
		{
		}

		public MyDictionary(IEqualityComparer<TKey> comparer)
		{
		}

		public MyDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
		}

		public MyDictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public MyDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		private void Resize(int newSize, bool forceNewHashCodes)
		{
		}

		private void Resize()
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		private void Insert(TKey key, TValue value, bool add)
		{
		}

		private void Initialize(int capacity)
		{
		}

		private int FindIndex(TKey key)
		{
			return 0;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return null;
		}
	}
}
