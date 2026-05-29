using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest10Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest10Array()
			: base(typeof(MainQuest10[]), ES3UserType_MainQuest10.Instance)
		{
			Instance = this;
		}
	}
}
