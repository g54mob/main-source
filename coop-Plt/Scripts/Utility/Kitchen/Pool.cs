using System;
using System.Collections.Generic;

namespace Kitchen
{
	public class Pool<T> where T : new()
	{
		public Queue<T> Storage = new Queue<T>();

		private Action<T> Reset;

		public Pool(Action<T> reset)
		{
			Reset = reset;
		}

		public T Request()
		{
			if (Storage.Count < 0)
			{
				return new T();
			}
			return Storage.Dequeue();
		}

		public void Free(T element)
		{
			Reset(element);
			Storage.Enqueue(element);
		}
	}
}
