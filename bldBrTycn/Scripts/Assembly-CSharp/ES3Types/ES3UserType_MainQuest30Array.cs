using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest30Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest30Array()
			: base(typeof(MainQuest30[]), ES3UserType_MainQuest30.Instance)
		{
			Instance = this;
		}
	}
}
