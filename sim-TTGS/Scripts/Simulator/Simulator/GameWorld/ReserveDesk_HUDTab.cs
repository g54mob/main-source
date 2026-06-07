using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveDesk_HUDTab : MonoBehaviour, IActivable
	{
		[SerializeField]
		private NavBox m_navBox;

		public bool IsActive { get; private set; }

		public NavBox NavBox => m_navBox;

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
				base.gameObject.SetActive(IsActive);
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
