using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest26Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest26Array()
			: base(typeof(MainQuest26[]), ES3UserType_MainQuest26.Instance)
		{
			Instance = this;
		}
	}
}
