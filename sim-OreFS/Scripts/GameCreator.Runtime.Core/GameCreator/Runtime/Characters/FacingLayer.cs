using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal class FacingLayer
	{
		private enum System
		{
			Direction = 0,
			Target = 1
		}

		private const float MAX_ANGLE_ERROR = 1f;

		[NonSerialized]
		private System m_System;

		[NonSerialized]
		private Vector3 m_Direction;

		[NonSerialized]
		private Transform m_Target;

		[NonSerialized]
		private readonly bool m_AutoDestroyOnReach;

		[NonSerialized]
		private readonly float m_AutoDestroyOnTimeout;

		[NonSerialized]
		private readonly float m_StartTime;

		public Vector3 Direction => m_Direction;

		public FacingLayer(Character character, bool autoDestroyOnReach)
		{
			m_System = System.Direction;
			m_Direction = character.transform.TransformDirection(Vector3.forward);
			m_StartTime = character.Time.Time;
			m_AutoDestroyOnReach = autoDestroyOnReach;
			m_AutoDestroyOnTimeout = -1f;
		}

		public FacingLayer(Character character, float autoDestroyOnTimeout)
		{
			m_System = System.Direction;
			m_Direction = character.transform.TransformDirection(Vector3.forward);
			m_StartTime = character.Time.Time;
			m_AutoDestroyOnReach = false;
			m_AutoDestroyOnTimeout = autoDestroyOnTimeout;
		}

		public void SetDirection(Vector3 direction)
		{
			m_System = System.Direction;
			m_Direction = direction.normalized;
		}

		public void SetTarget(Transform target)
		{
			m_System = System.Target;
			m_Target = target;
		}

		public bool Update(Character character)
		{
			if (m_System == System.Target && m_Target != null)
			{
				Vector3 vector = m_Target.position - character.transform.position;
				if (vector.sqrMagnitude >= float.Epsilon)
				{
					m_Direction = vector.normalized;
				}
			}
			float num = Vector3.Angle(m_Direction, character.Facing.WorldFaceDirection);
			if (m_AutoDestroyOnReach && num <= 1f)
			{
				return true;
			}
			if (m_AutoDestroyOnTimeout >= 0f && m_StartTime + m_AutoDestroyOnTimeout < character.Time.Time)
			{
				return true;
			}
			return false;
		}
	}
}
