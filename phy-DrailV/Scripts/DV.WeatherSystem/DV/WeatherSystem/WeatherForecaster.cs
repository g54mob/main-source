using System;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

namespace DV.WeatherSystem
{
	public class WeatherForecaster : SingletonBehaviour<WeatherForecaster>
	{
		public int hoursToForecast = 24;

		public int doForecastAt = 6;

		public float sampleEveryNHours = 0.2f;

		public float groupByNHours = 3f;

		public float nightEndsAt = 6f;

		public float nightStartsAt = 20f;

		public WeatherDriver driver;

		[NonSerialized]
		public List<WeatherStateChungus> weatherForecastData = new List<WeatherStateChungus>();

		[NonSerialized]
		public List<WeatherForecastItem> interpretedData = new List<WeatherForecastItem>();

		[NonSerialized]
		public DateTime? lastForecastTimestamp;

		public event Action ForecastUpdated;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void Start()
		{
			DoForecastIfNeeded();
			driver.OnDataLoaded += DoForecast;
			driver.manager.HourChanged += DoForecastIfNeeded;
		}

		private void DoForecastIfNeeded()
		{
			DateTime dateTime = driver.manager.DateTime.AddHours(-doForecastAt);
			if (!lastForecastTimestamp.HasValue || dateTime.Day != lastForecastTimestamp.Value.Day)
			{
				DoForecast();
			}
		}

		public void DoForecast()
		{
			DateTime dateTime = driver.manager.DateTime.AddHours(-doForecastAt);
			lastForecastTimestamp = dateTime;
			weatherForecastData.Clear();
			float num = Mathf.Floor(WeatherDriver.GetLinearTime(dateTime)) + (float)doForecastAt / 24f;
			for (int i = 0; i < Mathf.CeilToInt((float)hoursToForecast / sampleEveryNHours); i++)
			{
				float dateTime2 = num + (float)i * (sampleEveryNHours / 24f);
				WeatherStateChungus state = driver.CurrentChungusState.Clone();
				state.startingWeatherEnabled = true;
				state.currentLow = (state.currentHigh = null);
				driver.SimulateWeatherToTime(dateTime2, ref state);
				weatherForecastData.Add(state);
			}
			InterpretData();
			this.ForecastUpdated?.Invoke();
		}

		public bool HasValidForecastForToday()
		{
			if (!lastForecastTimestamp.HasValue)
			{
				return false;
			}
			if (interpretedData.Count == 0)
			{
				return false;
			}
			return true;
		}

		private void InterpretData()
		{
			List<List<WeatherStateChungus>> list = (from tup in weatherForecastData.Select((WeatherStateChungus c, int i) => new
				{
					DbgHour = TimeOfDay24hDbg(c),
					Hour = TimeOfDay24h(c),
					Chungus = c
				})
				group tup by Mathf.Floor((float)tup.Hour / groupByNHours) into grp
				select grp.Select(v => v.Chungus).ToList()).ToList();
			int num = Mathf.RoundToInt(groupByNHours / sampleEveryNHours);
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				if (list[num2].Count != num)
				{
					Debug.LogError(string.Format("[{0}] Group at index {1} has {2} samples instead of {3}", "WeatherForecaster", num2, list[num2].Count, num));
				}
			}
			interpretedData.Clear();
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				List<WeatherStateChungus> samples = list[num3];
				WeatherForecastItem item = InterpretData(samples);
				interpretedData.Add(item);
			}
		}

		private float TimeOfDay24hDbg(WeatherStateChungus s)
		{
			float num = TimeOfDay01(s) * 24f;
			if (num >= 24f)
			{
				num -= 24f;
			}
			return num;
		}

		private int TimeOfDay24h(WeatherStateChungus s)
		{
			float num = TimeOfDay01(s) * 24f;
			int num2 = Mathf.FloorToInt(num);
			if (num - (float)num2 >= 0.9f)
			{
				num2++;
			}
			if (num2 >= 24)
			{
				num2 -= 24;
			}
			return num2;
		}

		private float TimeOfDay01(WeatherStateChungus s)
		{
			return s.dateTime - (float)Mathf.FloorToInt(s.dateTime);
		}

		private WeatherForecastItem InterpretData(List<WeatherStateChungus> samples)
		{
			WeatherForecastItem result = new WeatherForecastItem
			{
				hourStart = TimeOfDay24h(samples[0]),
				hourEnd = TimeOfDay24h(samples[samples.Count - 1]) + 1,
				firstSampleTimestamp = samples[0].dateTime,
				sampledDataDuration = groupByNHours / 24f
			};
			float num = 0f;
			foreach (WeatherStateChungus sample in samples)
			{
				float num2 = (sample.dateTime - Mathf.Floor(sample.dateTime)) * 24f;
				if (num2 > nightStartsAt || num2 < nightEndsAt)
				{
					num += 1f;
				}
			}
			result.isNight = num / (float)samples.Count > 0.5f;
			result.averageThunder = 0f;
			foreach (WeatherStateChungus sample2 in samples)
			{
				result.averageThunder += Mathf.RoundToInt((float)sample2.thunderValue * 100f);
			}
			result.averageThunder /= samples.Count;
			result.averageCloudiness = 0f;
			foreach (WeatherStateChungus sample3 in samples)
			{
				result.averageCloudiness += Mathf.RoundToInt(sample3.currentLow.cloudCoverage * 100f);
			}
			result.averageCloudiness /= samples.Count;
			result.averageFog = 0f;
			foreach (WeatherStateChungus sample4 in samples)
			{
				result.averageFog += Mathf.RoundToInt(sample4.noisePoint.x * 100f);
			}
			result.averageFog /= samples.Count;
			result.averageRain = 0f;
			foreach (WeatherStateChungus sample5 in samples)
			{
				result.averageRain += Mathf.RoundToInt((float)sample5.rainValue * 100f);
			}
			result.averageRain /= samples.Count;
			if (result.averageThunder > 0.7f)
			{
				result.iconType = WeatherForecastIconType.Thunder;
			}
			else if (result.averageRain > 5f)
			{
				if (result.averageRain < 8f)
				{
					if (result.isNight)
					{
						result.iconType = WeatherForecastIconType.LightRain_Night;
					}
					else
					{
						result.iconType = WeatherForecastIconType.LightRain_Day;
					}
				}
				else
				{
					result.iconType = WeatherForecastIconType.HeavyRain;
				}
			}
			else if (result.averageFog > 60f)
			{
				if (result.averageFog > 80f)
				{
					result.iconType = WeatherForecastIconType.HeavyFog;
				}
				else if (result.isNight)
				{
					result.iconType = WeatherForecastIconType.LightFog_Night;
				}
				else
				{
					result.iconType = WeatherForecastIconType.LightFog_Day;
				}
			}
			else if (result.averageCloudiness > 60f)
			{
				result.iconType = WeatherForecastIconType.Overcast;
			}
			else if (result.averageCloudiness > 50f)
			{
				if (result.isNight)
				{
					result.iconType = WeatherForecastIconType.PartlyCloudy_Night;
				}
				else
				{
					result.iconType = WeatherForecastIconType.PartlyCloudy_Day;
				}
			}
			else if (result.isNight)
			{
				result.iconType = WeatherForecastIconType.Clear_Night;
			}
			else
			{
				result.iconType = WeatherForecastIconType.Clear_Day;
			}
			return result;
		}
	}
}
