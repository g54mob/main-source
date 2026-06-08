using System;
using System.Collections.Generic;

namespace kcp2k
{
	public class Pool<T>
	{
		private readonly Stack<T> objects;

		private readonly Func<T> objectGenerator;

		private readonly Action<T> objectResetter;

		public int Count => 0;

		public Pool(Func<T> objectGenerator, Action<T> objectResetter, int initialCapacity)
		{
		}

		public T Take()
		{
			return default(T);
		}

		public void Return(T item)
		{
		}

		public void Clear()
		{
		}
	}
}
