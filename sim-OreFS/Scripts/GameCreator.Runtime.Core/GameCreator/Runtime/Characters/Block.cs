using System;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Block
	{
		[NonSerialized]
		private bool m_IsBlocking;

		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private IShield m_Shield;

		public bool IsBlocking => m_IsBlocking;

		public IShield Shield => m_Shield;

		[field: NonSerialized]
		public float RaiseStartTime { get; set; }

		[field: NonSerialized]
		public float BlockHitTime { get; set; }

		internal void OnEnable(Character character)
		{
			m_Character = character;
			m_IsBlocking = false;
			RaiseStartTime = -9999f;
			BlockHitTime = -9999f;
		}

		internal void OnDisable(Character character)
		{
			LowerGuard();
		}

		public void RaiseGuard()
		{
			if (!m_IsBlocking && !m_Character.Busy.IsBusy)
			{
				RaiseStartTime = m_Character.Time.Time;
				m_IsBlocking = true;
				m_Shield?.OnRaise(m_Character);
			}
		}

		public void LowerGuard()
		{
			if (m_IsBlocking)
			{
				m_IsBlocking = false;
				m_Shield?.OnLower(m_Character);
			}
		}

		public void SetShield(IShield shield)
		{
			m_Shield = shield;
			if (m_Shield == null)
			{
				LowerGuard();
			}
		}
	}
}
