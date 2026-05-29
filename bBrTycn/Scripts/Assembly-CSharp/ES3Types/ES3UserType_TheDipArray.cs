using CTS;

namespace ES3Types
{
	public class ES3UserType_TheDipArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TheDipArray()
			: base(typeof(TheDip[]), ES3UserType_TheDip.Instance)
		{
			Instance = this;
		}
	}
}
