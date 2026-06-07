using System.Collections;
using System.Collections.Generic;

namespace Coherence.Entities
{
	public class SortedValueMap<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable
	{
		private readonly Dictionary<K, V> dictionary;

		private readonly List<V> sortedValues;

		private readonly IComparer<V> comparer;

		private bool isSorted;

		public int Count => 0;

		public bool IsReadOnly => false;

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

		public ICollection<K> Keys => null;

		ICollection<V> IDictionary<K, V>.Values => null;

		public IReadOnlyList<V> SortedValues => null;

		public SortedValueMap(IComparer<V> comparer)
		{
		}

		public SortedValueMap(IComparer<V> comparer, IDictionary<K, V> data)
		{
		}

		public SortedValueMap(IComparer<V> comparer, int capacity)
		{
		}

		public Dictionary<K, V>.Enumerator GetEnumerator()
		{
			return default(Dictionary<K, V>.Enumerator);
		}

		IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Add(KeyValuePair<K, V> item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(KeyValuePair<K, V> item)
		{
			return false;
		}

		public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
		{
		}

		public bool Remove(KeyValuePair<K, V> item)
		{
			return false;
		}

		public void Add(K key, V value)
		{
		}

		public bool ContainsKey(K key)
		{
			return false;
		}

		public bool Remove(K key)
		{
			return false;
		}

		public bool TryGetValue(K key, out V value)
		{
			value = default(V);
			return false;
		}
	}
}
