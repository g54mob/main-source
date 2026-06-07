using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public struct TetherLimit
	{
		[SerializeField]
		private float m_Limit;

		[SerializeField]
		private float m_Bounciness;

		[SerializeField]
		private float m_ContactDistance;

		public float Limit
		{
			get
			{
				return m_Limit;
			}
			set
			{
				m_Limit = value;
			}
		}

		public float Bounciness
		{
			get
			{
				return m_Bounciness;
			}
			set
			{
				m_Bounciness = value;
			}
		}

		public float ContactDistance
		{
			get
			{
				return m_ContactDistance;
			}
			set
			{
				m_ContactDistance = value;
			}
		}

		public TetherLimit(float limit, float bounciness, float contactDistance)
		{
			m_Limit = limit;
			m_Bounciness = bounciness;
			m_ContactDistance = contactDistance;
		}

		public SoftJointLimit ToJoint()
		{
			return new SoftJointLimit
			{
				limit = Limit,
				bounciness = Bounciness,
				contactDistance = ContactDistance
			};
		}
	}
}
