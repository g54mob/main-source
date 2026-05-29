using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_CustomerOrderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerOrderArray()
			: base(typeof(CustomerOrder[]), ES3UserType_CustomerOrder.Instance)
		{
			Instance = this;
		}
	}
}
