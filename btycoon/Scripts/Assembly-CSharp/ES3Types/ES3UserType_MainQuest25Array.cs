using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest25Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest25Array()
			: base(typeof(MainQuest25[]), ES3UserType_MainQuest25.Instance)
		{
			Instance = this;
		}
	}
}
