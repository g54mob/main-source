using XCharts.Runtime;

namespace ES3Types
{
	public class ES3UserType_CalendarCoordArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CalendarCoordArray()
			: base(typeof(CalendarCoord[]), ES3UserType_CalendarCoord.Instance)
		{
			Instance = this;
		}
	}
}
