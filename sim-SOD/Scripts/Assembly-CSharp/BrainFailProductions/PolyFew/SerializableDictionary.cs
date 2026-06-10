using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace BrainFailProductions.PolyFew
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private static class PrimeHelper
		{
			public static readonly int[] Primes;

			public static bool IsPrime(int candidate)
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
			private readonly SerializableDictionary<TKey, TValue> _Dictionary;

			private int _Version;

			private int _Index;

			private KeyValuePair<TKey, TValue> _Current;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			internal Enumerator(SerializableDictionary<TKey, TValue> dictionary)
			{
				_Dictionary = null;
				_Version = 0;
				_Index = 0;
				_Current = default(KeyValuePair<TKey, TValue>);
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

		[HideInInspector]
		[SerializeField]
		private int[] _Buckets;

		[SerializeField]
		[HideInInspector]
		private int[] _HashCodes;

		[SerializeField]
		[HideInInspector]
		private int[] _Next;

		[SerializeField]
		[HideInInspector]
		private int _Count;

		[SerializeField]
		[HideInInspector]
		private int _Version;

		[HideInInspector]
		[SerializeField]
		private int _FreeList;

		[HideInInspector]
		[SerializeField]
		private int _FreeCount;

		[SerializeField]
		[HideInInspector]
		private TKey[] _Keys;

		[SerializeField]
		[HideInInspector]
		private TValue[] _Values;

		private readonly IEqualityComparer<TKey> _Comparer;

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

		public SerializableDictionary()
		{
		}

		public SerializableDictionary(int capacity)
		{
		}

		public SerializableDictionary(IEqualityComparer<TKey> comparer)
		{
		}

		public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
		}

		public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public SerializableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
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
