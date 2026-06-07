using CTS;

namespace ES3Types
{
	public class ES3UserType_BloodDistillerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodDistillerArray()
			: base(typeof(BloodDistiller[]), ES3UserType_BloodDistiller.Instance)
		{
			Instance = this;
		}
	}
}
