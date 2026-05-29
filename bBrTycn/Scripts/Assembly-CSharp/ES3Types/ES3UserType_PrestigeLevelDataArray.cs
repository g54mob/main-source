using CTS;

namespace ES3Types
{
	public class ES3UserType_PrestigeLevelDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PrestigeLevelDataArray()
			: base(typeof(PrestigeLevelData[]), ES3UserType_PrestigeLevelData.Instance)
		{
			Instance = this;
		}
	}
}
