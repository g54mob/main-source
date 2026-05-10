using CTS;

namespace ES3Types
{
	public class ES3UserType_VigilanceStatsSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_VigilanceStatsSaveStructArray()
			: base(typeof(VigilanceStatsSaveStruct[]), ES3UserType_VigilanceStatsSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
