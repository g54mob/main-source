using System;
using UnityEngine.Events;

namespace Water2D
{
	[Serializable]
	public class BlurSettings
	{
		public enum BlurType
		{
			box = 0,
			gaussian = 1,
			bokeh = 2
		}

		public BlurType blurType;

		public WaterCryo<bool> useBlur;

		public WaterCryo<int> boxSamplingRange;

		public WaterCryo<float> boxStrength;

		public WaterCryo<int> gaussianSamplingRange;

		public WaterCryo<float> gaussianStrengthX;

		public WaterCryo<float> bokehArea;

		public WaterCryo<int> bokehQuality;

		public WaterCryo<float> bokehGamma;

		public WaterCryo<float> bokehHardness;

		public WaterCryo<float> bokehRatio;

		public WaterCryo<bool> useFalloff;

		public WaterCryo<float> falloffStart;

		public WaterCryo<float> falloffEnd;

		public WaterCryo<float> falloffStrength;

		internal void onValueChanged(UnityAction onOSimulationChanged)
		{
		}
	}
}
