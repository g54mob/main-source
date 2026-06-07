using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class SettingsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public DisplaySettingsSaveData _displaySettingsSaveData;

		public AudioSettingsSaveData _audioSettingsSaveData;

		public ControlsSettingsSaveData _controlSettingsSaveData;

		public AccessibilitySettingsSaveData _accessibilitySettingsSaveData;

		public OtherSettingsSaveData _otherSettingsSaveData;

		public SettingsSaveData(DisplaySettingsSaveData displaySettingsSaveData, AudioSettingsSaveData audioSettingsSaveData, ControlsSettingsSaveData controlsSettingsSaveData, AccessibilitySettingsSaveData accessibilitySettingsSaveData, OtherSettingsSaveData otherSettingsSaveData)
			: base(0)
		{
			_displaySettingsSaveData = displaySettingsSaveData;
			_audioSettingsSaveData = audioSettingsSaveData;
			_controlSettingsSaveData = controlsSettingsSaveData;
			_accessibilitySettingsSaveData = accessibilitySettingsSaveData;
			_otherSettingsSaveData = otherSettingsSaveData;
		}
	}
}
