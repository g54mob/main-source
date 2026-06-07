using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public class EventHandlerCollection<T> where T : IEventHandler
	{
		public delegate void EventFunction(T item);

		private class EventHandlerComparer : IComparer<T>
		{
			public int Compare(T x, T y)
			{
				return 0;
			}
		}

		private List<T> m_handlers;

		public int IndexOf(T obj)
		{
			return 0;
		}

		public bool Contains(T obj)
		{
			return false;
		}

		public bool Add(T obj)
		{
			return false;
		}

		public bool Remove(T handler)
		{
			return false;
		}

		public void SendEvent(EventFunction function)
		{
		}
	}
}
