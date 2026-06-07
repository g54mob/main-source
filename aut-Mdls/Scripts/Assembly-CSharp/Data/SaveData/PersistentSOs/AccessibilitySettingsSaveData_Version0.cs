using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class AccessibilitySettingsSaveData_Version0 : IPreviousSaveVersion, ISaveVersion
	{
		public LanguageCode _languageCode;

		public ISaveVersion ToNextVersion()
		{
			return new AccessibilitySettingsSaveData_Version2(_languageCode, 1f, 1f, 3f, darkModeIsActive: false);
		}
	}
}
