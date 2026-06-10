using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI.Extensions;

namespace NSEipix.View.UI
{
	public class CustomRangeSlider : RangeSlider
	{
		public class NonInteractableClickedEvent : UnityEvent
		{
		}

		private NonInteractableClickedEvent nonInteractableClickEvent = new NonInteractableClickedEvent();

		public NonInteractableClickedEvent NonInteractableClickEvent
		{
			get
			{
				return nonInteractableClickEvent;
			}
			set
			{
				nonInteractableClickEvent = value;
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				nonInteractableClickEvent?.Invoke();
			}
			base.OnPointerDown(eventData);
		}
	}
}
