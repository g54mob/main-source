using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public abstract class DictionaryBase<TKey, TValue> : CollectionBase<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection
	{
		[Serializable]
		private sealed class KeysCollection : ReadOnlyCollectionBase<TKey>
		{
			private readonly DictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public KeysCollection(DictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<TKey> GetEnumerator()
			{
				return null;
			}

			public override bool Contains(TKey key)
			{
				return false;
			}
		}

		[Serializable]
		private sealed class ValuesCollection : ReadOnlyCollectionBase<TValue>
		{
			private readonly DictionaryBase<TKey, TValue> myDictionary;

			public override int Count => 0;

			public ValuesCollection(DictionaryBase<TKey, TValue> myDictionary)
			{
			}

			public override IEnumerator<TValue> GetEnumerator()
			{
				return null;
			}
		}

		[Serializable]
		private class DictionaryEnumeratorWrapper : IDictionaryEnumerator, IEnumerator
		{
			private readonly IEnumerator<KeyValuePair<TKey, TValue>> enumerator;

			public DictionaryEntry Entry => default(DictionaryEntry);

			public object Key => null;

			public object Value => null;

			public object Current => null;

			public DictionaryEnumeratorWrapper(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
			{
			}

			public void Reset()
			{
			}

			public bool MoveNext()
			{
				return false;
			}
		}

		public virtual TValue Item
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public virtual ICollection<TKey> Keys => null;

		public virtual ICollection<TValue> Values => null;

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

		public abstract override void Clear();

		public abstract bool Remove(TKey key);

		public abstract bool TryGetValue(TKey key, out TValue value);

		public virtual void Add(TKey key, TValue value)
		{
		}

		public virtual bool ContainsKey(TKey key)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public new virtual IDictionary<TKey, TValue> AsReadOnly()
		{
			return null;
		}

		public override void Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public override bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public override bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		private static void CheckGenericType<ExpectedType>(string name, object value)
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

		void IDictionary.Remove(object key)
		{
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		internal new string DebuggerDisplayString()
		{
			return null;
		}
	}
}
