using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_CustomerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerArray()
			: base(typeof(Customer[]), ES3UserType_Customer.Instance)
		{
			Instance = this;
		}
	}
}
