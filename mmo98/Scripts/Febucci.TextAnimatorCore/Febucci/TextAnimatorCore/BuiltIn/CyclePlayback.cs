using System;
using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.BuiltIn
{
	[Serializable]
	public struct CyclePlayback : IEffectPlayback, IParameterUpdater
	{
		public float delayBeforeStart;

		public int cycles;

		public float delayBetweenCycles;

		public float fadeInDuration;

		public float fadeOutDuration;

		public float stillDuration;

		private float effectDuration;

		private float cycleDuration;

		public void UpdateParameters(RegionParameters parameters)
		{
		}

		public void Initialize()
		{
			cycleDuration = fadeInDuration + stillDuration + fadeOutDuration + delayBetweenCycles;
			if (cycles <= 0)
			{
				effectDuration = -1f;
			}
			else
			{
				effectDuration = delayBeforeStart + cycleDuration * (float)cycles - delayBetweenCycles;
			}
		}

		public float GetTotalDuration()
		{
			return effectDuration;
		}

		public void CalculateIntensity01(float time, out float intensity01, out bool hasFinishedEffect)
		{
			if (time < delayBeforeStart)
			{
				intensity01 = 0f;
				hasFinishedEffect = false;
				return;
			}
			time -= delayBeforeStart;
			if (cycleDuration <= 0f)
			{
				intensity01 = 1f;
				hasFinishedEffect = true;
				return;
			}
			if (effectDuration > 0f && time >= effectDuration)
			{
				intensity01 = 0f;
				hasFinishedEffect = true;
				return;
			}
			hasFinishedEffect = false;
			time %= cycleDuration;
			if (fadeInDuration > 0f && time <= fadeInDuration)
			{
				intensity01 = time / fadeInDuration;
				return;
			}
			time -= fadeInDuration;
			if (stillDuration > 0f && time <= stillDuration)
			{
				intensity01 = 1f;
				return;
			}
			time -= stillDuration;
			if (fadeOutDuration > 0f && time <= fadeOutDuration)
			{
				intensity01 = 1f - time / fadeOutDuration;
			}
			else
			{
				intensity01 = 0f;
			}
		}
	}
}
