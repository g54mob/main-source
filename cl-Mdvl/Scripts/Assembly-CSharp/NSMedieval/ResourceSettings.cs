using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class ResourceSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private float[] temperatureThresholds;

		public float[] TemperatureThresholds => temperatureThresholds;

		public override string GetID()
		{
			return "ResourceSettings";
		}
	}
}
