using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public struct ControlsSettingsSaveData
	{
		public string _rebindsJson;

		public ControlsSettingsSaveData(string rebindsJson)
		{
			_rebindsJson = rebindsJson;
		}
	}
}
