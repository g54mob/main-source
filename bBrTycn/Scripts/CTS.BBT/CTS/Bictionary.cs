using System;
using System.Collections.Generic;

namespace CTS
{
	[Serializable]
	public class Bictionary<TKey1, TKey2>
	{
		[ES3Serializable]
		private readonly Dictionary<TKey1, TKey2> _forwardDict = new Dictionary<TKey1, TKey2>();

		[ES3Serializable]
		private readonly Dictionary<TKey2, TKey1> _reverseDict = new Dictionary<TKey2, TKey1>();

		public IEnumerable<KeyValuePair<TKey1, TKey2>> Forward => _forwardDict;

		public IEnumerable<KeyValuePair<TKey2, TKey1>> Reverse => _reverseDict;

		public TKey2 this[TKey1 key]
		{
			get
			{
				return _forwardDict[key];
			}
			set
			{
				if (_forwardDict.TryGetValue(key, out var _))
				{
					Remove(key);
				}
				Add(key, value);
			}
		}

		public TKey1 this[TKey2 key]
		{
			get
			{
				return _reverseDict[key];
			}
			set
			{
				if (_reverseDict.TryGetValue(key, out var _))
				{
					Remove(key);
				}
				Add(key, value);
			}
		}

		public bool TryGet(TKey1 key, out TKey2 value)
		{
			return _forwardDict.TryGetValue(key, out value);
		}

		public bool TryGet(TKey2 key, out TKey1 value)
		{
			return _reverseDict.TryGetValue(key, out value);
		}

		public void Add(TKey2 key2, TKey1 key1)
		{
			Add(key1, key2);
		}

		public void Add(TKey1 key1, TKey2 key2)
		{
			if (key1 == null)
			{
				throw new ArgumentNullException("key1");
			}
			if (key2 == null)
			{
				throw new ArgumentNullException("key2");
			}
			if (_forwardDict.ContainsKey(key1) || _reverseDict.ContainsKey(key2))
			{
				throw new ArgumentException("An element with the same key already exists.");
			}
			_forwardDict.Add(key1, key2);
			_reverseDict.Add(key2, key1);
		}

		public bool TryAdd(TKey2 key2, TKey1 key1)
		{
			return TryAdd(key1, key2);
		}

		public bool TryAdd(TKey1 key1, TKey2 key2)
		{
			if (key1 == null)
			{
				throw new ArgumentNullException("key1");
			}
			if (key2 == null)
			{
				throw new ArgumentNullException("key2");
			}
			if (_forwardDict.ContainsKey(key1) || _reverseDict.ContainsKey(key2))
			{
				return false;
			}
			_forwardDict.Add(key1, key2);
			_reverseDict.Add(key2, key1);
			return true;
		}

		public bool Contains(TKey1 key1)
		{
			return _forwardDict.ContainsKey(key1);
		}

		public bool Contains(TKey2 key2)
		{
			return _reverseDict.ContainsKey(key2);
		}

		public void Clear()
		{
			_forwardDict.Clear();
			_reverseDict.Clear();
		}

		public void Remove(TKey1 key1)
		{
			TKey2 key2 = _forwardDict[key1];
			_forwardDict.Remove(key1);
			_reverseDict.Remove(key2);
		}

		public void Remove(TKey2 key2)
		{
			TKey1 key3 = _reverseDict[key2];
			_reverseDict.Remove(key2);
			_forwardDict.Remove(key3);
		}
	}
}
