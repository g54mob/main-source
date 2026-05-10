using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest27Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest27Array()
			: base(typeof(MainQuest27[]), ES3UserType_MainQuest27.Instance)
		{
			Instance = this;
		}
	}
}
