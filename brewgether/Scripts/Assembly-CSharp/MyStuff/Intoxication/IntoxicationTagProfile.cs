using Brewery.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace MyStuff.Intoxication
{
	[CreateAssetMenu(fileName = "IntoxicationProfile_", menuName = "Brewery/Intoxication Tag Profile")]
	public class IntoxicationTagProfile : ScriptableObject
	{
		[Header("Tag Binding")]
		public BrewTag tag;

		[Header("Timing")]
		public float baseDuration;

		public float fadeInDuration;

		public float fadeOutDuration;

		[Header("Vignette")]
		public bool vignetteEnabled;

		public Color vignetteColor;

		[Range(0f, 1f)]
		public float vignetteIntensity;

		[Range(0f, 1f)]
		public float vignetteSmoothness;

		[Header("Chromatic Aberration")]
		public bool chromaticAberrationEnabled;

		[Range(0f, 1f)]
		public float chromaticAberrationIntensity;

		[Header("Bloom")]
		public bool bloomEnabled;

		public float bloomIntensityAdd;

		public float bloomThreshold;

		[Range(0f, 1f)]
		public float bloomScatter;

		public Color bloomTint;

		[Header("Color Adjustments")]
		public bool colorAdjustmentsEnabled;

		public float exposureAdd;

		public float contrastAdd;

		public float hueShiftAdd;

		public float saturationAdd;

		public Color colorFilter;

		[Header("Film Grain")]
		public bool filmGrainEnabled;

		public FilmGrainLookup filmGrainType;

		[Range(0f, 1f)]
		public float filmGrainIntensity;

		[Header("Lens Distortion")]
		public bool lensDistortionEnabled;

		[Range(-1f, 1f)]
		public float lensDistortionIntensity;

		[Range(0f, 1f)]
		public float lensDistortionXMul;

		[Range(0f, 1f)]
		public float lensDistortionYMul;

		[Header("White Balance")]
		public bool whiteBalanceEnabled;

		public float temperatureAdd;

		public float tintAdd;

		[Header("Split Toning")]
		public bool splitToningEnabled;

		public Color shadowTint;

		public Color highlightTint;

		[Header("Screen Wobble")]
		public float wobbleAmplitude;

		public float wobbleFrequency;

		[Header("Double Vision")]
		public float doubleVisionOffset;

		[Range(0f, 1f)]
		public float doubleVisionAlpha;

		[Header("Color Cycling")]
		public float colorCyclingSpeed;

		[Range(0f, 1f)]
		public float colorCyclingIntensity;

		[Header("Radial Blur")]
		public float radialBlurStrength;

		[Range(2f, 20f)]
		public int radialBlurSamples;

		[Header("Screen Pulse")]
		public float screenPulseAmplitude;

		public float screenPulseFrequency;

		[Header("Focus Blur")]
		public float focusBlurStrength;

		[Range(0f, 1f)]
		public float focusBlurRadius;
	}
}
