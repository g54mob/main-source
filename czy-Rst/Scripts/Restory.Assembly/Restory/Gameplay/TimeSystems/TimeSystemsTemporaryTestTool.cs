using System.Collections.Generic;
using Mandragora.Utils;
using Restory.Data.TimeSystems;
using Restory.Gameplay.Common;
using Restory.TimeSystems;
using UnityEngine;

namespace Restory.Gameplay.TimeSystems
{
	public class TimeSystemsTemporaryTestTool : MonoBehaviour, IActiveStateSwitchRequester
	{
		[SerializeField]
		private TimeIntervalInfo[] additionalTestTimeIntervals = new TimeIntervalInfo[0];

		[SerializeField]
		private int year = 2000;

		[SerializeField]
		private int month = 1;

		[SerializeField]
		private int day = 1;

		[SerializeField]
		private int hour;

		[SerializeField]
		private int minute;

		[SerializeField]
		private int second;

		[SerializeField]
		private int daysPassedCount;

		[SerializeField]
		private int currentDayNumber;

		[SerializeField]
		private DayOfWeekInfo dayOfWeek;

		[SerializeField]
		private MainDayTimes currentDayTime;

		[SerializeField]
		private List<string> timeIntervals = new List<string>();

		[BoolButton(25, 0, Red = false)]
		private bool showTimeBlockers;

		private TimeSystem timeSystem;

		private GameCalendar gameCalendar;

		private TimeIntervalsTracker timeIntervalsTracker;

		private MainDayTimeSwitchingService mainDayTimeSwitcher;

		private Coroutine infoUpdatingCoroutine;
	}
}
