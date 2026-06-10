using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Utils.Pool
{
	public static class ListPool<T>
	{
		private const int AllocationBatchSize = 5;

		private const int CapacitySearchLimit = 10;

		private const int LargeThreshold = 4000;

		private const int MaxLargePoolSize = 8;

		private static readonly List<List<T>> Pool = new List<List<T>>();

		private static readonly List<List<T>> LargePool = new List<List<T>>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			lock (Pool)
			{
				Pool.Clear();
			}
			lock (LargePool)
			{
				LargePool.Clear();
			}
		}

		public static void Initialize(int count)
		{
			for (int i = 0; i < count; i++)
			{
				Pool.Add(new List<T>());
			}
		}

		public static List<T> Get()
		{
			lock (Pool)
			{
				int count = Pool.Count;
				if (count > 0)
				{
					List<T> result = Pool[count - 1];
					Pool.RemoveAt(count - 1);
					return result;
				}
				for (int i = 1; i < 5; i++)
				{
					Pool.Add(new List<T>());
				}
			}
			return new List<T>();
		}

		[MustDisposeResource]
		public static PooledList<T> GetJanitor()
		{
			return new PooledList<T>(Get());
		}

		[MustDisposeResource]
		public static PooledList<T> GetJanitor(T item)
		{
			List<T> list = Get();
			list.Add(item);
			return new PooledList<T>(list);
		}

		[MustDisposeResource]
		public static PooledList<T> GetJanitor(IEnumerable<T> copyItemsFromCollection, Predicate<T> filter = null)
		{
			PooledList<T> janitor = GetJanitor();
			foreach (T item in copyItemsFromCollection)
			{
				if (filter == null || filter(item))
				{
					janitor.Add(item);
				}
			}
			return janitor;
		}

		[MustDisposeResource]
		public static PooledList<T> GetJanitor<TInput>(IEnumerable<TInput> inputCollection, Func<TInput, T> selector)
		{
			PooledList<T> janitor = GetJanitor();
			foreach (TInput item2 in inputCollection)
			{
				T item = selector(item2);
				janitor.Add(item);
			}
			return janitor;
		}

		public static List<T> Get(int capacity)
		{
			if (capacity >= 4000)
			{
				lock (LargePool)
				{
					int num = FindCandidate(LargePool, capacity);
					if (num > 0)
					{
						List<T> result = LargePool[num];
						LargePool.RemoveAt(num);
						return result;
					}
				}
			}
			else
			{
				lock (Pool)
				{
					int num2 = FindCandidate(Pool, capacity);
					if (num2 > 0)
					{
						List<T> result2 = Pool[num2];
						Pool.RemoveAt(num2);
						return result2;
					}
					for (int i = 1; i < 5; i++)
					{
						Pool.Add(new List<T>(capacity));
					}
				}
			}
			return new List<T>(capacity);
		}

		public static PooledList<T> GetJanitor(int capacity)
		{
			return new PooledList<T>(Get(capacity));
		}

		public static void Return(List<T> list)
		{
			if (list == null)
			{
				return;
			}
			list.Clear();
			if (list.Capacity >= 4000)
			{
				lock (LargePool)
				{
					LargePool.Add(list);
					if (LargePool.Count > 8)
					{
						LargePool.RemoveAt(0);
					}
					return;
				}
			}
			lock (Pool)
			{
				Pool.Add(list);
			}
		}

		private static int FindCandidate(List<List<T>> pool, int capacity)
		{
			List<T> list = null;
			int result = -1;
			for (int i = 0; i < pool.Count && i < 10; i++)
			{
				List<T> list2 = pool[pool.Count - 1 - i];
				if ((list == null || list2.Capacity > list.Capacity) && list2.Capacity < capacity * 16)
				{
					list = list2;
					result = pool.Count - 1 - i;
					if (list.Capacity >= capacity)
					{
						return result;
					}
				}
			}
			return result;
		}
	}
}
