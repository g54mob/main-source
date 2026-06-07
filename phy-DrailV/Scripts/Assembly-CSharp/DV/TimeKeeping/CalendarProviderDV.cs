using System;
using System.Collections;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class CalendarProviderDV : ACalendarDataProvider
	{
		private WeatherPresetManager manager;

		private int dayOfMonth = 1;

		private int daysInMonth = 31;

		private int month = 7;

		private string N => "[" + GetType().Name + "]";

		public override int DayOfMonth => dayOfMonth;

		public override int DaysInMonth => daysInMonth;

		public override int Month => month;

		private IEnumerator Start()
		{
			int safety = 10;
			while (SingletonBehaviour<WeatherDriver>.Instance == null || SingletonBehaviour<WeatherDriver>.Instance.manager == null)
			{
				yield return WaitFor.Seconds(0.5f);
				int num = safety - 1;
				safety = num;
				if (num <= 0)
				{
					Debug.LogWarning(N + " Couldn't find WeatherDriver, calendars won't work", this);
					yield break;
				}
			}
			manager = SingletonBehaviour<WeatherDriver>.Instance.manager;
			manager.HourChanged += OnTimeChanged;
			OnTimeChanged();
		}

		private void OnTimeChanged()
		{
			if ((bool)manager)
			{
				DateTime dateTime = manager.DateTime;
				dayOfMonth = dateTime.Day;
				daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
				month = dateTime.Month;
				DayOfMonthChanged_Fire();
			}
		}
	}
}
