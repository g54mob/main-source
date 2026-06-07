using CTS;

namespace ES3Types
{
	public class ES3UserType_StationStocksVisualManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StationStocksVisualManagerArray()
			: base(typeof(StationStocksVisualManager[]), ES3UserType_StationStocksVisualManager.Instance)
		{
			Instance = this;
		}
	}
}
