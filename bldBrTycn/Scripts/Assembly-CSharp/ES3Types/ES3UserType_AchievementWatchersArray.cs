using CTS;

namespace ES3Types
{
	public class ES3UserType_AchievementWatchersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AchievementWatchersArray()
			: base(typeof(AchievementWatchers[]), ES3UserType_AchievementWatchers.Instance)
		{
			Instance = this;
		}
	}
}
