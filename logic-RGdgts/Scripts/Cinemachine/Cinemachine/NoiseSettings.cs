using System;
using UnityEngine;

namespace Cinemachine
{
	public sealed class NoiseSettings : SignalSourceAsset
	{
		[Serializable]
		public struct NoiseParams
		{
			public float Frequency;

			public float Amplitude;

			public bool Constant;

			public float GetValueAt(float time, float timeOffset)
			{
				return 0f;
			}
		}

		[Serializable]
		public struct TransformNoiseParams
		{
			public NoiseParams X;

			public NoiseParams Y;

			public NoiseParams Z;

			public Vector3 GetValueAt(float time, Vector3 timeOffsets)
			{
				return default(Vector3);
			}
		}

		public TransformNoiseParams[] PositionNoise;

		public TransformNoiseParams[] OrientationNoise;

		public override float SignalDuration => 0f;

		public static Vector3 GetCombinedFilterResults(TransformNoiseParams[] noiseParams, float time, Vector3 timeOffsets)
		{
			return default(Vector3);
		}

		public override void GetSignal(float timeSinceSignalStart, out Vector3 pos, out Quaternion rot)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
		}
	}
}
