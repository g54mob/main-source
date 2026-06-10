using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class TemperatureSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private float skipRoomIdleUnderTemperature;

		[SerializeField]
		private float skipRoomIdleOverTemperature;

		[SerializeField]
		private float optimalNodeTemperatureRangeMin;

		[SerializeField]
		private float optimalNodeTemperatureRangeMax;

		public float SkipRoomIdleUnderTemperature => skipRoomIdleUnderTemperature;

		public float SkipRoomIdleOverTemperature => skipRoomIdleOverTemperature;

		public float OptimalNodeTemperatureRangeMin => optimalNodeTemperatureRangeMin;

		public float OptimalNodeTemperatureRangeMax => optimalNodeTemperatureRangeMax;

		public override string GetID()
		{
			return "TemperatureSettings";
		}
	}
}
