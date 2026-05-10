using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest28Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest28Array()
			: base(typeof(MainQuest28[]), ES3UserType_MainQuest28.Instance)
		{
			Instance = this;
		}
	}
}
