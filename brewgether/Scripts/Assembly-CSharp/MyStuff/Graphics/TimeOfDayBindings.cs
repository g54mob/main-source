using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "TimeOfDayBindings", menuName = "Graphics/Time of Day Bindings", order = 4)]
	public sealed class TimeOfDayBindings : ScriptableObject
	{
		[Header("=== Exposure ===")]
		[Tooltip("Enable exposure binding")]
		public bool bindExposure;

		[Tooltip("Exposure compensation curve over time (EV units)")]
		public AnimationCurve exposureCurve;

		[Tooltip("Exposure multiplier/strength (0-2)")]
		[Range(0f, 2f)]
		public float exposureStrength;

		[Header("=== Color Temperature ===")]
		[Tooltip("Enable temperature binding")]
		public bool bindTemperature;

		[Tooltip("Temperature adjustment curve over time (-100 to 100)")]
		public AnimationCurve temperatureCurve;

		[Tooltip("Temperature multiplier/strength (0-2)")]
		[Range(0f, 2f)]
		public float temperatureStrength;

		[Header("=== Fog ===")]
		[Tooltip("Enable fog color binding")]
		public bool bindFogColor;

		[Tooltip("Fog color gradient over time")]
		public Gradient fogColorGradient;

		[Tooltip("Enable fog density binding")]
		public bool bindFogDensity;

		[Tooltip("Fog density curve over time")]
		public AnimationCurve fogDensityCurve;

		[Tooltip("Fog density multiplier (0-2)")]
		[Range(0f, 2f)]
		public float fogDensityStrength;

		[Header("=== Vignette ===")]
		[Tooltip("Enable vignette intensity binding")]
		public bool bindVignette;

		[Tooltip("Vignette intensity curve over time (0-1)")]
		public AnimationCurve vignetteCurve;

		[Tooltip("Vignette multiplier (0-2)")]
		[Range(0f, 2f)]
		public float vignetteStrength;

		[Header("=== Saturation ===")]
		[Tooltip("Enable saturation binding")]
		public bool bindSaturation;

		[Tooltip("Saturation adjustment curve over time (-100 to 100)")]
		public AnimationCurve saturationCurve;

		[Tooltip("Saturation multiplier (0-2)")]
		[Range(0f, 2f)]
		public float saturationStrength;

		[Header("=== Parameter Locks ===")]
		[Tooltip("If true, ToD won't override parameters that user has manually tweaked")]
		public bool respectManualOverrides;

		[Tooltip("Update rate in Hz (lower = better performance)")]
		[Range(1f, 60f)]
		public float updateRateHz;

		public TimeOfDayGraphicsState EvaluateAt(float normalizedTime)
		{
			return default(TimeOfDayGraphicsState);
		}
	}
}
