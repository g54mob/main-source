using CTS;

namespace ES3Types
{
	public class ES3UserType_BodyBagArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BodyBagArray()
			: base(typeof(BodyBag[]), ES3UserType_BodyBag.Instance)
		{
			Instance = this;
		}
	}
}
