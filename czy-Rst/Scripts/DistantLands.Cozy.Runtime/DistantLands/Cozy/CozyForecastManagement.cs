using System;
using System.Collections;
using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class CozyForecastManagement
	{
		public enum EcosystemStyle
		{
			manual = 0,
			forecast = 1,
			dailyForecast = 2,
			automatic = 3
		}

		[Serializable]
		public class WeatherPattern
		{
			public WeatherProfile profile;

			public float weatherProfileDuration;

			public float startTicks;

			public float endTicks;
		}

		[Serializable]
		public class WeightedWeather
		{
			[Range(0f, 1f)]
			public float weight;

			public WeatherProfile profile;

			public bool transitioning = true;

			public IEnumerator Transition(float value, float time)
			{
				transitioning = true;
				float t = 0f;
				float start = weight;
				for (; t < time; t += Time.deltaTime)
				{
					float div = t / time;
					yield return new WaitForEndOfFrame();
					weight = Mathf.Lerp(start, value, div);
				}
				weight = value;
				transitioning = false;
			}
		}

		public ForecastProfile forecastProfile;

		[Tooltip("How should this ecosystem manage weather selection? Manual allows you to manually select the weather profile that this ecosystem will use and the weights will adjust accordingly, Forecast allows for dynamically changing weather based on a predetermined forecast that runs entirely on it's own.")]
		public EcosystemStyle weatherSelectionMode;

		public List<WeatherPattern> currentForecast;

		public float weatherTransitionTime = 15f;

		public float weatherTimer;

		[Range(0f, 1f)]
		public float weight;

		public WeatherProfile currentWeather;

		public WeatherProfile weatherChangeCheck;

		[WeatherRelation]
		public List<WeightedWeather> weightedWeatherProfiles;
	}
}
