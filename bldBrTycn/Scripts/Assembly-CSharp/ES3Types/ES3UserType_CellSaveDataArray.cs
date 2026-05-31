namespace ES3Types
{
	public class ES3UserType_CellSaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CellSaveDataArray()
			: base(typeof(CellSaveData[]), ES3UserType_CellSaveData.Instance)
		{
			Instance = this;
		}
	}
}
