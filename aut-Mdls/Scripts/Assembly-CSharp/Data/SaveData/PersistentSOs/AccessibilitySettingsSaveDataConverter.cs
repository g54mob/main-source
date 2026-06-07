using System;

namespace Data.SaveData.PersistentSOs
{
	public class AccessibilitySettingsSaveDataConverter : SaveDataConverter<AccessibilitySettingsSaveData>
	{
		public AccessibilitySettingsSaveDataConverter()
			: base(3)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			return version switch
			{
				0 => typeof(AccessibilitySettingsSaveData_Version0), 
				1 => typeof(AccessibilitySettingsSaveData_Version1), 
				2 => typeof(AccessibilitySettingsSaveData_Version2), 
				_ => null, 
			};
		}
	}
}
