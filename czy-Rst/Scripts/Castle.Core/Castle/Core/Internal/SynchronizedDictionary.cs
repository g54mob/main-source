using System;
using System.Collections.Generic;
using System.Threading;

namespace Castle.Core.Internal
{
	internal sealed class SynchronizedDictionary<TKey, TValue> : IDisposable
	{
		private Dictionary<TKey, TValue> items;

		private ReaderWriterLockSlim itemsLock;

		public SynchronizedDictionary()
		{
			items = new Dictionary<TKey, TValue>();
			itemsLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
		}

		public void AddOrUpdateWithoutTakingLock(TKey key, TValue value)
		{
			items[key] = value;
		}

		public void Dispose()
		{
			itemsLock.Dispose();
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
		{
			itemsLock.EnterReadLock();
			TValue value;
			try
			{
				if (items.TryGetValue(key, out value))
				{
					return value;
				}
			}
			finally
			{
				itemsLock.ExitReadLock();
			}
			itemsLock.EnterUpgradeableReadLock();
			try
			{
				if (items.TryGetValue(key, out value))
				{
					return value;
				}
				value = valueFactory(key);
				itemsLock.EnterWriteLock();
				try
				{
					items.Add(key, value);
					return value;
				}
				finally
				{
					itemsLock.ExitWriteLock();
				}
			}
			finally
			{
				itemsLock.ExitUpgradeableReadLock();
			}
		}

		public TValue GetOrAddWithoutTakingLock(TKey key, Func<TKey, TValue> valueFactory)
		{
			if (items.TryGetValue(key, out var value))
			{
				return value;
			}
			value = valueFactory(key);
			items.Add(key, value);
			return value;
		}

		public void ForEach(Action<TKey, TValue> action)
		{
			itemsLock.EnterReadLock();
			try
			{
				foreach (KeyValuePair<TKey, TValue> item in items)
				{
					action(item.Key, item.Value);
				}
			}
			finally
			{
				itemsLock.ExitReadLock();
			}
		}
	}
}
