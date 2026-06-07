using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class WorldClockController : SingletonBehaviour<WorldClockController>
	{
		public delegate void TimeChangedDelegate(float hourHandleAngle, float minuteHandleAngle, DateTime currentTime);

		private WeatherPresetManager weatherPresetManager;

		private float hourHandleAngle;

		private float minuteHandleAngle;

		private HashSet<ItemBase> playerOwnedClocks = new HashSet<ItemBase>();

		public bool PlayerHasClock => playerOwnedClocks.Count > 0;

		public event TimeChangedDelegate TimeChanged;

		public new static string AllowAutoCreate()
		{
			return "[WorldClockController]";
		}

		private void Start()
		{
			if (SingletonBehaviour<WeatherDriver>.Instance == null)
			{
				Debug.LogError("WorldClockController: WeatherDriver.Instance is null.", this);
				return;
			}
			weatherPresetManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
			SetupListeners(on: true);
		}

		private void SetupListeners(bool on)
		{
			if (!(weatherPresetManager == null))
			{
				if (on)
				{
					weatherPresetManager.MinuteChanged += UpdateClocks;
					weatherPresetManager.TimeJump += UpdateClocks;
				}
				else
				{
					weatherPresetManager.MinuteChanged -= UpdateClocks;
					weatherPresetManager.TimeJump -= UpdateClocks;
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void UpdateClocks()
		{
			bool flag;
			DateTime currentTime;
			(flag, hourHandleAngle, minuteHandleAngle, currentTime) = GetCurrentAnglesAndTimeOfDay();
			if (flag)
			{
				this.TimeChanged?.Invoke(hourHandleAngle, minuteHandleAngle, currentTime);
			}
		}

		public (bool validTime, float hourHandleAngle, float minuteHandleAngle, DateTime timeOfDay) GetCurrentAnglesAndTimeOfDay()
		{
			if (weatherPresetManager == null)
			{
				return default((bool, float, float, DateTime));
			}
			DateTime dateTime = weatherPresetManager.DateTime;
			int num = dateTime.Hour % 12;
			int minute = dateTime.Minute;
			float item = (float)(num * 30) + (float)minute * 0.5f;
			float item2 = (float)minute * 6f;
			return (validTime: true, hourHandleAngle: item, minuteHandleAngle: item2, timeOfDay: dateTime);
		}

		public DateTime CalculateAlarmTime(int alarmTimeInMinutes)
		{
			DateTime dateTime = weatherPresetManager.DateTime;
			bool flag = dateTime.Hour >= 12;
			int num = alarmTimeInMinutes / 60 % 12;
			int minute = alarmTimeInMinutes % 60;
			int hour = num + (flag ? 12 : 0);
			DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, minute, 0);
			int num2 = alarmTimeInMinutes / 720;
			if ((dateTime2 - dateTime).TotalMinutes < 0.0)
			{
				num2++;
			}
			return dateTime2.AddMinutes(num2 * 720);
		}

		public void RegisterPlayerOwnedClock(ItemBase itemBase)
		{
			playerOwnedClocks.Add(itemBase);
		}

		public void UnregisterPlayerOwnedClock(ItemBase itemBase)
		{
			playerOwnedClocks.Remove(itemBase);
		}
	}
}
