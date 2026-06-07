using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class MotionDash
	{
		[SerializeField]
		private int m_InSuccession;

		[SerializeField]
		private bool m_DashInAir;

		[SerializeField]
		private float m_Cooldown;

		public int InSuccession
		{
			get
			{
				return m_InSuccession;
			}
			set
			{
				m_InSuccession = value;
			}
		}

		public float Cooldown
		{
			get
			{
				return m_Cooldown;
			}
			set
			{
				m_Cooldown = value;
			}
		}

		public bool DashInAir
		{
			get
			{
				return m_DashInAir;
			}
			set
			{
				m_DashInAir = value;
			}
		}

		public MotionDash()
		{
			m_InSuccession = 0;
			m_DashInAir = false;
			m_Cooldown = 1f;
		}
	}
}
