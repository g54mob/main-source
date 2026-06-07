using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MaxStack<T> : IEnumerable
{
	private int _limit;

	private LinkedList<T> _list;

	public int Count => 0;

	public MaxStack(int maxSize)
	{
	}

	public void Push(T value)
	{
	}

	public T Pop()
	{
		return default(T);
	}

	public T Peek()
	{
		return default(T);
	}

	public void Clear()
	{
	}

	public bool IsTop(T value)
	{
		return false;
	}

	public bool Contains(T value)
	{
		return false;
	}

	public IEnumerator GetEnumerator()
	{
		return null;
	}
}
