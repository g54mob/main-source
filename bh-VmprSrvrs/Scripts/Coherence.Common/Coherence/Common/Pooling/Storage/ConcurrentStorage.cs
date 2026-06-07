using System.Collections.Concurrent;

namespace Coherence.Common.Pooling.Storage
{
	internal class ConcurrentStorage<T> : IPoolStorage<T>
	{
		private readonly ConcurrentBag<T> bag;

		public bool TryTake(out T item)
		{
			item = default(T);
			return false;
		}

		public void Add(T item)
		{
		}
	}
}
