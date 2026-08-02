namespace ES3Types
{
	public class ES3UserType_CollectableItemDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CollectableItemDataArray()
			: base(typeof(CollectableItemData[]), ES3UserType_CollectableItemData.Instance)
		{
			Instance = this;
		}
	}
}
