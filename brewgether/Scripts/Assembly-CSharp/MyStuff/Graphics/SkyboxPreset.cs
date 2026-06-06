using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "SkyboxPreset", menuName = "Graphics/Skybox Preset", order = 10)]
	public sealed class SkyboxPreset : ScriptableObject
	{
		[Header("=== Preset Metadata ===")]
		[Tooltip("Display name for this preset")]
		public string presetName;

		[Tooltip("Brief description of the visual style")]
		[TextArea(2, 4)]
		public string description;

		[Tooltip("Optional preview thumbnail")]
		public Texture2D previewThumbnail;

		[Header("=== Skybox Material Blending ===")]
		[Tooltip("Enable blending between two skybox materials (e.g., day sky → night sky with moon)")]
		public bool enableMaterialBlending;

		[Tooltip("Secondary skybox material (e.g., night sky with moon/stars). If null, only primary material is used.")]
		public Material secondarySkyboxMaterial;

		[Tooltip("Blend weight curve (0-1 over 24 hours). 0=primary only, 1=secondary only. Use to switch to night sky.")]
		public AnimationCurve materialBlendCurve;

		[Header("=== Sun Disc ===")]
		[Tooltip("Sun disc brightness multiplier over time (5-30). Normal ≈ 10 at noon, larger at golden hours.")]
		public AnimationCurve sunDiscMultiplier;

		[Tooltip("Sun disc sharpness exponent over time (300-50000). Normal ≈ 1500 at noon, softer at golden hours.")]
		public AnimationCurve sunDiscExponent;

		[Tooltip("Sun disc color gradient over time (0=midnight, 0.5=noon)")]
		public Gradient sunDiscColor;

		[Header("=== Sun Halo ===")]
		[Tooltip("Sun halo color gradient over time. Warm at golden hours, cool/white at noon.")]
		public Gradient sunHaloColor;

		[Tooltip("Sun halo falloff exponent over time (50-300). Lower = wider halo.")]
		public AnimationCurve sunHaloExponent;

		[Tooltip("Sun halo visibility contribution over time (0-1). Fade out under overcast.")]
		[Range(0f, 1f)]
		public AnimationCurve sunHaloContribution;

		[Header("=== Horizon Line ===")]
		[Tooltip("Horizon line color gradient over time. Warm at dawn/dusk, cool at noon.")]
		public Gradient horizonLineColor;

		[Tooltip("Horizon line falloff exponent over time (1.5-8). Controls spread from horizon.")]
		public AnimationCurve horizonLineExponent;

		[Tooltip("Horizon line visibility contribution over time (0-1).")]
		[Range(0f, 1f)]
		public AnimationCurve horizonLineContribution;

		[Header("=== Sky Gradient ===")]
		[Tooltip("Sky gradient top color (zenith) over time. Most saturated.")]
		public Gradient skyGradientTop;

		[Tooltip("Sky gradient bottom color (near horizon) over time. Less saturated.")]
		public Gradient skyGradientBottom;

		[Tooltip("Sky gradient falloff exponent over time (1.5-4). Controls gradient steepness.")]
		public AnimationCurve skyGradientExponent;

		[Header("=== Ambient Trilight ===")]
		[Tooltip("Ambient sky color (zenith) over time. Should match skyGradientTop.")]
		public Gradient ambientSkyColor;

		[Tooltip("Ambient equator color (mid) over time. Transition between sky and ground.")]
		public Gradient ambientEquatorColor;

		[Tooltip("Ambient ground color (nadir) over time. Darkest, least saturated.")]
		public Gradient ambientGroundColor;

		[Tooltip("Ambient intensity multiplier over time (0-8).")]
		public AnimationCurve ambientIntensity;

		[Header("=== Fog ===")]
		[Tooltip("Fog color gradient over time. Should harmonize with skyGradientBottom/horizonLineColor.")]
		public Gradient fogColor;

		[Tooltip("Fog density curve over time. Low at noon, higher at dawn/dusk/night. Min 0.0015.")]
		public AnimationCurve fogDensity;

		[Tooltip("Fog mode (Exponential recommended for stylized look)")]
		public FogMode fogMode;

		[Tooltip("Use URP volumetric fog if available (requires URP 16+)")]
		public bool useVolumetricIfAvailable;

		[Header("=== Linear Fog (if fogMode = Linear) ===")]
		[Tooltip("Fog start distance for linear mode")]
		public float fogLinearStart;

		[Tooltip("Fog end distance for linear mode")]
		public float fogLinearEnd;

		[Header("=== Night Enhancement ===")]
		[Tooltip("Minimum ambient brightness floor (prevents pure black silhouettes at night). 0 = disabled.")]
		[Range(0f, 0.3f)]
		public float minAmbientBrightness;

		[Tooltip("Night ambient tint color (adds slight color to dark areas for moonlit feel)")]
		public Color nightAmbientTint;

		[Tooltip("Enable time-based bloom adjustment")]
		public bool enableTimeBasedBloom;

		[Tooltip("Bloom intensity multiplier over time (1.0 = no change, higher = more bloom)")]
		public AnimationCurve bloomIntensityMultiplier;

		[Tooltip("Bloom threshold offset over time (negative = more glow, 0 = no change)")]
		public AnimationCurve bloomThresholdOffset;

		[Header("=== Depth of Field (Time-Based) ===")]
		[Tooltip("Enable time-based depth of field adjustment")]
		public bool enableTimeBasedDOF;

		[Tooltip("DOF focus distance over time (meters). Shorter = closer focus = more background blur.")]
		public AnimationCurve dofFocusDistance;

		[Tooltip("DOF aperture over time (f-stop). Lower = shallower DOF = more blur. Range: 1.4-16")]
		public AnimationCurve dofAperture;

		[Tooltip("DOF focal length over time (mm). Higher = more background compression/blur. Range: 21-200")]
		public AnimationCurve dofFocalLength;

		public SkyboxState EvaluateAt(float normalizedTime)
		{
			return default(SkyboxState);
		}

		public string GetSummary()
		{
			return null;
		}
	}
}
