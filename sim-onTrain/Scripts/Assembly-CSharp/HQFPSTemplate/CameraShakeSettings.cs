using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class CameraShakeSettings : ICloneable
	{
		public Vector3 PositionAmplitude;

		public Vector3 RotationAmplitude;

		public AnimationCurve Decay = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

		[Clamp(0f, 10f)]
		public float Duration = 2f;

		public float Speed = 1f;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
