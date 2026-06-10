using System.Collections.Generic;
using JetBrains.Annotations;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Utils.Pool
{
	public static class QueuePool<T>
	{
		private const int AllocationBatchSize = 10;

		private static readonly Queue<Queue<T>> Pool = new Queue<Queue<T>>();

		[MustDisposeResource]
		public static PooledQueue<T> GetJanitor()
		{
			return new PooledQueue<T>(Get());
		}

		[MustDisposeResource]
		public static PooledQueue<T> GetJanitor(IEnumerable<T> copyItems)
		{
			PooledQueue<T> janitor = GetJanitor();
			foreach (T copyItem in copyItems)
			{
				janitor.Enqueue(copyItem);
			}
			return janitor;
		}

		public static Queue<T> Get()
		{
			lock (Pool)
			{
				if (Pool.Count > 0)
				{
					return Pool.Dequeue();
				}
				for (int i = 1; i < 10; i++)
				{
					Pool.Enqueue(new Queue<T>());
				}
			}
			return new Queue<T>();
		}

		public static void Return(Queue<T> set)
		{
			if (set == null)
			{
				return;
			}
			set.Clear();
			lock (Pool)
			{
				Pool.Enqueue(set);
			}
		}
	}
}
