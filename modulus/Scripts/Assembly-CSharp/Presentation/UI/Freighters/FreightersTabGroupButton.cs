using System;
using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.Freighters
{
	public class FreightersTabGroupButton : TabGroupButton
	{
		[SerializeField]
		private Button _backToListButton;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private BoolVariableSO _unsavedFreighterChanges;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private BoolVariableSO _freightersControlMode;

		private const string _titleListLocaKey = "FreightersUI.Title";

		private const string _titleControlLocaKey = "FreightersUI.ControlTitle";

		private const string _popupUnsavedChangesLocaKey = "FreightersUI.UnsavedChanges";

		private const string _popupUnsavedChangesSuccessButtonLocaKey = "ModalGeneric.AcceptButton";

		private string _titleList;

		private string _titleControl;

		protected override void Awake()
		{
			base.Awake();
			_backToListButton.onClick.AddListener(TryBackToList);
			_selectedFreighterInUI.ValueChanged += SelectedFreighterChanged;
			_freightersControlMode.ValueChanged += SetControlMode;
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpate;
			OnLanguageUpate();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_backToListButton.onClick.RemoveListener(TryBackToList);
			_selectedFreighterInUI.ValueChanged -= SelectedFreighterChanged;
			_freightersControlMode.ValueChanged -= SetControlMode;
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpate;
		}

		private void OnLanguageUpate()
		{
			_titleList = LocalizationUtility.GetLocalizedText("FreightersUI.Title");
			_titleControl = LocalizationUtility.GetLocalizedText("FreightersUI.ControlTitle");
			SetTitle();
		}

		private void SetTitle()
		{
			_titleText.SetText(_freightersControlMode.Value ? _titleControl : _titleList);
		}

		public override void Cancel()
		{
			_unsavedFreighterChanges.SetValue(value: false);
		}

		protected override void OnCloseButtonClicked()
		{
			TryCanClose(base.OnCloseButtonClicked);
		}

		protected override void SetActive(bool active)
		{
			if (!active)
			{
				_freightersControlMode.SetValue(value: false);
			}
			base.SetActive(active);
		}

		private void SetControlMode(bool value)
		{
			_backToListButton.gameObject.SetActive(value);
			_titleText.SetText(value ? _titleControl : _titleList);
		}

		private void TryBackToList()
		{
			TryCanClose(BackToList);
		}

		private void BackToList()
		{
			_freightersControlMode.SetValue(value: false);
		}

		private void SelectedFreighterChanged(int selectedFreighter)
		{
			SetControlMode(selectedFreighter >= 0);
		}

		private void UnsavedChangesPrompt(Action successMethod)
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("FreightersUI.UnsavedChanges", Sizes.S, successMethod, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		public override bool TryCanClose(Action successMethod = null)
		{
			if (_unsavedFreighterChanges.Value)
			{
				UnsavedChangesPrompt(OnUnsavedChangesPromptSuccess(successMethod));
				return false;
			}
			successMethod?.Invoke();
			return true;
		}

		private Action OnUnsavedChangesPromptSuccess(Action successMethod)
		{
			return delegate
			{
				_unsavedFreighterChanges.SetValue(value: false);
				successMethod?.Invoke();
			};
		}
	}
}
