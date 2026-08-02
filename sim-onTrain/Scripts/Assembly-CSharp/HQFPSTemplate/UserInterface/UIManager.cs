using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	public class UIManager : MonoBehaviour
	{
		public readonly Value<bool> Dragging = new Value<bool>();

		public readonly Value<bool> DraggingItem = new Value<bool>();

		public readonly Message PointerDown = new Message();

		public readonly Activity OnConsoleOpened = new Activity();

		public Activity ItemWheel = new Activity();

		[BHeader("SETUP", true)]
		[SerializeField]
		private Canvas m_Canvas;

		[SerializeField]
		private KeyCode m_AutoMoveKey;

		[Space]
		[SerializeField]
		private Font m_MainFont;

		private UserInterfaceBehaviour[] m_UIBehaviours;

		public Player Player { get; private set; }

		public KeyCode AutoMoveKey => AutoMoveKey;

		public Font MainFont => m_MainFont;

		public Canvas Canvas => m_Canvas;

		private void Awake()
		{
			AttachToPlayer(GetComponentInParent<Player>());
		}

		public void AttachToPlayer(Player player)
		{
			if (!m_Canvas.isActiveAndEnabled)
			{
				m_Canvas.gameObject.SetActive(value: true);
			}
			if (m_UIBehaviours == null)
			{
				m_UIBehaviours = GetComponentsInChildren<UserInterfaceBehaviour>(includeInactive: true);
			}
			Player = player;
			for (int i = 0; i < m_UIBehaviours.Length; i++)
			{
				m_UIBehaviours[i].OnAttachment();
			}
			for (int j = 0; j < m_UIBehaviours.Length; j++)
			{
				m_UIBehaviours[j].OnPostAttachment();
			}
		}

		private void Update()
		{
		}
	}
}
