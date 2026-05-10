using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class ArrayRandom<T>
	{
		private static readonly Dictionary<int, T[]> _allocs = new Dictionary<int, T[]>();

		private static T[] GetAlloc(int count)
		{
			if (!_allocs.TryGetValue(count, out var value))
			{
				value = new T[count];
				_allocs[count] = value;
			}
			return value;
		}

		public static T GetRandom(ICollection<T> list, Func<T, bool> filter)
		{
			if (list == null || list.Count <= 0)
			{
				return default(T);
			}
			T[] alloc = GetAlloc(list.Count);
			int num = 0;
			foreach (T item in list)
			{
				if (filter(item))
				{
					alloc[num] = item;
					num++;
				}
			}
			if (num <= 0)
			{
				return default(T);
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}

		public static T GetRandom<TArg>(ICollection<T> list, Func<T, TArg, bool> filter, TArg arg)
		{
			if (list == null || list.Count <= 0)
			{
				return default(T);
			}
			T[] alloc = GetAlloc(list.Count);
			int num = 0;
			foreach (T item in list)
			{
				if (filter(item, arg))
				{
					alloc[num] = item;
					num++;
				}
			}
			if (num <= 0)
			{
				return default(T);
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}

		public static T GetRandom<TArg1, TArg2>(ICollection<T> list, Func<T, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			if (list == null || list.Count <= 0)
			{
				return default(T);
			}
			T[] alloc = GetAlloc(list.Count);
			int num = 0;
			foreach (T item in list)
			{
				if (filter(item, arg1, arg2))
				{
					alloc[num] = item;
					num++;
				}
			}
			if (num <= 0)
			{
				return default(T);
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}
	}
}
