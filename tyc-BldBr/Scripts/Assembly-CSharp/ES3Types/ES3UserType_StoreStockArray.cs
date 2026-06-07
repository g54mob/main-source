using CTS;

namespace ES3Types
{
	public class ES3UserType_StoreStockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StoreStockArray()
			: base(typeof(StoreStock[]), ES3UserType_StoreStock.StoreStockInstance)
		{
			Instance = this;
		}
	}
}
