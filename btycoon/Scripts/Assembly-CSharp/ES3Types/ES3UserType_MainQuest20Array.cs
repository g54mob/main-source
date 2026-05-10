using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest20Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest20Array()
			: base(typeof(MainQuest20[]), ES3UserType_MainQuest20.Instance)
		{
			Instance = this;
		}
	}
}
