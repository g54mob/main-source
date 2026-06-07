using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public readonly struct PositionTowards : IPosition
	{
		[NonSerialized]
		private readonly Transform m_Target;

		[NonSerialized]
		private readonly Vector3 m_Axis;

		[NonSerialized]
		private readonly Vector3 m_Offset;

		[NonSerialized]
		private readonly float m_Distance;

		public PositionTowards(Transform target, Vector3 axis, Vector3 offset, float distance)
		{
			m_Target = target;
			m_Axis = new Vector3(Mathf.Approximately(axis.x, 0f) ? 0f : 1f, Mathf.Approximately(axis.y, 0f) ? 0f : 1f, Mathf.Approximately(axis.z, 0f) ? 0f : 1f);
			m_Offset = offset;
			m_Distance = distance;
		}

		public bool HasPosition(GameObject user)
		{
			if (user != null)
			{
				return m_Target != null;
			}
			return false;
		}

		public Vector3 GetPosition(GameObject source)
		{
			Vector3 vector = m_Target.TransformPoint(m_Offset);
			if (m_Distance > 0f)
			{
				Vector3 normalized = (vector - source.transform.position).normalized;
				vector -= normalized * m_Distance;
			}
			return new Vector3((m_Axis.x >= 0.5f) ? vector.x : source.transform.position.x, (m_Axis.y >= 0.5f) ? vector.y : source.transform.position.y, (m_Axis.z >= 0.5f) ? vector.z : source.transform.position.z);
		}
	}
}
