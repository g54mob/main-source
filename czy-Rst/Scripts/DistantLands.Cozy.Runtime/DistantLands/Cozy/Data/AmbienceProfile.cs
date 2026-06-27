using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Ambience Profile", order = 361)]
	public class AmbienceProfile : CozyProfile
	{
		[Tooltip("Specifies the minimum length for this ambience profile.")]
		[MeridiemTime]
		public float minTime = new MeridiemTime(0, 30);

		[Tooltip("Specifies the maximum length for this ambience profile.")]
		[MeridiemTime]
		public float maxTime = new MeridiemTime(2, 30);

		[Tooltip("Multiplier for the computational chance that this ambience profile will play; 0 being never, and 2 being twice as likely as the average.")]
		[Range(0f, 2f)]
		public float likelihood = 1f;

		public WeightedRandomChance chance;

		[HideTitle(1f)]
		public WeatherProfile[] dontPlayDuring;

		[ChanceEffector]
		public List<ChanceEffector> chances;

		[FX]
		public FXProfile[] FX;

		public float GetChance(CozyWeather weather)
		{
			float num = likelihood;
			foreach (ChanceEffector chance in chances)
			{
				num *= chance.GetChance(weather);
			}
			if (!(num > 0f))
			{
				return 0f;
			}
			return num;
		}

		public void SetWeight(float weightVal)
		{
			FXProfile[] fX = FX;
			for (int i = 0; i < fX.Length; i++)
			{
				fX[i]?.PlayEffect(weightVal);
			}
		}
	}
}
