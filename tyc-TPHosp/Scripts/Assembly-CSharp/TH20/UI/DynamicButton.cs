using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TH20.UI
{
	public class DynamicButton : Selectable, ISubmitHandler, IEventSystemHandler
	{
		[Serializable]
		public class ButtonClickedEvent : UnityEvent
		{
		}

		[SerializeField]
		private ButtonClickedEvent _onPrimaryDown = new ButtonClickedEvent();

		[SerializeField]
		private ButtonClickedEvent _onSecondaryDown = new ButtonClickedEvent();

		[SerializeField]
		private ButtonClickedEvent _onPrimaryDownFailed = new ButtonClickedEvent();

		private TMP_Text _cachedTMPTextRef;

		public ButtonClickedEvent onPrimaryDown => _onPrimaryDown;

		public ButtonClickedEvent onSecondaryDown => _onSecondaryDown;

		public ButtonClickedEvent onPrimaryDownFailed => _onPrimaryDownFailed;

		protected DynamicButton()
		{
		}

		private void PrimaryPress()
		{
			if (IsActive())
			{
				if (!IsInteractable())
				{
					_onPrimaryDownFailed.Invoke();
				}
				else
				{
					_onPrimaryDown.Invoke();
				}
			}
		}

		private void SecondaryPress()
		{
			if (IsActive() && IsInteractable())
			{
				_onSecondaryDown.Invoke();
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				PrimaryPress();
			}
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				SecondaryPress();
			}
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			PrimaryPress();
			if (IsActive() && IsInteractable())
			{
				DoStateTransition(SelectionState.Pressed, instant: false);
				StartCoroutine(OnFinishSubmit());
			}
		}

		private IEnumerator OnFinishSubmit()
		{
			float fadeTime = base.colors.fadeDuration;
			float elapsedTime = 0f;
			while (elapsedTime < fadeTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				yield return null;
			}
			DoStateTransition(base.currentSelectionState, instant: false);
		}

		public void SetTMPText(string titleText)
		{
			if (_cachedTMPTextRef == null)
			{
				_cachedTMPTextRef = GetComponentInChildren<TMP_Text>();
			}
			if (_cachedTMPTextRef != null)
			{
				_cachedTMPTextRef.text = titleText;
			}
		}
	}
}
