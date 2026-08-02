using UnityEngine;
using UnityEngine.EventSystems;

namespace HQFPSTemplate.UserInterface
{
	public abstract class UI_ContainerInterface<T> : UserInterfaceBehaviour where T : UI_Slot
	{
		public readonly Message<T> SlotInterfaceRefresh = new Message<T>();

		public readonly Message<T, PointerEventData> SlotPointerDown = new Message<T, PointerEventData>();

		public readonly Message<T, PointerEventData> SlotPointerUp = new Message<T, PointerEventData>();

		public readonly Message<PointerEventData, T> SlotBeginDrag = new Message<PointerEventData, T>();

		public readonly Message<PointerEventData, T> SlotDrag = new Message<PointerEventData, T>();

		public readonly Message<PointerEventData, T> SlotEndDrag = new Message<PointerEventData, T>();

		[SerializeField]
		protected UI_ItemSlotInterface m_SlotTemplate;

		[SerializeField]
		private RectTransform m_SlotsParent;

		[SerializeField]
		private int m_DefaultSlotCount = 1;

		[SerializeField]
		[Tooltip("If enabled, the template will be disabled after the slots are generated.")]
		private bool m_DisableTemplateAfterGen;

		protected T[] m_SlotInterfaces;

		protected T m_Selected;

		public T[] SlotInterfaces => m_SlotInterfaces;

		public virtual bool GenerateSlots()
		{
			return GenerateSlots(m_DefaultSlotCount);
		}

		public virtual bool GenerateSlots(int count)
		{
			if (m_SlotTemplate == null)
			{
				Debug.LogError("No slot template is provided, can't generate any slots.", base.gameObject);
				return false;
			}
			if (m_SlotsParent == null)
			{
				Debug.LogWarning("The slots parent is not assigned. Will parent them under this object.", base.gameObject);
			}
			UI_Slot[] slotInterfaces = m_SlotInterfaces;
			RemoveListeners(slotInterfaces);
			Transform transform = ((m_SlotsParent == null) ? base.transform : m_SlotsParent);
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(transform.childCount - 1);
				if (child != m_SlotTemplate.transform && (bool)child.GetComponent<T>())
				{
					Object.DestroyImmediate(child.gameObject);
				}
			}
			bool activeSelf = m_SlotTemplate.gameObject.activeSelf;
			m_SlotTemplate.gameObject.SetActive(value: true);
			m_SlotInterfaces = new T[count];
			for (int j = 0; j < count; j++)
			{
				m_SlotInterfaces[j] = Object.Instantiate(m_SlotTemplate, transform) as T;
			}
			slotInterfaces = m_SlotInterfaces;
			AddListeners(slotInterfaces);
			m_SlotTemplate.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			m_SlotTemplate.gameObject.SetActive(!m_DisableTemplateAfterGen && activeSelf);
			return true;
		}

		public void Select(int index)
		{
			if (index < m_SlotInterfaces.Length && (!(m_Selected != null) || !(m_SlotInterfaces[index] == m_Selected)))
			{
				if (m_Selected != null)
				{
					m_Selected.Deselect();
				}
				m_Selected = m_SlotInterfaces[index];
				m_Selected.Select();
			}
		}

		public void Select(UI_Slot slot)
		{
			if (m_Selected != null && slot == m_Selected)
			{
				return;
			}
			for (int i = 0; i < m_SlotInterfaces.Length; i++)
			{
				if (m_SlotInterfaces[i] == slot)
				{
					Select(i);
					break;
				}
			}
		}

		public void DeselectAll()
		{
			for (int i = 0; i < m_SlotInterfaces.Length; i++)
			{
				m_SlotInterfaces[i].Deselect();
			}
			if (m_Selected != null)
			{
				m_Selected = null;
			}
		}

		private void RemoveListeners(UI_Slot[] slotInterfaces)
		{
			if (Application.isPlaying && slotInterfaces != null)
			{
				for (int i = 0; i < slotInterfaces.Length; i++)
				{
					slotInterfaces[i].Refresh.RemoveListener(OnSlotInterfaceRefresh);
					slotInterfaces[i].PointerDown.RemoveListener(OnPointerDownOnSlot);
					slotInterfaces[i].PointerUp.RemoveListener(OnPointerUpOnSlot);
				}
			}
		}

		private void AddListeners(UI_Slot[] slotInterfaces)
		{
			if (Application.isPlaying && slotInterfaces != null)
			{
				for (int i = 0; i < slotInterfaces.Length; i++)
				{
					slotInterfaces[i].Refresh.AddListener(OnSlotInterfaceRefresh);
					slotInterfaces[i].PointerDown.AddListener(OnPointerDownOnSlot);
					slotInterfaces[i].PointerUp.AddListener(OnPointerUpOnSlot);
					slotInterfaces[i].BeginDrag.AddListener(OnSlotBeginDrag);
					slotInterfaces[i].Drag.AddListener(OnSlotDrag);
					slotInterfaces[i].EndDrag.AddListener(OnSlotEndDrag);
				}
			}
		}

		private void OnSlotBeginDrag(PointerEventData data, UI_Slot slotInterface)
		{
			SlotBeginDrag.Send(data, slotInterface as T);
		}

		private void OnSlotDrag(PointerEventData data, UI_Slot slotInterface)
		{
			SlotDrag.Send(data, slotInterface as T);
		}

		private void OnSlotEndDrag(PointerEventData data, UI_Slot slotInterface)
		{
			SlotEndDrag.Send(data, slotInterface as T);
		}

		private void OnSlotInterfaceRefresh(UI_Slot slotInterface)
		{
			SlotInterfaceRefresh.Send(slotInterface as T);
		}

		private void OnPointerDownOnSlot(UI_Slot slotInterface, PointerEventData data)
		{
			SlotPointerDown.Send(slotInterface as T, data);
		}

		private void OnPointerUpOnSlot(UI_Slot slotInterface, PointerEventData data)
		{
			SlotPointerUp.Send(slotInterface as T, data);
		}
	}
}
