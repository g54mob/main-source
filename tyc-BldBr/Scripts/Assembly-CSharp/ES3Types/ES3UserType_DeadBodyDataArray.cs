using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_DeadBodyDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DeadBodyDataArray()
			: base(typeof(DeadBodyData[]), ES3UserType_DeadBodyData.Instance)
		{
			Instance = this;
		}
	}
}
