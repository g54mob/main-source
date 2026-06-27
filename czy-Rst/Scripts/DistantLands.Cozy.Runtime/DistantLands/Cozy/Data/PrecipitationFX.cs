using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Precipitation FX", order = 361)]
	public class PrecipitationFX : FXProfile
	{
		[Range(0f, 0.05f)]
		public float rainAccumulationSpeed;

		[Range(0f, 1f)]
		public float maximumRainAmount;

		[Range(0f, 0.05f)]
		public float snowAccumulationSpeed;

		[Range(0f, 1f)]
		public float maximumSnowAmount;

		public float weight;

		private CozyWeather weather;

		private CozyClimateModule climateModule;

		public override void PlayEffect(float i)
		{
			if ((bool)weather || InitializeEffect(null))
			{
				climateModule.snowSpeed += snowAccumulationSpeed * Mathf.Clamp01(transitionTimeModifier.Evaluate(i)) * (float)((climateModule.snowAmount < maximumSnowAmount) ? 1 : 0);
				climateModule.rainSpeed += rainAccumulationSpeed * Mathf.Clamp01(transitionTimeModifier.Evaluate(i)) * (float)((climateModule.groundwaterAmount < maximumRainAmount) ? 1 : 0);
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			weatherSphere = (weather ? weather : CozyWeather.instance);
			if (!weatherSphere.climateModule)
			{
				return false;
			}
			climateModule = weatherSphere.climateModule;
			return true;
		}
	}
}
