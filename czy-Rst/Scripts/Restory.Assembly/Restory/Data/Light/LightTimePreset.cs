using System;
using Restory.Gameplay.TimeSystems;
using UnityEngine;

namespace Restory.Data.Light
{
	[Serializable]
	public class LightTimePreset
	{
		[SerializeField]
		private TimeOfDay timeOfDay;

		[SerializeField]
		private Color color = Color.white;

		[SerializeField]
		[Min(0f)]
		[Range(1500f, 20000f)]
		private float colorTemperature = 7343f;

		[SerializeField]
		[Min(0f)]
		private float intensity = 1f;

		public TimeOfDay TimeOfDay => timeOfDay;

		public Color Color => color;

		public float ColorTemperature => colorTemperature;

		public float Intensity => intensity;
	}
}
