using System.Collections.Generic;

namespace Mirror
{
	public class SyncDictionary<TKey, TValue> : SyncIDictionary<TKey, TValue>
	{
		public new Dictionary<TKey, TValue>.ValueCollection Values => null;

		public new Dictionary<TKey, TValue>.KeyCollection Keys => null;

		public SyncDictionary()
			: base((IDictionary<TKey, TValue>)null)
		{
		}

		public SyncDictionary(IEqualityComparer<TKey> eq)
			: base((IDictionary<TKey, TValue>)null)
		{
		}

		public new Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return default(Dictionary<TKey, TValue>.Enumerator);
		}
	}
}
