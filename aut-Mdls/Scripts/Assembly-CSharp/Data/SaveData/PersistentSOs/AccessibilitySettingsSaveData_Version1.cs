using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class AccessibilitySettingsSaveData_Version1 : IPreviousSaveVersion, ISaveVersion
	{
		public LanguageCode _languageCode;

		public float _cameraPanSensitivity;

		public float _cameraRotSensitivity;

		public bool _darkModeIsActive;

		public ISaveVersion ToNextVersion()
		{
			return new AccessibilitySettingsSaveData_Version2(_languageCode, _cameraPanSensitivity, _cameraRotSensitivity, 3f, _darkModeIsActive);
		}
	}
}
