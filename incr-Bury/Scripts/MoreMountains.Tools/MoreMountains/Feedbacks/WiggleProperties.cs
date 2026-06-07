using System;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public class WiggleProperties
	{
		[Header("Status")]
		public bool WigglePermitted = true;

		[Header("Type")]
		[Tooltip("the position mode : none, random or ping pong - none won't do anything, random will randomize min and max bounds, ping pong will oscillate between min and max bounds")]
		public WiggleTypes WiggleType = WiggleTypes.Random;

		[Tooltip("if this is true, unscaled delta time, otherwise regular delta time")]
		public bool UseUnscaledTime;

		[Tooltip("a multiplier to apply to all time related operations, allowing you to speed up or slow down the wiggle")]
		public float TimeMultiplier = 1f;

		[Tooltip("whether or not this object should start wiggling automatically on Start()")]
		public bool StartWigglingAutomatically = true;

		[Tooltip("if this is true, position will be ping ponged with an ease in/out curve")]
		public bool SmoothPingPong = true;

		[Header("Speed")]
		[Tooltip("Whether or not the position's speed curve will be used")]
		public bool UseSpeedCurve;

		[Tooltip("an animation curve to define the speed over time from one position to the other (x), and the actual position (y), allowing for overshoot")]
		public AnimationCurve SpeedCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Frequency")]
		[Tooltip("the minimum time (in seconds) between two position changes")]
		public float FrequencyMin;

		[Tooltip("the maximum time (in seconds) between two position changes")]
		public float FrequencyMax = 1f;

		[Header("Amplitude")]
		[Tooltip("the minimum position the object can have")]
		public Vector3 AmplitudeMin = Vector3.zero;

		[Tooltip("the maximum position the object can have")]
		public Vector3 AmplitudeMax = Vector3.one;

		[Tooltip("if this is true, amplitude will be relative, otherwise world space")]
		public bool RelativeAmplitude = true;

		[Tooltip("if this is true, all amplitude values will match the x amplitude value")]
		public bool UniformValues;

		[Tooltip("if this is true, when randomizing amplitude, the resulting vector's length will be forced to match ForcedVectorLength")]
		public bool ForceVectorLength;

		[Tooltip("the length of the randomized amplitude if ForceVectorLength is true")]
		[MMCondition("ForceVectorLength", true)]
		public float ForcedVectorLength = 1f;

		[Header("Curve")]
		[Tooltip("a curve to animate this property on")]
		public AnimationCurve Curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Tooltip("the minimum value to randomize the curve's zero remap to")]
		public Vector3 RemapCurveZeroMin = Vector3.zero;

		[Tooltip("the maximum value to randomize the curve's zero remap to")]
		public Vector3 RemapCurveZeroMax = Vector3.zero;

		[Tooltip("the minimum value to randomize the curve's one remap to")]
		public Vector3 RemapCurveOneMin = Vector3.one;

		[Tooltip("the maximum value to randomize the curve's one remap to")]
		public Vector3 RemapCurveOneMax = Vector3.one;

		[Tooltip("whether or not to add the initial value of this property to the curve's outcome")]
		public bool RelativeCurveAmplitude = true;

		[Tooltip("whether or not the curve should be read from left to right, then right to left")]
		public bool CurvePingPong;

		[Header("Pause")]
		[Tooltip("the minimum time to spend between two random positions")]
		public float PauseMin;

		[Tooltip("the maximum time to spend between two random positions")]
		public float PauseMax;

		[Header("Limited Time")]
		[Tooltip("if this is true, this property will only animate for the specified time")]
		public bool LimitedTime;

		[Tooltip("the maximum time left")]
		public float LimitedTimeTotal;

		[Tooltip("the animation curve to use to decrease the effect of the wiggle as time goes")]
		public AnimationCurve LimitedTimeFalloff = AnimationCurve.Linear(0f, 1f, 1f, 0f);

		[Tooltip("if this is true, original position will be restored when time left reaches zero")]
		public bool LimitedTimeResetValue = true;

		[Tooltip("the actual time left")]
		[MMFReadOnly]
		public float LimitedTimeLeft;

		[Header("Noise Frequency")]
		[Tooltip("the minimum time between two changes of noise frequency")]
		public Vector3 NoiseFrequencyMin = Vector3.zero;

		[Tooltip("the maximum time between two changes of noise frequency")]
		public Vector3 NoiseFrequencyMax = Vector3.one;

		[Header("Noise Shift")]
		[Tooltip("how much the noise should be shifted at minimum")]
		public Vector3 NoiseShiftMin = Vector3.zero;

		[Tooltip("how much the noise should be shifted at maximum")]
		public Vector3 NoiseShiftMax = Vector3.zero;

		public float GetDeltaTime()
		{
			return (UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) * TimeMultiplier;
		}

		public float GetTime()
		{
			return (UseUnscaledTime ? Time.unscaledTime : Time.time) * TimeMultiplier;
		}
	}
}
