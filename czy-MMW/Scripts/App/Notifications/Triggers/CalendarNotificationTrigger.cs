using System;

namespace Notifications.Triggers
{
	public class CalendarNotificationTrigger : SystemNotificationTrigger
	{
		public int? Year { get; set; }

		public int? Month { get; set; }

		public int? Day { get; set; }

		public int? Hour { get; set; }

		public int? Minute { get; set; }

		public int? Second { get; set; }

		public bool MatchesDateTime(DateTime dateTime)
		{
			if ((!Year.HasValue || Year.Value == dateTime.Year) && (!Month.HasValue || Month.Value == dateTime.Month) && (!Day.HasValue || Day.Value == dateTime.Day) && (!Hour.HasValue || Hour.Value == dateTime.Hour) && (!Minute.HasValue || Minute.Value == dateTime.Minute))
			{
				if (Second.HasValue)
				{
					return Second.Value == dateTime.Second;
				}
				return true;
			}
			return false;
		}

		public DateTime AsDateTime(DateTime now)
		{
			return new DateTime(Year ?? now.Year, Month ?? now.Month, Day ?? now.Day, Hour ?? now.Hour, Minute ?? now.Minute, Second ?? now.Second);
		}

		public override string ToString()
		{
			return $"{Hour}:{Minute}:{Second} {Day}/{Month}/{Year}";
		}
	}
}
