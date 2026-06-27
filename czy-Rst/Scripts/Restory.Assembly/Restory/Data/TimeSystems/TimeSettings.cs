using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.TimeSystems
{
	[CreateAssetMenu(fileName = "TimeSettings", menuName = "Restory/TimeSystemsData/MainTimeSettingsAsset")]
	public class TimeSettings : ScriptableObject
	{
		private static class Style
		{
			public const string StartingTimeGroupName = "Game Start Time";

			public const string StartingTimeDateGroupName = "Game Start Time/Date";

			public const string StartingTimeTimeGroupName = "Game Start Time/Time";

			public const string MainDayTimesSettingsGroupName = "Main Day Times";
		}

		[SerializeField]
		private int startingYear = 2000;

		[SerializeField]
		private int startingMonth = 1;

		[SerializeField]
		private int startingDay = 1;

		[SerializeField]
		private int startingHour;

		[SerializeField]
		private int startingMinute;

		[SerializeField]
		private int startingSecond;

		[SerializeField]
		private MainDayTimesSettings mainDayTimesSettings;

		[SerializeField]
		private TimeOfDay timeStep;

		[SerializeField]
		private DaysOfWeekList daysOfWeek;

		public TimeOfDay TimeStep => timeStep;

		public DaysOfWeekList DaysOfWeek => daysOfWeek;

		public MainDayTimesSettings MainDayTimesSettings => mainDayTimesSettings;

		public int StartingYear => startingYear;

		public int StartingMonth => startingMonth;

		public int StartingDay => startingDay;

		public int StartingHour => startingHour;

		public int StartingMinute => startingMinute;

		public int StartingSecond => startingSecond;
	}
}
