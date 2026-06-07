using System;
using System.Collections.Generic;
using UnityEngine;

public static class ListPool<T>
{
	public class List : List<T>, IDisposable
	{
		private bool _isPooled;

		public List()
		{
		}

		public List(int capacity)
			: base(capacity)
		{
		}

		public List(IEnumerable<T> collection)
			: base(collection)
		{
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
			ListPool<T>._stack.Push(this);
			_isPooled = true;
		}

		public static List Get()
		{
			if (ListPool<T>._stack.Count == 0)
			{
				return new List();
			}
			List list = ListPool<T>._stack.Pop();
			list._isPooled = false;
			return list;
		}

		public static List Get(int minimumCapacity)
		{
			if (ListPool<T>._stack.Count == 0)
			{
				return new List(minimumCapacity);
			}
			List list = ListPool<T>._stack.Pop();
			list._isPooled = false;
			if (list.Capacity < minimumCapacity)
			{
				list.Capacity = minimumCapacity;
			}
			return list;
		}

		public static List Get(IEnumerable<T> collection)
		{
			if (ListPool<T>._stack.Count == 0)
			{
				return new List(collection);
			}
			List list = ListPool<T>._stack.Pop();
			list._isPooled = false;
			list.AddRange(collection);
			return list;
		}

		public static List Get(params T[] items)
		{
			if (ListPool<T>._stack.Count == 0)
			{
				return new List(items);
			}
			List list = ListPool<T>._stack.Pop();
			list._isPooled = false;
			list.AddRange(items);
			return list;
		}
	}

	private static Stack<List> _stack = new Stack<List>();

	public static List Get()
	{
		return List.Get();
	}

	public static List Get(int minimumCapacity)
	{
		return List.Get(minimumCapacity);
	}

	public static List Get(IEnumerable<T> collection)
	{
		return List.Get(collection);
	}

	public static List Get(params T[] items)
	{
		return List.Get(items);
	}

	public static void Add(List<T> list)
	{
		if (!(list is List list2))
		{
			Debug.LogWarning("Trying to pool a list that is not poolable. This is a memory leak!");
		}
		else
		{
			list2.Dispose();
		}
	}

	public static void Add(List list)
	{
		list.Dispose();
	}

	public static bool ReturnIsPooled(List<T> list)
	{
		if (!(list is List item))
		{
			return false;
		}
		return _stack.Contains(item);
	}
}
