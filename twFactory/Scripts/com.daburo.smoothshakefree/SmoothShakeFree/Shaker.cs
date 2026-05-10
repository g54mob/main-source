using System;
using UnityEngine;

namespace SmoothShakeFree
{
	[Serializable]
	public class Shaker
	{
		public enum NoiseType
		{
			SineWave = 0,
			WhiteNoise = 1
		}

		[Tooltip("The type of shake to use")]
		public NoiseType noiseType;

		[Tooltip("The amplitude (strength) of this shaker")]
		public Vector3 amplitude;

		[Tooltip("The frequency (speed) of this shaker")]
		public Vector3 frequency;

		public Vector3 Evaluate(float t)
		{
			Vector3 result = default(Vector3);
			result.x = EvaluateBase(t, amplitude.x, frequency.x);
			result.y = EvaluateBase(t, amplitude.y, frequency.y);
			result.z = EvaluateBase(t, amplitude.z, frequency.z);
			return result;
		}

		protected float EvaluateBase(float t, float amplitude, float frequency)
		{
			return noiseType switch
			{
				NoiseType.SineWave => amplitude * EvaluateSinewave(frequency * t), 
				NoiseType.WhiteNoise => amplitude * EvaluateWhiteNoise(), 
				_ => throw new Exception("Unknown noise type"), 
			};
		}

		private float EvaluateSinewave(float t)
		{
			return Mathf.Sin(MathF.PI * 2f * t);
		}

		private float EvaluateWhiteNoise()
		{
			return UnityEngine.Random.Range(-1f, 1f);
		}
	}
}
