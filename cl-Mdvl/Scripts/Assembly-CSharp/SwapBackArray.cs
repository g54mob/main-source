using System;
using System.Collections.Generic;

public class SwapBackArray<T>
{
	private T[] array;

	public int Count { get; private set; }

	public int Capacity => array.Length;

	public ref T this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			return ref array[index];
		}
	}

	public SwapBackArray(int initialCapacity)
	{
		initialCapacity = Math.Max(1, initialCapacity);
		array = new T[initialCapacity];
		Count = 0;
	}

	public void Add(in T item)
	{
		if (Count == array.Length)
		{
			T[] destinationArray = new T[array.Length * 2];
			Array.Copy(array, destinationArray, array.Length);
			array = destinationArray;
		}
		array[Count] = item;
		Count++;
	}

	public bool RemoveAt(int index)
	{
		if (index < 0 || index >= Count)
		{
			return false;
		}
		Count--;
		if (index == Count)
		{
			return true;
		}
		array[index] = array[Count];
		return true;
	}

	public void Clear()
	{
		Count = 0;
	}

	public void Sort(IComparer<T> comparer)
	{
		Array.Sort(array, 0, Count, comparer);
	}
}
