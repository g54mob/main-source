using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	public class ProductionSpeedMultiplierTemperature
	{
		[SerializeField]
		private float temperature;

		[SerializeField]
		private float multiplier;

		[SerializeField]
		private string mode;

		private bool isInit;

		private bool isModeGreaterThan;

		public float Temperature => temperature;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void TryInit()
		{
			if (!isInit)
			{
				isInit = true;
				isModeGreaterThan = mode.Equals("greater_than");
			}
		}

		public bool CanApply(float temperature)
		{
			TryInit();
			if (!isModeGreaterThan)
			{
				return temperature < this.temperature;
			}
			return temperature >= this.temperature;
		}

		public float GetMultiplier(float temperature)
		{
			if (!CanApply(temperature))
			{
				return 1f;
			}
			return multiplier;
		}
	}
}
