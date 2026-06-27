using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Forecast Profile", order = 361)]
	public class ForecastProfile : CozyProfile
	{
		public enum StartWeatherWith
		{
			Random = 0,
			InitialProfile = 1,
			InitialForecast = 2
		}

		[Tooltip("The weather profiles that this profile will forecast.")]
		public List<WeatherProfile> profilesToForecast;

		[Tooltip("The weather profile that this profile will forecast initially.")]
		public WeatherProfile initialProfile;

		[Tooltip("The weather profiles that this profile will forecast initially.")]
		public List<CozyEcosystem.WeatherPattern> initialForecast;

		public StartWeatherWith startWeatherWith;

		[Tooltip("The amount of weather profiles to forecast ahead.")]
		public int forecastLength;
	}
}
