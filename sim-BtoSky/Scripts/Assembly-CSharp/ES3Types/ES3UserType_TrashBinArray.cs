namespace ES3Types
{
	public class ES3UserType_TrashBinArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TrashBinArray()
			: base(typeof(TrashBin[]), ES3UserType_TrashBin.Instance)
		{
			Instance = this;
		}
	}
}
