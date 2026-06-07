using CTS;

namespace ES3Types
{
	public class ES3UserType_UnitHealthArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_UnitHealthArray()
			: base(typeof(UnitHealth[]), ES3UserType_UnitHealth.Instance)
		{
			Instance = this;
		}
	}
}
