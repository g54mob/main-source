using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Multi FX", order = 361)]
	public class MultiFXProfile : FXProfile
	{
		[Serializable]
		public class MultiFXType
		{
			public FXProfile FX;

			public ChanceEffector intensityCurve;
		}

		public CozyWeather weather;

		[MultiAudio]
		public List<MultiFXType> multiFX;

		[MultiAudio]
		public MultiFXType test;

		public override void PlayEffect(float weight)
		{
			if (weather == null)
			{
				weather = CozyWeather.instance;
			}
			foreach (MultiFXType item in multiFX)
			{
				item.FX.PlayEffect(item.intensityCurve.GetChance(weather) * weight);
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			if (weather == null)
			{
				weather = CozyWeather.instance;
			}
			foreach (MultiFXType item in multiFX)
			{
				item.FX.InitializeEffect(weather);
			}
			return true;
		}
	}
}
