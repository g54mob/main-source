using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_StationDrinkArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StationDrinkArray()
			: base(typeof(StationDrink[]), ES3UserType_StationDrink.Instance)
		{
			Instance = this;
		}
	}
}
