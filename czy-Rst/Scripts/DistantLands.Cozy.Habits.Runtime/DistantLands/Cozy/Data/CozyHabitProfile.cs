using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Habits/Cozy Habit", order = 361)]
	public class CozyHabitProfile : ScriptableObject
	{
		public delegate void OnStart();

		public delegate void OnEnd();

		public delegate void OnUpdate();

		public enum RepeatStyle
		{
			never = 0,
			daily = 1,
			everyOtherDay = 2,
			weekdays = 3,
			weekends = 4,
			weekly = 5,
			monthly = 6,
			annually = 7
		}

		public bool isEventRunning;

		public CozyHabits.ModifiedDate startDate;

		public CozyHabits.ModifiedDate endDate;

		public RepeatStyle repeatStyle;

		public bool allDay;

		public bool overnight;

		public bool runHabitOnStart = true;

		public bool runHabitOnEnd;

		public bool runHabitContinuously;

		public bool dateRange;

		[FormatTime]
		public MeridiemTime startTime;

		[FormatTime]
		public MeridiemTime endTime;

		public CozyHabits.Weekday weekday;

		public CozyHabits.Calendar calendar;

		public List<WeatherProfile> cancelIfWeatherIsPlaying;

		public event OnStart onStart;

		public event OnEnd onEnd;

		public event OnUpdate onUpdate;

		public void RaiseOnStart()
		{
			if (this.onStart != null)
			{
				this.onStart();
			}
		}

		public void RaiseOnEnd()
		{
			if (this.onEnd != null)
			{
				this.onEnd();
			}
		}

		public void RaiseOnUpdate()
		{
			if (this.onUpdate != null)
			{
				this.onUpdate();
			}
		}
	}
}
