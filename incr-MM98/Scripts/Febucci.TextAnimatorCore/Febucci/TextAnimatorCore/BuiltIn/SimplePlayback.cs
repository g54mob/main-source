using System;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct SimplePlayback : IEffectPlayback, IParameterUpdater
	{
		public float delayBeforeStart;

		public float fadeDuration;

		public float stillDuration;

		public void UpdateParameters(RegionParameters parameters)
		{
		}

		public void Initialize()
		{
		}

		public float GetTotalDuration()
		{
			return delayBeforeStart + fadeDuration + stillDuration;
		}

		public void CalculateIntensity01(float time, out float intensity01, out bool hasFinishedEffect)
		{
			hasFinishedEffect = false;
			if (delayBeforeStart > 0f && time <= delayBeforeStart)
			{
				intensity01 = 0f;
				return;
			}
			time -= delayBeforeStart;
			if (fadeDuration > 0f && time <= fadeDuration)
			{
				intensity01 = time / fadeDuration;
				return;
			}
			time -= fadeDuration;
			if (stillDuration > 0f && time <= stillDuration)
			{
				intensity01 = 1f;
				return;
			}
			intensity01 = 1f;
			hasFinishedEffect = true;
		}
	}
}
