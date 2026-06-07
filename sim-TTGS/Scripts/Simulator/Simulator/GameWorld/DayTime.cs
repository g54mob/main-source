using System;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct DayTime
	{
		public int hour;

		public int minute;

		public const int MINUTES_IN_HOUR = 60;

		public const int MINUTES_IN_DAY = 1439;

		public DayTime(int hour, int minute)
		{
			this.hour = hour;
			this.minute = minute;
		}

		public DayTime(int totalMinutes)
		{
			hour = totalMinutes % 1439 / 60;
			minute = totalMinutes % 1439 % 60;
		}

		public int TotalMinutes()
		{
			return hour * 60 + minute;
		}

		public override string ToString()
		{
			return hour.ToString("00") + ":" + minute.ToString("00");
		}
	}
}
