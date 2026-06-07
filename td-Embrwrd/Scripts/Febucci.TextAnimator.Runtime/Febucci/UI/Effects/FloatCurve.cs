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
			enabled = false;
			this.defaultAmplitude = 0f;
			weightOverTime = null;
			this.amplitude = 0f;
			this.waveSize = 0f;
		}

		public float Evaluate(float passedTime, int charIndex)
		{
			return 0f;
		}
	}
}
