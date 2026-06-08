using System;
using System.Collections.Generic;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Util
{
	public class LruCache<TKey, TValue> where TKey : class where TValue : class
	{
		private readonly object cacheLock = new object();

		private Dictionary<TKey, LruListItem<TKey, TValue>> cache;

		private LruList<TKey, TValue> lruList;

		public int MaxEntries { get; private set; }

		public int Count
		{
			get
			{
				lock (cacheLock)
				{
					return cache.Count;
				}
			}
		}

		public LruCache(int maxEntries)
		{
			if (maxEntries < 1)
			{
				throw new ArgumentException("maxEntries must be greater than zero.");
			}
			MaxEntries = maxEntries;
			cache = new Dictionary<TKey, LruListItem<TKey, TValue>>();
			lruList = new LruList<TKey, TValue>();
		}

		public LruListItem<TKey, TValue> FindOldestItem()
		{
			lock (cacheLock)
			{
				LruListItem<TKey, TValue> result = null;
				if (lruList.Tail != null)
				{
					result = lruList.Tail;
				}
				return result;
			}
		}

		public void EvictExpiredLRUListItems(int validityInSeconds)
		{
			lock (cacheLock)
			{
				while (Count != 0)
				{
					LruListItem<TKey, TValue> lruListItem = FindOldestItem();
					if ((AWSSDKUtils.CorrectedUtcNow - lruListItem.LastTouchedTimestamp).TotalSeconds > (double)validityInSeconds)
					{
						Evict(lruListItem.Key);
						continue;
					}
					break;
				}
			}
		}

		public void AddOrUpdate(TKey key, TValue value)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value2))
				{
					value2.Value = value;
					lruList.Touch(value2);
					return;
				}
				LruListItem<TKey, TValue> lruListItem = new LruListItem<TKey, TValue>(key, value);
				while (cache.Count >= MaxEntries)
				{
					cache.Remove(lruList.EvictOldest());
				}
				lruList.Add(lruListItem);
				cache.Add(key, lruListItem);
			}
		}

		public void Evict(TKey key)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value))
				{
					lruList.Remove(value);
					cache.Remove(key);
				}
			}
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value2))
				{
					lruList.Touch(value2);
					value = value2.Value;
					return true;
				}
				value = null;
				return false;
			}
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> factory)
		{
			if (TryGetValue(key, out var value))
			{
				return value;
			}
			value = factory(key);
			AddOrUpdate(key, value);
			return value;
		}

		public void Clear()
		{
			lock (cacheLock)
			{
				cache.Clear();
				lruList.Clear();
			}
		}
	}
}
