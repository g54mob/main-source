using CTS;

namespace ES3Types
{
	public class ES3UserType_ToiletArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ToiletArray()
			: base(typeof(Toilet[]), ES3UserType_Toilet.Instance)
		{
			Instance = this;
		}
	}
}
