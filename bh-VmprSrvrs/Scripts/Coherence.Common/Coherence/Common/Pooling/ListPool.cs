using System;
using System.Collections.Generic;

namespace Coherence.Common.Pooling
{
	internal class ListPool<T>
	{
		private readonly Pool<PooledList<T>> pool;

		public ListPool(int initialListCapacity = 0, int poolPrefillSize = 0)
		{
		}

		public ListPool(Func<IPool<PooledList<T>>, PooledList<T>> objectGenerator = null, int initialListCapacity = 0, int poolPrefillSize = 0)
		{
		}

		public void Return(List<T> list)
		{
		}

		public PooledList<T> Rent()
		{
			return null;
		}
	}
}
