using System;

namespace Restory.Gameplay.TimeSystems
{
	[Serializable]
	public struct TimeOfDay
	{
		public int Hours;

		public int Minutes;

		public int Seconds;

		public float TotalSeconds => Hours * 60 * 60 + Minutes * 60 + Seconds;

		public float TotalMinutes => (float)(Hours * 60 + Minutes) + (float)Seconds / 60f;

		public float TotalHours => (float)Hours + (float)Minutes / 60f + (float)Seconds / 60f / 60f;

		public TimeOfDay(int hours, int minutes, int seconds)
		{
			Hours = hours;
			Minutes = minutes;
			Seconds = seconds;
		}

		public TimeSpan InTimeSpan()
		{
			return new TimeSpan(Hours, Minutes, Seconds);
		}
	}
}
