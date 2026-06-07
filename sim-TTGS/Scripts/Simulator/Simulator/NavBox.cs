using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class NavBox : UINavElement
	{
		[Header("Box Properties")]
		[SerializeField]
		private UINavElement m_firstSelectedElement;

		[SerializeField]
		private NavBoxCategory m_navBoxCategory;

		[SerializeField]
		private List<UINavElement> m_allElements = new List<UINavElement>();

		[SerializeField]
		private ScrollRect m_scrollRect;

		private UINavElement m_currentElement;

		private bool m_deviceChangeRegistered;

		public bool HasSelection { get; protected set; }

		public UINavElement CurrentElement => m_currentElement;

		public event Action Cancelled;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying)
			{
				SetupChildren();
			}
		}

		public virtual void SetActive()
		{
			if (m_navBoxCategory != null)
			{
				m_navBoxCategory.SetActive();
				return;
			}
			if (m_scrollRect != null)
			{
				m_scrollRect.verticalNormalizedPosition = 1f;
			}
			SelectFirstChild(searchForFirstElement: true);
		}

		public virtual void SetInactive()
		{
			if (m_navBoxCategory != null)
			{
				m_navBoxCategory.SetInactive();
			}
		}

		public void SetupChildren()
		{
			SetFirstElement();
			SetChildrenParent();
		}

		private void SetChildrenParent()
		{
			foreach (UINavElement allElement in m_allElements)
			{
				allElement.Parent = this;
			}
		}

		public void SetupAllElements()
		{
			m_allElements.Clear();
			SetupAllElements(base.transform);
		}

		private void SetupAllElements(Transform parent)
		{
			for (int i = 0; i < parent.childCount; i++)
			{
				Transform child = parent.GetChild(i);
				if (child.TryGetComponent<UINavElement>(out var component))
				{
					m_allElements.Add(component);
					component.Parent = this;
					if (component is NavBox)
					{
						continue;
					}
				}
				SetupAllElements(child);
			}
		}

		protected void SetFirstElement(UINavElement element = null)
		{
			if (element != null)
			{
				m_firstSelectedElement = element;
			}
			m_currentElement = m_firstSelectedElement;
		}

		public void SetCurrentElement(UINavElement navElement)
		{
			m_currentElement = navElement;
		}

		public void ClearAllElements()
		{
			m_allElements.Clear();
		}

		public void AddChild(UINavElement child)
		{
			if (m_allElements.Count < 1)
			{
				SetFirstElement(child);
			}
			if (!m_allElements.Contains(child))
			{
				m_allElements.Add(child);
				child.Parent = this;
			}
		}

		public void AddChildren(List<UINavElement> children)
		{
			if (children == null || children.Count < 1)
			{
				return;
			}
			foreach (UINavElement child in children)
			{
				AddChild(child);
			}
		}

		public void RemoveChild(UINavElement child, UINavElement selectedElement = null)
		{
			m_allElements.Remove(child);
			if (m_currentElement == child && m_allElements.Count > 0)
			{
				SetFirstElement((selectedElement == null) ? m_allElements[0] : selectedElement);
				SelectFirstChild();
			}
		}

		public virtual void OnChildMove(AxisEventData eventData)
		{
			UINavElement uINavElement = null;
			uINavElement = m_currentElement.GetNeighbour(eventData.moveDir);
			if (!UINavElement.IsValidElement(uINavElement))
			{
				uINavElement = GetNextValidNeighbourElement(m_currentElement, uINavElement, eventData.moveDir);
			}
			if (uINavElement == null)
			{
				OnMove(eventData);
			}
			else
			{
				NavigateTo(uINavElement, searchForFirstElement: false, eventData.moveDir);
			}
		}

		public void NavigateTo(UINavElement navElement, bool searchForFirstElement = false, MoveDirection direction = MoveDirection.Left)
		{
			UINavElement deepestNavElement = GetDeepestNavElement(navElement, searchForFirstElement);
			if (UINavElement.IsValidElement(navElement) && UINavElement.IsValidElement(deepestNavElement))
			{
				if (m_allElements.Contains(navElement))
				{
					m_currentElement = navElement;
				}
				deepestNavElement.Select();
				return;
			}
			UINavElement neighbour = navElement.GetNeighbour(direction);
			if (UINavElement.IsValidElement(neighbour))
			{
				if (neighbour is NavBox navElement2)
				{
					NavigateTo(navElement2, searchForFirstElement, direction);
				}
				else
				{
					neighbour.Select();
				}
			}
		}

		public void SelectFirstChild(bool searchForFirstElement = false)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice != EInputDeviceType.GAMEPAD)
			{
				return;
			}
			UINavElement uINavElement = m_firstSelectedElement;
			if (!UINavElement.IsValidElement(uINavElement) && m_allElements.Count > 0)
			{
				uINavElement = m_allElements[0];
			}
			if (!UINavElement.IsValidElement(uINavElement))
			{
				if (base.Parent != null)
				{
					base.Parent.SelectFirstChild();
				}
			}
			else
			{
				NavigateTo(uINavElement, searchForFirstElement);
			}
		}

		public void ResumeSelection()
		{
			if (!(m_currentElement == null))
			{
				NavigateTo(m_currentElement);
			}
		}

		private UINavElement GetDeepestNavElement(UINavElement navElement, bool useFirstSelectedElement = false)
		{
			UINavElement result = navElement;
			if (!(navElement is NavBox navBox))
			{
				return result;
			}
			NavBox navBox2 = navBox;
			if (!UINavElement.IsValidElement(navBox2) && navBox2.Parent != null)
			{
				List<UINavElement> allElements = navBox2.Parent.m_allElements;
				if (!allElements.Contains(navBox2))
				{
					return result;
				}
				int num = allElements.IndexOf(navBox2);
				for (int i = num; i < allElements.Count + num; i++)
				{
					int index = ((i < allElements.Count - 1) ? i : 0);
					if (UINavElement.IsValidElement(allElements[index]))
					{
						navBox2 = allElements[index] as NavBox;
						break;
					}
				}
			}
			if (navBox2 == null)
			{
				return null;
			}
			result = navBox2.GetDeepestNavElement(useFirstSelectedElement ? navBox2.m_firstSelectedElement : navBox2.m_currentElement, useFirstSelectedElement);
			if (UINavElement.IsValidElement(result))
			{
				return result;
			}
			List<UINavElement> allElements2 = navBox2.m_allElements;
			if (!allElements2.Contains(result))
			{
				return result;
			}
			int num2 = allElements2.IndexOf(result);
			for (int j = num2; j < navBox2.m_allElements.Count + num2; j++)
			{
				int index2 = ((j < navBox2.m_allElements.Count - 1) ? j : 0);
				if (UINavElement.IsValidElement(allElements2[index2]))
				{
					result = allElements2[index2];
					break;
				}
			}
			return result;
		}

		private UINavElement GetNextValidNeighbourElement(UINavElement initialSearchSource, UINavElement navElement, MoveDirection direction)
		{
			if (navElement == null)
			{
				return null;
			}
			UINavElement neighbour = navElement.GetNeighbour(direction);
			if (neighbour == initialSearchSource)
			{
				return null;
			}
			if (UINavElement.IsValidElement(neighbour))
			{
				return neighbour;
			}
			return GetNextValidNeighbourElement(initialSearchSource, neighbour, direction);
		}

		public UINavElement GetDeepestCurrentElement()
		{
			return GetDeepestNavElement(m_currentElement);
		}

		public List<UINavElement> GetAllElements()
		{
			return m_allElements;
		}

		public void Deselect()
		{
			EventSystem current = EventSystem.current;
			if (!(current == null))
			{
				current.SetSelectedGameObject(null);
			}
		}

		public virtual void OnChildSelect(UINavElement child)
		{
			HasSelection = true;
			if (!(child is NavBoxCategory))
			{
				m_currentElement = child;
				if (base.Parent != null)
				{
					base.Parent.OnChildSelect(this);
				}
				SelectElementEvent?.Invoke(child.GetRectTransformReference());
			}
		}

		public virtual void OnChildDeselect(UINavElement child)
		{
			foreach (UINavElement allElement in m_allElements)
			{
				if (allElement.Selected)
				{
					return;
				}
			}
			HasSelection = false;
			if (!(child is NavBoxCategory))
			{
				if (base.Parent != null)
				{
					base.Parent.OnChildDeselect(this);
				}
				DeselectElementEvent?.Invoke();
			}
		}

		public void OnChildCancel()
		{
			this.Cancelled?.Invoke();
			if (base.Parent != null)
			{
				base.Parent.OnChildCancel();
			}
		}

		public void RegisterToDeviceChange(bool register)
		{
			if (m_deviceChangeRegistered != register)
			{
				m_deviceChangeRegistered = register;
				if (register)
				{
					InputManager.DeviceChanged += OnDeviceChange;
				}
				else
				{
					InputManager.DeviceChanged -= OnDeviceChange;
				}
			}
		}

		public void OnDeviceChange(EInputDeviceType type)
		{
			if (type != EInputDeviceType.KEYBOARD && type == EInputDeviceType.GAMEPAD && UINavElement.Selection == null)
			{
				SelectFirstChild();
			}
		}
	}
}
