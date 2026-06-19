using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Loxodon.Log;

namespace Loxodon.Framework.Utilities
{
	[Serializable]
	public class WeakValueDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection where TValue : class
	{
		[Serializable]
		protected class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
		{
			private Dictionary<TKey, WeakReference<TValue>> dictionary;

			public int Count
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			bool ICollection<TKey>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)dictionary).SyncRoot;

			public KeyCollection(Dictionary<TKey, WeakReference<TValue>> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.dictionary = dictionary;
			}

			public IEnumerator GetEnumerator()
			{
				return ((IEnumerable<TKey>)this).GetEnumerator();
			}

			public void CopyTo(TKey[] array, int index)
			{
				throw new NotSupportedException();
			}

			void ICollection<TKey>.Add(TKey item)
			{
				throw new NotSupportedException();
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				throw new NotSupportedException();
			}

			void ICollection<TKey>.Clear()
			{
				throw new NotSupportedException();
			}

			bool ICollection<TKey>.Contains(TKey item)
			{
				throw new NotSupportedException();
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				Dictionary<TKey, WeakReference<TValue>>.Enumerator e = dictionary.GetEnumerator();
				while (e.MoveNext())
				{
					KeyValuePair<TKey, WeakReference<TValue>> current = e.Current;
					if (current.Value.IsAlive)
					{
						yield return current.Key;
					}
				}
			}

