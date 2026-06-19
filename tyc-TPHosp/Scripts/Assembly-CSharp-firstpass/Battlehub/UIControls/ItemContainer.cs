using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Battlehub.UIControls
{
	[RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
	public class ItemContainer : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
	{
		public bool CanDrag = true;

		private LayoutElement m_layoutElement;

		private RectTransform m_rectTransform;

		private bool m_isSelected;

		public LayoutElement LayoutElement => m_layoutElement;

		public RectTransform RectTransform => m_rectTransform;

		public virtual bool IsSelected
		{
			get
			{
				return m_isSelected;
			}
			set
			{
				if (m_isSelected == value)
				{
					return;
				}
				m_isSelected = value;
				if (m_isSelected)
				{
					if (ItemContainer.Selected != null)
					{
						ItemContainer.Selected(this, EventArgs.Empty);
					}
				}
				else if (ItemContainer.Unselected != null)
				{
					ItemContainer.Unselected(this, EventArgs.Empty);
				}
			}
		}

		public object Item { get; set; }

		public static event EventHandler Selected;

		public static event EventHandler Unselected;

		public static event ItemEventHandler PointerDown;

		public static event ItemEventHandler PointerUp;

		public static event ItemEventHandler PointerEnter;

		public static event ItemEventHandler PointerExit;

		public static event ItemEventHandler BeginDrag;

		public static event ItemEventHandler Drag;

		public static event ItemEventHandler Drop;

		public static event ItemEventHandler EndDrag;

		private void Awake()
		{
			m_rectTransform = GetComponent<RectTransform>();
			m_layoutElement = GetComponent<LayoutElement>();
			AwakeOverride();
		}

		protected virtual void AwakeOverride()
		{
		}

		private void Start()
		{
			StartOverride();
		}

		protected virtual void StartOverride()
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (ItemContainer.PointerDown != null)
			{
				ItemContainer.PointerDown(this, eventData);
			}
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (ItemContainer.PointerUp != null)
			{
				ItemContainer.PointerUp(this, eventData);
			}
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			if (CanDrag && ItemContainer.BeginDrag != null)
			{
				ItemContainer.BeginDrag(this, eventData);
			}
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
			if (CanDrag && ItemContainer.Drop != null)
			{
				ItemContainer.Drop(this, eventData);
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (CanDrag && ItemContainer.Drag != null)
			{
				ItemContainer.Drag(this, eventData);
			}
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			if (CanDrag && ItemContainer.EndDrag != null)
			{
				ItemContainer.EndDrag(this, eventData);
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (ItemContainer.PointerEnter != null)
			{
				ItemContainer.PointerEnter(this, eventData);
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (ItemContainer.PointerExit != null)
			{
				ItemContainer.PointerExit(this, eventData);
			}
		}
	}
}
