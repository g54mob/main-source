using CTS;

namespace ES3Types
{
	public class ES3UserType_LevelSettingsSecondaryMissionsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsSecondaryMissionsArray()
			: base(typeof(LevelSettingsSecondaryMissions[]), ES3UserType_LevelSettingsSecondaryMissions.Instance)
		{
			Instance = this;
		}
	}
}
