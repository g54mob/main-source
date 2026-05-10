using CTS;

namespace ES3Types
{
	public class ES3UserType_ProgressSaveSucessArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ProgressSaveSucessArray()
			: base(typeof(AchievementWatchers.ProgressSaveSucess[]), ES3UserType_ProgressSaveSucess.Instance)
		{
			Instance = this;
		}
	}
}
