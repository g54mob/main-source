using System;
using UnityEngine;

namespace DV.WeatherSystem
{
	[Serializable]
	public struct WeatherStateChungus
	{
		public float dateTime;

		public OverridableValue<float> windDirection;

		public OverridableValue<float> rainValue;

		public OverridableValue<float> thunderValue;

		public OverridableValue<float> wetnessValue;

		public OverridableValue<float> noisePointX;

		public OverridableValue<float> noisePointY;

		public Weather24hPresetSO closestPreset;

		public WeatherSnapshot currentLow;

		public WeatherSnapshot currentHigh;

		public bool startingWeatherEnabled;

		public float startingWeatherTransitionStart;

		public float startingWeatherTransitionEnd;

		public Vector2 startingWeatherNoisePoint;

		public float startingWeatherRain;

		public float startingWeatherThunder;

		public float startingWeatherWetness;

		public float StartingWeatherFactor => GetStartingWeatherFactorAtTime(dateTime);

		public Vector2 noisePoint => new Vector2(noisePointX.CurrentValue, noisePointY.CurrentValue);

		public float GetStartingWeatherFactorAtTime(float dateTime)
		{
			if (!startingWeatherEnabled)
			{
				return 0f;
			}
			return Mathf.InverseLerp(startingWeatherTransitionEnd, startingWeatherTransitionStart, dateTime);
		}

		public WeatherStateChungus(float dateTime = 0f, float windDirection = 0f, float rainValue = 0f, float thunderValue = 0f, float wetnessValue = 0f, Vector2 noisePoint = default(Vector2), Weather24hPresetSO closestPreset = null, WeatherSnapshot currentLow = null, WeatherSnapshot currentHigh = null, bool startingWeatherEnabled = false, float startingWeatherTransitionStart = 0f, float startingWeatherTransitionEnd = 0f, Vector2 startingWeatherNoisePoint = default(Vector2), float startingWeatherRain = 0f, float startingWeatherThunder = 0f, float startingWeatherWetness = 0f)
		{
			this.dateTime = dateTime;
			this.windDirection = new OverridableValue<float>(windDirection);
			this.rainValue = new OverridableValue<float>(rainValue);
			this.thunderValue = new OverridableValue<float>(thunderValue);
			this.wetnessValue = new OverridableValue<float>(wetnessValue);
			noisePointX = new OverridableValue<float>(noisePoint.x);
			noisePointY = new OverridableValue<float>(noisePoint.y);
			this.closestPreset = closestPreset;
			this.currentLow = currentLow;
			this.currentHigh = currentHigh;
			this.startingWeatherEnabled = startingWeatherEnabled;
			this.startingWeatherTransitionStart = startingWeatherTransitionStart;
			this.startingWeatherTransitionEnd = startingWeatherTransitionEnd;
			this.startingWeatherNoisePoint = startingWeatherNoisePoint;
			this.startingWeatherRain = startingWeatherRain;
			this.startingWeatherThunder = startingWeatherThunder;
			this.startingWeatherWetness = startingWeatherWetness;
		}

		public WeatherStateChungus Clone()
		{
			WeatherStateChungus result = this;
			result.windDirection = new OverridableValue<float>(windDirection);
			result.rainValue = new OverridableValue<float>(rainValue);
			result.thunderValue = new OverridableValue<float>(thunderValue);
			result.wetnessValue = new OverridableValue<float>(wetnessValue);
			result.noisePointX = new OverridableValue<float>(noisePointX);
			result.noisePointY = new OverridableValue<float>(noisePointY);
			return result;
		}
	}
}
