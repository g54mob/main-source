using CTS;

namespace ES3Types
{
	public class ES3UserType_DeliveryArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DeliveryArray()
			: base(typeof(Delivery[]), ES3UserType_Delivery.Instance)
		{
			Instance = this;
		}
	}
}
