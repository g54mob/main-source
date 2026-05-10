using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_DrinkArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DrinkArray()
			: base(typeof(Drink[]), ES3UserType_Drink.Instance)
		{
			Instance = this;
		}
	}
}
