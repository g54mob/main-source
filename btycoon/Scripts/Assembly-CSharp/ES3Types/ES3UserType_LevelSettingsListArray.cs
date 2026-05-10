using CTS;

namespace ES3Types
{
	public class ES3UserType_LevelSettingsListArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsListArray()
			: base(typeof(LevelSettingsList[]), ES3UserType_LevelSettingsList.Instance)
		{
			Instance = this;
		}
	}
}
