using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class Sensor : MonoBehaviour, IActivable
	{
		private ISensable m_sensable;

		public ISensable CurrentSensable => m_sensable;

		public abstract bool IsPlayer { get; }

		public bool IsActive { get; private set; }

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
			}
		}

		protected virtual void OnSetActive()
		{
		}

		protected virtual void OnSetInactive()
		{
		}

		protected void SetSensable(ISensable sensable)
		{
			if (sensable != m_sensable)
			{
				if (m_sensable != null)
				{
					OnUnsensed(m_sensable);
					m_sensable.OnUnsensed();
				}
				ISensable sensable2 = m_sensable;
				m_sensable = sensable;
				if (m_sensable != null)
				{
					OnSensed(m_sensable);
					m_sensable.OnSensed();
				}
				OnChangeSensable(sensable2, sensable);
			}
		}

		public bool TryGetSensable(out ISensable sensable)
		{
			sensable = m_sensable;
			return sensable != null;
		}

		protected virtual void OnChangeSensable(ISensable former, ISensable next)
		{
		}

		protected virtual void OnSensed(ISensable sensable)
		{
		}

		protected virtual void OnUnsensed(ISensable sensable)
		{
		}
	}
}
