using System;
using System.Collections.Generic;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class ReflectionSettings
	{
		public List<string> layers;

		public WaterCryo<float> angle;

		public WaterCryo<float> tilt;

		public WaterCryo<float> length;

		public WaterCryo<float> originalColor;

		public WaterCryo<Color> color;

		public WaterCryo<float> alpha;

		public WaterCryo<float> y;
	}
}
