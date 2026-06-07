using CTS;

namespace ES3Types
{
	public class ES3UserType_CareerProfileArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CareerProfileArray()
			: base(typeof(CareerProfile[]), ES3UserType_CareerProfile.Instance)
		{
			Instance = this;
		}
	}
}
