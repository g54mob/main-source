using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class TwoWayDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
	private Dictionary<TKey, TValue> _primary = new Dictionary<TKey, TValue>();

	private Dictionary<TValue, HashSet<TKey>> _secondary = new Dictionary<TValue, HashSet<TKey>>();

	public int Count
	{
		get
		{
			return _primary.Count;
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return false;
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			return _primary[key];
		}
		set
		{
			TValue value2;
			HashSet<TKey> value3;
			if (_primary.TryGetValue(key, out value2) && value2 != null && !value2.Equals(value) && _secondary.TryGetValue(value2, out value3))
			{
				value3.Remove(key);
				if (value3.Count == 0)
				{
					_secondary.Remove(value2);
				}
			}
			_primary[key] = value;
			if (value != null)
			{
				_secondary.Append(value, key);
			}
		}
	}

	public ICollection<TKey> Keys
	{
		get
		{
			return _primary.Keys;
		}
	}

	public ICollection<TValue> Values
	{
		get
		{
			return _primary.Values;
		}
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return _primary.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(KeyValuePair<TKey, TValue> item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		_primary.Clear();
		_secondary.Clear();
	}

	public bool Contains(KeyValuePair<TKey, TValue> item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(KeyValuePair<TKey, TValue> item)
	{
		throw new NotImplementedException();
	}

	public void Add(TKey key, TValue value)
	{
		_primary.Add(key, value);
		if (value != null)
		{
			_secondary.Append(value, key);
		}
	}

	public bool ContainsKey(TKey key)
	{
		return _primary.ContainsKey(key);
	}

	public bool Remove(TKey key)
	{
		TValue value;
		if (_primary.TryGetValue(key, out value))
		{
			_primary.Remove(key);
			HashSet<TKey> value2;
			if (value != null && _secondary.TryGetValue(value, out value2))
			{
				value2.Remove(key);
				if (value2.Count == 0)
				{
					_secondary.Remove(value);
				}
			}
			return true;
		}
		return false;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		return _primary.TryGetValue(key, out value);
	}

	public bool TryGetReverse(TValue key, out HashSet<TKey> value)
	{
		return _secondary.TryGetValue(key, out value);
	}

	public HashSet<TKey> ReverseLookup(TValue key)
	{
		HashSet<TKey> value;
		if (!_secondary.TryGetValue(key, out value))
		{
			return null;
		}
		return value;
	}
}
