using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest29Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest29Array()
			: base(typeof(MainQuest29[]), ES3UserType_MainQuest29.Instance)
		{
			Instance = this;
		}
	}
}
