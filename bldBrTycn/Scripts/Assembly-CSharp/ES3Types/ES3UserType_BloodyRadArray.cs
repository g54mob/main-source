using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyRadArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyRadArray()
			: base(typeof(BloodyRad[]), ES3UserType_BloodyRad.Instance)
		{
			Instance = this;
		}
	}
}
