using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class UseRaycast
	{
		private const int BUFFER_SIZE = 20;

		[SerializeField]
		private bool m_UseRaycast;

		[SerializeField]
		private LayerMask m_LayerMask;

		private RaycastHit[] m_Buffer;

		public UseRaycast()
		{
			m_UseRaycast = false;
			m_LayerMask = -5;
		}

		public bool HasObstacle(Transform origin, Transform target)
		{
			if (!m_UseRaycast)
			{
				return false;
			}
			if (m_Buffer == null)
			{
				m_Buffer = new RaycastHit[20];
			}
			Vector3 direction = target.position - origin.position;
			float maxDistance = Vector3.Distance(origin.position, target.position);
			int num = Physics.RaycastNonAlloc(origin.position, direction, m_Buffer, maxDistance, m_LayerMask);
			for (int i = 0; i < num; i++)
			{
				Transform transform = m_Buffer[i].transform;
				if (!transform.IsChildOf(origin) && !transform.IsChildOf(target))
				{
					return true;
				}
			}
			return false;
		}
	}
}
