using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Simulator
{
	public class UINavElement : Selectable
	{
		public enum ESelectionState
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Selected = 3,
			Disabled = 4
		}

		[SerializeField]
		[FormerlySerializedAs("_neighbours")]
		private NavElementNeighbours m_neighbours;

		[SerializeField]
		private RectTransform m_rectTransformReference;

		[SerializeField]
		[ReadOnly(false, false)]
		private NavBox m_parent;

		public Action<RectTransform> SelectElementEvent;

		public Action DeselectElementEvent;

		public Action PointerEnterEvent;

		public Action PointerExitEvent;

		public bool Selected { get; private set; }

		public bool PointerDown { get; private set; }

		public bool PointerOver { get; private set; }

		public virtual bool NeedToBeSelectedFirst { get; }

		public NavBox Parent
		{
			get
			{
				return m_parent;
			}
			set
			{
				SetParent(value);
			}
		}

		public static UINavElement Selection { get; private set; }

		private UINavElement GetLeftNeighbour()
		{
			return GetNeighbour(m_neighbours.LeftNeighbour);
		}

		private UINavElement GetRightNeighbour()
		{
			return GetNeighbour(m_neighbours.RightNeighbour);
		}

		private UINavElement GetUpNeighbour()
		{
			return GetNeighbour(m_neighbours.UpNeighbour);
		}

		private UINavElement GetDownNeighbour()
		{
			return GetNeighbour(m_neighbours.DownNeighbour);
		}

		private UINavElement GetNeighbour(NavElementNeighbour neighbour)
		{
			if (IsValidElement(neighbour.Neighbour))
			{
				return neighbour.Neighbour;
			}
			return neighbour.BackupNeighbour;
		}

		public UINavElement GetNeighbour(MoveDirection direction)
		{
			return direction switch
			{
				MoveDirection.Down => GetDownNeighbour(), 
				MoveDirection.Up => GetUpNeighbour(), 
				MoveDirection.Left => GetLeftNeighbour(), 
				MoveDirection.Right => GetRightNeighbour(), 
				_ => null, 
			};
		}

		public RectTransform GetRectTransformReference()
		{
			if (m_rectTransformReference == null)
			{
				return m_rectTransformReference = GetComponent<RectTransform>();
			}
			return m_rectTransformReference;
		}

		public override void OnMove(AxisEventData eventData)
		{
			if (Parent != null && !(Parent is NavBoxCategory))
			{
				Parent.OnChildMove(eventData);
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			PointerOver = true;
			base.OnPointerEnter(eventData);
			PointerEnterEvent?.Invoke();
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			PointerOver = false;
			base.OnPointerExit(eventData);
			PointerExitEvent?.Invoke();
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			PointerDown = true;
			base.OnPointerDown(eventData);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			PointerDown = false;
			base.OnPointerUp(eventData);
		}

		public override void OnSelect(BaseEventData eventData)
		{
			Selected = true;
			Selection = this;
			base.OnSelect(eventData);
			if (Parent != null)
			{
				Parent.OnChildSelect(this);
			}
			SelectElementEvent?.Invoke(m_rectTransformReference);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			Selected = false;
			Selection = null;
			base.OnDeselect(eventData);
			if (Parent != null)
			{
				Parent.OnChildDeselect(this);
			}
			DeselectElementEvent?.Invoke();
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		protected virtual void SetParent(NavBox parent)
		{
			m_parent = parent;
		}

		public static bool IsValidElement(UINavElement element)
		{
			bool flag = element != null && element.IsActive() && element.IsInteractable();
			if (!(element is NavBox navBox))
			{
				return flag;
			}
			List<UINavElement> allElements = navBox.GetAllElements();
			int num = allElements.Count((UINavElement navBoxElement) => !IsValidElement(navBoxElement));
			if (flag)
			{
				return num < allElements.Count;
			}
			return false;
		}

		public void SetNeighbours(SimpleNavElementNeighbours neighbours)
		{
			m_neighbours.DownNeighbour.Neighbour = neighbours.DownNeighbour;
			m_neighbours.UpNeighbour.Neighbour = neighbours.UpNeighbour;
			m_neighbours.RightNeighbour.Neighbour = neighbours.RightNeighbour;
			m_neighbours.LeftNeighbour.Neighbour = neighbours.LeftNeighbour;
		}

		private void SetNeighbour(NavElementNeighbour neighbour, UINavElement newNeighbour, bool overrideNeighbour = false)
		{
			if (neighbour.Neighbour == null || overrideNeighbour)
			{
				m_neighbours.LeftNeighbour.Neighbour = newNeighbour;
			}
		}

		public void SetLeftNeighbour(UINavElement neighbour, bool overrideNeighbour = false)
		{
			SetNeighbour(m_neighbours.LeftNeighbour, neighbour, overrideNeighbour);
		}

		public void SetRightNeighbour(UINavElement neighbour, bool overrideNeighbour = false)
		{
			SetNeighbour(m_neighbours.RightNeighbour, neighbour, overrideNeighbour);
		}

		public void SetUpNeighbour(UINavElement neighbour, bool overrideNeighbour = false)
		{
			SetNeighbour(m_neighbours.UpNeighbour, neighbour, overrideNeighbour);
		}

		public void SetDownNeighbour(UINavElement neighbour, bool overrideNeighbour = false)
		{
			SetNeighbour(m_neighbours.DownNeighbour, neighbour, overrideNeighbour);
		}
	}
}
