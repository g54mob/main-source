using System;
using Simulator;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadItem : NavBox, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IDropHandler
	{
		[Header("UI Components")]
		[SerializeField]
		private RectTransform m_rectTransform;

		[SerializeField]
		private Image m_background;

		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private Image m_armyImage;

		[SerializeField]
		private Button m_deleteButton;

		[SerializeField]
		private NavButton m_navButton;

		[SerializeField]
		private GameObject m_navigationFeedback;

		[SerializeField]
		private UI_WargameMiniatureTooltip m_skillTooltip;

		[SerializeField]
		private Transitioner m_transitioner;

		private bool m_isNavigating;

		private bool m_isDragging;

		public UI_CollectionSquadMiniatureSlot Slot { get; private set; }

		public MiniatureData Data { get; private set; }

		public event Action<int> DeletedItem;

		public event Action<UI_CollectionSquadItem> EnterGamepadNavigationMode;

		public event Action ItemSubmitted;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_deleteButton.onClick.AddListener(OnButtonDelete);
			m_navButton.SubmitEvent += OnButtonSubmit;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_deleteButton.onClick.RemoveListener(OnButtonDelete);
		}

		public void Init(MiniatureData data)
		{
			Data = data;
			RefreshMiniatureImage();
			m_armyImage.sprite = MiniatureSettings.GetArmySprite(Data.Army);
			m_skillTooltip.SetContent(data.Skill);
			PositionOnAnchor();
		}

		public void RefreshMiniatureImage()
		{
			m_miniatureImage.uvRect = TabletopPreview3DManager.Instance.GetImageRectForMiniature(Data.UID);
		}

		public void Anchor(UI_CollectionSquadMiniatureSlot slot)
		{
			if (slot != Slot)
			{
				if (Slot != null)
				{
					Slot.LostItem(this);
				}
				Slot = slot;
			}
		}

		private void PositionOnAnchor()
		{
			m_rectTransform.position = Slot.transform.position;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			m_background.raycastTarget = false;
			m_rectTransform.SetAsLastSibling();
			m_isDragging = true;
			m_transitioner.DoTransition(Transitioner.ESelectionState.Pressed, instant: false);
		}

		public void OnDrag(PointerEventData eventData)
		{
			m_rectTransform.anchoredPosition += eventData.delta;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			PositionOnAnchor();
			m_background.raycastTarget = true;
			m_isDragging = false;
			m_transitioner.DoTransition(Transitioner.ESelectionState.Highlighted, instant: false);
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (Slot.AcceptDrop(eventData, out var item))
			{
				UI_CollectionSquadMiniatureSlot slot = Slot;
				item.Slot.WelcomeItem(this, callback: false);
				PositionOnAnchor();
				slot.OnDrop(eventData);
			}
		}

		public void OnMoveItem(UI_CollectionSquadMiniatureSlot newSlot)
		{
			UI_CollectionSquadItem item = newSlot.Item;
			if (item != null)
			{
				Slot.WelcomeItem(item, callback: true);
				item.PositionOnAnchor();
				Slot.OnItemDropped(item);
			}
			newSlot.OnItemDropped(this);
			PositionOnAnchor();
		}

		private void OnButtonDelete()
		{
			this.DeletedItem?.Invoke(Slot.Index);
		}

		private void OnButtonSubmit()
		{
			this.ItemSubmitted?.Invoke();
			if (m_isNavigating)
			{
				m_navigationFeedback.SetActive(value: false);
				m_isNavigating = false;
			}
			else
			{
				EnterItemNavigationMode();
			}
		}

		private void EnterItemNavigationMode()
		{
			this.EnterGamepadNavigationMode?.Invoke(this);
			m_isNavigating = true;
			m_navigationFeedback.SetActive(value: true);
		}

		public void Delete()
		{
			OnButtonDelete();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			m_transitioner.DoTransition(Transitioner.ESelectionState.Highlighted, instant: false);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (!m_isDragging)
			{
				m_transitioner.DoTransition(Transitioner.ESelectionState.Normal, instant: false);
			}
		}
	}
}
