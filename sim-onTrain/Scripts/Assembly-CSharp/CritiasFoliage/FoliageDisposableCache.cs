using System;

namespace CritiasFoliage
{
	public class FoliageDisposableCache<TKey, TValue> : FoliageCache<TKey, TValue>, IDisposable where TValue : IDisposable
	{
		public FoliageDisposableCache(int maxValues = 100, int evictionCount = 10)
			: base(maxValues, evictionCount)
		{
		}

		public void Add(TKey key, TValue value)
		{
			int count = m_CachedQueue.Count;
			if (count + 1 > m_MaximumValues)
			{
				int num = ((m_EvictionCount <= count) ? m_EvictionCount : count);
				for (int i = 0; i < num; i++)
				{
					TKey key2 = m_CachedQueue.Dequeue();
					m_CachedData[key2].Dispose();
					m_CachedData.Remove(key2);
				}
			}
			m_CachedData.Add(key, value);
			m_CachedQueue.Enqueue(key);
		}

		public void Dispose()
		{
			if (m_CachedData.Count <= 0)
			{
				return;
			}
			foreach (TValue value in m_CachedData.Values)
			{
				value.Dispose();
			}
			m_CachedData.Clear();
			m_CachedQueue.Clear();
		}
	}
}
