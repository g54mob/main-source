using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodyShakerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyShakerArray()
			: base(typeof(BloodyShaker[]), ES3UserType_BloodyShaker.Instance)
		{
			Instance = this;
		}
	}
}
