using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_Interactable : UIBehaviour
	{
		[SerializeField]
		private bool interactable = true;

		[SerializeField]
		private UnityEvent isInteractableChanged;

		private bool groupsAllowInteraction = true;

		private readonly List<CanvasGroup> canvasGroupCache = new List<CanvasGroup>();

		public bool Interactable
		{
			get
			{
				return interactable;
			}
			set
			{
				if (interactable != value)
				{
					interactable = value;
					isInteractableChanged?.Invoke();
				}
			}
		}

		public event UnityAction IsInteractableChanged
		{
			add
			{
				isInteractableChanged.AddListener(value);
			}
			remove
			{
				isInteractableChanged.RemoveListener(value);
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

		protected override void OnEnable()
		{
			base.OnEnable();
			OnCanvasGroupChanged();
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			OnCanvasGroupChanged();
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
				isInteractableChanged?.Invoke();
			}
		}
	}
}
