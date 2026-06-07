using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class MotionAcceleration
	{
		[SerializeField]
		private bool m_UseAcceleration;

		[SerializeField]
		private float m_Acceleration;

		[SerializeField]
		private float m_Deceleration;

		public bool UseAcceleration
		{
			get
			{
				return m_UseAcceleration;
			}
			set
			{
				m_UseAcceleration = value;
			}
		}

		public float Acceleration
		{
			get
			{
				return m_Acceleration;
			}
			set
			{
				m_Acceleration = value;
			}
		}

		public float Deceleration
		{
			get
			{
				return m_Deceleration;
			}
			set
			{
				m_Deceleration = value;
			}
		}

		public MotionAcceleration()
		{
			UseAcceleration = true;
			m_Acceleration = 10f;
			m_Deceleration = 4f;
		}
	}
}
