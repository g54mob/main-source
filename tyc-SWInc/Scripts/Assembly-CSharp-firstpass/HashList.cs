using System;
using System.Collections;
using System.Collections.Generic;

public class HashList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	private List<T> _list = new List<T>();

	private HashSet<T> _hashSet = new HashSet<T>();

	public int Count
	{
		get
		{
			return _list.Count;
		}
	}

	public bool IsSynchronized { get; private set; }

	public object SyncRoot { get; private set; }

	public bool IsReadOnly
	{
		get
		{
			return false;
		}
	}

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			if (value is T)
			{
				this[index] = (T)value;
			}
			throw new ArgumentException("Wrong type");
		}
	}

	public bool IsFixedSize { get; private set; }

	public T this[int index]
	{
		get
		{
			return _list[index];
		}
		set
		{
			if (index > -1 && index < Count)
			{
				T item = this[index];
				_hashSet.Remove(item);
				_list.RemoveAt(index);
				Remove(value);
				Insert(index, value);
				return;
			}
			throw new ArgumentOutOfRangeException();
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	public void Add(T item)
	{
		if (_hashSet.Add(item))
		{
			_list.Add(item);
		}
	}

	public bool AddIfNotExists(T item)
	{
		if (_hashSet.Add(item))
		{
			_list.Add(item);
			return true;
		}
		return false;
	}

	public void SortList(Comparison<T> comparer)
	{
		_list.Sort(comparer);
	}

	public int Add(object value)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		_hashSet.Clear();
		_list.Clear();
	}

	public bool Contains(object value)
	{
		if (value is T)
		{
			return Contains((T)value);
		}
		return false;
	}

	public int IndexOf(object value)
	{
		if (value is T)
		{
			return IndexOf((T)value);
		}
		return -1;
	}

	public void Insert(int index, object value)
	{
		if (value is T)
		{
			Insert(index, (T)value);
		}
		throw new ArgumentException("Wrong type");
	}

	public void Remove(object value)
	{
		if (value is T)
		{
			Remove((T)value);
		}
	}

	public bool Contains(T item)
	{
		return _hashSet.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_list.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		if (_hashSet.Remove(item))
		{
			_list.Remove(item);
			return true;
		}
		return false;
	}

	public void CopyTo(Array array, int index)
	{
		throw new NotImplementedException();
	}

	public int IndexOf(T item)
	{
		if (!Contains(item))
		{
			return -1;
		}
		return _list.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		if (_hashSet.Add(item))
		{
			_list.Insert(index, item);
		}
	}

	public void RemoveAt(int index)
	{
		if (index > -1 && index < Count)
		{
			T item = this[index];
			_hashSet.Remove(item);
			_list.RemoveAt(index);
			return;
		}
		throw new ArgumentOutOfRangeException("index", "Got " + index + ", count: " + Count);
	}

	public void ForEach(Action<T> act)
	{
		for (int i = 0; i < _list.Count; i++)
		{
			act(_list[i]);
		}
	}

	public int GetCount()
	{
		return _list.Count;
	}

	public T Get(int index)
	{
		return _list[index];
	}

	public List<T> GetUnderlyingList()
	{
		return _list;
	}
}
