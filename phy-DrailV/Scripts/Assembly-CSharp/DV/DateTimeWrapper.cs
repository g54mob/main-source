using System;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV
{
	public class DateTimeWrapper : SingletonBehaviour<DateTimeWrapper>
	{
		private WeatherPresetManager weatherManager;

		public DateTime DateTime => weatherManager?.DateTime ?? DateTime.Now;

		public new static string AllowAutoCreate()
		{
			return "[DateTimeWrapper]";
		}

		protected override void Awake()
		{
			base.Awake();
			weatherManager = UnityEngine.Object.FindObjectOfType<WeatherPresetManager>();
			if (weatherManager == null)
			{
				Debug.LogError("Unexpected state: Can't find WeatherPresetManager, DateTimeWrapper will use DateTime.Now!");
			}
		}

		public DateTime GetDateTimeOfMostRecentHour(int desiredHour)
		{
			DateTime dateTime = DateTime;
			if (dateTime.Hour < desiredHour)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, desiredHour, 0, 0);
		}
	}
}
