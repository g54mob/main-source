using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest24Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest24Array()
			: base(typeof(MainQuest24[]), ES3UserType_MainQuest24.Instance)
		{
			Instance = this;
		}
	}
}
