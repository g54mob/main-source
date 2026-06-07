using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AltSerialize;

[Serializable]
public class EventList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IAltSerializable, IList, ICollection
{
	[NonSerialized]
	public Action OnChange;

	[NonSerialized]
	public Action PreChange;

	private List<T> _underlying = new List<T>();

	[CompilerGenerated]
	private readonly bool _003CIsSynchronized_003Ek__BackingField;

	[CompilerGenerated]
	private readonly object _003CSyncRoot_003Ek__BackingField;

	[CompilerGenerated]
	private readonly bool _003CIsFixedSize_003Ek__BackingField;

	public int Count
	{
		get
		{
			return _underlying.Count;
		}
	}

	public bool IsSynchronized
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSynchronized_003Ek__BackingField;
		}
	}

	public object SyncRoot
	{
		[CompilerGenerated]
		get
		{
			return _003CSyncRoot_003Ek__BackingField;
		}
	}

	public T this[int i]
	{
		get
		{
			return _underlying[i];
		}
		set
		{
			_underlying[i] = value;
		}
	}

	public bool IsFixedSize
	{
		[CompilerGenerated]
		get
		{
			return _003CIsFixedSize_003Ek__BackingField;
		}
	}

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
			return _underlying[index];
		}
		set
		{
			_underlying[index] = (T)value;
		}
	}

	public bool CanCache
	{
		get
		{
			return true;
		}
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)_underlying).CopyTo(array, index);
	}

	public EventList()
	{
	}

	public EventList(List<T> list)
	{
		_underlying = list;
	}

	public void Add(T item)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.Add(item);
		if (OnChange != null)
		{
			OnChange();
		}
	}

	public void AddRange(IEnumerable<T> range)
	{
		bool flag = false;
		using (IEnumerator<T> enumerator = range.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!flag)
				{
					flag = true;
					if (PreChange != null)
					{
						PreChange();
					}
				}
				_underlying.Add(enumerator.Current);
			}
		}
		if (flag && OnChange != null)
		{
			OnChange();
		}
	}

	public void Update<Y>(EventList<Y> list)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		foreach (Y item3 in list.ToList())
		{
			T item = (T)(object)item3;
			if (!Contains(item))
			{
				list.Remove(item3);
			}
		}
		using (IEnumerator<T> enumerator2 = GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				Y item2 = (Y)(object)enumerator2.Current;
				if (!list.Contains(item2))
				{
					list.Add(item2);
				}
			}
		}
		list.OnChange();
	}

	public void SyncContent<T1>(params IList<T1>[] lists)
	{
		bool flag = false;
		for (int i = 0; i < _underlying.Count; i++)
		{
			T val = _underlying[i];
			bool flag2 = false;
			for (int j = 0; j < lists.Length; j++)
			{
				if (flag2)
				{
					break;
				}
				IList<T1> list = lists[j];
				for (int k = 0; k < list.Count; k++)
				{
					T1 val2 = list[k];
					if (val.Equals(val2))
					{
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				if (!flag && PreChange != null)
				{
					flag = true;
					PreChange();
				}
				_underlying.RemoveAt(i);
				i--;
			}
		}
		foreach (IList<T1> list2 in lists)
		{
			for (int m = 0; m < list2.Count; m++)
			{
				T1 val3 = list2[m];
				bool flag3 = false;
				for (int n = 0; n < _underlying.Count; n++)
				{
					if (_underlying[n].Equals(val3))
					{
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					if (!flag && PreChange != null)
					{
						flag = true;
						PreChange();
					}
					_underlying.Add((T)(object)val3);
				}
			}
		}
		if (flag && OnChange != null)
		{
			OnChange();
		}
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			if (PreChange != null)
			{
				PreChange();
			}
			_underlying.RemoveAt(num);
			if (OnChange != null)
			{
				OnChange();
			}
			return true;
		}
		return false;
	}

	public int IndexOf(T item)
	{
		return _underlying.IndexOf(item);
	}

	public void Sort(Comparison<T> comp)
	{
		_underlying.Sort(comp);
	}

	public void Reverse()
	{
		_underlying.Reverse();
	}

	public static implicit operator EventList<T>(List<T> list)
	{
		return new EventList<T>(list);
	}

	public static implicit operator List<T>(EventList<T> list)
	{
		return new List<T>(list._underlying);
	}

	public void ForEach(Action<T> a)
	{
		_underlying.ForEach(a);
	}

	public T FirstOrDefault(Func<T, bool> a)
	{
		return _underlying.FirstOrDefault(a);
	}

	public void Insert(int index, T item)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.Insert(index, item);
		if (OnChange != null)
		{
			OnChange();
		}
	}

	public void Remove(object value)
	{
		int num = IndexOf(value);
		if (num >= 0)
		{
			if (PreChange != null)
			{
				PreChange();
			}
			_underlying.RemoveAt(num);
			if (OnChange != null)
			{
				OnChange();
			}
		}
	}

	public void RemoveAt(int index)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.RemoveAt(index);
		if (OnChange != null)
		{
			OnChange();
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (T item in _underlying)
		{
			yield return item;
		}
	}

	public int Add(object value)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.Add((T)value);
		if (OnChange != null)
		{
			OnChange();
		}
		return _underlying.Count - 1;
	}

	public void Clear()
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.Clear();
		if (OnChange != null)
		{
			OnChange();
		}
	}

	public bool Contains(object value)
	{
		return _underlying.Contains((T)value);
	}

	public int IndexOf(object value)
	{
		return IndexOf((T)value);
	}

	public void Insert(int index, object value)
	{
		if (PreChange != null)
		{
			PreChange();
		}
		_underlying.Insert(index, (T)value);
		if (OnChange != null)
		{
			OnChange();
		}
	}

	public bool Contains(T item)
	{
		return _underlying.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		_underlying.CopyTo(array, arrayIndex);
	}

	bool ICollection<T>.Remove(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			if (PreChange != null)
			{
				PreChange();
			}
			_underlying.RemoveAt(num);
			if (OnChange != null)
			{
				OnChange();
			}
			return true;
		}
		return false;
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		foreach (T item in _underlying)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _underlying.GetEnumerator();
	}

	public void RemoveAll(Func<T, bool> predicate)
	{
		bool flag = false;
		for (int i = 0; i < _underlying.Count; i++)
		{
			if (!predicate(_underlying[i]))
			{
				continue;
			}
			if (!flag)
			{
				if (PreChange != null)
				{
					PreChange();
				}
				flag = true;
			}
			RemoveAt(i);
			i--;
		}
		if (flag && OnChange != null)
		{
			OnChange();
		}
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		serializer.Serialize(_underlying, depth);
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		_underlying = (List<T>)deserializer.Deserialize();
		return this;
	}
}
