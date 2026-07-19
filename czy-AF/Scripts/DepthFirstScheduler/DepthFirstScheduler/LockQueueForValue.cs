using System.Collections;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public class LockQueueForValue<T> where T : struct
	{
		private List<T> m_queue = new List<T>();

		public int Count
		{
			get
			{
				lock (((ICollection)m_queue).SyncRoot)
				{
					return m_queue.Count;
				}
			}
		}

		public void Enqueue(T t)
		{
			lock (((ICollection)m_queue).SyncRoot)
			{
				m_queue.Add(t);
			}
		}

		public bool TryDequeue(out T t)
		{
			lock (((ICollection)m_queue).SyncRoot)
			{
				if (m_queue.Count == 0)
				{
					t = default(T);
					return false;
				}
				t = m_queue[0];
				m_queue.RemoveAt(0);
				return true;
			}
		}
	}
}
