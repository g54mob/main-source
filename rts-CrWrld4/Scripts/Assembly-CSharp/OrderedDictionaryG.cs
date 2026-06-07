using System;
using System.Collections;
using System.Collections.Generic;

public class OrderedDictionaryG<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable
	{
		public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
		{
			private LinkedListNode<KeyValuePair<TKey, TValue>> current;

			private KeyCollection parent;

			public TKey Current => default(TKey);

			object IEnumerator.Current => null;

			internal Enumerator(KeyCollection parent)
			{
				current = null;
				this.parent = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private OrderedDictionaryG<TKey, TValue> parent;

		public int Count => 0;

		bool ICollection<TKey>.IsReadOnly => false;

		internal KeyCollection(OrderedDictionaryG<TKey, TValue> parent)
		{
		}

		public void CopyTo(TKey[] array, int arrayIndex)
		{
		}

		public IEnumerator<TKey> GetEnumerator()
		{
			return null;
		}

		void ICollection<TKey>.Add(TKey item)
		{
		}

		void ICollection<TKey>.Clear()
		{
		}

		bool ICollection<TKey>.Contains(TKey item)
		{
			return false;
		}

		bool ICollection<TKey>.Remove(TKey item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable
	{
		public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
		{
			private LinkedListNode<KeyValuePair<TKey, TValue>> current;

			private ValueCollection parent;

			public TValue Current => default(TValue);

			object IEnumerator.Current => null;

			internal Enumerator(ValueCollection parent)
			{
				current = null;
				this.parent = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private OrderedDictionaryG<TKey, TValue> parent;

		public int Count => 0;

		bool ICollection<TValue>.IsReadOnly => false;

		internal ValueCollection(OrderedDictionaryG<TKey, TValue> parent)
		{
		}

		public void CopyTo(TValue[] array, int arrayIndex)
		{
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return null;
		}

		void ICollection<TValue>.Add(TValue item)
		{
		}

		void ICollection<TValue>.Clear()
		{
		}

		bool ICollection<TValue>.Contains(TValue item)
		{
			return false;
		}

		bool ICollection<TValue>.Remove(TValue item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> mDictionary;

	private LinkedList<KeyValuePair<TKey, TValue>> mLinkedList;

	private ValueCollection valueCollection;

	private KeyCollection keyCollection;

	public ICollection<TKey> Keys => null;

	public ICollection<TValue> Values => null;

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

	public bool IsReadOnly => false;

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

	public OrderedDictionaryG()
	{
	}

	public OrderedDictionaryG(int capacity)
	{
	}

	public OrderedDictionaryG(IEqualityComparer<TKey> comparer)
	{
	}

	public KeyValuePair<TKey, TValue> GetFirst()
	{
		return default(KeyValuePair<TKey, TValue>);
	}

	public void Add(TKey key, TValue value)
	{
	}

	public bool ContainsKey(TKey key)
	{
		return false;
	}

	public bool Remove(TKey key)
	{
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		value = default(TValue);
		return false;
	}

	public void Clear()
	{
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
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
}
