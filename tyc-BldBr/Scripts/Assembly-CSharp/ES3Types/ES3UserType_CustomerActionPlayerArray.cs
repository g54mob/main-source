using CTS.BBT.AI;

namespace ES3Types
{
	public class ES3UserType_CustomerActionPlayerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerActionPlayerArray()
			: base(typeof(CustomerActionPlayer[]), ES3UserType_CustomerActionPlayer.Instance)
		{
			Instance = this;
		}
	}
}
