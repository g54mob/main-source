using CTS;

namespace ES3Types
{
	public class ES3UserType_BBTStockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BBTStockArray()
			: base(typeof(BBTStock[]), ES3UserType_BBTStock.Instance)
		{
			Instance = this;
		}
	}
}
