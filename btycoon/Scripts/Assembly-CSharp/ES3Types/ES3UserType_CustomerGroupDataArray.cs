using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_CustomerGroupDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerGroupDataArray()
			: base(typeof(CustomerGroupData[]), ES3UserType_CustomerGroupData.Instance)
		{
			Instance = this;
		}
	}
}
