using CTS;

namespace ES3Types
{
	public class ES3UserType_ReviewPanelSaveStructArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewPanelSaveStructArray()
			: base(typeof(ReviewPanelSaveStruct[]), ES3UserType_ReviewPanelSaveStruct.Instance)
		{
			Instance = this;
		}
	}
}
