using System;
using System.Collections.Generic;
using System.Threading;

namespace Gh
{
	public static class DictionaryPoolX
	{
		private static class ThreadLocalPool<TKey, TValue>
		{
			public static readonly ThreadLocal<Stack<DisposableDictionary<TKey, TValue>>> pool;
		}

		public class DisposableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IDisposable
		{
			public void Dispose()
			{
			}
		}

		private static Stack<DisposableDictionary<TKey, TValue>> GetPool<TKey, TValue>()
		{
			return null;
		}

		private static void AddBackToPool<TKey, TValue>(DisposableDictionary<TKey, TValue> dict)
		{
		}

		private static DisposableDictionary<TKey, TValue> GetDictionary<TKey, TValue>()
		{
			return null;
		}

		public static DisposableDictionary<TKey, TValue> ToPooledDictionary<T, TKey, TValue>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, Func<T, TValue> valueSelector)
		{
			return null;
		}
	}
}
