using System;
using UnityEngine;

namespace Febucci.UI.Effects
{
	[Serializable]
	public struct FloatCurve
	{
		public bool enabled;

		private readonly float defaultAmplitude;

		public AnimationCurve weightOverTime;

		public float amplitude;

		public float waveSize;

		public FloatCurve(float amplitude, float waveSize, float defaultAmplitude)
		{
			this.defaultAmplitude = defaultAmplitude;
			enabled = false;
			this.amplitude = amplitude;
			weightOverTime = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 0.5f), new Keyframe(1f, 0f));
			weightOverTime.preWrapMode = WrapMode.Loop;
			weightOverTime.postWrapMode = WrapMode.Loop;
			this.waveSize = 0f;
		}

		public float Evaluate(float passedTime, int charIndex)
		{
			if (!enabled)
			{
				return defaultAmplitude;
			}
			return Mathf.LerpUnclamped(defaultAmplitude, amplitude, weightOverTime.Evaluate(passedTime + waveSize * (float)charIndex));
		}
	}
}
