using System.Collections.Generic;
using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI
{
	public class SettingsAccessibility : MonoBehaviour
	{
		[SerializeField]
		private Button _resetAllButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private TMP_Dropdown _languageDropdown;

		[SerializeField]
		private TMP_Dropdown _extraConnectedDevicesDropdown;

		[SerializeField]
		private LanguageCodeVariableSO _languageSO;

		[SerializeField]
		private ConnectedExtraDevicesSO _connectedExtraDevicesSo;

		[SerializeField]
		private Slider _cameraPanSlider;

		[SerializeField]
		private Slider _cameraRotSlider;

		[SerializeField]
		private Slider _cameraKeysRotSlider;

		[SerializeField]
		private FloatVariableSO _cameraPanSensitivity;

		[SerializeField]
		private FloatVariableSO _cameraRotSensitivity;

		[SerializeField]
		private FloatVariableSO _cameraKeysRotSensitivity;

		[SerializeField]
		private BoolVariableSO _darkModeIsActive;

		[SerializeField]
		private Toggle _darkModeToggle;

		private void Awake()
		{
			BuildLanguageDropdown();
			BuildExtraDevicesDropdown();
			SetInitialValues();
		}

		private void Start()
		{
			_resetAllButton.onClick.AddListener(HandleReset);
			_languageDropdown.onValueChanged.AddListener(SetLanguageByIndex);
			_extraConnectedDevicesDropdown.onValueChanged.AddListener(SetExtraDevicesBitMask);
			_connectedExtraDevicesSo.OnConnectedDevicesUpdate += OnInputConnectedDevicesUpdate;
			_cameraPanSlider.onValueChanged.AddListener(OnCameraPanSensitivityChanged);
			_cameraRotSlider.onValueChanged.AddListener(OnCameraRotSensitivityChanged);
			_cameraKeysRotSlider.onValueChanged.AddListener(OnCameraKeysRotSensitivityChanged);
			_darkModeToggle.onValueChanged.AddListener(OnDarkModeToggleChanged);
		}

		private void OnInputConnectedDevicesUpdate()
		{
			BuildExtraDevicesDropdown();
			_extraConnectedDevicesDropdown.SetValueWithoutNotify(_connectedExtraDevicesSo.GetInputsBitmask());
		}

		private void HandleReset()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("ModalWarning.Title", "ModalWarning.ResetSettingsGeneric", Sizes.S, ResetAccessibility, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalWarning.ResetBindingsConfirmButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void ResetAccessibility()
		{
			_languageSO.ResetToDefault();
			_cameraPanSensitivity.ResetToDefault();
			_cameraRotSensitivity.ResetToDefault();
			_cameraKeysRotSensitivity.ResetToDefault();
			_darkModeIsActive.ResetToDefault();
			_connectedExtraDevicesSo.ResetToDefault();
			SetInitialValues();
		}

		private void OnCameraPanSensitivityChanged(float newValue)
		{
			_cameraPanSensitivity.SetValue(newValue);
		}

		private void OnCameraRotSensitivityChanged(float newValue)
		{
			_cameraRotSensitivity.SetValue(newValue);
		}

		private void OnCameraKeysRotSensitivityChanged(float newValue)
		{
			_cameraKeysRotSensitivity.SetValue(newValue);
		}

		private void OnDarkModeToggleChanged(bool newValue)
		{
			_darkModeIsActive.SetValue(newValue);
		}

		private void SetInitialValues()
		{
			_cameraPanSlider.SetValueWithoutNotify(_cameraPanSensitivity.Value);
			_cameraRotSlider.SetValueWithoutNotify(_cameraRotSensitivity.Value);
			_cameraKeysRotSlider.SetValueWithoutNotify(_cameraKeysRotSensitivity.Value);
			_darkModeToggle.SetIsOnWithoutNotify(_darkModeIsActive.Value);
			_extraConnectedDevicesDropdown.SetValueWithoutNotify(_connectedExtraDevicesSo.GetInputsBitmask());
			int num = 0;
			foreach (LocalizedLanguage language in LocalizationUtility.Settings.Languages)
			{
				if (language.IsActive)
				{
					if (language.LanguageCode == _languageSO.Value)
					{
						_languageDropdown.SetValueWithoutNotify(num);
						break;
					}
					num++;
				}
			}
		}

		private void BuildLanguageDropdown()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			_languageDropdown.options.Clear();
			foreach (LocalizedLanguage language in LocalizationUtility.Settings.Languages)
			{
				if (language.IsActive)
				{
					list.Add(new TMP_Dropdown.OptionData(language.Name));
				}
			}
			_languageDropdown.options = list;
		}

		public void SetLanguageByIndex(int index)
		{
			string text = _languageDropdown.options[index].text;
			if (text == "PSEUDO")
			{
				_languageSO.SetValue(LanguageCode.PSEUDO);
				return;
			}
			foreach (LocalizedLanguage language in LocalizationUtility.Settings.Languages)
			{
				if (language.IsActive && language.Name == text)
				{
					LanguageCode languageCode = language.LanguageCode;
					if (languageCode != LocalizationUtility.CurrentLanguage)
					{
						_languageSO.SetValue(languageCode);
					}
					break;
				}
			}
		}

		private void BuildExtraDevicesDropdown()
		{
			_extraConnectedDevicesDropdown.ClearOptions();
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			foreach (InputDevice currentlyConnectedDevice in _connectedExtraDevicesSo.GetCurrentlyConnectedDevices())
			{
				list.Add(new TMP_Dropdown.OptionData(currentlyConnectedDevice.name));
			}
			_extraConnectedDevicesDropdown.AddOptions(list);
		}

		private void SetExtraDevicesBitMask(int bitmask)
		{
			_connectedExtraDevicesSo.TrySetConnectedDevices(bitmask);
			_extraConnectedDevicesDropdown.SetValueWithoutNotify(_connectedExtraDevicesSo.GetInputsBitmask());
		}

		private void OnDestroy()
		{
			_resetAllButton.onClick.RemoveListener(HandleReset);
			_languageDropdown.onValueChanged.RemoveListener(SetLanguageByIndex);
			_cameraPanSlider.onValueChanged.RemoveListener(OnCameraPanSensitivityChanged);
			_cameraRotSlider.onValueChanged.RemoveListener(OnCameraRotSensitivityChanged);
			_cameraKeysRotSlider.onValueChanged.RemoveListener(OnCameraKeysRotSensitivityChanged);
			_darkModeToggle.onValueChanged.RemoveListener(OnDarkModeToggleChanged);
			_extraConnectedDevicesDropdown.onValueChanged.RemoveListener(SetExtraDevicesBitMask);
			_connectedExtraDevicesSo.OnConnectedDevicesUpdate -= OnInputConnectedDevicesUpdate;
		}
	}
}
