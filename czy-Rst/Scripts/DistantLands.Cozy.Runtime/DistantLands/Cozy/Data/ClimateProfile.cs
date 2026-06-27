using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Climate Profile", order = 361)]
	public class ClimateProfile : CozyProfile
	{
		[Tooltip("The global temperature during the year. the x-axis is the current day over the days in the year and the y axis is the temperature in Fahrenheit.")]
		public AnimationCurve temperatureOverYear;

		[Tooltip("The global humidity during the year. the x-axis is the current day over the days in the year and the y axis is the humidity.")]
		public AnimationCurve humidityOverYear;

		[Tooltip("The local temperature during the day. the x-axis is the current ticks over 360 and the y axis is the temperature change in Fahrenheit from the global temperature.")]
		public AnimationCurve temperatureOverDay;

		[Tooltip("The local humidity during the day. the x-axis is the current ticks over 360 and the y axis is the humidity change from the global precipitation.")]
		public AnimationCurve humidityOverDay;

		[Tooltip("Adds an offset to the global temperature. Useful for adding biomes or climate change by location or elevation")]
		public float temperatureFilter;

		[Tooltip("Adds an offset to the global precipitation. Useful for adding biomes or climate change by location or elevation")]
		public float humidityFilter;

		public float GetTemperature()
		{
			CozyWeather instance = CozyWeather.instance;
			return temperatureOverYear.Evaluate(instance.yearPercentage) * temperatureOverDay.Evaluate(instance.modifiedDayPercentage) + temperatureFilter;
		}

		public float GetTemperature(CozyWeather weather)
		{
			if (weather == null)
			{
				return GetTemperature();
			}
			return temperatureOverYear.Evaluate(weather.yearPercentage) * temperatureOverDay.Evaluate(weather.modifiedDayPercentage) + temperatureFilter;
		}

		public float GetTemperature(CozyWeather weather, float time)
		{
			if (!weather.timeModule)
			{
				return GetTemperature(weather);
			}
			return temperatureOverYear.Evaluate(time / (float)weather.timeModule.DaysPerYear) * temperatureOverDay.Evaluate(time % 1f) + temperatureFilter;
		}

		public float GetHumidity()
		{
			CozyWeather instance = CozyWeather.instance;
			return humidityOverYear.Evaluate(instance.yearPercentage) * humidityOverDay.Evaluate(instance.modifiedDayPercentage) + humidityFilter;
		}

		public float GetHumidity(CozyWeather weather)
		{
			if (weather == null)
			{
				weather = CozyWeather.instance;
			}
			return humidityOverYear.Evaluate(weather.yearPercentage) * humidityOverDay.Evaluate(weather.modifiedDayPercentage) + humidityFilter;
		}

		public float GetHumidity(CozyWeather weather, float time)
		{
			if (!weather.timeModule)
			{
				return GetHumidity(weather);
			}
			return humidityOverYear.Evaluate(time / (float)weather.timeModule.DaysPerYear) * humidityOverDay.Evaluate(time % 1f) + humidityFilter;
		}
	}
}
