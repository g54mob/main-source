using HQFPSTemplate.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_ItemSlotInterface : UI_Slot
	{
		[BHeader("Item Slot")]
		[SerializeField]
		private Image m_Icon;

		[Space]
		[SerializeField]
		private Text m_Stack;

		[SerializeField]
		private Color m_NormalStackColor = Color.grey;

		[SerializeField]
		private Color m_HighlightStackColor = Color.black;

		protected ItemSlot m_ItemSlot;

		public ItemSlot ItemSlot
		{
			get
			{
				if (m_ItemSlot != null)
				{
					return m_ItemSlot;
				}
				Debug.LogError("No item slot is linked to this interface.");
				return null;
			}
		}

		public bool HasItem
		{
			get
			{
				if (m_ItemSlot != null)
				{
					return m_ItemSlot.HasItem;
				}
				return false;
			}
		}

		public Item Item
		{
			get
			{
				if (m_ItemSlot != null)
				{
					return m_ItemSlot.Item;
				}
				return null;
			}
		}

		public UI_ItemContainerInterface Parent { get; private set; }

		public void LinkToSlot(ItemSlot itemSlot)
		{
			m_ItemSlot = itemSlot;
			if (m_ItemSlot != null)
			{
				m_ItemSlot.Changed.RemoveListener(OnSlotChanged);
			}
			m_ItemSlot.Changed.AddListener(OnSlotChanged);
			DoRefresh();
		}

		public void UnlinkFromSlot()
		{
			if (m_ItemSlot != null)
			{
				m_ItemSlot.Changed.RemoveListener(OnSlotChanged);
			}
		}

		public virtual void DoRefresh()
		{
			m_Icon.enabled = HasItem;
			if (m_Stack != null)
			{
				m_Stack.enabled = HasItem && Item.CurrentStackSize > 1;
			}
			if (m_Icon.enabled)
			{
				m_Icon.sprite = Item.Info.Icon;
			}
			if (m_Stack != null && m_Stack.enabled)
			{
				m_Stack.text = "x" + Item.CurrentStackSize;
			}
			Refresh.Send(this);
		}

		public RectTransform GetItemUI(Item item, float alpha)
		{
			UI_ItemSlotInterface uI_ItemSlotInterface = Object.Instantiate(this);
			uI_ItemSlotInterface.enabled = false;
			uI_ItemSlotInterface._Graphic.enabled = false;
			uI_ItemSlotInterface.m_Icon.enabled = true;
			uI_ItemSlotInterface.m_Icon.sprite = item.Info.Icon;
			if (m_Stack != null)
			{
				uI_ItemSlotInterface.m_Stack.enabled = item.CurrentStackSize > 1;
				uI_ItemSlotInterface.m_Stack.text = $"x{item.CurrentStackSize}";
			}
			CanvasGroup canvasGroup = uI_ItemSlotInterface.gameObject.AddComponent<CanvasGroup>();
			canvasGroup.alpha = alpha;
			canvasGroup.interactable = false;
			return uI_ItemSlotInterface.GetComponent<RectTransform>();
		}

		public override void OnPointerDown(PointerEventData data)
		{
			base.OnPointerDown(data);
		}

		protected override void Awake()
		{
			base.Awake();
			Parent = GetComponentInParent<UI_ItemContainerInterface>();
			StateChanged.AddListener(OnStateChanged);
		}

		protected override void OnDestroy()
		{
			base.Awake();
			if (m_ItemSlot != null)
			{
				m_ItemSlot.Changed.RemoveListener(OnSlotChanged);
			}
		}

		private void OnSlotChanged(ItemSlot itemSlot, SlotChangeType slotChangeType)
		{
			DoRefresh();
		}

		private void OnStateChanged(State state)
		{
			if (m_Stack != null)
			{
				m_Stack.color = ((state == State.Normal) ? m_NormalStackColor : m_HighlightStackColor);
			}
		}
	}
}
