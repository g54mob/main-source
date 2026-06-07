using CTS;

namespace ES3Types
{
	public class ES3UserType_DeliveriesArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DeliveriesArray()
			: base(typeof(Deliveries[]), ES3UserType_Deliveries.Instance)
		{
			Instance = this;
		}
	}
}
