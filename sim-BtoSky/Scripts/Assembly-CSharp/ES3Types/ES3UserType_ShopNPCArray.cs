namespace ES3Types
{
	public class ES3UserType_ShopNPCArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ShopNPCArray()
			: base(typeof(ShopNPC[]), ES3UserType_ShopNPC.Instance)
		{
			Instance = this;
		}
	}
}
