using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class PrestigeLevelData
	{
		public int Level;

		public float PrestigeRequired;

		public int MaxPopulation;

		public float SeatCoeficient;

		public float VampireRatio;

		public float TimeBetweenSpawnsInSeconds;

		public PrestigeLevelData()
		{
		}

		public PrestigeLevelData(PrestigeLevelData toCopy)
		{
			Level = toCopy.Level;
			PrestigeRequired = toCopy.PrestigeRequired;
			MaxPopulation = toCopy.MaxPopulation;
			TimeBetweenSpawnsInSeconds = toCopy.TimeBetweenSpawnsInSeconds;
			SeatCoeficient = toCopy.SeatCoeficient;
			VampireRatio = toCopy.VampireRatio;
		}

		public int MaxCustomerPopulation(bool isVampire)
		{
			int num = CTSSingleton<SeatCounter>.Instance.CurrentEveryoneSeatCount;
			if (isVampire)
			{
				num += CTSSingleton<SeatCounter>.Instance.CurrentVampireSeatCount;
			}
			return Math.Min(Mathf.CeilToInt((float)num * SeatCoeficient), MaxPopulation);
		}
	}
}
