using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class AccessibilitySettingsSaveData_Version2 : IPreviousSaveVersion, ISaveVersion
	{
		public LanguageCode _languageCode;

		public float _cameraPanSensitivity;

		public float _cameraRotSensitivity;

		public float _cameraKeysRotSensitivity;

		public bool _darkModeIsActive;

		public AccessibilitySettingsSaveData_Version2(LanguageCode languageCode, float cameraPanSensitivity, float cameraRotSensitivity, float cameraKeysRotSensitivity, bool darkModeIsActive)
		{
			_languageCode = languageCode;
			_cameraPanSensitivity = cameraPanSensitivity;
			_cameraRotSensitivity = cameraRotSensitivity;
			_cameraKeysRotSensitivity = cameraKeysRotSensitivity;
			_darkModeIsActive = darkModeIsActive;
		}

		public ISaveVersion ToNextVersion()
		{
			return new AccessibilitySettingsSaveData(_languageCode, _cameraPanSensitivity, _cameraRotSensitivity, _cameraKeysRotSensitivity, _darkModeIsActive, new List<string>(), new List<bool>());
		}
	}
}
