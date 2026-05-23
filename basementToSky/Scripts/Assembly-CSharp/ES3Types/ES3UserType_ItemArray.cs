namespace ES3Types
{
	public class ES3UserType_ItemArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ItemArray()
			: base(typeof(Item[]), ES3UserType_Item.Instance)
		{
			Instance = this;
		}
	}
}
