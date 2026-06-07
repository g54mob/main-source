using System;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Invincibility
	{
		[NonSerialized]
		private float m_InvincibleStartTime;

		[NonSerialized]
		private float m_InvincibleUntil;

		[NonSerialized]
		private bool m_WasInvincible;

		[NonSerialized]
		private Character m_Character;

		public bool IsInvincible
		{
			get
			{
				if (m_Character != null)
				{
					return m_Character.Time.Time <= m_InvincibleUntil;
				}
				return false;
			}
		}

		public float StartTime
		{
			get
			{
				if (!IsInvincible)
				{
					return -1f;
				}
				return m_InvincibleStartTime;
			}
		}

		public float Duration
		{
			get
			{
				if (!IsInvincible)
				{
					return -1f;
				}
				return m_InvincibleUntil - m_InvincibleStartTime;
			}
		}

		public event Action<bool> EventChange;

		public event Action EventBecomeInvincible;

		public event Action EventBecomeVincible;

		internal void OnEnable(Character character)
		{
			m_Character = character;
			m_InvincibleUntil = -1f;
			m_WasInvincible = false;
		}

		internal void OnDisable(Character character)
		{
			m_InvincibleUntil = -1f;
			m_WasInvincible = false;
		}

		internal void OnUpdate()
		{
			bool isInvincible = IsInvincible;
			if (isInvincible != m_WasInvincible)
			{
				if (IsInvincible)
				{
					this.EventBecomeInvincible?.Invoke();
				}
				else
				{
					this.EventBecomeVincible?.Invoke();
				}
				this.EventChange?.Invoke(isInvincible);
				m_WasInvincible = isInvincible;
			}
		}

		public void Set(float duration)
		{
			if (!(m_Character == null))
			{
				m_InvincibleStartTime = m_Character.Time.Time;
				m_InvincibleUntil = Math.Max(m_InvincibleUntil, m_Character.Time.Time + duration);
			}
		}
	}
}
