using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	public class UserInterfaceBehaviour : MonoBehaviour
	{
		private UIManager m_UIManager;

		public UIManager UIManager
		{
			get
			{
				if (!m_UIManager)
				{
					m_UIManager = GetComponentInChildren<UIManager>();
				}
				if (!m_UIManager)
				{
					m_UIManager = GetComponentInParent<UIManager>();
				}
				return m_UIManager;
			}
		}

		public Player Player
		{
			get
			{
				if (!(UIManager != null))
				{
					return null;
				}
				return UIManager.Player;
			}
		}

		public Inventory PlayerStorage
		{
			get
			{
				if (!(Player != null))
				{
					return null;
				}
				return Player.Inventory;
			}
		}

		public virtual void OnAttachment()
		{
		}

		public virtual void OnPostAttachment()
		{
		}
	}
}
