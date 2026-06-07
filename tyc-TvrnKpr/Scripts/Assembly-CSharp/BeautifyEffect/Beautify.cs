using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace BeautifyEffect
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Rendering/Beautify")]
	[HelpURL("https://kronnect.com/support")]
	[ImageEffectAllowedInSceneView]
	public class Beautify : MonoBehaviour
	{
		public enum FrameStyle
		{
			Border = 0,
			CinematicBands = 1
		}

		public static class ShaderParams
		{
			public static int BokehData;

			public static int BokehData3;

			public static int BokehData2;

			public static int Sharpen;

			public static int Bloom;

			public static int BloomTexture;

			public static int BloomTexture1;

			public static int BloomTexture2;

			public static int BloomTexture3;

			public static int BloomTexture4;

			public static int BloomWeights2;

			public static int BloomWeights;

			public static int BloomZDepthBias;

			public static int BloomTint;

			public static int BloomTint0;

			public static int BloomTint1;

			public static int BloomTint2;

			public static int BloomTint3;

			public static int BloomTint4;

			public static int BloomTint5;

			public static int BloomDepthNearThreshold;

			public static int BloomDepthThreshold;

			public static int BloomSourceTexture;

			public static int BloomSourceDepthTexture;

			public static int BloomSourceRightEyeDepthTexture;

			public static int BloomSourceRightEyeTexture;

			public static int Purkinje;

			public static int EyeAdaptation;

			public static int CompareData;

			public static int CompareTexture;

			public static int DoFDepthBias;

			public static int DoFExclusionCullMode;

			public static int DoFTransparencyCullMode;

			public static int DoFTexture;

			public static int DoFExclusionTexture;

			public static int DoFBokehRT;

			public static int DepthTexture;

			public static int AFTint;

			public static int OverlayTexture;

			public static int SFMainTexture;

			public static int SFHalo;

			public static int SFSunTint;

			public static int SFGhosts4;

			public static int SFGhosts3;

			public static int SFGhosts2;

			public static int SFGhosts1;

			public static int SFCoronaRays1;

			public static int SFCoronaRays2;

			public static int SFSunData;

			public static int SFSunPos;

			public static int SFSunPosRightEye;

			public static int Frame;

			public static int FrameMaskTexture;

			public static int FrameData;

			public static int OutlineColor;

			public static int OutlineIntensityMultiplier;

			public static int OutlineMinDepthThreshold;

			public static int VignetteAspectRatio;

			public static int Vignette;

			public static int VignetteMaskTexture;

			public static int FXData;

			public static int FXColor;

			public static int HardLight;

			public static int ColorBoost;

			public static int ColorBoost2;

			public static int AntialiasData;

			public static int Dither;

			public static int Dirt;

			public static int ScreenLum;

			public static int TintColor;

			public static int LUT;

			public static int LUT3D;

			public static int LUT3DParams;

			public static int BlurScale;

			public static int EAHist;

			public static int EALumSrc;

			public static int FlareTexture;

			public static int ChromaticAberration;

			public static int LUTPreview;

			public static int LUTTex;

			public static int TonemapGamma;

			public const string SKW_BLOOM = "BEAUTIFY_BLOOM";

			public const string SKW_BLOOM_CONSERVATIVE_THRESHOLD = "BEAUTIFY_BLOOM_PROP_THRESHOLDING";

			public const string SKW_LUT = "BEAUTIFY_LUT";

			public const string SKW_LUT3D = "BEAUTIFY_LUT3D";

			public const string SKW_NIGHT_VISION = "BEAUTIFY_NIGHT_VISION";

			public const string SKW_THERMAL_VISION = "BEAUTIFY_THERMAL_VISION";

			public const string SKW_OUTLINE = "BEAUTIFY_OUTLINE";

			public const string SKW_FRAME = "BEAUTIFY_FRAME";

			public const string SKW_FRAME_MASK = "BEAUTIFY_FRAME_MASK";

			public const string SKW_DALTONIZE = "BEAUTIFY_DALTONIZE";

			public const string SKW_DIRT = "BEAUTIFY_DIRT";

			public const string SKW_VIGNETTING = "BEAUTIFY_VIGNETTING";

			public const string SKW_VIGNETTING_MASK = "BEAUTIFY_VIGNETTING_MASK";

			public const string SKW_DEPTH_OF_FIELD = "BEAUTIFY_DEPTH_OF_FIELD";

			public const string SKW_DEPTH_OF_FIELD_TRANSPARENT = "BEAUTIFY_DEPTH_OF_FIELD_TRANSPARENT";

			public const string SKW_EYE_ADAPTATION = "BEAUTIFY_EYE_ADAPTATION";

			public const string SKW_TONEMAP_ACES = "BEAUTIFY_TONEMAP_ACES";

			public const string SKW_TONEMAP_AGX = "BEAUTIFY_TONEMAP_AGX";

			public const string SKW_PURKINJE = "BEAUTIFY_PURKINJE";

			public const string SKW_BLOOM_USE_DEPTH = "BEAUTIFY_BLOOM_USE_DEPTH";

			public const string SKW_BLOOM_USE_LAYER = "BEAUTIFY_BLOOM_USE_LAYER";

			public const string SKW_CHROMATIC_ABERRATION = "BEAUTIFY_CHROMATIC_ABERRATION";
		}

		[CompilerGenerated]
		private sealed class _003CDoBlink_003Ed__981 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public Beautify _003C_003E4__this;

			public float maxValue;

			private float _003Cstart_003E5__2;

			private float _003Ct_003E5__3;

			private WaitForEndOfFrame _003Cw_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDoBlink_003Ed__981(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private BEAUTIFY_PRESET _preset;

		[SerializeField]
		private BEAUTIFY_QUALITY _quality;

		[SerializeField]
		private BeautifyProfile _profile;

		[SerializeField]
		private bool _syncWithProfile;

		[SerializeField]
		private bool _compareMode;

		[SerializeField]
		private BEAUTIFY_COMPARE_STYLE _compareStyle;

		[SerializeField]
		[Range(0f, 0.5f)]
		private float _comparePanning;

		[SerializeField]
		[Range(-(float)Math.PI, (float)Math.PI)]
		private float _compareLineAngle;

		[SerializeField]
		[Range(0.0001f, 0.05f)]
		private float _compareLineWidth;

		[SerializeField]
		[Range(0f, 0.2f)]
		private float _dither;

		[SerializeField]
		[Range(0f, 1f)]
		private float _ditherDepth;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sharpenMinDepth;

		[SerializeField]
		[Range(0f, 1.1f)]
		private float _sharpenMaxDepth;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sharpenMinMaxDepthFallOff;

		[SerializeField]
		[Range(0f, 15f)]
		private float _sharpen;

		[SerializeField]
		[Range(0f, 0.05f)]
		private float _sharpenDepthThreshold;

		[SerializeField]
		private Color _tintColor;

		[SerializeField]
		[Range(0f, 0.2f)]
		private float _sharpenRelaxation;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sharpenClamp;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sharpenMotionSensibility;

		[SerializeField]
		[Range(0.01f, 5f)]
		private float _sharpenMotionRestoreSpeed;

		[SerializeField]
		[Range(-2f, 3f)]
		private float _saturate;

		[SerializeField]
		[Range(0.5f, 1.5f)]
		private float _contrast;

		[SerializeField]
		private float _brightness;

		[SerializeField]
		[Range(0f, 2f)]
		private float _daltonize;

		[SerializeField]
		[Range(0f, 1f)]
		private float _hardLightIntensity;

		[SerializeField]
		[Range(0f, 1f)]
		private float _hardLightBlend;

		[SerializeField]
		private bool _vignetting;

		[SerializeField]
		private Color _vignettingColor;

		[SerializeField]
		[Range(0f, 1f)]
		private float _vignettingFade;

		[SerializeField]
		private bool _vignettingCircularShape;

		[SerializeField]
		private float _vignettingAspectRatio;

		[SerializeField]
		[Range(0f, 1f)]
		private float _vignettingBlink;

		[SerializeField]
		private BEAUTIFY_BLINK_STYLE _vignettingBlinkStyle;

		[SerializeField]
		private Vector2 _vignettingCenter;

		[SerializeField]
		private Texture2D _vignettingMask;

		[SerializeField]
		private bool _frame;

		[SerializeField]
		private FrameStyle _frameStyle;

		[SerializeField]
		[Range(0f, 0.5f)]
		private float _frameBandHorizontalSize;

		[SerializeField]
		[Range(0f, 1f)]
		private float _frameBandHorizontalSmoothness;

		[SerializeField]
		[Range(0f, 0.5f)]
		private float _frameBandVerticalSize;

		[SerializeField]
		[Range(0f, 1f)]
		private float _frameBandVerticalSmoothness;

		[SerializeField]
		private Color _frameColor;

		[SerializeField]
		private Texture2D _frameMask;

		[SerializeField]
		private bool _lut;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lutIntensity;

		[SerializeField]
		private Texture2D _lutTexture;

		[SerializeField]
		private Texture3D _lutTexture3D;

		[SerializeField]
		private bool _nightVision;

		[SerializeField]
		private Color _nightVisionColor;

		[SerializeField]
		private bool _outline;

		[SerializeField]
		[ColorUsage(false, true)]
		private Color _outlineColor;

		[SerializeField]
		private bool _outlineCustomize;

		[SerializeField]
		private BEAUTIFY_OUTLINE_STAGE _outlineStage;

		[SerializeField]
		[Range(0f, 1.3f)]
		private float _outlineSpread;

		[SerializeField]
		[Range(1f, 5f)]
		private int _outlineBlurPassCount;

		[SerializeField]
		[Range(0f, 8f)]
		private float _outlineIntensityMultiplier;

		[SerializeField]
		private bool _outlineBlurDownscale;

		[SerializeField]
		[Range(0f, 1f)]
		private float _outlineMinDepthThreshold;

		[SerializeField]
		private bool _thermalVision;

		[SerializeField]
		private bool _lensDirt;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lensDirtThreshold;

		[SerializeField]
		[Range(0f, 1f)]
		private float _lensDirtIntensity;

		[SerializeField]
		private Texture2D _lensDirtTexture;

		[SerializeField]
		private bool _bloom;

		[SerializeField]
		private LayerMask _bloomCullingMask;

		[SerializeField]
		[Range(1f, 4f)]
		private float _bloomLayerMaskDownsampling;

		[SerializeField]
		private float _bloomIntensity;

		[SerializeField]
		private float _bloomMaxBrightness;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost0;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost1;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost2;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost3;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost4;

		[SerializeField]
		[Range(0f, 3f)]
		private float _bloomBoost5;

		[SerializeField]
		private bool _bloomAntiflicker;

		[SerializeField]
		private float _bloomAntiflickerMaxOutput;

		[SerializeField]
		[Range(3f, 5f)]
		private int _bloomIterations;

		[SerializeField]
		private bool _bloomUltra;

		[SerializeField]
		[Range(1f, 10f)]
		private int _bloomUltraResolution;

		[SerializeField]
		[Range(0f, 5f)]
		private float _bloomThreshold;

		[SerializeField]
		private bool _bloomConservativeThreshold;

		[SerializeField]
		private Color _bloomTint;

		[SerializeField]
		private bool _bloomCustomize;

		[SerializeField]
		private bool _bloomDebug;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight0;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight1;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight2;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight3;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight4;

		[SerializeField]
		[Range(0f, 1f)]
		private float _bloomWeight5;

		[SerializeField]
		private Color _bloomTint0;

		[SerializeField]
		private Color _bloomTint1;

		[SerializeField]
		private Color _bloomTint2;

		[SerializeField]
		private Color _bloomTint3;

		[SerializeField]
		private Color _bloomTint4;

		[SerializeField]
		private Color _bloomTint5;

		[SerializeField]
		private bool _bloomBlur;

		[SerializeField]
		private bool _bloomQuickerBlur;

		[SerializeField]
		private float _bloomDepthAtten;

		[SerializeField]
		private float _bloomNearAtten;

		[SerializeField]
		[Range(-1f, 1f)]
		private float _bloomLayerZBias;

		[SerializeField]
		private BEAUTIFY_PRERENDER_EVENT _preRenderCameraEvent;

		[SerializeField]
		private bool _anamorphicFlares;

		[SerializeField]
		private LayerMask _anamorphicFlaresCullingMask;

		[SerializeField]
		[Range(1f, 4f)]
		private float _anamorphicFlaresLayerMaskDownsampling;

		[SerializeField]
		private float _anamorphicFlaresIntensity;

		[SerializeField]
		private bool _anamorphicFlaresAntiflicker;

		[SerializeField]
		private float _anamorphicFlaresAntiflickerMaxOutput;

		[SerializeField]
		private bool _anamorphicFlaresUltra;

		[SerializeField]
		[Range(1f, 10f)]
		private int _anamorphicFlaresUltraResolution;

		[SerializeField]
		[Range(0f, 5f)]
		private float _anamorphicFlaresThreshold;

		[SerializeField]
		[Range(0.1f, 2f)]
		private float _anamorphicFlaresSpread;

		[SerializeField]
		private bool _anamorphicFlaresVertical;

		[SerializeField]
		private Color _anamorphicFlaresTint;

		[SerializeField]
		private bool _anamorphicFlaresBlur;

		[SerializeField]
		private bool _depthOfField;

		[SerializeField]
		private bool _depthOfFieldTransparencySupport;

		[SerializeField]
		private LayerMask _depthOfFieldTransparencyLayerMask;

		[SerializeField]
		private CullMode _depthOfFieldTransparencyCullMode;

		[SerializeField]
		private Transform _depthOfFieldTargetFocus;

		[SerializeField]
		private bool _depthOfFieldDebug;

		[SerializeField]
		private bool _depthOfFieldAutofocus;

		[SerializeField]
		private Vector2 _depthofFieldAutofocusViewportPoint;

		[SerializeField]
		private float _depthOfFieldAutofocusMinDistance;

		[SerializeField]
		private float _depthOfFieldAutofocusDistanceShift;

		[SerializeField]
		private float _depthOfFieldAutofocusMaxDistance;

		[SerializeField]
		private LayerMask _depthOfFieldAutofocusLayerMask;

		[SerializeField]
		private LayerMask _depthOfFieldExclusionLayerMask;

		[SerializeField]
		private CullMode _depthOfFieldExclusionCullMode;

		[SerializeField]
		[Range(1f, 4f)]
		private float _depthOfFieldExclusionLayerMaskDownsampling;

		[SerializeField]
		[Range(1f, 4f)]
		private float _depthOfFieldTransparencySupportDownsampling;

		[SerializeField]
		[Range(0.9f, 1f)]
		private float _depthOfFieldExclusionBias;

		[SerializeField]
		[Range(1f, 100f)]
		private float _depthOfFieldDistance;

		[SerializeField]
		[Range(0.001f, 5f)]
		private float _depthOfFieldFocusSpeed;

		[SerializeField]
		[Range(1f, 5f)]
		private int _depthOfFieldDownsampling;

		[SerializeField]
		[Range(2f, 16f)]
		private int _depthOfFieldMaxSamples;

		[SerializeField]
		private BEAUTIFY_DOF_CAMERA_SETTINGS _depthOfFieldCameraSettings;

		[SerializeField]
		[Range(1f, 300f)]
		private float _depthOfFieldFocalLengthReal;

		[SerializeField]
		[Range(1f, 32f)]
		private float _depthOfFieldFStop;

		[SerializeField]
		[Range(1f, 48f)]
		private float _depthOfFieldImageSensorHeight;

		[SerializeField]
		[Range(0.005f, 0.5f)]
		private float _depthOfFieldFocalLength;

		[SerializeField]
		private float _depthOfFieldAperture;

		[SerializeField]
		private bool _depthOfFieldForegroundBlur;

		[SerializeField]
		private bool _depthOfFieldForegroundBlurHQ;

		[SerializeField]
		[Range(0f, 32f)]
		private float _depthOfFieldForegroundBlurHQSpread;

		[SerializeField]
		private float _depthOfFieldForegroundDistance;

		[SerializeField]
		private bool _depthOfFieldBokeh;

		[SerializeField]
		private BEAUTIFY_BOKEH_COMPOSITION _depthOfFieldBokehComposition;

		[SerializeField]
		[Range(0.5f, 3f)]
		private float _depthOfFieldBokehThreshold;

		[SerializeField]
		[Range(0f, 8f)]
		private float _depthOfFieldBokehIntensity;

		[SerializeField]
		private float _depthOfFieldMaxBrightness;

		[SerializeField]
		[Range(0f, 1f)]
		private float _depthOfFieldMaxDistance;

		[SerializeField]
		private FilterMode _depthOfFieldFilterMode;

		[NonSerialized]
		public OnBeforeFocusEvent OnBeforeFocus;

		[SerializeField]
		private bool _eyeAdaptation;

		[SerializeField]
		[Range(0f, 1f)]
		private float _eyeAdaptationMinExposure;

		[SerializeField]
		[Range(1f, 100f)]
		private float _eyeAdaptationMaxExposure;

		[SerializeField]
		[Range(0f, 1f)]
		private float _eyeAdaptationSpeedToLight;

		[SerializeField]
		[Range(0f, 1f)]
		private float _eyeAdaptationSpeedToDark;

		[SerializeField]
		private bool _eyeAdaptationInEditor;

		[SerializeField]
		private bool _purkinje;

		[SerializeField]
		[Range(0f, 5f)]
		private float _purkinjeAmount;

		[SerializeField]
		[Range(0f, 1f)]
		private float _purkinjeLuminanceThreshold;

		[SerializeField]
		private BEAUTIFY_TMO _tonemap;

		[SerializeField]
		[Range(0f, 5f)]
		private float _tonemapGamma;

		[SerializeField]
		private float _tonemapExposurePre;

		[SerializeField]
		private float _tonemapBrightnessPost;

		[SerializeField]
		private bool _sunFlares;

		[SerializeField]
		private Transform _sun;

		[SerializeField]
		private LayerMask _sunFlaresLayerMask;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresIntensity;

		[SerializeField]
		private float _sunFlaresRevealSpeed;

		[SerializeField]
		private float _sunFlaresHideSpeed;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresSolarWindSpeed;

		[SerializeField]
		private Color _sunFlaresTint;

		[SerializeField]
		[Range(1f, 5f)]
		private int _sunFlaresDownsampling;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresSunIntensity;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresSunDiskSize;

		[SerializeField]
		[Range(0f, 10f)]
		private float _sunFlaresSunRayDiffractionIntensity;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresSunRayDiffractionThreshold;

		[SerializeField]
		[Range(0f, 0.2f)]
		private float _sunFlaresCoronaRays1Length;

		[SerializeField]
		[Range(2f, 30f)]
		private int _sunFlaresCoronaRays1Streaks;

		[SerializeField]
		[Range(0f, 0.1f)]
		private float _sunFlaresCoronaRays1Spread;

		[SerializeField]
		[Range(0f, (float)Math.PI * 2f)]
		private float _sunFlaresCoronaRays1AngleOffset;

		[SerializeField]
		[Range(0f, 0.2f)]
		private float _sunFlaresCoronaRays2Length;

		[SerializeField]
		[Range(2f, 30f)]
		private int _sunFlaresCoronaRays2Streaks;

		[SerializeField]
		[Range(0f, 0.1f)]
		private float _sunFlaresCoronaRays2Spread;

		[SerializeField]
		[Range(0f, (float)Math.PI * 2f)]
		private float _sunFlaresCoronaRays2AngleOffset;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts1Size;

		[SerializeField]
		[Range(-3f, 3f)]
		private float _sunFlaresGhosts1Offset;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts1Brightness;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts2Size;

		[SerializeField]
		[Range(-3f, 3f)]
		private float _sunFlaresGhosts2Offset;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts2Brightness;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts3Size;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts3Brightness;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts3Offset;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts4Size;

		[SerializeField]
		[Range(-3f, 3f)]
		private float _sunFlaresGhosts4Offset;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresGhosts4Brightness;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresHaloOffset;

		[SerializeField]
		[Range(0f, 50f)]
		private float _sunFlaresHaloAmplitude;

		[SerializeField]
		[Range(0f, 1f)]
		private float _sunFlaresHaloIntensity;

		[SerializeField]
		private float _sunFlaresRadialOffset;

		[SerializeField]
		private bool _sunFlaresRotationDeadZone;

		[SerializeField]
		private bool _blur;

		[SerializeField]
		[Range(0f, 4f)]
		private float _blurIntensity;

		[SerializeField]
		[Range(1f, 8f)]
		private float _downscale;

		[SerializeField]
		[Range(1f, 3f)]
		private int _superSampling;

		[SerializeField]
		[Range(1f, 256f)]
		private int _pixelateAmount;

		[SerializeField]
		private bool _pixelateDownscale;

		[SerializeField]
		[Range(0f, 20f)]
		private float _antialiasStrength;

		[SerializeField]
		[Range(0.1f, 8f)]
		private float _antialiasMaxSpread;

		[SerializeField]
		[Range(0f, 0.001f)]
		private float _antialiasDepthThreshold;

		[SerializeField]
		private float _antialiasDepthAtten;

		[SerializeField]
		private bool _chromaticAberration;

		[SerializeField]
		[Range(0f, 0.05f)]
		private float _chromaticAberrationIntensity;

		[SerializeField]
		[Range(0f, 32f)]
		private float _chromaticAberrationSmoothing;

		public bool isDirty;

		private static Beautify _beautify;

		private Material bMatDesktop;

		private Material bMatMobile;

		private Material bMatBasic;

		private static Color ColorTransparent;

		[SerializeField]
		private Material bMat;

		private Camera currentCamera;

		private Vector3 camPrevPos;

		private Quaternion camPrevRotation;

		private float currSens;

		private int renderPass;

		private RenderTextureFormat rtFormat;

		private RenderTexture[] rt;

		private RenderTexture[] rtAF;

		private RenderTexture[] rtEA;

		private RenderTexture rtEAacum;

		private RenderTexture rtEAHist;

		private float dofPrevDistance;

		private float dofLastAutofocusDistance;

		private Vector4 dofLastBokehData;

		private Camera depthCam;

		private GameObject depthCamObj;

		private List<string> shaderKeywords;

		private Shader depthShader;

		private Shader dofExclusionShader;

		private bool shouldUpdateMaterialProperties;

		private const string BEAUTIFY_BUILD_HINT = "BeautifyBuildHint22rc5";

		private float sunFlareCurrentIntensity;

		private bool sunIsSpotlight;

		private Vector4 sunLastScrPos;

		private float sunLastRot;

		private Texture2D flareNoise;

		private RenderTexture dofDepthTexture;

		private RenderTexture dofExclusionTexture;

		private RenderTexture bloomSourceTexture;

		private RenderTexture bloomSourceDepthTexture;

		private RenderTexture bloomSourceTextureRightEye;

		private RenderTexture bloomSourceDepthTextureRightEye;

		private RenderTexture anamorphicFlaresSourceTexture;

		private RenderTexture anamorphicFlaresSourceDepthTexture;

		private RenderTexture anamorphicFlaresSourceTextureRightEye;

		private RenderTexture anamorphicFlaresSourceDepthTextureRightEye;

		private RenderTexture pixelateTexture;

		private RenderTextureDescriptor rtDescBase;

		private float sunFlareTime;

		private int dofCurrentLayerMaskValue;

		private int bloomCurrentLayerMaskValue;

		private int anamorphicFlaresCurrentLayerMaskValue;

		private int eyeWidth;

		private int eyeHeight;

		private bool isSuperSamplingActive;

		private RenderTextureFormat rtOutlineColorFormat;

		private bool linearColorSpace;

		public BEAUTIFY_PRESET preset
		{
			get
			{
				return default(BEAUTIFY_PRESET);
			}
			set
			{
			}
		}

		public BEAUTIFY_QUALITY quality
		{
			get
			{
				return default(BEAUTIFY_QUALITY);
			}
			set
			{
			}
		}

		public BeautifyProfile profile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool syncWithProfile
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool compareMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BEAUTIFY_COMPARE_STYLE compareStyle
		{
			get
			{
				return default(BEAUTIFY_COMPARE_STYLE);
			}
			set
			{
			}
		}

		public float comparePanning
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float compareLineAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float compareLineWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float dither
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ditherDepth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenMinDepth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenMaxDepth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenMinMaxDepthFallOff
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpen
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenDepthThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color tintColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float sharpenRelaxation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenClamp
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenMotionSensibility
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sharpenMotionRestoreSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float saturate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float contrast
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float daltonize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float hardLightIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float hardLightBlend
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool vignetting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color vignettingColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float vignettingFade
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool vignettingCircularShape
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float vignettingAspectRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float vignettingBlink
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BEAUTIFY_BLINK_STYLE vignettingBlinkStyle
		{
			get
			{
				return default(BEAUTIFY_BLINK_STYLE);
			}
			set
			{
			}
		}

		public Vector2 vignettingCenter
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Texture2D vignettingMask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool frame
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FrameStyle frameStyle
		{
			get
			{
				return default(FrameStyle);
			}
			set
			{
			}
		}

		public float frameBandHorizontalSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float frameBandHorizontalSmoothness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float frameBandVerticalSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float frameBandVerticalSmoothness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color frameColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Texture2D frameMask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool lut
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float lutIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Texture2D lutTexture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Texture3D lutTexture3D
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool nightVision
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color nightVisionColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool outline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color outlineColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool outlineCustomize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BEAUTIFY_OUTLINE_STAGE outlineStage
		{
			get
			{
				return default(BEAUTIFY_OUTLINE_STAGE);
			}
			set
			{
			}
		}

		public float outlineSpread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int outlineBlurPassCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float outlineIntensityMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool outlineBlurDownscale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float outlineMinDepthThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool thermalVision
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool lensDirt
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float lensDirtThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float lensDirtIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Texture2D lensDirtTexture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool bloom
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LayerMask bloomCullingMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public float bloomLayerMaskDownsampling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomMaxBrightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost0
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost3
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost4
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomBoost5
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool bloomAntiflicker
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float bloomAntiflickerMaxOutput
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int bloomIterations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool bloomUltra
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int bloomUltraResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float bloomThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool bloomConservativeThreshold
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color bloomTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool bloomCustomize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool bloomDebug
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float bloomWeight0
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomWeight1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomWeight2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomWeight3
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomWeight4
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomWeight5
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color bloomTint0
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color bloomTint1
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color bloomTint2
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color bloomTint3
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color bloomTint4
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color bloomTint5
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool bloomBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool bloomQuickerBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float bloomDepthAtten
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomNearAtten
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float bloomLayerZBias
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BEAUTIFY_PRERENDER_EVENT preRenderCameraEvent
		{
			get
			{
				return default(BEAUTIFY_PRERENDER_EVENT);
			}
			set
			{
			}
		}

		public bool anamorphicFlares
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LayerMask anamorphicFlaresCullingMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public float anamorphicFlaresLayerMaskDownsampling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float anamorphicFlaresIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool anamorphicFlaresAntiflicker
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float anamorphicFlaresAntiflickerMaxOutput
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool anamorphicFlaresUltra
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int anamorphicFlaresUltraResolution
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float anamorphicFlaresThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float anamorphicFlaresSpread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool anamorphicFlaresVertical
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color anamorphicFlaresTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public bool anamorphicFlaresBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool depthOfField
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool depthOfFieldTransparencySupport
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LayerMask depthOfFieldTransparencyLayerMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public CullMode depthOfFieldTransparencyCullMode
		{
			get
			{
				return default(CullMode);
			}
			set
			{
			}
		}

		public Transform depthOfFieldTargetFocus
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool depthOfFieldDebug
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool depthOfFieldAutofocus
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2 depthofFieldAutofocusViewportPoint
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float depthOfFieldAutofocusMinDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldAutofocusDistanceShift
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldAutofocusMaxDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public LayerMask depthOfFieldAutofocusLayerMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public LayerMask depthOfFieldExclusionLayerMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public CullMode depthOfFieldExclusionCullMode
		{
			get
			{
				return default(CullMode);
			}
			set
			{
			}
		}

		public float depthOfFieldExclusionLayerMaskDownsampling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldTransparencySupportDownsampling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldExclusionBias
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldFocusSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int depthOfFieldDownsampling
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int depthOfFieldMaxSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public BEAUTIFY_DOF_CAMERA_SETTINGS depthOfFieldCameraSettings
		{
			get
			{
				return default(BEAUTIFY_DOF_CAMERA_SETTINGS);
			}
			set
			{
			}
		}

		public float depthOfFieldFocalLengthReal
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldFStop
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldImageSensorHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldFocalLength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldAperture
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool depthOfFieldForegroundBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool depthOfFieldForegroundBlurHQ
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float depthOfFieldForegroundBlurHQSpread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldForegroundDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool depthOfFieldBokeh
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BEAUTIFY_BOKEH_COMPOSITION depthOfFieldBokehComposition
		{
			get
			{
				return default(BEAUTIFY_BOKEH_COMPOSITION);
			}
			set
			{
			}
		}

		public float depthOfFieldBokehThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldBokehIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldMaxBrightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float depthOfFieldMaxDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FilterMode depthOfFieldFilterMode
		{
			get
			{
				return default(FilterMode);
			}
			set
			{
			}
		}

		public bool eyeAdaptation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float eyeAdaptationMinExposure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float eyeAdaptationMaxExposure
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float eyeAdaptationSpeedToLight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float eyeAdaptationSpeedToDark
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool eyeAdaptationInEditor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool purkinje
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float purkinjeAmount
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float purkinjeLuminanceThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BEAUTIFY_TMO tonemap
		{
			get
			{
				return default(BEAUTIFY_TMO);
			}
			set
			{
			}
		}

		public float tonemapGamma
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float tonemapExposurePre
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float tonemapBrightnessPost
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool sunFlares
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Transform sun
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LayerMask sunFlaresLayerMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public float sunFlaresIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresRevealSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresHideSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresSolarWindSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color sunFlaresTint
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int sunFlaresDownsampling
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float sunFlaresSunIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresSunDiskSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresSunRayDiffractionIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresSunRayDiffractionThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays1Length
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int sunFlaresCoronaRays1Streaks
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays1Spread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays1AngleOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays2Length
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int sunFlaresCoronaRays2Streaks
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays2Spread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresCoronaRays2AngleOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts1Size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts1Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts1Brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts2Size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts2Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts2Brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts3Size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts3Brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts3Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts4Size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts4Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresGhosts4Brightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresHaloOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresHaloAmplitude
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresHaloIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float sunFlaresRadialOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool sunFlaresRotationDeadZone
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool blur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float blurIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float downscale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int superSampling
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private float renderScale => 0f;

		public int pixelateAmount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool pixelateDownscale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float antialiasStrength
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float antialiasMaxSpread
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float antialiasDepthThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float antialiasDepthAtten
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool chromaticAberration
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float chromaticAberrationIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float chromaticAberrationSmoothing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static Beautify instance => null;

		public Camera cameraEffect => null;

		private bool isUsingAnamorphicFlaresLayerMask => false;

		private bool isUsingBloomLayerMask => false;

		private bool isUsingDepthOfFieldExclusionLayerMask => false;

		public float depthOfFieldCurrentFocalPointDistance => 0f;

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnPreCull()
		{
		}

		private void DoOnPreRenderTasks()
		{
		}

		private void OnPreRender()
		{
		}

		private void ConfigureRenderScale()
		{
		}

		private void CleanUpRT()
		{
		}

		private RenderTextureDescriptor GetDefaultRenderTextureDescriptor()
		{
			return default(RenderTextureDescriptor);
		}

		private void CheckDoFTransparencySupport()
		{
		}

		private void CheckDoFExclusionMask()
		{
		}

		private void CheckBloomAndFlaresCulling()
		{
		}

		private void RenderLeftEyeDepth()
		{
		}

		private void RenderRightEyeDepth()
		{
		}

		private void RenderLeftEyeDepthAF()
		{
		}

		private void RenderRightEyeDepthAF()
		{
		}

		private int GetRawCopyPass()
		{
			return 0;
		}

		protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		private void EnsureSafeDimensions(ref RenderTextureDescriptor desc)
		{
		}

		private void SeparateOutlinePass(RenderTexture source)
		{
		}

		private void OnPostRender()
		{
		}

		private void BlurThis(RenderTexture rt, float blurScale = 1f)
		{
		}

		private void BlurThisOutline(RenderTexture rt, float blurScale = 1f, int downscale = 1)
		{
		}

		private void BlurThisDownscaling(RenderTexture rt, RenderTexture downscaled, float blurScale = 1f)
		{
		}

		private RenderTexture BlurThisOneDirection(RenderTexture rt, bool vertical, float blurScale = 1f)
		{
			return null;
		}

		private void BlurThisDoF(RenderTexture rt, int renderPass)
		{
		}

		private void BlurThisAlpha(RenderTexture rt, float blurScale = 1f)
		{
		}

		public void OnDidApplyAnimationProperties()
		{
		}

		public void UpdateQualitySettings()
		{
		}

		public void UpdateMaterialProperties()
		{
		}

		private void CheckColorSpace()
		{
		}

		public void UpdateMaterialPropertiesNow()
		{
		}

		private void UpdateMaterialBloomIntensityAndThreshold()
		{
		}

		private void UpdateMaterialAnamorphicIntensityAndThreshold()
		{
		}

		private void UpdateSharpenParams(float sharpen)
		{
		}

		private void UpdateDepthOfFieldData()
		{
		}

		private void UpdateDepthOfFieldBlurData(Vector2 blurDir)
		{
		}

		private void UpdateDoFAutofocusDistance()
		{
		}

		public void Blink(float duration, float maxValue = 1f)
		{
		}

		[IteratorStateMachine(typeof(_003CDoBlink_003Ed__981))]
		private IEnumerator DoBlink(float duration, float maxValue)
		{
			return null;
		}
	}
}
