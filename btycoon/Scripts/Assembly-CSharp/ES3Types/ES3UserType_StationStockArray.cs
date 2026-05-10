using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_StationStockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StationStockArray()
			: base(typeof(StationStock[]), ES3UserType_StationStock.Instance)
		{
			Instance = this;
		}
	}
}
