using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionTransient
	{
		[NonSerialized]
		private readonly Character m_Character;

		[NonSerialized]
		private readonly TUnitMotion m_Motion;

		[NonSerialized]
		private Vector3 m_Direction;

		[NonSerialized]
		private float m_StartTime;

		[NonSerialized]
		private float m_Duration;

		[NonSerialized]
		private float m_Fade;

		private float Opacity
		{
			get
			{
				if (m_Direction == Vector3.zero)
				{
					return 0f;
				}
				float time = m_Character.Time.Time;
				if (time <= m_StartTime + m_Duration)
				{
					return 1f;
				}
				if (m_Fade <= float.Epsilon)
				{
					return 0f;
				}
				if (time >= m_StartTime + m_Duration + m_Fade)
				{
					return 0f;
				}
				float num = (time - (m_StartTime + m_Duration)) / m_Fade;
				return 1f - num;
			}
		}

		public MotionTransient(TUnitMotion motion)
		{
			m_Character = motion.Character;
			m_Motion = motion;
		}

		public void Set(Vector3 direction, float speed, float duration, float fade)
		{
			m_Direction = direction.normalized * speed;
			m_StartTime = m_Character.Time.Time;
			m_Duration = duration;
			m_Fade = fade;
		}

		internal Character.MovementType Update()
		{
			if (m_Direction == Vector3.zero)
			{
				return m_Motion.MovementType;
			}
			float opacity = Opacity;
			if (opacity <= float.Epsilon)
			{
				return m_Motion.MovementType;
			}
			Vector3 vector = Vector3.Lerp(m_Motion.MoveDirection, m_Direction, opacity);
			m_Motion.MoveDirection = vector;
			m_Motion.MovePosition = m_Character.transform.TransformPoint(vector);
			return Character.MovementType.MoveToDirection;
		}
	}
}
