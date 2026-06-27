using System;
using System.Collections.Generic;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	public class WeightedRandomChance
	{
		[Range(0f, 1f)]
		public float baseChance = 1f;

		[Tooltip("Animation curves that increase or decrease chance based on time, temperature, etc.")]
		public List<ChanceEffector> chanceEffectors = new List<ChanceEffector>();

		public float GetChance()
		{
			return GetChance(CozyWeather.instance);
		}

		public float GetChance(CozyWeather weather)
		{
			float num = baseChance;
			foreach (ChanceEffector chanceEffector in chanceEffectors)
			{
				if (chanceEffector != null)
				{
					num *= chanceEffector.GetChance(weather);
				}
			}
			return Mathf.Max(num, 0f);
		}

		public float GetChance(CozyWeather weather, float inTime)
		{
			float num = baseChance;
			foreach (ChanceEffector chanceEffector in chanceEffectors)
			{
				if (chanceEffector != null)
				{
					num *= chanceEffector.GetChanceAtTime(weather, inTime);
				}
			}
			return Mathf.Max(num, 0f);
		}

		public bool HasLimit(ChanceEffector.LimitType limit)
		{
			foreach (ChanceEffector chanceEffector in chanceEffectors)
			{
				if (chanceEffector.limitType == limit)
				{
					return true;
				}
			}
			return false;
		}

		public float GetChance(ChanceEffector.LimitType limit, float test)
		{
			float num = baseChance;
			foreach (ChanceEffector chanceEffector in chanceEffectors)
			{
				num *= ((chanceEffector.limitType == limit) ? chanceEffector.GetChance(test) : 1f);
			}
			return num;
		}

		public static implicit operator float(WeightedRandomChance chance)
		{
			return chance.GetChance();
		}
	}
}
