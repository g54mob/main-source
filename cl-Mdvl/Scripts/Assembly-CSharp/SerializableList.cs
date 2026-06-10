using System;
using System.Collections;
using System.Collections.Generic;
using NSEipix;
using UnityEngine;

[Serializable]
public class SerializableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	[SerializeField]
	private List<T> items;

	public int Count => items.Count;

	public bool IsReadOnly => ((ICollection<T>)items).IsReadOnly;

	public T this[int index]
	{
		get
		{
			return items[index];
		}
		set
		{
			items[index] = value;
		}
	}

	public SerializableList(List<T> list = null)
	{
		items = list ?? new List<T>();
	}

	public List<T>.Enumerator GetEnumerator()
	{
		return items.GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return items.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return items.GetEnumerator();
	}

	public void Add(T item)
	{
		items.Add(item);
	}

	public void AddRange(IEnumerable<T> collection)
	{
		items.AddRange(collection);
	}

	public void Clear()
	{
		items.Clear();
	}

	public bool Contains(T item)
	{
		return items.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		items.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		return items.Remove(item);
	}

	public int IndexOf(T item)
	{
		return items.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		items.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		items.RemoveAt(index);
	}

	public void Sort(Comparison<T> comparison)
	{
		items.Sort(comparison);
	}

	public void RemoveWhere(Func<T, bool> predicate)
	{
		items.RemoveWhere(predicate);
	}
}
