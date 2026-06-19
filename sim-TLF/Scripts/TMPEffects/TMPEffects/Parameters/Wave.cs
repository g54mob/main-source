using System;
using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters.Attributes;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[Serializable]
	[TMPParameterBundle("Wave")]
	public class Wave : ISerializationCallbackReceiver
	{
		[Flags]
		public enum PulseExtrema
		{
			Early = 1,
			Late = 2,
			Both = 3
		}

		public struct WaveParameters
		{
			public float? upPeriod;

			public float? downPeriod;

			public float? amplitude;

			public AnimationCurve upwardCurve;

			public AnimationCurve downwardCurve;

			public float? crestWait;

			public float? troughWait;
		}

		[Tooltip("The time it takes for the wave to travel from trough to crest, or from its lowest to its highest point, in seconds.")]
		[SerializeField]
		[TMPParameterBundleField("upperiod", new string[] { "uppd" })]
		private float upPeriod;

		[Tooltip("The time it takes for the wave to travel from crest to trough, or from its highest to its lowest point, in seconds.")]
		[SerializeField]
		[TMPParameterBundleField("downperiod", new string[] { "downpd", "dnpd" })]
		private float downPeriod;

		[Tooltip("The amplitude of the wave.")]
		[SerializeField]
		[TMPParameterBundleField("amplitude", new string[] { "amp" })]
		private float amplitude;

		[Tooltip("The \"up\" part of the wave. This is the curve that is used to travel from trough to crest, or from the wave's lowest to its highest point.")]
		[SerializeField]
		[TMPParameterBundleField("upcurve", new string[] { "upcrv", "up" })]
		private AnimationCurve upwardCurve;

		[Tooltip("The \"down\" part of the wave. This is the curve that is used to travel from crest to trough, or from the wave's highest to its lowest point.")]
		[SerializeField]
		[TMPParameterBundleField("downcurve", new string[] { "downcrv", "down", "dn" })]
		private AnimationCurve downwardCurve;

		[Tooltip("The amount of time to remain at the crest before moving down again, in seconds.")]
		[SerializeField]
		[TMPParameterBundleField("crestwait", new string[] { "cwait", "cw" })]
		private float crestWait;

		[Tooltip("The amount of time to remain at the trough before moving up again, in seconds.")]
		[SerializeField]
		[TMPParameterBundleField("troughwait", new string[] { "twait", "tw" })]
		private float troughWait;

		[SerializeField]
		[HideInInspector]
		private float velocity;

		[NonSerialized]
		private float period;

		[NonSerialized]
		private float adjustedPeriod;

		[NonSerialized]
		private float adjustedUpPeriod;

		[NonSerialized]
		private float adjustedDownPeriod;

		[NonSerialized]
		private float frequency;

		[NonSerialized]
		private float wavelength;

		public float UpPeriod
		{
			get
			{
				return upPeriod;
			}
			set
			{
				if (value < 0f)
				{
					throw new ArgumentException("UpPeriod may not be negative");
				}
				if (value + downPeriod <= 0f)
				{
					throw new ArgumentException("The sum of UpPeriod and DownPeriod must be larger than zero");
				}
				upPeriod = value;
				period = upPeriod + downPeriod;
				frequency = 1f / period;
				wavelength = velocity * period;
				if (Velocity == 0f)
				{
					adjustedPeriod = period;
					adjustedUpPeriod = upPeriod;
				}
				else
				{
					adjustedPeriod = period * Velocity;
					adjustedUpPeriod = upPeriod * Velocity;
				}
			}
		}

		public float DownPeriod
		{
			get
			{
				return downPeriod;
			}
			set
			{
				if (value < 0f)
				{
					throw new ArgumentException("DownPeriod may not be negative");
				}
				if (value + upPeriod <= 0f)
				{
					throw new ArgumentException("The sum of UpPeriod and DownPeriod must be larger than zero");
				}
				downPeriod = value;
				period = upPeriod + downPeriod;
				frequency = 1f / period;
				wavelength = velocity * period;
				if (Velocity == 0f)
				{
					adjustedPeriod = period;
					adjustedDownPeriod = downPeriod;
				}
				else
				{
					adjustedPeriod = period * Velocity;
					adjustedDownPeriod = downPeriod * Velocity;
				}
			}
		}

		public float Amplitude
		{
			get
			{
				return amplitude;
			}
			set
			{
				amplitude = value;
			}
		}

		public float Velocity
		{
			get
			{
				return velocity;
			}
			private set
			{
				velocity = value;
				wavelength = velocity / frequency;
				frequency = velocity / wavelength;
				period = 1f / frequency;
				UpPeriod = upPeriod;
				DownPeriod = downPeriod;
			}
		}

		public float Period => period;

		public float WaveLength => wavelength;

		public float EffectiveUpPeriod => adjustedUpPeriod;

		public float EffectiveDownPeriod => adjustedDownPeriod;

		public float EffectivePeriod => adjustedPeriod;

		public float Frequency => frequency;

		public AnimationCurve UpwardCurve
		{
			get
			{
				return upwardCurve;
			}
			set
			{
				upwardCurve = value;
			}
		}

		public AnimationCurve DownwardCurve
		{
			get
			{
				return downwardCurve;
			}
			set
			{
				downwardCurve = value;
			}
		}

		public float CrestWait
		{
			get
			{
				return crestWait;
			}
			set
			{
				crestWait = value;
			}
		}

		public float TroughWait
		{
			get
			{
				return troughWait;
			}
			set
			{
				troughWait = value;
			}
		}

		public Wave()
			: this(AnimationCurveUtility.EaseInOutSine(), AnimationCurveUtility.EaseInOutSine(), 1f, 1f, 1f, 0f, 0f)
		{
		}

		public Wave(Wave original)
			: this(original.upwardCurve.Copy(), original.downwardCurve.Copy(), original.upPeriod, original.downPeriod, original.amplitude, original.crestWait, original.troughWait)
		{
		}

		private Wave(float upPeriod, float downPeriod, float amplitude)
		{
			this.upPeriod = 1f;
			this.downPeriod = 1f;
			this.amplitude = 1f;
			velocity = 1f;
			period = 1f;
			adjustedPeriod = 1f;
			adjustedUpPeriod = 1f;
			adjustedDownPeriod = 1f;
			frequency = 1f;
			wavelength = 1f;
			UpPeriod = upPeriod;
			DownPeriod = downPeriod;
			Velocity = velocity;
			Amplitude = amplitude;
		}

		public Wave(AnimationCurve upwardCurve, AnimationCurve downwardCurve, float upPeriod, float downPeriod, float amplitude)
			: this(upPeriod, downPeriod, amplitude)
		{
			if (upwardCurve == null)
			{
				throw new ArgumentNullException("upwardCurve");
			}
			if (downwardCurve == null)
			{
				throw new ArgumentNullException("downwardCurve");
			}
			if (upPeriod < 0f)
			{
				throw new ArgumentException("upPeriod may not be negative");
			}
			if (downPeriod < 0f)
			{
				throw new ArgumentException("downPeriod may not be negative");
			}
			if (upPeriod + downPeriod <= 0f)
			{
				throw new ArgumentException("The sum of upPeriod and downPeriod must be larger than zero");
			}
			UpwardCurve = upwardCurve;
			DownwardCurve = downwardCurve;
		}

		public Wave(AnimationCurve upwardCurve, AnimationCurve downwardCurve, float upPeriod, float downPeriod, float amplitude, float crestWait, float troughWait)
			: this(upwardCurve, downwardCurve, upPeriod, downPeriod, amplitude)
		{
			if (crestWait < 0f)
			{
				throw new ArgumentException("crestWait may not be negative");
			}
			if (TroughWait < 0f)
			{
				throw new ArgumentException("TroughWait may not be negative");
			}
			CrestWait = crestWait;
			TroughWait = troughWait;
		}

		public int PassedExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			if (CrestWait <= 0f)
			{
				if (TroughWait <= 0f)
				{
					return PassedWaveExtrema(time, deltaTime, offset);
				}
				return PassedPulseExtrema(time, deltaTime, offset, realtimeWait, extrema);
			}
			if (TroughWait <= 0f)
			{
				return PassedInvertedPulseExtrema(time, deltaTime, offset, realtimeWait, extrema);
			}
			return PassedOneDirectionalPulseExtrema(time, deltaTime, offset, realtimeWait, extrema);
		}

		public int PassedWaveExtrema(float time, float deltaTime, float offset)
		{
			float num = CalculateT(EffectivePeriod, time, offset, -1);
			if (deltaTime >= EffectivePeriod)
			{
				num %= EffectivePeriod;
				if (!(num < EffectiveUpPeriod))
				{
					return 1;
				}
				return -1;
			}
			float num2 = CalculateT(EffectivePeriod, time - deltaTime, offset, -1);
			if ((int)(num / EffectivePeriod) > (int)(num2 / EffectivePeriod))
			{
				num %= EffectivePeriod;
				if (!(num < EffectiveUpPeriod))
				{
					return 1;
				}
				return -1;
			}
			num2 %= EffectivePeriod;
			num %= EffectivePeriod;
			if (num2 < EffectiveUpPeriod && num >= EffectiveUpPeriod)
			{
				return 1;
			}
			return 0;
		}

		public int PassedPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			float num = TroughWait * (realtimeWait ? Velocity : 1f) + EffectivePeriod;
			float num2 = CalculateT(num, time, offset, -1);
			if (deltaTime >= num)
			{
				num2 %= num;
				if (num2 < EffectiveUpPeriod)
				{
					return -1;
				}
				if (num2 < EffectivePeriod)
				{
					return 1;
				}
				return -1;
			}
			float num3 = CalculateT(num, time - deltaTime, offset, -1);
			if ((int)(num2 / num) > (int)(num3 / num))
			{
				num2 %= num;
				if (num2 < EffectiveUpPeriod)
				{
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return -1;
					}
					return 0;
				}
				return 1;
			}
			num3 %= num;
			num2 %= num;
			if (num3 < EffectiveUpPeriod && num2 >= EffectiveUpPeriod)
			{
				return 1;
			}
			if (num3 < EffectivePeriod && num2 >= EffectivePeriod && extrema.HasFlag(PulseExtrema.Early))
			{
				return -1;
			}
			return 0;
		}

		public int PassedInvertedPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			float num = CrestWait * (realtimeWait ? Velocity : 1f) + EffectivePeriod;
			float num2 = CalculateT(num, time, offset, -1);
			if (deltaTime >= num)
			{
				num2 %= num;
				if (num2 < EffectiveDownPeriod)
				{
					return 1;
				}
				if (num2 < EffectivePeriod)
				{
					return -1;
				}
				return 1;
			}
			float num3 = CalculateT(num, time - deltaTime, offset, -1);
			if ((int)(num2 / num) > (int)(num3 / num))
			{
				num2 %= num;
				if (num2 < EffectiveDownPeriod)
				{
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return 1;
					}
					return 0;
				}
				return -1;
			}
			num3 %= num;
			num2 %= num;
			if (num3 < EffectiveDownPeriod && num2 >= EffectiveDownPeriod)
			{
				return -1;
			}
			if (num3 < EffectivePeriod && num2 >= EffectivePeriod && extrema.HasFlag(PulseExtrema.Early))
			{
				return 1;
			}
			return 0;
		}

		public int PassedOneDirectionalPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			float num = CrestWait * (realtimeWait ? Velocity : 1f);
			float num2 = TroughWait * (realtimeWait ? Velocity : 1f);
			float num3 = num + num2 + EffectivePeriod;
			float num4 = CalculateT(num3, time, offset, -1);
			if (deltaTime >= num3)
			{
				if (num3 > 0f)
				{
					num4 %= num3;
				}
				if (num4 <= EffectiveUpPeriod)
				{
					return -1;
				}
				if ((num4 -= EffectiveUpPeriod) <= num)
				{
					return 1;
				}
				if ((num4 -= num) <= EffectiveDownPeriod)
				{
					return 1;
				}
				if ((num4 -= EffectiveDownPeriod) <= num2)
				{
					return -1;
				}
				throw new Exception("Should not be reachable");
			}
			float num5 = CalculateT(num3, time - deltaTime, offset, -1);
			if ((int)(num4 / num3) > (int)(num5 / num3))
			{
				num4 %= num3;
				if (num4 < EffectiveUpPeriod)
				{
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return -1;
					}
					return 0;
				}
				if (num4 - EffectiveUpPeriod < num)
				{
					if (extrema.HasFlag(PulseExtrema.Early))
					{
						return 1;
					}
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return -1;
					}
					return 0;
				}
				if (num4 - num < EffectiveDownPeriod)
				{
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return 1;
					}
					if (extrema.HasFlag(PulseExtrema.Early))
					{
						return 1;
					}
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return -1;
					}
					return 0;
				}
				if (num4 - EffectiveDownPeriod < num2)
				{
					if (extrema.HasFlag(PulseExtrema.Early))
					{
						return -1;
					}
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return 1;
					}
					if (extrema.HasFlag(PulseExtrema.Early))
					{
						return 1;
					}
					if (extrema.HasFlag(PulseExtrema.Late))
					{
						return -1;
					}
					return 0;
				}
				throw new Exception("Should not be reachable");
			}
			num5 %= num3;
			num4 %= num3;
			num3 -= num;
			if (num5 < num3 && num4 >= num3 && extrema.HasFlag(PulseExtrema.Early))
			{
				return -1;
			}
			num3 -= EffectiveDownPeriod;
			if (num5 < num3 && num4 >= num3 && extrema.HasFlag(PulseExtrema.Late))
			{
				return 1;
			}
			num3 -= num2;
			if (num5 < num3 && num4 >= num3 && extrema.HasFlag(PulseExtrema.Early))
			{
				return 1;
			}
			return 0;
		}

		public (float Value, int Direction) Evaluate(float time, float offset, bool realtimeWait = true)
		{
			if (CrestWait <= 0f)
			{
				if (TroughWait <= 0f)
				{
					return EvaluateAsWave(time, offset);
				}
				return EvaluateAsPulse(time, offset, realtimeWait);
			}
			if (TroughWait <= 0f)
			{
				return EvaluateAsInvertedPulse(time, offset, realtimeWait);
			}
			return EvaluateAsOneDirectionalPulse(time, offset, realtimeWait);
		}

		public (float Value, int Direction) Evaluate(float time, float offset)
		{
			if (CrestWait <= 0f)
			{
				if (TroughWait <= 0f)
				{
					return EvaluateAsWave(time, offset);
				}
				return EvaluateAsPulse(time, offset);
			}
			if (TroughWait <= 0f)
			{
				return EvaluateAsInvertedPulse(time, offset);
			}
			return EvaluateAsOneDirectionalPulse(time, offset);
		}

		public (float Value, int Direction) EvaluateAsWave(float time, float offset)
		{
			float num = CalculateT(EffectivePeriod, time, offset, -1);
			if (num <= EffectiveUpPeriod)
			{
				num = Mathf.Lerp(0f, 1f, num / EffectiveUpPeriod);
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, num), Direction: 1);
			}
			num = Mathf.Lerp(1f, 2f, (num - EffectiveUpPeriod) / EffectiveDownPeriod);
			return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, num), Direction: -1);
		}

		public (float Value, int Direction) EvaluateAsPulse(float time, float offset, bool realTimeWait = true)
		{
			float num = TroughWait * (realTimeWait ? Velocity : 1f) + EffectivePeriod;
			float num2 = CalculateT(num, time, offset, -1);
			if (num2 <= 0f)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, 0f), Direction: 1);
			}
			if (num2 <= EffectiveUpPeriod)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, Mathf.Lerp(0f, 1f, num2 / EffectiveUpPeriod)), Direction: 1);
			}
			if (num2 <= EffectivePeriod)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, Mathf.Lerp(1f, 2f, (num2 - EffectiveUpPeriod) / EffectiveDownPeriod)), Direction: -1);
			}
			return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, 2f), Direction: -1);
		}

		public (float Value, int Direction) EvaluateAsInvertedPulse(float time, float offset, bool realTimeWait = true)
		{
			float num = CrestWait * (realTimeWait ? Velocity : 1f);
			float num2 = num + EffectivePeriod;
			float num3 = CalculateT(num2, time, offset, -1);
			if (num3 <= 0f)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, 0f), Direction: 1);
			}
			if (num3 <= EffectiveUpPeriod)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, Mathf.Lerp(0f, 1f, num3 / EffectiveUpPeriod)), Direction: 1);
			}
			if (num3 <= EffectiveUpPeriod + num)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, 1f), Direction: 1);
			}
			return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, Mathf.Lerp(1f, 2f, (num3 - EffectiveUpPeriod - num) / EffectiveDownPeriod)), Direction: -1);
		}

		public (float Value, int Direction) EvaluateAsOneDirectionalPulse(float time, float offset, bool realTimeWait = true)
		{
			float num = CrestWait * (realTimeWait ? Velocity : 1f);
			float num2 = TroughWait * (realTimeWait ? Velocity : 1f);
			float num3 = num + num2 + EffectivePeriod;
			float num4 = CalculateT(num3, time, offset, -1);
			if (num4 <= EffectiveUpPeriod)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, Mathf.Lerp(0f, 1f, num4 / EffectiveUpPeriod)), Direction: 1);
			}
			num4 -= EffectiveUpPeriod;
			if (num4 <= num)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(UpwardCurve, WrapMode.PingPong, 1f), Direction: 1);
			}
			num4 -= num;
			if (num4 <= EffectiveDownPeriod)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, Mathf.Lerp(1f, 2f, num4 / EffectiveDownPeriod)), Direction: -1);
			}
			num4 -= EffectiveDownPeriod;
			if (num4 <= num2)
			{
				return (Value: Amplitude * TMPAnimationUtility.GetValue(DownwardCurve, WrapMode.PingPong, Mathf.Lerp(1f, 2f, 1f)), Direction: -1);
			}
			throw new Exception("Shouldnt be reachable (interval = " + num3 + ")");
		}

		private float CalculateT(float period, float time, float offset, int mult)
		{
			float num = time + offset * (float)mult;
			if (num < 0f)
			{
				return period - (0f - num) % period;
			}
			return num % period;
		}

		public void OnBeforeSerialize()
		{
			UpdateFields();
		}

		public void OnAfterDeserialize()
		{
			UpdateFields();
		}

		private void UpdateFields()
		{
			upPeriod = Mathf.Max(upPeriod, 0f);
			downPeriod = Mathf.Max(downPeriod, 0f);
			if (downPeriod + upPeriod == 0f)
			{
				upPeriod = 0.1f;
			}
			velocity = Mathf.Max(velocity, 0.001f);
			Velocity = velocity;
			if (upwardCurve == null || upwardCurve.keys.Length == 0)
			{
				upwardCurve = AnimationCurveUtility.EaseInOutSine();
			}
			if (downwardCurve == null || downwardCurve.keys.Length == 0)
			{
				downwardCurve = AnimationCurveUtility.EaseInOutSine();
			}
			troughWait = Mathf.Max(troughWait, 0f);
			crestWait = Mathf.Max(crestWait, 0f);
		}

		public override string ToString()
		{
			return $"Wave {{\r\n    upPeriod: {upPeriod},\r\n    downPeriod: {downPeriod},\r\n    amplitude: {amplitude},\r\n    upwardCurve: {upwardCurve},\r\n    downwardCurve: {downwardCurve},\r\n    crestWait: {crestWait},\r\n    troughWait: {troughWait},\r\n    velocity: {velocity},\r\n    period: {period},\r\n    adjustedPeriod: {adjustedPeriod},\r\n    adjustedUpPeriod: {adjustedUpPeriod},\r\n    adjustedDownPeriod: {adjustedDownPeriod},\r\n    frequency: {frequency},\r\n    wavelength: {wavelength}\r\n}}";
		}

		private static void Create_Hook(ref Wave newInstance, Wave originalInstance, WaveParameters parameters)
		{
			newInstance.UpdateFields();
		}

		public static bool ValidateWaveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "upperiod", prefix + "uppd"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "downperiod", prefix + "downpd", prefix + "dnpd"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "amplitude", prefix + "amp"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywords, prefix + "upcurve", prefix + "upcrv", prefix + "up"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywords, prefix + "downcurve", prefix + "downcrv", prefix + "down", prefix + "dn"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "crestwait", prefix + "cwait", prefix + "cw"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "troughwait", prefix + "twait", prefix + "tw"))
			{
				return false;
			}
			return true;
		}

		public static WaveParameters GetWaveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			WaveParameters result = default(WaveParameters);
			if (parameters == null)
			{
				return result;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywords, prefix + "upperiod", prefix + "uppd"))
			{
				result.upPeriod = value;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywords, prefix + "downperiod", prefix + "downpd", prefix + "dnpd"))
			{
				result.downPeriod = value2;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywords, prefix + "amplitude", prefix + "amp"))
			{
				result.amplitude = value3;
			}
			if (TMPParameterUtility.TryGetAnimCurveParameter(out var value4, parameters, keywords, prefix + "upcurve", prefix + "upcrv", prefix + "up"))
			{
				result.upwardCurve = value4;
			}
			if (TMPParameterUtility.TryGetAnimCurveParameter(out var value5, parameters, keywords, prefix + "downcurve", prefix + "downcrv", prefix + "down", prefix + "dn"))
			{
				result.downwardCurve = value5;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value6, parameters, keywords, prefix + "crestwait", prefix + "cwait", prefix + "cw"))
			{
				result.crestWait = value6;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value7, parameters, keywords, prefix + "troughwait", prefix + "twait", prefix + "tw"))
			{
				result.troughWait = value7;
			}
			return result;
		}

		public static Wave CreateWave(Wave WaveInstance, WaveParameters parameters)
		{
			Wave newInstance = new Wave();
			newInstance.upPeriod = parameters.upPeriod ?? WaveInstance.upPeriod;
			newInstance.downPeriod = parameters.downPeriod ?? WaveInstance.downPeriod;
			newInstance.amplitude = parameters.amplitude ?? WaveInstance.amplitude;
			newInstance.upwardCurve = parameters.upwardCurve ?? WaveInstance.upwardCurve;
			newInstance.downwardCurve = parameters.downwardCurve ?? WaveInstance.downwardCurve;
			newInstance.crestWait = parameters.crestWait ?? WaveInstance.crestWait;
			newInstance.troughWait = parameters.troughWait ?? WaveInstance.troughWait;
			Create_Hook(ref newInstance, WaveInstance, parameters);
			return newInstance;
		}
	}
}
