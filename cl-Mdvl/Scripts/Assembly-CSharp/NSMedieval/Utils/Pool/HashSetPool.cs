using System.Collections.Generic;
using JetBrains.Annotations;
using NSEipix;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Utils.Pool
{
	public static class HashSetPool<T>
	{
		private const int AllocationBatchSize = 10;

		private static readonly Stack<HashSet<T>> Pool = new Stack<HashSet<T>>();

		[MustDisposeResource]
		public static PooledHashSet<T> GetJanitor()
		{
			return new PooledHashSet<T>(Get());
		}

		[MustDisposeResource]
		public static PooledHashSet<T> GetJanitor(IEnumerable<T> copyItemsFromCollection)
		{
			PooledHashSet<T> janitor = GetJanitor();
			janitor.AddRange(copyItemsFromCollection);
			return janitor;
		}

		public static HashSet<T> Get()
		{
			lock (Pool)
			{
				if (Pool.Count > 0)
				{
					Pool.TryPop(out var result);
					return result;
				}
				for (int i = 1; i < 10; i++)
				{
					Pool.Push(new HashSet<T>());
				}
			}
			return new HashSet<T>();
		}

		public static void Return(HashSet<T> set)
		{
			if (set == null)
			{
				return;
			}
			set.Clear();
			lock (Pool)
			{
				Pool.Push(set);
			}
		}
	}
}
