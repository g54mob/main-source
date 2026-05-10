using System;
using System.Collections;
using System.Collections.Generic;

public class OrderedList<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : unmanaged
{
	private List<KeyValuePair<TKey, TValue>> _list;

	private bool _ascending;

	public int Count { get; }

	public bool IsReadOnly { get; }

	public TValue this[TKey key]
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public ICollection<TKey> Keys { get; }

	public ICollection<TValue> Values { get; }

	public OrderedList(bool ascending = true)
	{
		_list = new List<KeyValuePair<TKey, TValue>>();
		_ascending = ascending;
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return _list.GetEnumerator();
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
		throw new NotImplementedException();
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
		throw new NotImplementedException();
	}

	public bool ContainsKey(TKey key)
	{
		throw new NotImplementedException();
	}

	public bool Remove(TKey key)
	{
		throw new NotImplementedException();
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		throw new NotImplementedException();
	}
}
