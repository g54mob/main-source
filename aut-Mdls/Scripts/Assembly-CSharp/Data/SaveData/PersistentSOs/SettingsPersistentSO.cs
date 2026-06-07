#define ENABLE_DEBUG_ERRORS
using Data.UI.Controls;
using Data.Variables;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Settings", fileName = "SettingsPersistentSO", order = 0)]
	public class SettingsPersistentSO : AbstractPersistentSO
	{
		[Header("Display")]
		[SerializeField]
		private ResolutionSO _resolutionSO;

		[SerializeField]
		private AllowedFullscreenModeSO _allowedFullscreenMode;

		[SerializeField]
		private QualityLevelSO _qualityLevel;

		[SerializeField]
		private RenderScaleSO _renderScale;

		[SerializeField]
		private BoolVariableSO _limitFrameRate;

		[SerializeField]
		private TargetFrameRateSO _targetFrameRate;

		[SerializeField]
		private VSyncSO _vSync;

		[SerializeField]
		private TiltShiftSO _tiltShift;

		[SerializeField]
		private ModulesOutlineSO _modulesOutline;

		[SerializeField]
		private MaxZoomLevelModifierSO _maxZoomLevelModifier;

		[Header("Audio")]
		[SerializeField]
		private FloatVariableSO _masterVolume;

		[SerializeField]
		private FloatVariableSO _musicVolume;

		[SerializeField]
		private FloatVariableSO _sfxVolume;

		[Header("Controls")]
		[SerializeField]
		private InputActionAsset _inputActions;

		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[Header("Accessibility")]
		[SerializeField]
		private LanguageCodeVariableSO _languageSO;

		[SerializeField]
		private ConnectedExtraDevicesSO _connectedExtraDevicesSo;

		[SerializeField]
		private FloatVariableSO _cameraRotSensitivity;

		[SerializeField]
		private FloatVariableSO _cameraKeysRotSensitivity;

		[SerializeField]
		private FloatVariableSO _cameraPanSensitivity;

		[SerializeField]
		private BoolVariableSO _darkModeIsActive;

		[Header("Other")]
		[SerializeField]
		private DataCollectionVariableSO _dataCollectionOptOut;

		[SerializeField]
		private BoolVariableSO _showUserName;

		[SerializeField]
		private RunInBackgroundSO _runInBackground;

		[SerializeField]
		private FloatVariableSO _autoSaveInterval;

		[SerializeField]
		private BoolVariableSO _autoSaveFlag;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (!(saveData is SettingsSaveData settingsSaveData))
			{
				this.LogError("Could not convert savedata to settings-savedata", "ApplyLoadedSaveData", 55);
				return;
			}
			ApplyDisplaySettings(settingsSaveData._displaySettingsSaveData);
			ApplyAudioSettings(settingsSaveData._audioSettingsSaveData);
			ApplyControlSettings(settingsSaveData._controlSettingsSaveData);
			ApplyAccessibilitySettings(settingsSaveData._accessibilitySettingsSaveData);
			ApplyOtherSettings(settingsSaveData._otherSettingsSaveData);
		}

		protected override void ApplyNoSaveData()
		{
			_rebindInfo.Initialize();
		}

		private void ApplyDisplaySettings(DisplaySettingsSaveData displaySettingsSaveData)
		{
			_qualityLevel.SetValue(displaySettingsSaveData._qualityLevel);
			_renderScale.SetValue(displaySettingsSaveData._renderScale);
			_limitFrameRate.SetValue(displaySettingsSaveData._limitFrameRate);
			_targetFrameRate.SetValue(displaySettingsSaveData._targetFrameRate);
			_vSync.SetValue(displaySettingsSaveData._vSync);
			_tiltShift.SetValue(displaySettingsSaveData._tiltShift);
			_modulesOutline.SetValue(displaySettingsSaveData._modulesOutline);
			_maxZoomLevelModifier.SetValue(displaySettingsSaveData._maxZoomLevelModifier);
		}

		private void ApplyAudioSettings(AudioSettingsSaveData audioSettingsSaveData)
		{
			_masterVolume.SetValue(audioSettingsSaveData._masterVolume);
			_musicVolume.SetValue(audioSettingsSaveData._musicVolume);
			_sfxVolume.SetValue(audioSettingsSaveData._sfxVolume);
		}

		private void ApplyControlSettings(ControlsSettingsSaveData controlSettingsSaveData)
		{
			if (!string.IsNullOrEmpty(controlSettingsSaveData._rebindsJson))
			{
				_inputActions.LoadBindingOverridesFromJson(controlSettingsSaveData._rebindsJson);
			}
			_rebindInfo.Initialize();
		}

		private void ApplyAccessibilitySettings(AccessibilitySettingsSaveData accessibilitySettingsSaveData)
		{
			_languageSO.SetValue(accessibilitySettingsSaveData._languageCode);
			_cameraPanSensitivity.SetValue(accessibilitySettingsSaveData._cameraPanSensitivity);
			_cameraRotSensitivity.SetValue(accessibilitySettingsSaveData._cameraRotSensitivity);
			_cameraKeysRotSensitivity.SetValue(accessibilitySettingsSaveData._cameraKeysRotSensitivity);
			_darkModeIsActive.SetValue(accessibilitySettingsSaveData._darkModeIsActive);
			_connectedExtraDevicesSo.ApplySaveDataConnectedDevices(accessibilitySettingsSaveData._extraDeviceNames, accessibilitySettingsSaveData._extraDeviceEnabled);
		}

		private void ApplyOtherSettings(OtherSettingsSaveData otherSettingsSaveData)
		{
			_dataCollectionOptOut.SetValue(otherSettingsSaveData._dataCollectionOptout);
			_showUserName.SetValue(otherSettingsSaveData._showUserName);
			_runInBackground.SetValue(otherSettingsSaveData._runInBackground);
			_autoSaveInterval.SetValue(otherSettingsSaveData._autoSaveInterval);
			_autoSaveFlag.SetValue(otherSettingsSaveData._autoSaveFlag);
		}

		public override void ResetToDefaults()
		{
			_qualityLevel.ResetToDefault();
			_renderScale.ResetToDefault();
			_limitFrameRate.ResetToDefault();
			_targetFrameRate.ResetToDefault();
			_vSync.ResetToDefault();
			_tiltShift.ResetToDefault();
			_modulesOutline.ResetToDefault();
			_masterVolume.ResetToDefault();
			_musicVolume.ResetToDefault();
			_cameraPanSensitivity.ResetToDefault();
			_cameraKeysRotSensitivity.ResetToDefault();
			_cameraRotSensitivity.ResetToDefault();
			_sfxVolume.ResetToDefault();
			_languageSO.ResetToDefault();
			_connectedExtraDevicesSo.ResetToDefault();
			_darkModeIsActive.ResetToDefault();
			_dataCollectionOptOut.ResetToDefault();
			_showUserName.ResetToDefault();
			_runInBackground.ResetToDefault();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new SettingsSaveData(new DisplaySettingsSaveData(_qualityLevel.Value, _renderScale.Value, _limitFrameRate.Value, _targetFrameRate.Value, _vSync.Value, _tiltShift.Value, _maxZoomLevelModifier.Value, _modulesOutline.Value), new AudioSettingsSaveData(_masterVolume.Value, _musicVolume.Value, _sfxVolume.Value), new ControlsSettingsSaveData(_inputActions.SaveBindingOverridesAsJson()), new AccessibilitySettingsSaveData(_languageSO.Value, _cameraPanSensitivity.Value, _cameraRotSensitivity.Value, _cameraKeysRotSensitivity.Value, _darkModeIsActive.Value, _connectedExtraDevicesSo.GetSavedDeviceNames(), _connectedExtraDevicesSo.GetSavedDeviceEnable()), new OtherSettingsSaveData(_dataCollectionOptOut.Value, _showUserName.Value, _runInBackground.Value, _autoSaveInterval.Value, _autoSaveFlag.Value));
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<SettingsSaveData>(fullPath);
		}
	}
}
