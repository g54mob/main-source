using UnityEngine.Scripting;
using XCharts.Runtime;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_CalendarCoord : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_CalendarCoord()
			: base(typeof(CalendarCoord))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			_ = (CalendarCoord)obj;
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			_ = (CalendarCoord)obj;
			foreach (string property in reader.Properties)
			{
				_ = property;
				reader.Skip();
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			CalendarCoord calendarCoord = new CalendarCoord();
			ReadObject<T>(reader, calendarCoord);
			return calendarCoord;
		}
	}
}
