using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class StandQueue : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		protected EnabledValue<int> m_queueLimit;

		[Header("Anchors")]
		[SerializeField]
		protected List<NavigationPoint> m_queueAnchors;

		protected Stand m_stand;

		protected List<IStandUser> m_queue = new List<IStandUser>();

		public int Size => m_queue.Count;

		public void Init(Stand stand)
		{
			m_stand = stand;
		}

		public virtual void AddToQueue(IStandUser user)
		{
			int size = Size;
			m_queue.Add(user);
			user.OnWaitInStandLine(m_stand, GetQueueAnchorAtIndex(size), size);
		}

		public virtual void QuitQueue(IStandUser user)
		{
			for (int i = 0; i < Size; i++)
			{
				if (m_queue[i] == user)
				{
					m_queue.RemoveAt(i);
					break;
				}
			}
			RearrangeQueue();
		}

		public virtual bool PopFirstInLine(out IStandUser user)
		{
			if (Size > 0)
			{
				user = m_queue[0];
				m_queue.RemoveAt(0);
				RearrangeQueue();
				return true;
			}
			user = null;
			return false;
		}

		public virtual void AccessViaSituation(IStandUser user, AIStandSituation situation)
		{
			while (m_queue.Count <= situation.index)
			{
				m_queue.Add(null);
			}
			m_queue[situation.index] = user;
		}

		public bool IsFull()
		{
			if (m_queueLimit.IsEnabled(out var value))
			{
				return Size >= value;
			}
			return !m_queueAnchors.IsValid();
		}

		public IEnumerable<IStandUser> GetUsersInQueue()
		{
			if (!m_queue.IsValid())
			{
				yield break;
			}
			foreach (IStandUser item in new List<IStandUser>(m_queue))
			{
				yield return item;
			}
		}

		public NavigationPoint GetDestination(IStandUser user)
		{
			for (int i = 0; i < m_queue.Count; i++)
			{
				if (m_queue[i] == user)
				{
					return GetQueueAnchorAtIndex(i);
				}
			}
			return null;
		}

		protected void RearrangeQueue()
		{
			for (int i = 0; i < Size; i++)
			{
				m_queue[i].OnWaitInStandLine(m_stand, GetQueueAnchorAtIndex(i), i);
			}
		}

		protected NavigationPoint GetQueueAnchorAtIndex(int index)
		{
			if (m_queueAnchors.Count > index)
			{
				return m_queueAnchors[index];
			}
			return GetLastQueueAnchor();
		}

		protected NavigationPoint GetLastQueueAnchor()
		{
			List<NavigationPoint> queueAnchors = m_queueAnchors;
			return queueAnchors[queueAnchors.Count - 1];
		}
	}
}
