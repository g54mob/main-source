using NSEipix.Base;
using NSMedieval.Sound;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSEipix.View.UI
{
	public class CustomToggle : Toggle
	{
		public class NonInteractableClickedEvent : UnityEvent
		{
		}

		private NonInteractableClickedEvent _nonInteractableClickEvent = new NonInteractableClickedEvent();

		private bool clicked;

		public NonInteractableClickedEvent onNonInteractableClick
		{
			get
			{
				return _nonInteractableClickEvent;
			}
			set
			{
				_nonInteractableClickEvent = value;
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				InternalToggle();
				if (IsInteractable())
				{
					string soundID = (base.isOn ? "UI_ToggleOn" : "UI_ToggleOff");
					MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
				}
				else
				{
					_nonInteractableClickEvent?.Invoke();
				}
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (IsInteractable())
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonHover");
			}
		}

		protected void InternalToggle()
		{
			if (IsActive() && IsInteractable())
			{
				SetValue(!base.isOn);
			}
		}

		public virtual void SetValue(bool isOn)
		{
			base.isOn = isOn;
		}
	}
}
