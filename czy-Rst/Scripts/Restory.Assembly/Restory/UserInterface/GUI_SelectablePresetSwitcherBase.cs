using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UserInterface
{
	public abstract class GUI_SelectablePresetSwitcherBase : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		[SerializeField]
		private bool trackSelectableInteractable;

		protected bool isInteractable = true;

		protected bool isPointerDown;

		public bool IsInteractable
		{
			get
			{
				return isInteractable;
			}
			set
			{
				if (trackSelectableInteractable)
				{
					Debug.LogError($"[{this}] has its 'IsInteractable' property set privately, by tracking the selectable's 'interactable' property. To switch it to being set via this public property, untick the 'Track Selectable Interactable' in Inspector.", base.gameObject);
				}
				else
				{
					SetInteractableState(value);
				}
			}
		}

		protected virtual bool IsPointerInside { get; set; }

		protected virtual bool HasSelection { get; set; }

		protected virtual void OnEnable()
		{
			UpdateVisuals(instantly: true);
		}

		protected virtual void OnDisable()
		{
			InstantClearState();
		}

		protected virtual void Update()
		{
			if (trackSelectableInteractable)
			{
				CheckInteractable();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isPointerDown = true;
			UpdateVisuals();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			isPointerDown = false;
			UpdateVisuals();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			IsPointerInside = true;
			UpdateVisuals();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			IsPointerInside = false;
			UpdateVisuals();
		}

		public void OnSelect(BaseEventData eventData)
		{
			HasSelection = true;
			UpdateVisuals();
		}

		public void OnDeselect(BaseEventData eventData)
		{
			HasSelection = false;
			UpdateVisuals();
		}

		protected void SetInteractableState(bool value)
		{
			if (value != isInteractable)
			{
				isInteractable = value;
				UpdateVisuals();
			}
		}

		protected abstract void CheckInteractable();

		public abstract void UpdateVisuals(bool instantly = false);

		protected virtual void InstantClearState()
		{
			IsPointerInside = false;
			isPointerDown = false;
			HasSelection = false;
			UpdateVisuals();
		}
	}
}
