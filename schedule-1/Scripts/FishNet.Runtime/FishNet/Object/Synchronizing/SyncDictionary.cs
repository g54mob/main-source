using System.Collections.Generic;
using FishNet.Documenting;

namespace FishNet.Object.Synchronizing
{
	[APIExclude]
	public class SyncDictionary<TKey, TValue> : SyncIDictionary<TKey, TValue>
	{
		[APIExclude]
		public new Dictionary<TKey, TValue>.ValueCollection Values => null;

		[APIExclude]
		public new Dictionary<TKey, TValue>.KeyCollection Keys => null;

		[APIExclude]
		public SyncDictionary()
			: base((IDictionary<TKey, TValue>)null)
		{
		}

		[APIExclude]
		public SyncDictionary(IEqualityComparer<TKey> eq)
			: base((IDictionary<TKey, TValue>)null)
		{
		}

		[APIExclude]
		public new Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return default(Dictionary<TKey, TValue>.Enumerator);
		}
	}
}