			public void CopyTo(Array array, int index)
			{
				throw new NotSupportedException();
			}
		}

		[Serializable]
		protected class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
		{
			private Dictionary<TKey, WeakReference<TValue>> dictionary;

			public int Count
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			bool ICollection<TValue>.IsReadOnly => true;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => ((ICollection)dictionary).SyncRoot;

			public ValueCollection(Dictionary<TKey, WeakReference<TValue>> dictionary)
			{
				if (dictionary == null)
				{
					throw new ArgumentNullException("dictionary");
				}
				this.dictionary = dictionary;
			}

			public IEnumerator GetEnumerator()
			{
				return ((IEnumerable<TValue>)this).GetEnumerator();
			}

			public void CopyTo(TValue[] array, int index)
			{
				throw new NotSupportedException();
			}

			void ICollection<TValue>.Add(TValue item)
			{
				throw new NotSupportedException();
			}

			bool ICollection<TValue>.Remove(TValue item)
			{
				throw new NotSupportedException();
			}

			void ICollection<TValue>.Clear()
			{
				throw new NotSupportedException();
			}

			bool ICollection<TValue>.Contains(TValue item)
			{
				throw new NotSupportedException();
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				Dictionary<TKey, WeakReference<TValue>>.Enumerator e = dictionary.GetEnumerator();
				while (e.MoveNext())
				{
					KeyValuePair<TKey, WeakReference<TValue>> current = e.Current;
					if (current.Value.IsAlive)
					{
						yield return current.Value.Target;
					}
				}
			}

			public void CopyTo(Array array, int index)
			{
				throw new NotSupportedException();
			}
		}

		protected class WeakReference<T> : WeakReference
		{
			public new T Target
			{
				get
				{
					return (T)base.Target;
				}
				set
				{
					base.Target = value;
				}
			}

			public WeakReference(T target)
				: base(target)
			{
			}

			public WeakReference(T target, bool trackResurrection)
				: base(target, trackResurrection)
			{
			}
		}

		private static readonly ILog log = LogManager.GetLogger(typeof(WeakValueDictionary<TKey, TValue>));

		private const int MIN_CLEANUP_INTERVAL = 500;

		private int cleanupFlag;

		protected Dictionary<TKey, WeakReference<TValue>> dictionary;

		public TValue this[TKey key]
		{
			get
			{
				CleanupCheck();
				if (!dictionary.ContainsKey(key))
				{
					return null;
				}
				return dictionary[key].Target;
			}
			set
			{
				Insert(key, value, add: false);
			}
		}

		public ICollection<TKey> Keys => new KeyCollection(dictionary);

		public ICollection<TValue> Values => new ValueCollection(dictionary);

		public int Count
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public bool IsReadOnly => ((IDictionary)dictionary).IsReadOnly;

		object IDictionary.this[object key]
		{
			get
			{
				if (!(key is TKey))
				{
					return null;
				}
				if (!dictionary.ContainsKey((TKey)key))
				{
					return null;
				}
				return dictionary[(TKey)key].Target;
			}
			set
			{
				Insert((TKey)key, (TValue)value, add: false);
			}
		}

		ICollection IDictionary.Keys => new KeyCollection(dictionary);

		ICollection IDictionary.Values => new ValueCollection(dictionary);

		bool IDictionary.IsFixedSize => ((IDictionary)dictionary).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)dictionary).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)dictionary).IsSynchronized;

		public WeakValueDictionary()
		{
			dictionary = new Dictionary<TKey, WeakReference<TValue>>();
		}

		public WeakValueDictionary(IDictionary<TKey, TValue> dictionary)
		{
			this.dictionary = new Dictionary<TKey, WeakReference<TValue>>();
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				this.dictionary.Add(item.Key, new WeakReference<TValue>(item.Value));
			}
		}

		public WeakValueDictionary(IEqualityComparer<TKey> comparer)
		{
			dictionary = new Dictionary<TKey, WeakReference<TValue>>(comparer);
		}

		public WeakValueDictionary(int capacity)
		{
			dictionary = new Dictionary<TKey, WeakReference<TValue>>(capacity);
		}

		public WeakValueDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			this.dictionary = new Dictionary<TKey, WeakReference<TValue>>(comparer);
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				this.dictionary.Add(item.Key, new WeakReference<TValue>(item.Value));
			}
		}

		public WeakValueDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			dictionary = new Dictionary<TKey, WeakReference<TValue>>(capacity, comparer);
		}

		public void Add(TKey key, TValue value)
		{
			CleanupCheck();
			Insert(key, value, add: true);
		}

		public bool Remove(TKey key)
		{
			CleanupCheck();
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return dictionary.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			CleanupCheck();
			if (dictionary.TryGetValue(key, out var value2))
			{
				value = value2.Target;
			}
			else
			{
				value = null;
			}
			return value != null;
		}

		public bool ContainsKey(TKey key)
		{
			CleanupCheck();
			if (dictionary.TryGetValue(key, out var value) && value.IsAlive)
			{
				return true;
			}
			return false;
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Insert(item.Key, item.Value, add: true);
		}

		public void Clear()
		{
			dictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			if (!dictionary.TryGetValue(item.Key, out var value))
			{
				return false;
			}
			if (value.IsAlive && EqualityComparer<TValue>.Default.Equals(value.Target, item.Value))
			{
				return true;
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			Dictionary<TKey, WeakReference<TValue>>.Enumerator e = dictionary.GetEnumerator();
			while (e.MoveNext())
			{
				KeyValuePair<TKey, WeakReference<TValue>> current = e.Current;
				if (current.Value.IsAlive)
				{
					yield return new KeyValuePair<TKey, TValue>(current.Key, current.Value.Target);
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
		}

		public void AddRange(IDictionary<TKey, TValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (items.Count <= 0)
			{
				return;
			}
			if (dictionary.Count > 0 && items.Keys.Any((TKey k) => ContainsKey(k)))
			{
				throw new ArgumentException("An item with the same key has already been added.");
			}
			foreach (KeyValuePair<TKey, TValue> item in items)
			{
				dictionary.Add(item.Key, new WeakReference<TValue>(item.Value));
			}
		}

		private void Insert(TKey key, TValue value, bool add)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (add && dictionary.TryGetValue(key, out var value2) && value2.IsAlive)
			{
				throw new ArgumentException("An item with the same key has already been added.");
			}
			dictionary[key] = new WeakReference<TValue>(value);
		}

		bool IDictionary.Contains(object key)
		{
			if (!(key is TKey))
			{
				return false;
			}
			return ((IDictionary<TKey, TValue>)this).ContainsKey((TKey)key);
		}

		void IDictionary.Add(object key, object value)
		{
			Add((TKey)key, (TValue)value);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			throw new NotSupportedException();
		}

		void IDictionary.Remove(object key)
		{
			Remove((TKey)key);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		protected virtual void CleanupCheck()
		{
			cleanupFlag++;
			if (cleanupFlag >= 500 + dictionary.Count)
			{
				cleanupFlag = 0;
				Cleanup();
			}
		}

		protected virtual void Cleanup()
		{
			try
			{
				lock (((ICollection)dictionary).SyncRoot)
				{
					List<TKey> list = new List<TKey>();
					Dictionary<TKey, WeakReference<TValue>>.Enumerator enumerator = dictionary.GetEnumerator();
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, WeakReference<TValue>> current = enumerator.Current;
						if (!current.Value.IsAlive)
						{
							list.Add(current.Key);
						}
					}
					for (int i = 0; i < list.Count; i++)
					{
						dictionary.Remove(list[i]);
					}
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Removes the left-over weak references for entries in the dictionary whose value has already been reclaimed by the garbage collector.Error:{0}", ex);
				}
			}
		}
	}
}
