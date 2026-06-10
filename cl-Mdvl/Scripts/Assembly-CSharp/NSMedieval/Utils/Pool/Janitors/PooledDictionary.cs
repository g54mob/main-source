using System;
using System.Collections;
using System.Collections.Generic;

namespace NSMedieval.Utils.Pool.Janitors
{
	public readonly struct PooledDictionary<TKey, TValue> : IDisposable, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly Dictionary<TKey, TValue> dict;

		public int Count => dict.Count;

		public bool IsReadOnly => ((IDictionary)dict).IsReadOnly;

		public Dictionary<TKey, TValue>.KeyCollection Keys => dict.Keys;

		public Dictionary<TKey, TValue>.ValueCollection Values => dict.Values;

		public TValue this[TKey key]
		{
			get
			{
				return dict[key];
			}
			set
			{
				dict[key] = value;
			}
		}

		public PooledDictionary(Dictionary<TKey, TValue> dict)
		{
			this.dict = dict;
		}

		public void Dispose()
		{
			DictionaryPool<TKey, TValue>.Return(dict);
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return dict.GetEnumerator();
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return dict.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return dict.GetEnumerator();
		}

		public void Clear()
		{
			dict.Clear();
		}

		public void Add(TKey key, TValue value)
		{
			dict.Add(key, value);
		}

		public bool ContainsKey(TKey key)
		{
			return dict.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			return dict.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return dict.TryGetValue(key, out value);
		}

		public bool TryAdd(TKey key, TValue value)
		{
			return dict.TryAdd(key, value);
		}
	}
}
