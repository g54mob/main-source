using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest23Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest23Array()
			: base(typeof(MainQuest23[]), ES3UserType_MainQuest23.Instance)
		{
			Instance = this;
		}
	}
}
