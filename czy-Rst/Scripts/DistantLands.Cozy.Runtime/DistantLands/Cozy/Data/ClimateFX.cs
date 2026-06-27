using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Climate FX", order = 361)]
	public class ClimateFX : FXProfile
	{
		[OverrideRange(-50f, 50f)]
		public Overridable<float> temperatureOffset;

		[OverrideRange(-50f, 50f)]
		public Overridable<float> precipitationOffset;

		private CozyClimateModule climate;

		public override void PlayEffect(float weight)
		{
			if (!(climate == null) || InitializeEffect(null))
			{
				climate.temperatureOffset += (float)temperatureOffset * weight;
				climate.precipitationOffset += (float)precipitationOffset * weight;
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			base.InitializeEffect(weather);
			if (weatherSphere.climateModule == null)
			{
				return false;
			}
			climate = weatherSphere.climateModule;
			return true;
		}
	}
}
