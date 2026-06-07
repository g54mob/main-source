using CTS;

namespace ES3Types
{
	public class ES3UserType_MissionBasketArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MissionBasketArray()
			: base(typeof(MissionBasket[]), ES3UserType_MissionBasket.Instance)
		{
			Instance = this;
		}
	}
}
