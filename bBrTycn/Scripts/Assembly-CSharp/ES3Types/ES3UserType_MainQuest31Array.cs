using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest31Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest31Array()
			: base(typeof(MainQuest31[]), ES3UserType_MainQuest31.Instance)
		{
			Instance = this;
		}
	}
}
