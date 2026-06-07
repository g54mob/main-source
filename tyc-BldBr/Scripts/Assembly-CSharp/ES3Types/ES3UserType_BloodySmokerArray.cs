using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodySmokerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodySmokerArray()
			: base(typeof(BloodySmoker[]), ES3UserType_BloodySmoker.Instance)
		{
			Instance = this;
		}
	}
}
