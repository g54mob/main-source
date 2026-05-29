using CTS;

namespace ES3Types
{
	public class ES3UserType_LevelSettingsUseMapLoaderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsUseMapLoaderArray()
			: base(typeof(LevelSettingsUseMapLoader[]), ES3UserType_LevelSettingsUseMapLoader.Instance)
		{
			Instance = this;
		}
	}
}
