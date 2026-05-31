using CTS;

namespace ES3Types
{
	public class ES3UserType_ReviewMounthSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewMounthSaveStructArray()
			: base(typeof(ReviewMounthSaveStruct[]), ES3UserType_ReviewMounthSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
