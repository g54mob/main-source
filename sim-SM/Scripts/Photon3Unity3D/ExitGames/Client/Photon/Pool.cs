using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public class Pool<T> where T : class
	{
		private readonly Func<T> createFunction;

		private readonly Queue<T> pool;

		private readonly Action<T> resetFunction;

		public int Count => 0;

		public Pool(Func<T> createFunction, Action<T> resetFunction, int poolCapacity)
		{
		}

		public Pool(Func<T> createFunction, int poolCapacity)
		{
		}

		private void CreatePoolItems(int numItems)
		{
		}

		[Obsolete("Use Release() rather than Push()")]
		public void Push(T item)
		{
		}

		public void Release(T item)
		{
		}

		[Obsolete("Use Acquire() rather than Pop()")]
		public T Pop()
		{
			return null;
		}

		public T Acquire()
		{
			return null;
		}
	}
}
