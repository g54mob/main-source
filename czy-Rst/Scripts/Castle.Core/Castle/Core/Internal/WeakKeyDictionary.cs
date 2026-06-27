using System;
using System.Collections;
using System.Collections.Generic;

namespace Castle.Core.Internal
{
	internal class WeakKeyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : class
	{
		private class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable
		{
			private readonly ICollection<object> keys;

			public int Count => keys.Count;

			bool ICollection<TKey>.IsReadOnly => true;

			public KeyCollection(ICollection<object> keys)
			{
				this.keys = keys;
			}

			public bool Contains(TKey item)
			{
				return keys.Contains(item);
			}

			public IEnumerator<TKey> GetEnumerator()
			{
				foreach (WeakKey key in keys)
				{
					TKey val = (TKey)key.Target;
					if (val != null)
					{
						yield return val;
					}
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public void CopyTo(TKey[] array, int index)
			{
				using IEnumerator<TKey> enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					TKey current = enumerator.Current;
					array[index++] = current;
				}
			}

			void ICollection<TKey>.Add(TKey item)
			{
				throw ReadOnlyCollectionError();
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw ReadOnlyCollectionError();
			}

			void ICollection<TKey>.Clear()
			{
				throw ReadOnlyCollectionError();
			}

			private static Exception ReadOnlyCollectionError()
			{
				return new NotSupportedException("The collection is read-only.");
			}
		}

		private readonly Dictionary<object, TValue> dictionary;

		private readonly WeakKeyComparer<TKey> comparer;

		private KeyCollection keys;

		private int age;

		private const int AgeThreshold = 128;

		public int Count
		{
			get
			{
				Age(1);
				return dictionary.Count;
			}
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		public ICollection<TKey> Keys => keys ?? (keys = new KeyCollection(dictionary.Keys));

		public ICollection<TValue> Values => dictionary.Values;

		public TValue this[TKey key]
		{
			get
			{
				Age(1);
				return dictionary[key];
			}
			set
			{
				Age(4);
				dictionary[comparer.Wrap(key)] = value;
			}
		}

		public WeakKeyDictionary()
			: this(0, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
		{
		}

		public WeakKeyDictionary(int capacity)
			: this(capacity, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
		{
		}

		public WeakKeyDictionary(IEqualityComparer<TKey> comparer)
			: this(0, comparer)
		{
		}

		public WeakKeyDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			this.comparer = new WeakKeyComparer<TKey>(comparer);
			dictionary = new Dictionary<object, TValue>(capacity, this.comparer);
		}

		public bool ContainsKey(TKey key)
		{
			Age(1);
			return dictionary.ContainsKey(key);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			Age(1);
			if (dictionary.TryGetValue(item.Key, out var value))
			{
				return EqualityComparer<TValue>.Default.Equals(value, item.Value);
			}
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			Age(1);
			return dictionary.TryGetValue(key, out value);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			bool hasDeadObjects = false;
			foreach (KeyValuePair<object, TValue> item in dictionary)
			{
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(comparer.Unwrap(item.Key), item.Value);
				if (keyValuePair.Key == null)
				{
					hasDeadObjects = true;
				}
				else
				{
					yield return keyValuePair;
				}
			}
			if (hasDeadObjects)
			{
				TrimDeadObjects();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			using IEnumerator<KeyValuePair<TKey, TValue>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<TKey, TValue> current = enumerator.Current;
				array[index++] = current;
			}
		}

		public void Add(TKey key, TValue value)
		{
			Age(2);
			dictionary.Add(comparer.Wrap(key), value);
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public bool Remove(TKey key)
		{
			Age(4);
			return dictionary.Remove(key);
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			if (((ICollection<KeyValuePair<TKey, TValue>>)this).Contains(item))
			{
				return Remove(item.Key);
			}
			return false;
		}

		public void Clear()
		{
			age = 0;
			dictionary.Clear();
		}

		private void Age(int amount)
		{
			if ((age += amount) > 128)
			{
				TrimDeadObjects();
			}
		}

		public void TrimDeadObjects()
		{
			age = 0;
			List<object> list = null;
			foreach (object key in dictionary.Keys)
			{
				if (comparer.Unwrap(key) == null)
				{
					if (list == null)
					{
						list = new List<object>();
					}
					list.Add(key);
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (object item in list)
			{
				dictionary.Remove(item);
			}
		}
	}
}
