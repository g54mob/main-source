namespace ES3Types
{
	public class ES3UserType_PlayerInventoryDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerInventoryDataArray()
			: base(typeof(PlayerInventoryData[]), ES3UserType_PlayerInventoryData.Instance)
		{
			Instance = this;
		}
	}
}
