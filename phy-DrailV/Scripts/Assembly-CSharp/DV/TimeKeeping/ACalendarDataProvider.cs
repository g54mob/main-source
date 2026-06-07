using System;
using DV.Utils;

namespace DV.TimeKeeping
{
	public abstract class ACalendarDataProvider : SingletonBehaviour<ACalendarDataProvider>
	{
		public abstract int DayOfMonth { get; }

		public abstract int DaysInMonth { get; }

		public abstract int Month { get; }

		public event Action DayOfMonthChanged;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		public void DayOfMonthChanged_Fire()
		{
			this.DayOfMonthChanged?.Invoke();
		}
	}
}
