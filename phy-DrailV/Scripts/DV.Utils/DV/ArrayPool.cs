using System;
using System.Collections.Generic;

namespace DV
{
	public static class ArrayPool<T>
	{
		private static readonly object poolLock = new object();

		private static readonly Dictionary<int, Stack<PooledArray<T>>> free = new Dictionary<int, Stack<PooledArray<T>>>();

		public static PooledArray<T> New(int length, T value1)
		{
			PooledArray<T> pooledArray = New(length);
			if (length >= 1)
			{
				pooledArray[0] = value1;
			}
			return pooledArray;
		}

		public static PooledArray<T> New(int length, T value1, T value2)
		{
			PooledArray<T> pooledArray = New(length, value1);
			if (length >= 2)
			{
				pooledArray[1] = value2;
			}
			return pooledArray;
		}

		public static PooledArray<T> New(int length)
		{
			if (length == 0)
			{
				return PooledArray<T>.Empty;
			}
			lock (poolLock)
			{
				if (!free.TryGetValue(length, out var value))
				{
					value = (free[length] = new Stack<PooledArray<T>>());
				}
				if (value.Count > 0)
				{
					return value.Pop();
				}
				return new PooledArray<T>(length);
			}
		}

		public static void Free(PooledArray<T> array)
		{
			if (array.Length == 0)
			{
				return;
			}
			Array.Clear((T[])array, 0, array.Length);
			lock (poolLock)
			{
				free[array.Length].Push(array);
			}
		}
	}
}
