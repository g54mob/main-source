using CTS;

namespace ES3Types
{
	public class ES3UserType_CalendarHandlersArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CalendarHandlersArray()
			: base(typeof(CalendarHandlers[]), ES3UserType_CalendarHandlers.Instance)
		{
			Instance = this;
		}
	}
}
