using System;
using System.Collections.Generic;

namespace Coherence.Common
{
	internal class CacheList<T> : List<T>, IDisposable
	{
		public CacheList()
		{
		}

		public CacheList(IEnumerable<T> collection)
		{
		}

		public CacheList(int capacity)
		{
		}

		public void Dispose()
		{
		}
	}
}
