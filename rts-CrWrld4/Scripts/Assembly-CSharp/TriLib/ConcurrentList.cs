using System.Collections.Generic;

namespace TriLib
{
	public class ConcurrentList<T>
	{
		private List<T> _list;

		private object _sync;

		public int Count => 0;

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void Add(T value)
		{
		}
	}
}
