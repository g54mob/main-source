namespace ES3Types
{
	public class ES3UserType_TsPlayerNetworkHelperArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TsPlayerNetworkHelperArray()
			: base(typeof(TsPlayerNetworkHelper[]), ES3UserType_TsPlayerNetworkHelper.Instance)
		{
			Instance = this;
		}
	}
}
