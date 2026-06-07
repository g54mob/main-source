using System;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public abstract class WeightedPlayback : IEffectPlayback, IParameterUpdater
	{
		protected abstract float Intensity01 { get; }

		public void UpdateParameters(RegionParameters parameters)
		{
		}

		public void Initialize()
		{
		}

		public float GetTotalDuration()
		{
			return -1f;
		}

		public void CalculateIntensity01(float time, out float intensity01, out bool hasFinishedEffect)
		{
			intensity01 = Intensity01;
			hasFinishedEffect = false;
		}
	}
}
