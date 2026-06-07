using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class ControllerComponent : MonoBehaviour, IActivable
	{
		[SerializeField]
		private Controller m_controller;

		protected Controller Controller => m_controller;

		public bool IsActive { get; private set; }

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

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
	}
}
