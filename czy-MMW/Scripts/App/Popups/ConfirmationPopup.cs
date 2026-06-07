using System;
using Factory;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
	public class ConfirmationPopup : AbstractConfirmationPopup
	{
		[SerializeField]
		private TouchButton _yesButton;

		[SerializeField]
		private LocalizedTextUI _mainPromptText;

		[SerializeField]
		private LocalizedTextUI _additionalText;

		[Dependency]
		private PopupStack _popupStack;

		private Action _onNoPressed;

		private Action _onYesPressed;

		public override void Initialise(IScope scope, StringId mainPromptStringId, Action onNoPressed, Action onYesPressed, StringId additionalInfoStringId = StringId.None)
		{
			_mainPromptText.SetStringId(scope, mainPromptStringId);
			_onNoPressed = onNoPressed;
			_onYesPressed = onYesPressed;
			_yesButton.gameObject.SetActive(value: true);
			SetAdditionalInfo(scope, additionalInfoStringId);
		}

		public override void Initialise(IScope scope, StringId mainPromptStringId, Action onClosed, StringId additionalInfoStringId = StringId.None)
		{
			_mainPromptText.SetStringId(scope, mainPromptStringId);
			_onNoPressed = onClosed;
			_yesButton.gameObject.SetActive(value: false);
			SetAdditionalInfo(scope, additionalInfoStringId);
		}

		private void SetAdditionalInfo(IScope scope, StringId additionalInfoStringId)
		{
			if (additionalInfoStringId != StringId.None)
			{
				_additionalText.gameObject.SetActive(value: true);
				_additionalText.SetStringId(scope, additionalInfoStringId);
			}
			else
			{
				_additionalText.gameObject.SetActive(value: false);
			}
		}

		public void NoPressed()
		{
			_popupStack.PopPopup();
			_onNoPressed?.Invoke();
		}

		public void YesPressed()
		{
			_popupStack.PopPopup();
			_onYesPressed?.Invoke();
		}
	}
}
