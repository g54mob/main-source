using System.Collections.Generic;
using JetBrains.Annotations;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Utils.Pool
{
	public static class DictionaryPool<TKey, TValue>
	{
		private const int AllocationBatchSize = 10;

		private static readonly Stack<Dictionary<TKey, TValue>> Pool = new Stack<Dictionary<TKey, TValue>>();

		[MustDisposeResource]
		public static PooledDictionary<TKey, TValue> GetJanitor()
		{
			return new PooledDictionary<TKey, TValue>(Get());
		}

		[MustDisposeResource]
		public static PooledDictionary<TKey, TValue> GetJanitor(Dictionary<TKey, TValue> dictToCopy)
		{
			Dictionary<TKey, TValue> dictionary = Get();
			foreach (KeyValuePair<TKey, TValue> item in dictToCopy)
			{
				dictionary.Add(item.Key, item.Value);
			}
			return new PooledDictionary<TKey, TValue>(dictionary);
		}

		public static Dictionary<TKey, TValue> Get()
		{
			lock (Pool)
			{
				if (Pool.Count > 0)
				{
					return Pool.Pop();
				}
				for (int i = 1; i < 10; i++)
				{
					Pool.Push(new Dictionary<TKey, TValue>());
				}
			}
			return new Dictionary<TKey, TValue>();
		}

		public static void Return(Dictionary<TKey, TValue> set)
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
