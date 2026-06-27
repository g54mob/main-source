using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Weather Profile", order = 361)]
	public class WeatherProfile : ScriptableObject
	{
		public enum ForecastModifierMethod
		{
			forecastNext = 0,
			DontForecastNext = 1,
			forecastAnyProfileNext = 2
		}

		[Tooltip("Specifies the minimum length for this weather profile in in-game hours and minutes.")]
		[FormerlySerializedAs("minWeatherTime")]
		[MeridiemTime]
		public float minTime = 0.25f;

		[Tooltip("Specifies the maximum length for this weather profile in in-game hours and minutes.")]
		[FormerlySerializedAs("maxWeatherTime")]
		[MeridiemTime]
		public float maxTime = 0.35f;

		public WeightedRandomChance chance;

		[HideTitle]
		[Tooltip("Allow only these weather profiles to immediately follow this weather profile in a forecast.")]
		public WeatherProfile[] forecastNext;

		public ForecastModifierMethod forecastModifierMethod = ForecastModifierMethod.forecastAnyProfileNext;

		[FX]
		public FXProfile[] FX;

		public float minWeatherTime => minTime;

		public float maxWeatherTime => maxTime;

		public float GetChance(CozyWeather weather, float inTime)
		{
			return chance.GetChance(weather, inTime);
		}

		public float GetChance(CozyWeather weather)
		{
			return chance.GetChance(weather);
		}

		public void SetWeatherWeight(float weightVal)
		{
			FXProfile[] fX = FX;
			for (int i = 0; i < fX.Length; i++)
			{
				fX[i]?.PlayEffect(weightVal);
			}
		}
	}
}
