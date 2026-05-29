using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest02Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest02Array()
			: base(typeof(MainQuest02[]), ES3UserType_MainQuest02.Instance)
		{
			Instance = this;
		}
	}
}
