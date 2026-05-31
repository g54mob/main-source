using CTS.BBT;

namespace ES3Types
{
	public class ES3UserType_StationMorgueArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StationMorgueArray()
			: base(typeof(StationMorgue[]), ES3UserType_StationMorgue.Instance)
		{
			Instance = this;
		}
	}
}
