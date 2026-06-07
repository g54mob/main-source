using System.Collections.Generic;
using Coherence.Brook;
using Coherence.Common.Pooling;

namespace Coherence.Core
{
	internal class SentSequenceCache
	{
		private struct CacheItem
		{
			public List<MessageID> MessageIDs;
		}

		private readonly List<CacheItem> cache;

		private readonly ListPool<MessageID> sentPool;

		public void EnqueueEmpty()
		{
		}

		public void Enqueue(IReadOnlyList<MessageID> messageIds)
		{
		}

		public bool Dequeue(List<MessageID> messageIdBuffer)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
