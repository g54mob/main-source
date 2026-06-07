using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class AccessibilitySettingsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 3;

		public LanguageCode _languageCode;

		public float _cameraPanSensitivity;

		public float _cameraRotSensitivity;

		public float _cameraKeysRotSensitivity;

		public bool _darkModeIsActive;

		public List<string> _extraDeviceNames;

		public List<bool> _extraDeviceEnabled;

		public AccessibilitySettingsSaveData(LanguageCode languageCode, float cameraPanSensitivity, float cameraRotSensitivity, float cameraKeysRotSensitivity, bool darkModeIsActive, List<string> extraDeviceNames, List<bool> extraDeviceEnable)
			: base(3)
		{
			_languageCode = languageCode;
			_cameraPanSensitivity = cameraPanSensitivity;
			_cameraRotSensitivity = cameraRotSensitivity;
			_cameraKeysRotSensitivity = cameraKeysRotSensitivity;
			_darkModeIsActive = darkModeIsActive;
			_extraDeviceNames = extraDeviceNames;
			_extraDeviceEnabled = extraDeviceEnable;
		}
	}
}
