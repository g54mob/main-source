using System.Collections.Generic;

namespace Coherence.Common.Pooling.Storage
{
	internal class StackStorage<T> : IPoolStorage<T>
	{
		private readonly Stack<T> stack;

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
