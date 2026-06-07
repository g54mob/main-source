using System;
using Factory;
using Motorways.UI;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class TwoButtonPrompt : MonoBehaviour
	{
		public RectTransform twoButtonDialogPanel;

		public LocalizedTextUI dialogMessageText;

		public VariableDeviceSelectable cancelButton;

		public VariableDeviceSelectable confirmButton;

		public TouchButton backButton;

		protected Action _onCancelActivated;

		protected Action _onConfirmActivated;

		private BaseScalingScreen _originalScreen;

		public void ShowSinglePromptConfirmation(IScope scope, BaseScalingScreen originalScreen, StringId messageTextId, Action onCancel, Action onConfirm)
		{
			ShowTwoPromptConfirmation(scope, originalScreen, messageTextId, onCancel, onConfirm);
			cancelButton.gameObject.SetActive(value: false);
			confirmButton.gameObject.SetActive(value: true);
		}

		public void ShowTwoPromptConfirmation(IScope scope, BaseScalingScreen originalScreen, StringId messageTextId, Action onCancel, Action onConfirm, bool selectConfirmByDefault = true)
		{
			twoButtonDialogPanel.gameObject.SetActive(value: true);
			StandaloneLocString locString = StandaloneLocString.CreateString(scope, messageTextId);
			dialogMessageText.LocString = locString;
			_onCancelActivated = onCancel;
			_onConfirmActivated = onConfirm;
			_originalScreen = originalScreen;
			_originalScreen.previousBackButton = _originalScreen.backButton;
			_originalScreen.backButton = backButton;
			cancelButton.gameObject.SetActive(value: true);
			confirmButton.gameObject.SetActive(value: true);
			LocaleDatabase localeDatabase = scope.Get<LocaleDatabase>();
			if (scope.Get<LocaleDatabase>().CurrentLocale.TextDirection == TextDirection.RightToLeft)
			{
				if (confirmButton.transform.GetSiblingIndex() > cancelButton.transform.GetSiblingIndex())
				{
					confirmButton.transform.SetSiblingIndex(cancelButton.transform.GetSiblingIndex());
				}
			}
			else if (confirmButton.transform.GetSiblingIndex() < cancelButton.transform.GetSiblingIndex())
			{
				confirmButton.transform.SetSiblingIndex(cancelButton.transform.GetSiblingIndex());
			}
			localeDatabase.AddLocalizedObject(dialogMessageText);
			if (scope.Get<InputState>().CurrentInputTypeRequiresFocus)
			{
				scope.Get<MenuNavigation>()?.SetNewFocus(selectConfirmByDefault ? confirmButton : cancelButton);
			}
		}

		public void OnCancelActivated()
		{
			if (Diagnostics.Verify(_onCancelActivated != null))
			{
				_onCancelActivated();
			}
		}

		public void OnConfirmActivated()
		{
			if (Diagnostics.Verify(_onConfirmActivated != null))
			{
				_onConfirmActivated();
			}
		}

		public void HidePrompt(IScope scope)
		{
			if (twoButtonDialogPanel.gameObject.activeInHierarchy)
			{
				_originalScreen.backButton = _originalScreen.previousBackButton;
				twoButtonDialogPanel.gameObject.SetActive(value: false);
				scope.Get<LocaleDatabase>().RemoveLocalizedObject(dialogMessageText);
				_onCancelActivated = null;
				_onConfirmActivated = null;
			}
		}
	}
}
