using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class ChanceEffector
	{
		public enum LimitType
		{
			Temperature = 0,
			Precipitation = 1,
			YearPercentage = 2,
			Time = 3,
			AccumulatedWetness = 4,
			AccumulatedSnow = 5,
			Custom = 6
		}

		public LimitType limitType;

		public AnimationCurve curve;

		public CustomCozyChanceEffector customChanceEffector;

		public float GetChance(float test)
		{
			return curve.Evaluate(test);
		}

		public float GetChance(CozyWeather weather)
		{
			switch (limitType)
			{
			case LimitType.Temperature:
				if (weather.climateModule != null)
				{
					return curve.Evaluate(weather.climateModule.currentTemperature / 100f);
				}
				return 1f;
			case LimitType.Precipitation:
				if (weather.climateModule != null)
				{
					return curve.Evaluate(weather.climateModule.currentPrecipitation / 100f);
				}
				return 1f;
			case LimitType.YearPercentage:
				return curve.Evaluate(weather.timeModule.yearPercentage);
			case LimitType.Time:
				return curve.Evaluate(weather.timeModule.currentTime);
			case LimitType.AccumulatedSnow:
				if ((bool)weather.climateModule)
				{
					return curve.Evaluate(weather.climateModule.snowAmount);
				}
				return 1f;
			case LimitType.AccumulatedWetness:
				if ((bool)weather.climateModule)
				{
					return curve.Evaluate(weather.climateModule.groundwaterAmount);
				}
				return 1f;
			case LimitType.Custom:
				return customChanceEffector.GetChance();
			default:
				return 1f;
			}
		}

		public float GetChanceAtTime(CozyWeather weather, float time)
		{
			switch (limitType)
			{
			case LimitType.Temperature:
				if (weather.climateModule != null)
				{
					return curve.Evaluate(weather.climateModule.GetTemperature(time) / 100f);
				}
				return 1f;
			case LimitType.Precipitation:
				if (weather.climateModule != null)
				{
					return curve.Evaluate(weather.climateModule.GetHumidity(time) / 100f);
				}
				return 1f;
			case LimitType.YearPercentage:
				return curve.Evaluate(time / (float)weather.timeModule.DaysPerYear % 1f);
			case LimitType.Time:
				return curve.Evaluate(time % 1f);
			case LimitType.AccumulatedSnow:
				if ((bool)weather.climateModule)
				{
					return curve.Evaluate(weather.climateModule.groundwaterAmount);
				}
				return 1f;
			case LimitType.AccumulatedWetness:
				if ((bool)weather.climateModule)
				{
					return curve.Evaluate(weather.climateModule.snowAmount);
				}
				return 1f;
			default:
				return 1f;
			}
		}
	}
}
