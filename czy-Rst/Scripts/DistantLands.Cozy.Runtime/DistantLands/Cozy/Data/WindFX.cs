using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Wind FX", order = 361)]
	public class WindFX : FXProfile
	{
		[Range(0f, 2f)]
		public float windAmount;

		[Range(0f, 2f)]
		public float windSpeed;

		[Range(0f, 2f)]
		public float windGusting;

		[Range(0f, 10f)]
		public float windChangeSpeed = 1f;

		private CozyWindModule windModule;

		public override void PlayEffect(float weight)
		{
			if ((bool)weatherSphere && ((bool)windModule || InitializeEffect(weatherSphere)))
			{
				windModule.windAmount += windAmount * weight;
				windModule.windGusting += windGusting * weight;
				windModule.windSpeed += windSpeed * weight;
				windModule.windChangeSpeed += windChangeSpeed * weight;
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			weatherSphere = (weather ? weather : CozyWeather.instance);
			if (!weatherSphere.windModule)
			{
				return false;
			}
			windModule = weatherSphere.windModule;
			return true;
		}
	}
}
