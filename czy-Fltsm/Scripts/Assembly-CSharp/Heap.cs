using System;
using UnityEngine;

public class Heap<T> where T : IHeapItem<T>
{
	public delegate void ClearItem(T item);

	private T[] _items;

	private int _currentItemCount;

	public int Count => _currentItemCount;

	public T[] Items => _items;

	public Heap(int maximumHeapSize)
	{
		_items = new T[maximumHeapSize];
	}

	public void Dispose()
	{
		_items = null;
	}

	public void Add(T item)
	{
		if (_currentItemCount == _items.Length)
		{
			T[] array = new T[_items.Length * 2];
			Array.Copy(_items, array, _items.Length);
			_items = array;
		}
		item.HeapIndex = _currentItemCount;
		_items[_currentItemCount] = item;
		SortUp(item);
		_currentItemCount++;
	}

	public T RemoveFirst()
	{
		T result = _items[0];
		_currentItemCount--;
		T val = _items[_currentItemCount];
		val.HeapIndex = 0;
		_items[0] = val;
		_items[_currentItemCount] = null;
		SortDown(val);
		return result;
	}

	public void Remove(T item)
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			if (_items[i].Equals(item))
			{
				_currentItemCount--;
				_items[i] = _items[_currentItemCount];
				_items[i].HeapIndex = i;
				SortDown(_items[i]);
				break;
			}
		}
	}

	private void SortDown(T item)
	{
		while (true)
		{
			int num = item.HeapIndex * 2 + 1;
			if (num >= _currentItemCount)
			{
				break;
			}
			T val = _items[num];
			int num2 = item.HeapIndex * 2 + 2;
			if (num2 < _currentItemCount)
			{
				T val2 = _items[num2];
				if (val.CompareTo(val2) < 0)
				{
					num = num2;
					val = val2;
				}
			}
			if (item.CompareTo(val) < 0)
			{
				Swap(item, val, num);
				continue;
			}
			break;
		}
	}

	private void SortUp(T item)
	{
		int num = item.HeapIndex;
		while (true)
		{
			num = (num - 1) / 2;
			T val = _items[num];
			if (0 < item.CompareTo(val))
			{
				Swap(item, val, num);
				continue;
			}
			break;
		}
	}

	private void ValidateItem(T item)
	{
		if (_items[item.HeapIndex].CompareTo(item) != 0)
		{
			Debug.LogWarning("Invalid heap item! Heap index mismatch");
		}
	}

	private void ValidateSorting(int parentIndex = 0)
	{
		T parent = _items[parentIndex];
		int num = parentIndex * 2 + 1;
		if (TryReturnCorrectlySortedChild(parent, num, out var _))
		{
			int num2 = parentIndex * 2 + 2;
			if (TryReturnCorrectlySortedChild(parent, num2, out var _))
			{
				ValidateSorting(num);
				ValidateSorting(num2);
			}
			else if (num2 < _currentItemCount)
			{
				Debug.LogWarning("Heap not correctly sorted!");
			}
		}
		else if (num < _currentItemCount)
		{
			Debug.LogWarning("Heap not correctly sorted!");
		}
	}

	private bool TryReturnCorrectlySortedChild(T parent, int childIndex, out T child)
	{
		if (childIndex < _currentItemCount)
		{
			child = _items[childIndex];
			return 0 <= parent.CompareTo(child);
		}
		child = null;
		return false;
	}

	private void Swap(T firstItem, T secondItem, int secondIndex)
	{
		int heapIndex = firstItem.HeapIndex;
		firstItem.HeapIndex = secondIndex;
		secondItem.HeapIndex = heapIndex;
		_items[heapIndex] = secondItem;
		_items[secondIndex] = firstItem;
	}

	public void UpdateItem(T item)
	{
		SortUp(item);
	}

	public bool Contains(T item)
	{
		return object.Equals(_items[item.HeapIndex], item);
	}

	public T[] ReturnTrimmedArray()
	{
		T[] array = new T[_currentItemCount];
		Array.Copy(_items, array, _currentItemCount);
		return array;
	}

	public void Clear()
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			_items[i] = null;
		}
		_currentItemCount = 0;
	}

	public void Clear(ClearItem callback)
	{
		for (int i = 0; i < _currentItemCount; i++)
		{
			callback(_items[i]);
			_items[i] = null;
		}
		_currentItemCount = 0;
	}
}
