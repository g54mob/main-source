using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct SpringLimit
	{
		[SerializeField]
		private float m_Spring;

		[SerializeField]
		private float m_Damper;

		public float Spring
		{
			get
			{
				return m_Spring;
			}
			set
			{
				m_Spring = value;
			}
		}

		public float Damper
		{
			get
			{
				return m_Damper;
			}
			set
			{
				m_Damper = value;
			}
		}

		public SpringLimit(float spring, float damper)
		{
			m_Spring = spring;
			m_Damper = damper;
		}

		public SoftJointLimitSpring ToJoint()
		{
			return new SoftJointLimitSpring
			{
				damper = Damper,
				spring = Spring
			};
		}
	}
}
