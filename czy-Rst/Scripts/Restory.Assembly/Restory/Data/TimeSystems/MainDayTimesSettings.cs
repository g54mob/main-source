using System;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.TimeSystems
{
	[Serializable]
	public class MainDayTimesSettings
	{
		private static class Style
		{
			public const string MorningStartTimeGroupName = "Morning";

			public const string MorningStartTimeHorizontalGroupName = "Morning/I";

			public const string AfternoonStartTimeGroupName = "Afternoon";

			public const string AfternoonStartTimeHorizontalGroupName = "Afternoon/I";

			public const string EveningStartTimeGroupName = "Evening";

			public const string EveningStartTimeHorizontalGroupName = "Evening/I";

			public const string WorkDayEndTimeGroupName = "Work End";

			public const string WorkDayEndTimeHorizontalGroupName = "Work End/I";

			public const string HoursName = "Hour";

			public const string MinutesName = "Minute";

			public const string SecondsName = "Second";
		}

		[SerializeField]
		private int morningStartHour = 8;

		[SerializeField]
		private int morningStartMinute;

		[SerializeField]
		private int morningStartSecond;

		[SerializeField]
		private int afternoonStartHour = 12;

		[SerializeField]
		private int afternoonStartMinute;

		[SerializeField]
		private int afternoonStartSecond;

		[SerializeField]
		private int eveningStartHour = 17;

		[SerializeField]
		private int eveningStartMinute;

		[SerializeField]
		private int eveningStartSecond;

		[SerializeField]
		private int workDayEndHour = 22;

		[SerializeField]
		private int workDayEndMinute;

		[SerializeField]
		private int workDayEndSecond;

		public TimeOfDay GetMorningStartTime()
		{
			return new TimeOfDay(morningStartHour, morningStartMinute, morningStartSecond);
		}

		public TimeOfDay GetAfternoonStartTime()
		{
			return new TimeOfDay(afternoonStartHour, afternoonStartMinute, afternoonStartSecond);
		}

		public TimeOfDay GetEveningStartTime()
		{
			return new TimeOfDay(eveningStartHour, eveningStartMinute, eveningStartSecond);
		}

		public TimeOfDay GetWorkDayEndTime()
		{
			return new TimeOfDay(workDayEndHour, workDayEndMinute, workDayEndSecond);
		}
	}
}
