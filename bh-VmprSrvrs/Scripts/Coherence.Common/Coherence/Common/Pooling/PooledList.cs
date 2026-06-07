using System;
using System.Collections.Generic;

namespace Coherence.Common.Pooling
{
	internal class PooledList<T> : List<T>, IPoolable, IDisposable, IReusable
	{
		private IPool<PooledList<T>> pool;

		public PooledList(IPool<PooledList<T>> pool)
		{
		}

		public PooledList(IPool<PooledList<T>> pool, IEnumerable<T> collection)
		{
		}

		public PooledList(IPool<PooledList<T>> pool, int capacity)
		{
		}

		public void Return()
		{
		}

		public void Dispose()
		{
		}

		public void ResetState()
		{
		}
	}
}
