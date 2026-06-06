using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "GraphicsQuality", menuName = "Graphics/Graphics Quality", order = 2)]
	public sealed class GraphicsQuality : ScriptableObject
	{
		[Header("=== Quality Tier ===")]
		[Tooltip("Quality tier name")]
		public string tierName;

		[Tooltip("Tier level for sorting/comparison")]
		public GraphicsQualityTier tier;

		[Tooltip("Brief description of this quality level")]
		[TextArea(2, 3)]
		public string description;

		[Header("Localization")]
		[Tooltip("Loc key for description (UI_Settings table). If set, overrides description field.")]
		public string descriptionLocKey;

		[Tooltip("Loc key for tier name (UI_Settings table). If set, overrides tierName field.")]
		public string tierNameLocKey;

		[Header("=== Post Processing Quality ===")]
		[Tooltip("Enable/disable bloom entirely")]
		public bool allowBloom;

		[Tooltip("Use high quality bloom (more samples)")]
		public bool bloomHighQuality;

		[Tooltip("Enable/disable depth of field")]
		public bool allowDepthOfField;

		[Tooltip("DOF kernel size (0=disabled, 1=small, 2=medium, 3=large)")]
		[Range(0f, 3f)]
		public int depthOfFieldKernel;

		[Tooltip("Enable/disable motion blur")]
		public bool allowMotionBlur;

		[Tooltip("Motion blur sample count (2-32)")]
		[Range(2f, 32f)]
		public int motionBlurSamples;

		[Tooltip("Enable/disable chromatic aberration")]
		public bool allowChromaticAberration;

		[Tooltip("Enable/disable lens distortion")]
		public bool allowLensDistortion;

		[Tooltip("Enable/disable film grain")]
		public bool allowFilmGrain;

		[Tooltip("Enable/disable vignette")]
		public bool allowVignette;

		[Tooltip("Enable/disable panini projection")]
		public bool allowPaniniProjection;

		[Header("=== SSAO Quality ===")]
		[Tooltip("Enable/disable SSAO")]
		public bool allowSSAO;

		[Header("=== Shadows Quality ===")]
		[Tooltip("Maximum shadow cascade count (1-4)")]
		[Range(1f, 4f)]
		public int maxShadowCascades;

		[Tooltip("Shadow distance multiplier (0.5-2.0)")]
		[Range(0.5f, 2f)]
		public float shadowDistanceMultiplier;

		[Tooltip("Enable soft shadows")]
		public bool softShadows;

		[Tooltip("Shadow resolution (0=low 256, 1=medium 512, 2=high 1024, 3=veryhigh 2048)")]
		[Range(0f, 3f)]
		public int shadowResolution;

		[Header("=== LOD Quality ===")]
		[Tooltip("Maximum LOD bias allowed (higher = better quality at distance)")]
		[Range(0.5f, 2f)]
		public float maxLodBias;

		[Header("=== Rendering Quality ===")]
		[Tooltip("Render scale multiplier (0.5-2.0)")]
		[Range(0.5f, 2f)]
		public float renderScale;

		[Tooltip("MSAA quality level (disabled when TAA is active)")]
		public MsaaQuality msaaQuality;

		[Tooltip("Enable HDR rendering")]
		public bool hdrEnabled;

		[Tooltip("Enable opaque texture (for effects)")]
		public bool opaqueTexture;

		[Tooltip("Enable depth texture")]
		public bool depthTexture;

		[Tooltip("Enable dynamic resolution")]
		public bool dynamicResolution;

		[Header("=== Fog & Volumetrics ===")]
		[Tooltip("Enable standard fog")]
		public bool allowFog;

		[Tooltip("Enable volumetric fog (expensive)")]
		public bool allowVolumetricFog;

		[Tooltip("Volumetric fog quality (0=low, 1=medium, 2=high)")]
		[Range(0f, 2f)]
		public int volumetricFogQuality;

		[Header("=== Renderer Features ===")]
		[Tooltip("Enable decals")]
		public bool allowDecals;

		[Tooltip("Use Forward+ rendering (if available)")]
		public bool useForwardPlus;

		public string GetLocalizedTierName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		public void ApplyToPreset(GraphicsPreset preset)
		{
		}

		public string GetSummary()
		{
			return null;
		}

		public static GraphicsQuality CreateLowPreset()
		{
			return null;
		}

		public static GraphicsQuality CreateMediumPreset()
		{
			return null;
		}

		public static GraphicsQuality CreateHighPreset()
		{
			return null;
		}

		public static GraphicsQuality CreateUltraPreset()
		{
			return null;
		}

		public static GraphicsQuality CreateCinematicPreset()
		{
			return null;
		}
	}
}
