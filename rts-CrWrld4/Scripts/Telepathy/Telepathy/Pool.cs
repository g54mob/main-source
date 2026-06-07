using System;
using System.Collections.Generic;

namespace Telepathy
{
	public class Pool<T>
	{
		private readonly Stack<T> objects;

		private readonly Func<T> objectGenerator;

		public Pool(Func<T> objectGenerator)
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

		public int Count()
		{
			return 0;
		}
	}
}
