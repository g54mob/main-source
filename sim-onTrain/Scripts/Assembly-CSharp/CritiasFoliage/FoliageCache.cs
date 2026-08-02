using System.Collections.Generic;

namespace CritiasFoliage
{
	public class FoliageCache<TKey, TValue>
	{
		protected Dictionary<TKey, TValue> m_CachedData = new Dictionary<TKey, TValue>();

		protected Queue<TKey> m_CachedQueue = new Queue<TKey>();

		protected readonly int m_MaximumValues;

		protected readonly int m_EvictionCount;

		public TValue this[TKey key]
		{
			get
			{
				return m_CachedData[key];
			}
			set
			{
				m_CachedData[key] = value;
			}
		}

		public int Count => m_CachedData.Count;

		public FoliageCache(int maxValues = 100, int evictionCount = 10)
		{
			m_MaximumValues = maxValues;
			m_EvictionCount = evictionCount;
		}

		public bool ContainsKey(TKey key)
		{
			return m_CachedData.ContainsKey(key);
		}
	}
}
