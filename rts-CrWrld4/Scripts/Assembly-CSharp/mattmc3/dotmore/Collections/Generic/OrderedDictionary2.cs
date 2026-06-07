using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace mattmc3.dotmore.Collections.Generic
{
	public class OrderedDictionary2<TKey, TValue> : IOrderedDictionary<TKey, TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IOrderedDictionary, ICollection, IDictionary
	{
		private KeyedCollection2<TKey, KeyValuePair<TKey, TValue>> _keyedCollection;

		public TValue Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public TValue Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public int Count => 0;

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public IEqualityComparer<TKey> Comparer { get; private set; }

		ICollection<TKey> IDictionary<TKey, TValue>.Keys => null;

		ICollection<TValue> IDictionary<TKey, TValue>.Values => null;

		TValue IDictionary<TKey, TValue>.Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		int ICollection<KeyValuePair<TKey, TValue>>.Count => 0;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		object IOrderedDictionary.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => null;

		ICollection IDictionary.Values => null;

		object IDictionary.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		int ICollection.Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public OrderedDictionary2()
		{
		}

		public OrderedDictionary2(IEqualityComparer<TKey> comparer)
		{
		}

		public OrderedDictionary2(IOrderedDictionary<TKey, TValue> dictionary)
		{
		}

		public OrderedDictionary2(IOrderedDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
		}

		public OrderedDictionary2(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
		}

		public OrderedDictionary2(IEnumerable<KeyValuePair<TKey, TValue>> items, IEqualityComparer<TKey> comparer)
		{
		}

		private void Initialize(IEqualityComparer<TKey> comparer = null)
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Clear()
		{
		}

		public void Insert(int index, TKey key, TValue value)
		{
		}

		public int IndexOf(TKey key)
		{
			return 0;
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public bool ContainsValue(TValue value, IEqualityComparer<TValue> comparer)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public KeyValuePair<TKey, TValue> GetItem(int index)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public void SetItem(int index, TValue value)
		{
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public TValue GetValue(TKey key)
		{
			return default(TValue);
		}

		public void SetValue(TKey key, TValue value)
		{
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void SortKeys()
		{
		}

		public void SortKeys(IComparer<TKey> comparer)
		{
		}

		public void SortKeys(Comparison<TKey> comparison)
		{
		}

		public void SortValues()
		{
		}

		public void SortValues(IComparer<TValue> comparer)
		{
		}

		public void SortValues(Comparison<TValue> comparison)
		{
		}

		void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
		{
		}

		bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
		{
			return false;
		}

		bool IDictionary<TKey, TValue>.Remove(TKey key)
		{
			return false;
		}

		bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Clear()
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			return null;
		}

		void IOrderedDictionary.Insert(int index, object key, object value)
		{
		}

		void IOrderedDictionary.RemoveAt(int index)
		{
		}

		void IDictionary.Add(object key, object value)
		{
		}

		void IDictionary.Clear()
		{
		}

		bool IDictionary.Contains(object key)
		{
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Remove(object key)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}
	}
}
