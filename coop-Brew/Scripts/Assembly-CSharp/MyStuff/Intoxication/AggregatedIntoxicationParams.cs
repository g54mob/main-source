using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace MyStuff.Intoxication
{
	public struct AggregatedIntoxicationParams
	{
		public Color vignetteColor;

		public float vignetteIntensity;

		public float vignetteSmoothness;

		public float chromaticAberration;

		public float bloomIntensity;

		public float bloomThreshold;

		public float bloomScatter;

		public Color bloomTint;

		public bool hasColorAdjustments;

		public float exposure;

		public float contrast;

		public float hueShift;

		public float saturation;

		public Color colorFilter;

		public float filmGrainIntensity;

		public FilmGrainLookup filmGrainType;

		public float lensDistortion;

		public float lensDistortionXMul;

		public float lensDistortionYMul;

		public float temperature;

		public float wbTint;

		public bool hasSplitToning;

		public Color shadowTint;

		public Color highlightTint;

		public float wobbleAmplitude;

		public float wobbleFrequency;

		public float doubleVisionOffset;

		public float doubleVisionAlpha;

		public float colorCyclingSpeed;

		public float colorCyclingIntensity;

		public float radialBlurStrength;

		public int radialBlurSamples;

		public float screenPulseAmplitude;

		public float screenPulseFrequency;

		public float focusBlurStrength;

		public float focusBlurRadius;

		public static AggregatedIntoxicationParams CreateDefault()
		{
			return default(AggregatedIntoxicationParams);
		}

		public void Clamp()
		{
		}

		public void Scale(float factor)
		{
		}

		public bool HasAnyEffect()
		{
			return false;
		}
	}
}
