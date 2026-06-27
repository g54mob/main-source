using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Restory.UserInterface.CommonElements
{
	[DisallowMultipleComponent]
	public class GUI_Selectable : UIBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[Serializable]
		public class SelectableEvent : UnityEvent<GUI_Selectable, bool>
		{
		}

		private static List<GUI_Selectable> allSelectables = new List<GUI_Selectable>();

		[Tooltip("Can the Selectable be interacted with?")]
		[SerializeField]
		protected bool interactable = true;

		[SerializeField]
		protected SelectableEvent interactableChanged = new SelectableEvent();

		protected readonly List<CanvasGroup> canvasGroupCache = new List<CanvasGroup>();

		protected bool groupsAllowInteraction = true;

		protected bool isPointerInside;

		protected bool isPointerDown;

		protected bool hasSelection;

		public virtual bool Interactable
		{
			get
			{
				return interactable;
			}
			set
			{
				interactable = value;
				interactableChanged.Invoke(this, interactable);
			}
		}

		public event UnityAction<GUI_Selectable, bool> InteractableChanged
		{
			add
			{
				interactableChanged.AddListener(value);
			}
			remove
			{
				interactableChanged.RemoveListener(value);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			allSelectables.Add(this);
		}

		protected override void OnDisable()
		{
			allSelectables.Remove(this);
			base.OnDisable();
		}

		protected override void OnCanvasGroupChanged()
		{
			bool flag = true;
			Transform parent = base.transform;
			while (parent != null)
			{
				parent.GetComponents(canvasGroupCache);
				bool flag2 = false;
				for (int i = 0; i < canvasGroupCache.Count; i++)
				{
					if (!canvasGroupCache[i].interactable)
					{
						flag = false;
						flag2 = true;
					}
					if (canvasGroupCache[i].ignoreParentGroups)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					break;
				}
				parent = parent.parent;
			}
			if (flag != groupsAllowInteraction)
			{
				groupsAllowInteraction = flag;
			}
		}

		public virtual bool IsInteractable()
		{
			if (groupsAllowInteraction)
			{
				return interactable;
			}
			return false;
		}

		protected bool IsHighlighted(BaseEventData eventData)
		{
			if (!IsActive())
			{
				return false;
			}
			if (IsPressed())
			{
				return false;
			}
			bool flag = hasSelection;
			if (eventData is PointerEventData)
			{
				PointerEventData pointerEventData = eventData as PointerEventData;
				return flag | ((isPointerDown && !isPointerInside && pointerEventData.pointerPress == base.gameObject) || (!isPointerDown && isPointerInside && pointerEventData.pointerPress == base.gameObject) || (!isPointerDown && isPointerInside && pointerEventData.pointerPress == null));
			}
			return flag | isPointerInside;
		}

		protected bool IsPressed()
		{
			if (!IsActive())
			{
				return false;
			}
			if (isPointerInside)
			{
				return isPointerDown;
			}
			return false;
		}

		public virtual void Select()
		{
			if (!EventSystem.current.alreadySelecting)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				isPointerDown = true;
			}
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				isPointerDown = false;
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			isPointerInside = true;
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			isPointerInside = false;
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
			hasSelection = true;
		}

		public virtual void OnDeselect(BaseEventData eventData)
		{
			hasSelection = false;
		}
	}
}
