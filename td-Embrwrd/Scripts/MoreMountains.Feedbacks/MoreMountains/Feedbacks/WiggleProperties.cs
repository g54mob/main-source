using System;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class WiggleProperties
	{
		[Header("Status")]
		public bool WigglePermitted;

		[Header("Type")]
		public WiggleTypes WiggleType;

		public bool UseUnscaledTime;

		public bool StartWigglingAutomatically;

		public bool SmoothPingPong;

		[Header("Speed")]
		public bool UseSpeedCurve;

		public AnimationCurve SpeedCurve;

		[Header("Frequency")]
		public float FrequencyMin;

		public float FrequencyMax;

		[Header("Amplitude")]
		public Vector3 AmplitudeMin;

		public Vector3 AmplitudeMax;

		public bool RelativeAmplitude;

		public bool UniformValues;

		public bool ForceVectorLength;

		[MMCondition("ForceVectorLength", true)]
		public float ForcedVectorLength;

		[Header("Curve")]
		public AnimationCurve Curve;

		public Vector3 RemapCurveZeroMin;

		public Vector3 RemapCurveZeroMax;

		public Vector3 RemapCurveOneMin;

		public Vector3 RemapCurveOneMax;

		public bool RelativeCurveAmplitude;

		public bool CurvePingPong;

		[Header("Pause")]
		public float PauseMin;

		public float PauseMax;

		[Header("Limited Time")]
		public bool LimitedTime;

		public float LimitedTimeTotal;

		public AnimationCurve LimitedTimeFalloff;

		public bool LimitedTimeResetValue;

		[MMFReadOnly]
		public float LimitedTimeLeft;

		[Header("Noise Frequency")]
		public Vector3 NoiseFrequencyMin;

		public Vector3 NoiseFrequencyMax;

		[Header("Noise Shift")]
		public Vector3 NoiseShiftMin;

		public Vector3 NoiseShiftMax;

		public float GetDeltaTime()
		{
			return 0f;
		}

		public float GetTime()
		{
			return 0f;
		}
	}
}
