using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "PolyverseSkyPreset", menuName = "Graphics/Polyverse Sky Preset", order = 11)]
	public class PolyverseSkyPreset : ScriptableObject
	{
		[Header("=== Preset Metadata ===")]
		[Tooltip("Display name for this preset")]
		public string presetName;

		[Tooltip("Brief description of the visual style")]
		[TextArea(2, 4)]
		public string description;

		[Header("=== Reference Materials ===")]
		[Tooltip("Day sky material to sample initial values from (optional)")]
		public Material dayReferenceMaterial;

		[Tooltip("Night sky material to sample initial values from (optional)")]
		public Material nightReferenceMaterial;

		[Header("=== Sky Gradient Colors ===")]
		[Tooltip("Sky top color (zenith) over 24 hours")]
		[GradientUsage(true)]
		public Gradient skyColor;

		[Tooltip("Equator/horizon color over 24 hours")]
		[GradientUsage(true)]
		public Gradient equatorColor;

		[Tooltip("Ground reflection color over 24 hours")]
		[GradientUsage(true)]
		public Gradient groundColor;

		[Tooltip("Equator height (0-1) - where horizon color is centered")]
		public AnimationCurve equatorHeight;

		[Tooltip("Equator smoothness - how sharp the gradient transition is")]
		public AnimationCurve equatorSmoothness;

		[Header("=== Sun Settings ===")]
		[Tooltip("Sun disc color over 24 hours")]
		[GradientUsage(true)]
		public Gradient sunColor;

		[Tooltip("Sun intensity over 24 hours (0 = invisible)")]
		public AnimationCurve sunIntensity;

		[Tooltip("Sun size over 24 hours")]
		public AnimationCurve sunSize;

		[Tooltip("Enable sun disc rendering")]
		public bool enableSun;

		[Header("=== Stars Settings ===")]
		[Tooltip("Stars intensity over 24 hours (0 = invisible)")]
		public AnimationCurve starsIntensity;

		[Tooltip("Stars size multiplier")]
		public AnimationCurve starsSize;

		[Tooltip("Stars layer count (1-3)")]
		public AnimationCurve starsLayers;

		[Tooltip("Enable twinkling effect")]
		public bool enableStarsTwinkling;

		[Tooltip("Twinkling speed")]
		public float twinklingSpeed;

		[Tooltip("Twinkling contrast")]
		public float twinklingContrast;

		[Tooltip("Stars rotation speed (degrees per second)")]
		public float starsRotationSpeed;

		[Header("=== Cloud Settings ===")]
		[Tooltip("Cloud light color (sun-lit side)")]
		[GradientUsage(true)]
		public Gradient cloudsLightColor;

		[Tooltip("Cloud shadow color")]
		[GradientUsage(true)]
		public Gradient cloudsShadowColor;

		[Tooltip("Cloud intensity/visibility over 24 hours")]
		public AnimationCurve cloudsIntensity;

		[Tooltip("Cloud height position")]
		public AnimationCurve cloudsHeight;

		[Tooltip("Enable clouds")]
		public bool enableClouds;

		[Tooltip("Enable cloud rotation")]
		public bool enableCloudsRotation;

		[Tooltip("Cloud rotation speed")]
		public float cloudsRotationSpeed;

		[Header("=== Atmosphere Settings ===")]
		[Tooltip("Background exposure/brightness over 24 hours")]
		public AnimationCurve backgroundExposure;

		[Tooltip("Overall contrast")]
		public AnimationCurve contrast;

		[Tooltip("Fog intensity over 24 hours")]
		public AnimationCurve fogIntensity;

		[Tooltip("Fog height")]
		public AnimationCurve fogHeight;

		[Header("=== Pattern Overlay ===")]
		[Tooltip("Enable pattern overlay for extra detail")]
		public bool enablePatternOverlay;

		[Tooltip("Pattern contrast/visibility over 24 hours")]
		public AnimationCurve patternContrast;

		[Header("=== Ambient Light (RenderSettings) ===")]
		[Tooltip("Ambient sky color over 24 hours")]
		[GradientUsage(true)]
		public Gradient ambientSkyColor;

		[Tooltip("Ambient equator color over 24 hours")]
		[GradientUsage(true)]
		public Gradient ambientEquatorColor;

		[Tooltip("Ambient ground color over 24 hours")]
		[GradientUsage(true)]
		public Gradient ambientGroundColor;

		[Tooltip("Ambient intensity multiplier over 24 hours")]
		public AnimationCurve ambientIntensity;

		[Header("=== Fog (RenderSettings) ===")]
		[Tooltip("Unity fog color over 24 hours")]
		[GradientUsage(true)]
		public Gradient unityFogColor;

		[Tooltip("Unity fog density over 24 hours")]
		public AnimationCurve unityFogDensity;

		public PolyverseSkyState EvaluateAt(float normalizedTime)
		{
			return default(PolyverseSkyState);
		}
	}
}
