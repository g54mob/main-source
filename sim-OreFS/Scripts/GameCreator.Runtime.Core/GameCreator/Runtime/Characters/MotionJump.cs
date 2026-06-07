using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class MotionJump
	{
		[SerializeField]
		private bool m_CanJump;

		[SerializeField]
		private int m_AirJumps;

		[SerializeField]
		private float m_JumpForce;

		[SerializeField]
		private float m_JumpCooldown;

		public bool CanJump
		{
			get
			{
				return m_CanJump;
			}
			set
			{
				m_CanJump = value;
			}
		}

		public int AirJumps
		{
			get
			{
				return m_AirJumps;
			}
			set
			{
				m_AirJumps = value;
			}
		}

		public float JumpForce
		{
			get
			{
				return m_JumpForce;
			}
			set
			{
				m_JumpForce = value;
			}
		}

		public float JumpCooldown
		{
			get
			{
				return m_JumpCooldown;
			}
			set
			{
				m_JumpCooldown = value;
			}
		}

		public MotionJump()
		{
			m_CanJump = true;
			m_AirJumps = 0;
			m_JumpForce = 5f;
			m_JumpCooldown = 0.5f;
		}
	}
}
