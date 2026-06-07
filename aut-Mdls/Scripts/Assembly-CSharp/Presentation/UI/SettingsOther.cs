using System;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.UI.Overlays;
using Integrations.Interfaces;
using Presentation.Locators;
using Presentation.UI.ButtonHelpers;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI
{
	public class SettingsOther : MonoBehaviour
	{
		[SerializeField]
		private Button _resetAllButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private Toggle _dataCollectionToggle;

		[SerializeField]
		private Toggle _showUserNameToggle;

		[SerializeField]
		private Toggle _runInBackgroundToggle;

		[SerializeField]
		private Toggle _autoSaveFlagToggle;

		[SerializeField]
		private Slider _autoSaveIntervalSlider;

		[SerializeField]
		private BoolVariableSO _autoSaveFlag;

		[SerializeField]
		private FloatVariableSO _autoSaveInterval;

		[SerializeField]
		private DataCollectionVariableSO _dataCollectionOptOut;

		[SerializeField]
		private BoolVariableSO _showUserName;

		[SerializeField]
		private RunInBackgroundSO _runInBackground;

		[SerializeField]
		private TextMeshProUGUI _termsText;

		[SerializeField]
		private TextLinkHelper _termsTextLink;

		[SerializeField]
		[LocaKey]
		private string _termsLinkKey;

		[SerializeField]
		[LocaKey]
		private string _privacyLinkKey;

		[SerializeField]
		private TextMeshProUGUI _modulusIDText;

		[SerializeField]
		private Button _copyToClipboardButton;

		[SerializeField]
		private Button _clearAllBreadcrumbsButton;

		[SerializeField]
		private BreadcrumbsPersistentSO _breadcrumbsPersistentSO;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		private void Start()
		{
			_resetAllButton.onClick.AddListener(HandleReset);
			SetInitialValues();
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_showUserNameToggle.onValueChanged.AddListener(OnShowUserNameChanged);
			_dataCollectionToggle.onValueChanged.AddListener(OnOptoutToggleChanged);
			_runInBackgroundToggle.onValueChanged.AddListener(OnRunInBackgroundToggleChanged);
			_autoSaveFlagToggle.onValueChanged.AddListener(OnAutoSaveToggleChanged);
			_autoSaveIntervalSlider.onValueChanged.AddListener(SetAutoSaveInterval);
			_copyToClipboardButton.onClick.AddListener(OnCopyToClipboardButtonClicked);
			_clearAllBreadcrumbsButton.onClick.AddListener(OnClearAllBreadcrumbButtonClicked);
			SetPrivacyText();
			SetModulusID();
			TextLinkHelper termsTextLink = _termsTextLink;
			termsTextLink.OnClick = (Action<string>)Delegate.Combine(termsTextLink.OnClick, new Action<string>(OnClickedLink));
			ICloudServiceHandler cloudService = _integrationManagerLocator.Integration.CloudService;
			cloudService.OnCloudServiceLoggedIn = (Action)Delegate.Combine(cloudService.OnCloudServiceLoggedIn, new Action(OnIntegrationsReady));
		}

		private void HandleReset()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.ResetSettingsGeneric", Sizes.S, ResetOther, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalWarning.ResetBindingsConfirmButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void ResetOther()
		{
			_autoSaveFlag.ResetToDefault();
			_autoSaveInterval.ResetToDefault();
			_dataCollectionOptOut.ResetToDefault();
			_showUserName.ResetToDefault();
			_runInBackground.ResetToDefault();
			SetInitialValues();
		}

		private void OnCopyToClipboardButtonClicked()
		{
			GUIUtility.systemCopyBuffer = _integrationManagerLocator.Integration.CloudService.GetCloudServiceUserId();
		}

		private void OnClearAllBreadcrumbButtonClicked()
		{
			_breadcrumbsPersistentSO.ClearAllStates();
		}

		private void OnClickedLink(string linkId)
		{
			if (!(linkId == "Privacy"))
			{
				if (linkId == "Terms")
				{
					_integrationManagerLocator.Integration.Platform.OpenWebPage(LocalizationUtility.GetLocalizedText(_termsLinkKey));
				}
			}
			else
			{
				_integrationManagerLocator.Integration.Platform.OpenWebPage(LocalizationUtility.GetLocalizedText(_privacyLinkKey));
			}
		}

		private void OnIntegrationsReady()
		{
			SetModulusID();
		}

		private void OnDestroy()
		{
			_resetAllButton.onClick.RemoveListener(HandleReset);
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
			_showUserNameToggle.onValueChanged.RemoveListener(OnShowUserNameChanged);
			_dataCollectionToggle.onValueChanged.RemoveListener(OnOptoutToggleChanged);
			_runInBackgroundToggle.onValueChanged.RemoveListener(OnRunInBackgroundToggleChanged);
			_copyToClipboardButton.onClick.RemoveListener(OnCopyToClipboardButtonClicked);
			_clearAllBreadcrumbsButton.onClick.RemoveListener(OnClearAllBreadcrumbButtonClicked);
			IPlatformHandler platform = _integrationManagerLocator.Integration.Platform;
			platform.OnPlatformReady = (Action)Delegate.Remove(platform.OnPlatformReady, new Action(OnIntegrationsReady));
			_autoSaveFlagToggle.onValueChanged.RemoveListener(OnAutoSaveToggleChanged);
			_autoSaveIntervalSlider.onValueChanged.RemoveListener(SetAutoSaveInterval);
		}

		private void SetInitialValues()
		{
			_dataCollectionToggle.isOn = !_dataCollectionOptOut.Value;
			_showUserNameToggle.isOn = _showUserName.Value;
			_runInBackgroundToggle.isOn = _runInBackground.Value;
			_autoSaveFlagToggle.isOn = _autoSaveFlag.Value;
			_autoSaveIntervalSlider.minValue = 5f;
			_autoSaveIntervalSlider.maxValue = 60f;
			_autoSaveIntervalSlider.value = _autoSaveInterval.Value;
		}

		private void OnLanguageUpdate()
		{
			SetModulusID();
			SetPrivacyText();
		}

		private void SetPrivacyText()
		{
			string arg = string.Format("<style=Link><link=\"Privacy\">{0}</link></style>", LocalizationUtility.GetLocalizedText("Settings.OtherPrivacyPolicy"));
			string arg2 = string.Format("<style=Link><link=\"Terms\">{0}</link></style>", LocalizationUtility.GetLocalizedText("Settings.OtherTermsOfService"));
			_termsText.SetText(string.Format(LocalizationUtility.GetLocalizedText("Settings.OtherReadLegal"), arg, arg2));
		}

		private void SetModulusID()
		{
			_modulusIDText.SetText(string.Format("{0}: {1}", LocalizationUtility.GetLocalizedText("Settings.ModulusID"), _integrationManagerLocator.Integration.CloudService.GetCloudServiceUserId()));
		}

		private void OnOptoutToggleChanged(bool value)
		{
			_dataCollectionOptOut.SetValue(!value);
		}

		private void OnAutoSaveToggleChanged(bool value)
		{
			_autoSaveFlag.SetValue(value);
		}

		private void SetAutoSaveInterval(float sliderValue)
		{
			if (sliderValue >= _autoSaveIntervalSlider.minValue && sliderValue <= _autoSaveIntervalSlider.maxValue)
			{
				_autoSaveInterval.SetValue(sliderValue);
			}
		}

		private void OnShowUserNameChanged(bool value)
		{
			_showUserName.SetValue(value);
		}

		private void OnRunInBackgroundToggleChanged(bool value)
		{
			_runInBackground.SetValue(value);
		}
	}
}
