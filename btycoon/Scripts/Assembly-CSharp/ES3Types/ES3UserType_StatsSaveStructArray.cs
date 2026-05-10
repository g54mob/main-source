using CTS;

namespace ES3Types
{
	public class ES3UserType_StatsSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StatsSaveStructArray()
			: base(typeof(StatsSaveStruct[]), ES3UserType_StatsSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
