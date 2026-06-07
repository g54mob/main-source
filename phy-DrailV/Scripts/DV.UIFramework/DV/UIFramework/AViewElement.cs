using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UIFramework
{
	[RequireComponent(typeof(IMarkable))]
	public abstract class AViewElement<T> : NullCheckingMonoBehaviour, ISelectHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public event Action<AViewElement<T>> SelectionRequested;

		public event Action<AViewElement<T>, bool> HoverChanged;

		public virtual void SetSelected(bool selected)
		{
			if (TryGetComponent<IMarkable>(out var component))
			{
				component.ToggleMarked(selected);
			}
		}

		public virtual void SetInteractable(bool interactable)
		{
			if (TryGetComponent<IMarkable>(out var component))
			{
				component.ToggleInteractable(interactable);
			}
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
			this.SelectionRequested?.Invoke(this);
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			this.HoverChanged?.Invoke(this, arg2: true);
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			this.HoverChanged?.Invoke(this, arg2: false);
		}

		public abstract void SetData(T data, AGridView<T> parentView);
	}
}
