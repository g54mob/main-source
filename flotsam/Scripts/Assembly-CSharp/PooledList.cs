using System;
using System.Collections.Generic;
using UnityEngine;

public class PooledList<T> : List<T>, IDisposable
{
	private static Stack<PooledList<T>> _stack = new Stack<PooledList<T>>(16);

	private bool _isPooled;

	private PooledList()
	{
	}

	private PooledList(int capacity)
		: base(capacity)
	{
	}

	private PooledList(IEnumerable<T> collection)
		: base(collection)
	{
	}

	public static PooledList<T> Get()
	{
		if (_stack.Count == 0)
		{
			return new PooledList<T>();
		}
		PooledList<T> pooledList = _stack.Pop();
		pooledList._isPooled = false;
		return pooledList;
	}

	public static PooledList<T> Get(int minimumCapacity)
	{
		if (_stack.Count == 0)
		{
			return new PooledList<T>(minimumCapacity);
		}
		PooledList<T> pooledList = _stack.Pop();
		pooledList._isPooled = false;
		if (pooledList.Capacity < minimumCapacity)
		{
			pooledList.Capacity = minimumCapacity;
		}
		return pooledList;
	}

	public static PooledList<T> Get(IEnumerable<T> collection)
	{
		if (_stack.Count == 0)
		{
			return new PooledList<T>(collection);
		}
		PooledList<T> pooledList = _stack.Pop();
		pooledList._isPooled = false;
		pooledList.AddRange(collection);
		return pooledList;
	}

	public static PooledList<T> Get(params T[] items)
	{
		if (_stack.Count == 0)
		{
			return new PooledList<T>(items);
		}
		PooledList<T> pooledList = _stack.Pop();
		pooledList._isPooled = false;
		pooledList.AddRange(items);
		return pooledList;
	}

	public new void Add(T item)
	{
		if (_isPooled)
		{
			throw new NotSupportedException($"Adding items to a pooled list of type {typeof(T).ToString()} is not support!");
		}
		base.Add(item);
	}

	public new void AddRange(IEnumerable<T> collection)
	{
		if (_isPooled)
		{
			throw new NotSupportedException($"Adding items to a pooled list of type {typeof(T).ToString()} is not support!");
		}
		base.AddRange(collection);
	}

	public void Dispose()
	{
		if (_isPooled)
		{
			Debug.LogWarning("A PooledList.List that is pooled cannot be pooled again!");
			return;
		}
		Clear();
		_stack.Push(this);
		_isPooled = true;
	}

	public static bool IsPooled(PooledList<T> pooledList)
	{
		return _stack.Contains(pooledList);
	}
}
