using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_OrderPlateArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_OrderPlateArray()
			: base(typeof(OrderPlate[]), ES3UserType_OrderPlate.Instance)
		{
			Instance = this;
		}
	}
}
