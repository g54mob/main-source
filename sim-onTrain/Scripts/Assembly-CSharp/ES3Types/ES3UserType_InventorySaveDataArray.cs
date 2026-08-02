namespace ES3Types
{
	public class ES3UserType_InventorySaveDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InventorySaveDataArray()
			: base(typeof(InventorySaveData[]), ES3UserType_InventorySaveData.Instance)
		{
			Instance = this;
		}
	}
}
