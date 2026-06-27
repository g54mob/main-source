using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class WeekdayAttribute : PropertyAttribute
	{
		public enum TitleStyle
		{
			weekdayInitial = 0,
			weekday = 1,
			fullDayName = 2,
			day = 3
		}

		public TitleStyle titleStyle;

		public bool labelTime;

		public bool highlightCurrentDay;

		public int linesCount;

		public WeekdayAttribute(TitleStyle title, int lines, bool labelTimes, bool highlightDay)
		{
			titleStyle = title;
			linesCount = lines;
			labelTime = labelTimes;
			highlightCurrentDay = highlightDay;
		}
	}
}
