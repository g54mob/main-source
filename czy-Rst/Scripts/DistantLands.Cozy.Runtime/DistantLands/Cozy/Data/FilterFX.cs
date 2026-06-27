using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Filter FX", order = 361)]
	public class FilterFX : FXProfile
	{
		[Range(-1f, 1f)]
		public float filterSaturation;

		[Range(-1f, 1f)]
		public float filterValue;

		[ColorUsage(false, true)]
		public Color filterColor = Color.white;

		[ColorUsage(false, true)]
		public Color sunFilter = Color.white;

		[ColorUsage(false, true)]
		public Color cloudFilter = Color.white;

		private CozyWeatherModule weatherModule;

		public override void PlayEffect(float weight)
		{
			if ((bool)weatherSphere || InitializeEffect(null))
			{
				weatherModule.filterSaturation = Mathf.Lerp(weatherModule.filterSaturation, filterSaturation, weight);
				weatherModule.filterValue = Mathf.Lerp(weatherModule.filterValue, filterValue, weight);
				weatherModule.filterColor = Color.Lerp(weatherModule.filterColor, filterColor, weight);
				weatherModule.sunFilter = Color.Lerp(weatherModule.sunFilter, sunFilter, weight);
				weatherModule.cloudFilter = Color.Lerp(weatherModule.cloudFilter, cloudFilter, weight);
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			weatherSphere = (weather ? weather : CozyWeather.instance);
			if (!weatherSphere.weatherModule)
			{
				return false;
			}
			weatherModule = weatherSphere.weatherModule;
			return true;
		}
	}
}
