namespace ES3Types
{
	public class ES3UserType_SaveFileInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SaveFileInfoArray()
			: base(typeof(SaveFileInfo[]), ES3UserType_SaveFileInfo.Instance)
		{
			Instance = this;
		}
	}
}
