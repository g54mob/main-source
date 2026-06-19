using System;
using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.Parameters.Attributes;
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
				return 0f;
			}
			set
			{
			}
		}

		public float DownPeriod
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Amplitude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Velocity
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float Period => 0f;

		public float WaveLength => 0f;

		public float EffectiveUpPeriod => 0f;

		public float EffectiveDownPeriod => 0f;

		public float EffectivePeriod => 0f;

		public float Frequency => 0f;

		public AnimationCurve UpwardCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AnimationCurve DownwardCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float CrestWait
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TroughWait
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Wave()
		{
		}

		public Wave(Wave original)
		{
		}

		private Wave(float upPeriod, float downPeriod, float amplitude)
		{
		}

		public Wave(AnimationCurve upwardCurve, AnimationCurve downwardCurve, float upPeriod, float downPeriod, float amplitude)
		{
		}

		public Wave(AnimationCurve upwardCurve, AnimationCurve downwardCurve, float upPeriod, float downPeriod, float amplitude, float crestWait, float troughWait)
		{
		}

		public int PassedExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			return 0;
		}

		public int PassedWaveExtrema(float time, float deltaTime, float offset)
		{
			return 0;
		}

		public int PassedPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			return 0;
		}

		public int PassedInvertedPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			return 0;
		}

		public int PassedOneDirectionalPulseExtrema(float time, float deltaTime, float offset, bool realtimeWait = true, PulseExtrema extrema = PulseExtrema.Early)
		{
			return 0;
		}

		public (float, int) Evaluate(float time, float offset, bool realtimeWait = true)
		{
			return default((float, int));
		}

		public (float, int) Evaluate(float time, float offset)
		{
			return default((float, int));
		}

		public (float, int) EvaluateAsWave(float time, float offset)
		{
			return default((float, int));
		}

		public (float, int) EvaluateAsPulse(float time, float offset, bool realTimeWait = true)
		{
			return default((float, int));
		}

		public (float, int) EvaluateAsInvertedPulse(float time, float offset, bool realTimeWait = true)
		{
			return default((float, int));
		}

		public (float, int) EvaluateAsOneDirectionalPulse(float time, float offset, bool realTimeWait = true)
		{
			return default((float, int));
		}

		private float CalculateT(float period, float time, float offset, int mult)
		{
			return 0f;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		private void UpdateFields()
		{
		}

		public override string ToString()
		{
			return null;
		}

		private static void Create_Hook(ref Wave newInstance, Wave originalInstance, WaveParameters parameters)
		{
		}

		public static bool ValidateWaveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return false;
		}

		public static WaveParameters GetWaveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return default(WaveParameters);
		}

		public static Wave CreateWave(Wave WaveInstance, WaveParameters parameters)
		{
			return null;
		}
	}
}
