using CTS;

namespace ES3Types
{
	public class ES3UserType_DanceTrapArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DanceTrapArray()
			: base(typeof(DanceTrap[]), ES3UserType_DanceTrap.Instance)
		{
			Instance = this;
		}
	}
}
