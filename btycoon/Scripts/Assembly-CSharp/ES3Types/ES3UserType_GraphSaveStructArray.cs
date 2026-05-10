using CTS;

namespace ES3Types
{
	public class ES3UserType_GraphSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GraphSaveStructArray()
			: base(typeof(GraphSaveStruct[]), ES3UserType_GraphSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
