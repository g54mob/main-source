using UnityEngine;

namespace DV.TimeKeeping
{
	public class CalendarExampleProvider : ACalendarDataProvider
	{
		[Range(-3f, 33f)]
		public int dayOfMonth = 16;

		[Range(-3f, 33f)]
		public int daysInMonth = 31;

		[Range(-3f, 14f)]
		public int month = 8;

		private int prevDayOfMonth = -1;

		private int prevDaysInMonth = -1;

		private int prevMonth = -1;

		public override int DayOfMonth => dayOfMonth;

		public override int DaysInMonth => daysInMonth;

		public override int Month => month;

		private void Update()
		{
			if (dayOfMonth != prevDayOfMonth || daysInMonth != prevDaysInMonth || month != prevMonth)
			{
				Debug.Log($"Day of month changed from {prevDayOfMonth} to {dayOfMonth}");
				prevDayOfMonth = dayOfMonth;
				prevDaysInMonth = daysInMonth;
				prevMonth = month;
				DayOfMonthChanged_Fire();
			}
		}

		public void FireEvent()
		{
			DayOfMonthChanged_Fire();
		}
	}
}
