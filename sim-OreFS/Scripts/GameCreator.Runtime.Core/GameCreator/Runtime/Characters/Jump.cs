using System;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Jump
	{
		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private int m_RemainingAirJumps;

		public int RemainingAirJumps => m_RemainingAirJumps;

		public int AirJumps => m_Character.Motion.AirJumps - m_RemainingAirJumps;

		public event Action EventAttemptJump;

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_Character.EventLand += OnLand;
			m_Character.EventJump += OnJump;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
			m_Character.EventLand += OnLand;
			m_Character.EventJump -= OnJump;
		}

		internal void OnEnable()
		{
		}

		internal void OnDisable()
		{
		}

		public void Do()
		{
			this.EventAttemptJump?.Invoke();
			if (CanJump())
			{
				m_Character.Motion.Jump();
			}
		}

		public void Do(float force)
		{
			this.EventAttemptJump?.Invoke();
			if (CanJump())
			{
				m_Character.Motion.Jump(force);
			}
		}

		public bool CanJump()
		{
			if (m_Character.Busy.AreLegsBusy)
			{
				return false;
			}
			if (m_Character.Driver.IsGrounded)
			{
				return true;
			}
			return m_RemainingAirJumps > 0;
		}

		private void OnLand(float velocity)
		{
			m_RemainingAirJumps = m_Character.Motion.AirJumps;
		}

		private void OnJump(float force)
		{
			if (!m_Character.Driver.IsGrounded)
			{
				m_RemainingAirJumps--;
			}
		}
	}
}
