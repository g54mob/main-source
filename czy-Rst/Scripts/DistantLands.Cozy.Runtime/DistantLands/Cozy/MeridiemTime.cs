using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class MeridiemTime
	{
		public int hours;

		public int minutes;

		public int seconds;

		public int milliseconds;

		public float timeAsPercentage;

		public MeridiemTime()
		{
		}

		public MeridiemTime(int hour, int minute)
		{
			hours = hour;
			minutes = minute;
		}

		public MeridiemTime(int hour, int minute, int second, int millisecond)
		{
			hours = hour;
			minutes = minute;
			seconds = second;
			milliseconds = millisecond;
		}

		public static implicit operator MeridiemTime(float floatValue)
		{
			return new MeridiemTime
			{
				hours = Mathf.FloorToInt(floatValue * 24f),
				minutes = Mathf.FloorToInt(floatValue * 1440f % 60f),
				seconds = Mathf.FloorToInt(floatValue * 86400f % 60f),
				milliseconds = Mathf.FloorToInt(floatValue * 86400000f % 1000f)
			};
		}

		public static implicit operator float(MeridiemTime time)
		{
			return ((float)time.hours * 3600000f + (float)time.minutes * 60000f + (float)time.seconds * 1000f + (float)time.milliseconds) / 86400000f;
		}

		public static implicit operator DateTime(MeridiemTime time)
		{
			return new DateTime(1, 1, 1, time.hours, time.minutes, time.seconds, time.milliseconds);
		}

		public static implicit operator string(MeridiemTime time)
		{
			return $"{time.hours:D2}:{time.minutes:D2}";
		}

		public new string ToString()
		{
			return $"{hours:D2}:{minutes:D2}";
		}

		public string FullString()
		{
			return $"{hours:D2}:{minutes:D2}:{seconds:D2}:{milliseconds:D4}";
		}
	}
}
