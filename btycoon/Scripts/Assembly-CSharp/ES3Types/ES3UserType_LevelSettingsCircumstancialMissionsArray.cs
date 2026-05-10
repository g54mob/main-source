using CTS;

namespace ES3Types
{
	public class ES3UserType_LevelSettingsCircumstancialMissionsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsCircumstancialMissionsArray()
			: base(typeof(LevelSettingsCircumstantialMissions[]), ES3UserType_LevelSettingsCircumstantialMissions.Instance)
		{
			Instance = this;
		}
	}
}
