using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace BeautifyEffect
{
	[CreateAssetMenu(fileName = "BeautifyProfile", menuName = "Beautify Profile", order = 101)]
	public class BeautifyProfile : ScriptableObject
	{
		[Range(0f, 0.2f)]
		public float dither;

		[Range(0f, 1f)]
		public float ditherDepth;

		[Range(0f, 1f)]
		public float sharpenMinDepth;

		[Range(0f, 1.1f)]
		public float sharpenMaxDepth;

		[Range(0f, 15f)]
		public float sharpen;

		[Range(0f, 1f)]
		public float sharpenMinMaxDepthFallOff;

		[Range(0f, 0.05f)]
		public float sharpenDepthThreshold;

		public Color tintColor;

		[Range(0f, 0.2f)]
		public float sharpenRelaxation;

		[Range(0f, 1f)]
		public float sharpenClamp;

		[Range(0f, 1f)]
		public float sharpenMotionSensibility;

		[Range(0.01f, 5f)]
		public float sharpenMotionRestoreSpeed;

		[Header("Best performance mode only")]
		[Range(1f, 8f)]
		public float downscale;

		[Header("Best quality mode only")]
		[Range(1f, 3f)]
		public int superSampling;

		[Range(0f, 20f)]
		public float antialiasStrength;

		[Range(0.1f, 8f)]
		public float antialiasMaxSpread;

		[Range(0f, 0.05f)]
		public float antialiasDepthThreshold;

		public float antialiasDepthAtten;

		[Range(-2f, 3f)]
		public float saturate;

		[Range(0.5f, 1.5f)]
		public float contrast;

		[Range(0f, 2f)]
		public float brightness;

		[Range(0f, 2f)]
		public float daltonize;

		[Range(0f, 1f)]
		public float hardLightIntensity;

		[Range(0f, 1f)]
		public float hardLightBlend;

		public bool vignetting;

		public Color vignettingColor;

		public float vignettingFade;

		public bool vignettingCircularShape;

		public float vignettingAspectRatio;

		[Range(0f, 1f)]
		public float vignettingBlink;

		public BEAUTIFY_BLINK_STYLE vignettingBlinkStyle;

		public Texture2D vignettingMask;

		public Vector2 vignettingCenter;

		public bool frame;

		public Color frameColor;

		public Texture2D frameMask;

		public Beautify.FrameStyle frameStyle;

		[Range(0f, 0.5f)]
		public float frameBandHorizontalSize;

		[Range(0f, 1f)]
		public float frameBandHorizontalSmoothness;

		[Range(0f, 0.5f)]
		public float frameBandVerticalSize;

		[Range(0f, 1f)]
		public float frameBandVerticalSmoothness;

		public bool lut;

		[Range(0f, 1f)]
		public float lutIntensity;

		public Texture2D lutTexture;

		public Texture3D lutTexture3D;

		public bool nightVision;

		public Color nightVisionColor;

		public bool outline;

		[ColorUsage(false, true)]
		public Color outlineColor;

		public bool outlineCustomize;

		public bool outlineBlurDownscale;

		public BEAUTIFY_OUTLINE_STAGE outlineStage;

		[Range(0f, 2f)]
		public float outlineSpread;

		[Range(0f, 5f)]
		public int outlineBlurPassCount;

		[Range(0f, 8f)]
		public float outlineIntensityMultiplier;

		[Range(0f, 1f)]
		public float outlineMinDepthThreshold;

		public bool thermalVision;

		public bool lensDirt;

		[Range(0f, 1f)]
		public float lensDirtThreshold;

		[Range(0f, 1f)]
		public float lensDirtIntensity;

		public Texture2D lensDirtTexture;

		public bool chromaticAberration;

		[Range(0f, 0.05f)]
		public float chromaticAberrationIntensity;

		[Range(0f, 32f)]
		public float chromaticAberrationSmoothing;

		public bool bloom;

		public LayerMask bloomCullingMask;

		[Range(1f, 4f)]
		public float bloomLayerMaskDownsampling;

		public float bloomIntensity;

		public float bloomMaxBrightness;

		[Range(0f, 3f)]
		public float bloomBoost0;

		[Range(0f, 3f)]
		public float bloomBoost1;

		[Range(0f, 3f)]
		public float bloomBoost2;

		[Range(0f, 3f)]
		public float bloomBoost3;

		[Range(0f, 3f)]
		public float bloomBoost4;

		[Range(0f, 3f)]
		public float bloomBoost5;

		public bool bloomAntiflicker;

		public float bloomAntiflickerMaxOutput;

		public bool bloomUltra;

		[Range(1f, 10f)]
		public int bloomUltraResolution;

		[Range(0f, 5f)]
		public float bloomThreshold;

		public bool bloomConservativeThreshold;

		public bool bloomCustomize;

		[Range(0f, 1f)]
		public float bloomWeight0;

		[Range(0f, 1f)]
		public float bloomWeight1;

		[Range(0f, 1f)]
		public float bloomWeight2;

		[Range(0f, 1f)]
		public float bloomWeight3;

		[Range(0f, 1f)]
		public float bloomWeight4;

		[Range(0f, 1f)]
		public float bloomWeight5;

		public bool bloomBlur;

		[Range(3f, 5f)]
		public int bloomIterations;

		public bool bloomQuickerBlur;

		public float bloomDepthAtten;

		public float bloomNearAtten;

		[Range(-1f, 1f)]
		public float bloomLayerZBias;

		public Color bloomTint;

		public Color bloomTint0;

		public Color bloomTint1;

		public Color bloomTint2;

		public Color bloomTint3;

		public Color bloomTint4;

		public Color bloomTint5;

		public bool anamorphicFlares;

		public LayerMask anamorphicFlaresCullingMask;

		[Range(1f, 4f)]
		public float anamorphicFlaresLayerMaskDownsampling;

		public float anamorphicFlaresIntensity;

		public bool anamorphicFlaresAntiflicker;

		public float anamorphicFlaresAntiflickerMaxOutput;

		public bool anamorphicFlaresUltra;

		[Range(1f, 10f)]
		public int anamorphicFlaresUltraResolution;

		[Range(0f, 5f)]
		public float anamorphicFlaresThreshold;

		public bool anamorphicFlaresConservativeThreshold;

		[Range(0.1f, 2f)]
		public float anamorphicFlaresSpread;

		public bool anamorphicFlaresVertical;

		public Color anamorphicFlaresTint;

		public bool anamorphicFlaresBlur;

		public bool depthOfField;

		public bool depthOfFieldTransparencySupport;

		public Transform depthOfFieldTargetFocus;

		public bool depthOfFieldAutofocus;

		public Vector2 depthofFieldAutofocusViewportPoint;

		public LayerMask depthOfFieldAutofocusLayerMask;

		public float depthOfFieldAutofocusMinDistance;

		public float depthOfFieldAutofocusMaxDistance;

		public float depthOfFieldAutofocusDistanceShift;

		public LayerMask depthOfFieldExclusionLayerMask;

		[Range(1f, 4f)]
		public float depthOfFieldExclusionLayerMaskDownsampling;

		public CullMode depthOfFieldTransparencyCullMode;

		[Range(1f, 4f)]
		public float depthOfFieldTransparencySupportDownsampling;

		[Range(0.9f, 1f)]
		public float depthOfFieldExclusionBias;

		[Range(1f, 100f)]
		public float depthOfFieldDistance;

		[Range(0.001f, 1f)]
		public float depthOfFieldFocusSpeed;

		[Range(1f, 5f)]
		public int depthOfFieldDownsampling;

		[Range(2f, 16f)]
		public int depthOfFieldMaxSamples;

		public BEAUTIFY_DOF_CAMERA_SETTINGS depthOfFieldCameraSettings;

		[Range(0.005f, 0.5f)]
		public float depthOfFieldFocalLength;

		public float depthOfFieldAperture;

		[Range(1f, 300f)]
		public float depthOfFieldFocalLengthReal;

		[Range(1f, 32f)]
		public float depthOfFieldFStop;

		[Range(1f, 48f)]
		public float depthOfFieldImageSensorHeight;

		public bool depthOfFieldForegroundBlur;

		public bool depthOfFieldForegroundBlurHQ;

		[Range(0f, 32f)]
		public float depthOfFieldForegroundBlurHQSpread;

		public float depthOfFieldForegroundDistance;

		public bool depthOfFieldBokeh;

		public BEAUTIFY_BOKEH_COMPOSITION depthOfFieldBokehComposition;

		[Range(0.5f, 3f)]
		public float depthOfFieldBokehThreshold;

		[Range(0f, 8f)]
		public float depthOfFieldBokehIntensity;

		public float depthOfFieldMaxBrightness;

		public float depthOfFieldMaxDistance;

		public FilterMode depthOfFieldFilterMode;

		public LayerMask depthOfFieldTransparencyLayerMask;

		public CullMode depthOfFieldExclusionCullMode;

		public bool eyeAdaptation;

		[Range(0f, 1f)]
		public float eyeAdaptationMinExposure;

		[Range(1f, 100f)]
		public float eyeAdaptationMaxExposure;

		[Range(0f, 1f)]
		public float eyeAdaptationSpeedToLight;

		[Range(0f, 1f)]
		public float eyeAdaptationSpeedToDark;

		public bool purkinje;

		[Range(0f, 5f)]
		public float purkinjeAmount;

		[Range(0f, 1f)]
		public float purkinjeLuminanceThreshold;

		public BEAUTIFY_TMO tonemap;

		[Range(0f, 5f)]
		public float tonemapGamma;

		public float tonemapExposurePre;

		public float tonemapBrightnessPost;

		public bool sunFlares;

		[Range(0f, 1f)]
		public float sunFlaresIntensity;

		public float sunFlaresRevealSpeed;

		public float sunFlaresHideSpeed;

		[Range(0f, 1f)]
		public float sunFlaresSolarWindSpeed;

		public Color sunFlaresTint;

		[Range(1f, 5f)]
		public int sunFlaresDownsampling;

		[Range(0f, 1f)]
		public float sunFlaresSunIntensity;

		[Range(0f, 1f)]
		public float sunFlaresSunDiskSize;

		[Range(0f, 10f)]
		public float sunFlaresSunRayDiffractionIntensity;

		[Range(0f, 1f)]
		public float sunFlaresSunRayDiffractionThreshold;

		[Range(0f, 0.2f)]
		public float sunFlaresCoronaRays1Length;

		[Range(2f, 30f)]
		public int sunFlaresCoronaRays1Streaks;

		[Range(0f, 0.1f)]
		public float sunFlaresCoronaRays1Spread;

		[Range(0f, (float)Math.PI * 2f)]
		public float sunFlaresCoronaRays1AngleOffset;

		[Range(0f, 0.2f)]
		public float sunFlaresCoronaRays2Length;

		[Range(2f, 30f)]
		public int sunFlaresCoronaRays2Streaks;

		[Range(0f, 0.1f)]
		public float sunFlaresCoronaRays2Spread;

		[Range(0f, (float)Math.PI * 2f)]
		public float sunFlaresCoronaRays2AngleOffset;

		[Range(0f, 1f)]
		public float sunFlaresGhosts1Size;

		[Range(-3f, 3f)]
		public float sunFlaresGhosts1Offset;

		[Range(0f, 1f)]
		public float sunFlaresGhosts1Brightness;

		[Range(0f, 1f)]
		public float sunFlaresGhosts2Size;

		[Range(-3f, 3f)]
		public float sunFlaresGhosts2Offset;

		[Range(0f, 1f)]
		public float sunFlaresGhosts2Brightness;

		[Range(0f, 1f)]
		public float sunFlaresGhosts3Size;

		[Range(-3f, 3f)]
		public float sunFlaresGhosts3Brightness;

		[Range(0f, 1f)]
		public float sunFlaresGhosts3Offset;

		[Range(0f, 1f)]
		public float sunFlaresGhosts4Size;

		[Range(-3f, 3f)]
		public float sunFlaresGhosts4Offset;

		[Range(0f, 1f)]
		public float sunFlaresGhosts4Brightness;

		[Range(0f, 1f)]
		public float sunFlaresHaloOffset;

		[Range(0f, 50f)]
		public float sunFlaresHaloAmplitude;

		[Range(0f, 1f)]
		public float sunFlaresHaloIntensity;

		public bool sunFlaresRotationDeadZone;

		public float sunFlaresRadialOffset;

		public bool blur;

		[Range(0f, 4f)]
		public float blurIntensity;

		public int pixelateAmount;

		public bool pixelateDownscale;

		public void Load(Beautify b)
		{
		}

		public void Save(Beautify b)
		{
		}

		private void OnValidate()
		{
		}
	}
}
