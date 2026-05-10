using CTS;

namespace ES3Types
{
	public class ES3UserType_ReviewManagerSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewManagerSaveStructArray()
			: base(typeof(ReviewManagerSaveStruct[]), ES3UserType_ReviewManagerSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
