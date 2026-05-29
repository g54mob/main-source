using CTS;

namespace ES3Types
{
	public class ES3UserType_MainQuest32Array : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainQuest32Array()
			: base(typeof(MainQuest32[]), ES3UserType_MainQuest32.Instance)
		{
			Instance = this;
		}
	}
}
