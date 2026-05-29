using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentDay", "CurrentMonth", "CurrentYear", "ProgressPercentCurrentMonth", "NBDaysLastMonth", "NBDaysCurrentMonth" })]
	public class ES3UserType_CalendarHandlers : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CalendarHandlers()
			: base(typeof(CalendarHandlers))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CalendarHandlers calendarHandlers = (CalendarHandlers)obj;
			writer.WriteProperty("CurrentDay", calendarHandlers.CurrentDay, ES3Type_int.Instance);
			writer.WriteProperty("CurrentMonth", calendarHandlers.CurrentMonth, ES3Type_int.Instance);
			writer.WriteProperty("CurrentYear", calendarHandlers.CurrentYear, ES3Type_int.Instance);
			writer.WriteProperty("ProgressPercentCurrentMonth", calendarHandlers.ProgressPercentCurrentMonth, ES3Type_float.Instance);
			writer.WriteProperty("NBDaysLastMonth", calendarHandlers.NBDaysLastMonth, ES3Type_int.Instance);
			writer.WriteProperty("NBDaysCurrentMonth", calendarHandlers.NBDaysCurrentMonth, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CalendarHandlers calendarHandlers = (CalendarHandlers)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "CurrentDay":
					calendarHandlers.CurrentDay = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "CurrentMonth":
					calendarHandlers.CurrentMonth = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "CurrentYear":
					calendarHandlers.CurrentYear = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "ProgressPercentCurrentMonth":
					calendarHandlers.ProgressPercentCurrentMonth = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "NBDaysLastMonth":
					calendarHandlers.NBDaysLastMonth = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "NBDaysCurrentMonth":
					calendarHandlers.NBDaysCurrentMonth = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
