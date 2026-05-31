using System;
using System.Collections;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class NonAllocDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
	{
		public struct KeyIterator : IEnumerator<K>, IEnumerator, IDisposable
		{
			private int _index;

			private NonAllocDictionary<K, V> _dict;

			object IEnumerator.Current => null;

			public K Current => default(K);

			public KeyIterator(NonAllocDictionary<K, V> dictionary)
			{
				_index = 0;
				_dict = null;
			}

			public KeyIterator GetEnumerator()
			{
				return default(KeyIterator);
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}
		}

		public struct ValueIterator : IEnumerator<V>, IEnumerator, IDisposable
		{
			private int _index;

			private NonAllocDictionary<K, V> _dict;

			public V Current => default(V);

			object IEnumerator.Current => null;

			public ValueIterator(NonAllocDictionary<K, V> dictionary)
			{
				_index = 0;
				_dict = null;
			}

			public ValueIterator GetEnumerator()
			{
				return default(ValueIterator);
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}
		}

		public struct PairIterator : IEnumerator<KeyValuePair<K, V>>, IEnumerator, IDisposable
		{
			private int _index;

			private NonAllocDictionary<K, V> _dict;

			object IEnumerator.Current => null;

			public KeyValuePair<K, V> Current => default(KeyValuePair<K, V>);

			public PairIterator(NonAllocDictionary<K, V> dictionary)
			{
				_index = 0;
				_dict = null;
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}
		}

		private struct Node
		{
			public bool Used;

			public int Next;

			public uint Hash;

			public K Key;

			public V Val;
		}

		private static uint[] _primeTableUInt;

		private int _freeHead;

		private int _freeCount;

		private int _usedCount;

		private uint _capacity;

		private int[] _buckets;

		private Node[] _nodes;

		private bool isReadOnly;

		private ICollection<K> keys;

		private ICollection<V> values;

		public KeyIterator Keys => default(KeyIterator);

		ICollection<V> IDictionary<K, V>.Values => null;

		ICollection<K> IDictionary<K, V>.Keys => null;

		public ValueIterator Values => default(ValueIterator);

		public int Count => 0;

		public bool IsReadOnly => false;

		public uint Capacity => 0u;

		public V this[K key]
		{
			get
			{
				return default(V);
			}
			set
			{
			}
		}

		public NonAllocDictionary(uint capacity = 29u)
		{
		}

		public bool ContainsKey(K key)
		{
			return false;
		}

		public bool Contains(KeyValuePair<K, V> item)
		{
			return false;
		}

		public bool TryGetValue(K key, out V val)
		{
			val = default(V);
			return false;
		}

		public void Set(K key, V val)
		{
		}

		public void Add(K key, V val)
		{
		}

		public void Add(KeyValuePair<K, V> item)
		{
		}

		public bool Remove(K key)
		{
			return false;
		}

		public bool Remove(KeyValuePair<K, V> item)
		{
			return false;
		}

		IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
		{
			return null;
		}

		public PairIterator GetEnumerator()
		{
			return default(PairIterator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private int FindNode(K key)
		{
			return 0;
		}

		private void Insert(K key, V val)
		{
		}

		private void Expand()
		{
		}

		public void Clear()
		{
		}

		void ICollection<KeyValuePair<K, V>>.CopyTo(KeyValuePair<K, V>[] array, int index)
		{
		}

		private static bool IsPrimeFromList(uint value)
		{
			return false;
		}

		private static uint GetNextPrime(uint value)
		{
			return 0u;
		}

		private static void Assert(bool condition)
		{
		}
	}
}
