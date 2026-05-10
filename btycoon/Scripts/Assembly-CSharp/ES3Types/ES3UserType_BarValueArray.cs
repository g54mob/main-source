using CTS;

namespace ES3Types
{
	public class ES3UserType_BarValueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BarValueArray()
			: base(typeof(BarValue[]), ES3UserType_BarValue.Instance)
		{
			Instance = this;
		}
	}
}
