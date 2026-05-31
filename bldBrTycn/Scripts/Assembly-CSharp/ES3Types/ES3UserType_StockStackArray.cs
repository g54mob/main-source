using CTS;

namespace ES3Types
{
	public class ES3UserType_StockStackArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StockStackArray()
			: base(typeof(StockStack[]), ES3UserType_StockStack.Instance)
		{
			Instance = this;
		}
	}
}
