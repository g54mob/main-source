using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public class OVRManager : MonoBehaviour, OVRMixedRealityCaptureConfiguration
{
	public enum XrApi
	{
		Unknown = 0,
		CAPI = 1,
		VRAPI = 2,
		OpenXR = 3
	}

	public enum TrackingOrigin
	{
		EyeLevel = 0,
		FloorLevel = 1,
		Stage = 2
	}

	public enum EyeTextureFormat
	{
		Default = 0,
		R16G16B16A16_FP = 2,
		R11G11B10_FP = 3
	}

	public enum FixedFoveatedRenderingLevel
	{
		Off = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		HighTop = 4
	}

	[Obsolete("Please use FixedFoveatedRenderingLevel instead")]
	public enum TiledMultiResLevel
	{
		Off = 0,
		LMSLow = 1,
		LMSMedium = 2,
		LMSHigh = 3,
		LMSHighTop = 4
	}

	public enum SystemHeadsetType
	{
		None = 0,
		Oculus_Quest = 8,
		Oculus_Quest_2 = 9,
		Placeholder_10 = 10,
		Placeholder_11 = 11,
		Placeholder_12 = 12,
		Placeholder_13 = 13,
		Placeholder_14 = 14,
		Rift_DK1 = 4096,
		Rift_DK2 = 4097,
		Rift_CV1 = 4098,
		Rift_CB = 4099,
		Rift_S = 4100,
		Oculus_Link_Quest = 4101,
		Oculus_Link_Quest_2 = 4102,
		PC_Placeholder_4103 = 4103,
		PC_Placeholder_4104 = 4104,
		PC_Placeholder_4105 = 4105,
		PC_Placeholder_4106 = 4106,
		PC_Placeholder_4107 = 4107
	}

	public enum XRDevice
	{
		Unknown = 0,
		Oculus = 1,
		OpenVR = 2
	}

	public enum ColorSpace
	{
		Unknown = 0,
		Unmanaged = 1,
		Rec_2020 = 2,
		Rec_709 = 3,
		Rift_CV1 = 4,
		Rift_S = 5,
		Quest = 6,
		P3 = 7,
		Adobe_RGB = 8
	}

	public enum ProcessorPerformanceLevel
	{
		PowerSavings = 0,
		SustainedLow = 1,
		SustainedHigh = 2,
		Boost = 3
	}

	public enum CompositionMethod
	{
		External = 0,
		Direct = 1
	}

	public enum CameraDevice
	{
		WebCamera0 = 0,
		WebCamera1 = 1,
		ZEDCamera = 2
	}

	public enum DepthQuality
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public enum VirtualGreenScreenType
	{
		Off = 0,
		[Obsolete("Deprecated. This enum value will not be supported in OpenXR", false)]
		OuterBoundary = 1,
		PlayArea = 2
	}

	public enum MrcActivationMode
	{
		Automatic = 0,
		Disabled = 1
	}

	public enum MrcCameraType
	{
		Normal = 0,
		Foreground = 1,
		Background = 2
	}

	public delegate GameObject InstantiateMrcCameraDelegate(GameObject mainCameraGameObject, MrcCameraType cameraType);

	private enum PassthroughInitializationState
	{
		Unspecified = 0,
		Pending = 1,
		Initialized = 2,
		Failed = 3
	}

	private static OVRProfile _profile;

	private IEnumerable<Camera> disabledCameras;

	private float prevTimeScale;

	private static bool _isHmdPresentCached = false;

	private static bool _isHmdPresent = false;

	private static bool _wasHmdPresent = false;

	private static bool _hasVrFocusCached = false;

	private static bool _hasVrFocus = false;

	private static bool _hadVrFocus = false;

	private static bool _hadInputFocus = true;

	[Header("Performance/Quality")]
	[Tooltip("If true, Unity will use the optimal antialiasing level for quality/performance on the current hardware.")]
	public bool useRecommendedMSAALevel = true;

	[SerializeField]
	[Tooltip("If true, both eyes will see the same image, rendered from the center eye pose, saving performance.")]
	private bool _monoscopic;

	[HideInInspector]
	private ColorSpace _colorGamut = ColorSpace.Rift_CV1;

	[Range(0.5f, 2f)]
	[Tooltip("Min RenderScale the app can reach under adaptive resolution mode")]
	public float minRenderScale = 0.7f;

	[Range(0.5f, 2f)]
	[Tooltip("Max RenderScale the app can reach under adaptive resolution mode")]
	public float maxRenderScale = 1f;

	[SerializeField]
	[Tooltip("Set the relative offset rotation of head poses")]
	private Vector3 _headPoseRelativeOffsetRotation;

	[SerializeField]
	[Tooltip("Set the relative offset translation of head poses")]
	private Vector3 _headPoseRelativeOffsetTranslation;

	public int profilerTcpPort = 32419;

	[HideInInspector]
	public bool expandMixedRealityCapturePropertySheet;

	[HideInInspector]
	[Tooltip("If true, Mixed Reality mode will be enabled. It would be always set to false when the game is launching without editor")]
	public bool enableMixedReality;

	[HideInInspector]
	public CompositionMethod compositionMethod;

	[HideInInspector]
	[Tooltip("Extra hidden layers")]
	public LayerMask extraHiddenLayers;

	[HideInInspector]
	[Tooltip("Extra visible layers")]
	public LayerMask extraVisibleLayers;

	[HideInInspector]
	[Tooltip("Dynamic Culling Mask")]
	public bool dynamicCullingMask = true;

	[HideInInspector]
	[Tooltip("Backdrop color for Rift (External Compositon)")]
	public Color externalCompositionBackdropColorRift = Color.green;

	[HideInInspector]
	[Tooltip("Backdrop color for Quest (External Compositon)")]
	public Color externalCompositionBackdropColorQuest = Color.clear;

	[HideInInspector]
	[Tooltip("The camera device for direct composition")]
	public CameraDevice capturingCameraDevice;

	[HideInInspector]
	[Tooltip("Flip the camera frame horizontally")]
	public bool flipCameraFrameHorizontally;

	[HideInInspector]
	[Tooltip("Flip the camera frame vertically")]
	public bool flipCameraFrameVertically;

	[HideInInspector]
	[Tooltip("Delay the touch controller pose by a short duration (0 to 0.5 second) to match the physical camera latency")]
	public float handPoseStateLatency;

	[HideInInspector]
	[Tooltip("Delay the foreground / background image in the sandwich composition to match the physical camera latency. The maximum duration is sandwichCompositionBufferedFrames / {Game FPS}")]
	public float sandwichCompositionRenderLatency;

	[HideInInspector]
	[Tooltip("The number of frames are buffered in the SandWich composition. The more buffered frames, the more memory it would consume.")]
	public int sandwichCompositionBufferedFrames = 8;

	[HideInInspector]
	[Tooltip("Chroma Key Color")]
	public Color chromaKeyColor = Color.green;

	[HideInInspector]
	[Tooltip("Chroma Key Similarity")]
	public float chromaKeySimilarity = 0.6f;

	[HideInInspector]
	[Tooltip("Chroma Key Smooth Range")]
	public float chromaKeySmoothRange = 0.03f;

	[HideInInspector]
	[Tooltip("Chroma Key Spill Range")]
	public float chromaKeySpillRange = 0.06f;

	[HideInInspector]
	[Tooltip("Use dynamic lighting (Depth sensor required)")]
	public bool useDynamicLighting;

	[HideInInspector]
	[Tooltip("The quality level of depth image. The lighting could be more smooth and accurate with high quality depth, but it would also be more costly in performance.")]
	public DepthQuality depthQuality = DepthQuality.Medium;

	[HideInInspector]
	[Tooltip("Smooth factor in dynamic lighting. Larger is smoother")]
	public float dynamicLightingSmoothFactor = 8f;

	[HideInInspector]
	[Tooltip("The maximum depth variation across the edges. Make it smaller to smooth the lighting on the edges.")]
	public float dynamicLightingDepthVariationClampingValue = 0.001f;

	[HideInInspector]
	[Tooltip("Type of virutal green screen ")]
	public VirtualGreenScreenType virtualGreenScreenType;

	[HideInInspector]
	[Tooltip("Top Y of virtual green screen")]
	public float virtualGreenScreenTopY = 10f;

	[HideInInspector]
	[Tooltip("Bottom Y of virtual green screen")]
	public float virtualGreenScreenBottomY = -10f;

	[HideInInspector]
	[Tooltip("When using a depth camera (e.g. ZED), whether to use the depth in virtual green screen culling.")]
	public bool virtualGreenScreenApplyDepthCulling;

	[HideInInspector]
	[Tooltip("The tolerance value (in meter) when using the virtual green screen with a depth camera. Make it bigger if the foreground objects got culled incorrectly.")]
	public float virtualGreenScreenDepthTolerance = 0.2f;

	[HideInInspector]
	[Tooltip("(Quest-only) control if the mixed reality capture mode can be activated automatically through remote network connection.")]
	public MrcActivationMode mrcActivationMode;

	public InstantiateMrcCameraDelegate instantiateMixedRealityCameraGameObject;

	[HideInInspector]
	[Tooltip("Specify if Insight Passthrough should be enabled. Passthrough layers can only be used if passthrough is enabled.")]
	public bool isInsightPassthroughEnabled;

	public static string OCULUS_UNITY_NAME_STR = "Oculus";

	public static string OPENVR_UNITY_NAME_STR = "OpenVR";

	public static XRDevice loadedXRDevice;

	private static Vector3 OpenVRTouchRotationOffsetEulerLeft = new Vector3(40f, 0f, 0f);

	private static Vector3 OpenVRTouchRotationOffsetEulerRight = new Vector3(40f, 0f, 0f);

	private static Vector3 OpenVRTouchPositionOffsetLeft = new Vector3(0.0075f, -0.005f, -0.0525f);

	private static Vector3 OpenVRTouchPositionOffsetRight = new Vector3(-0.0075f, -0.005f, -0.0525f);

	private static bool m_SpaceWarpEnabled;

	private static Transform m_AppSpaceTransform;

	private static DepthTextureMode m_CachedDepthTextureMode;

	[Header("Tracking")]
	[SerializeField]
	[Tooltip("Defines the current tracking origin type.")]
	private TrackingOrigin _trackingOriginType;

	[Tooltip("If true, head tracking will affect the position of each OVRCameraRig's cameras.")]
	public bool usePositionTracking = true;

	[HideInInspector]
	public bool useRotationTracking = true;

	[Tooltip("If true, the distance between the user's eyes will affect the position of each OVRCameraRig's cameras.")]
	public bool useIPDInPositionTracking = true;

	[Tooltip("If true, each scene load will cause the head pose to reset. This function only works on Rift.")]
	public bool resetTrackerOnLoad;

	[Tooltip("If true, the Reset View in the universal menu will cause the pose to be reset in PC VR. This should generally be enabled for applications with a stationary position in the virtual world and will allow the View Reset command to place the person back to a predefined location (such as a cockpit seat). Set this to false if you have a locomotion system because resetting the view would effectively teleport the player to potentially invalid locations.")]
	public bool AllowRecenter = true;

	[Tooltip("If true, rendered controller latency is reduced by several ms, as the left/right controllers will have their positions updated right before rendering.")]
	public bool LateControllerUpdate = true;

	private static bool _isUserPresentCached = false;

	private static bool _isUserPresent = false;

	private static bool _wasUserPresent = false;

	private static bool prevAudioOutIdIsCached = false;

	private static bool prevAudioInIdIsCached = false;

	private static string prevAudioOutId = string.Empty;

	private static string prevAudioInId = string.Empty;

	private static bool wasPositionTracked = false;

	private static OVRPlugin.EventDataBuffer eventDataBuffer = default(OVRPlugin.EventDataBuffer);

	public static string UnityAlphaOrBetaVersionWarningMessage = "WARNING: It's not recommended to use Unity alpha/beta release in Oculus development. Use a stable release if you encounter any issue.";

	public static bool OVRManagerinitialized = false;

	private static bool multipleMainCameraWarningPresented = false;

	private static bool suppressUnableToFindMainCameraMessage = false;

	private static WeakReference<Camera> lastFoundMainCamera = null;

	public static bool staticMixedRealityCaptureInitialized = false;

	public static bool staticPrevEnableMixedRealityCapture = false;

	public static OVRMixedRealityCaptureSettings staticMrcSettings = null;

	private static bool suppressDisableMixedRealityBecauseOfNoMainCameraWarning = false;

	private static PassthroughInitializationState _passthroughInitializationState = PassthroughInitializationState.Unspecified;

	public static OVRManager instance { get; private set; }

	public static OVRDisplay display { get; private set; }

	public static OVRTracker tracker { get; private set; }

	public static OVRBoundary boundary { get; private set; }

	public static OVRRuntimeSettings runtimeSettings { get; private set; }

	public static OVRProfile profile
	{
		get
		{
			if (_profile == null)
			{
				_profile = new OVRProfile();
			}
			return _profile;
		}
	}

	public static bool isHmdPresent
	{
		get
		{
			if (!_isHmdPresentCached)
			{
				_isHmdPresentCached = true;
				_isHmdPresent = OVRNodeStateProperties.IsHmdPresent();
			}
			return _isHmdPresent;
		}
		private set
		{
			_isHmdPresentCached = true;
			_isHmdPresent = value;
		}
	}

	public static string audioOutId => OVRPlugin.audioOutId;

	public static string audioInId => OVRPlugin.audioInId;

	public static bool hasVrFocus
	{
		get
		{
			if (!_hasVrFocusCached)
			{
				_hasVrFocusCached = true;
				_hasVrFocus = OVRPlugin.hasVrFocus;
			}
			return _hasVrFocus;
		}
		private set
		{
			_hasVrFocusCached = true;
			_hasVrFocus = value;
		}
	}

	public static bool hasInputFocus => OVRPlugin.hasInputFocus;

	public bool chromatic
	{
		get
		{
			if (!isHmdPresent)
			{
				return false;
			}
			return OVRPlugin.chromatic;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.chromatic = value;
			}
		}
	}

	public bool monoscopic
	{
		get
		{
			if (!isHmdPresent)
			{
				return _monoscopic;
			}
			return OVRPlugin.monoscopic;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.monoscopic = value;
				_monoscopic = value;
			}
		}
	}

	public ColorSpace colorGamut
	{
		get
		{
			return _colorGamut;
		}
		set
		{
			_colorGamut = value;
			OVRPlugin.SetClientColorDesc((OVRPlugin.ColorSpace)_colorGamut);
		}
	}

	public ColorSpace nativeColorGamut => (ColorSpace)OVRPlugin.GetHmdColorDesc();

	public Vector3 headPoseRelativeOffsetRotation
	{
		get
		{
			return _headPoseRelativeOffsetRotation;
		}
		set
		{
			if (OVRPlugin.GetHeadPoseModifier(out var relativeRotation, out var relativeTranslation))
			{
				relativeRotation = Quaternion.Euler(value).ToQuatf();
				OVRPlugin.SetHeadPoseModifier(ref relativeRotation, ref relativeTranslation);
			}
			_headPoseRelativeOffsetRotation = value;
		}
	}

	public Vector3 headPoseRelativeOffsetTranslation
	{
		get
		{
			return _headPoseRelativeOffsetTranslation;
		}
		set
		{
			if (OVRPlugin.GetHeadPoseModifier(out var relativeRotation, out var relativeTranslation) && relativeTranslation.FromFlippedZVector3f() != value)
			{
				relativeTranslation = value.ToFlippedZVector3f();
				OVRPlugin.SetHeadPoseModifier(ref relativeRotation, ref relativeTranslation);
			}
			_headPoseRelativeOffsetTranslation = value;
		}
	}

	[HideInInspector]
	public static bool eyeFovPremultipliedAlphaModeEnabled
	{
		get
		{
			return OVRPlugin.eyeFovPremultipliedAlphaModeEnabled;
		}
		set
		{
			OVRPlugin.eyeFovPremultipliedAlphaModeEnabled = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.enableMixedReality
	{
		get
		{
			return enableMixedReality;
		}
		set
		{
			enableMixedReality = value;
		}
	}

	LayerMask OVRMixedRealityCaptureConfiguration.extraHiddenLayers
	{
		get
		{
			return extraHiddenLayers;
		}
		set
		{
			extraHiddenLayers = value;
		}
	}

	LayerMask OVRMixedRealityCaptureConfiguration.extraVisibleLayers
	{
		get
		{
			return extraVisibleLayers;
		}
		set
		{
			extraVisibleLayers = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.dynamicCullingMask
	{
		get
		{
			return dynamicCullingMask;
		}
		set
		{
			dynamicCullingMask = value;
		}
	}

	CompositionMethod OVRMixedRealityCaptureConfiguration.compositionMethod
	{
		get
		{
			return compositionMethod;
		}
		set
		{
			compositionMethod = value;
		}
	}

	Color OVRMixedRealityCaptureConfiguration.externalCompositionBackdropColorRift
	{
		get
		{
			return externalCompositionBackdropColorRift;
		}
		set
		{
			externalCompositionBackdropColorRift = value;
		}
	}

	Color OVRMixedRealityCaptureConfiguration.externalCompositionBackdropColorQuest
	{
		get
		{
			return externalCompositionBackdropColorQuest;
		}
		set
		{
			externalCompositionBackdropColorQuest = value;
		}
	}

	CameraDevice OVRMixedRealityCaptureConfiguration.capturingCameraDevice
	{
		get
		{
			return capturingCameraDevice;
		}
		set
		{
			capturingCameraDevice = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.flipCameraFrameHorizontally
	{
		get
		{
			return flipCameraFrameHorizontally;
		}
		set
		{
			flipCameraFrameHorizontally = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.flipCameraFrameVertically
	{
		get
		{
			return flipCameraFrameVertically;
		}
		set
		{
			flipCameraFrameVertically = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.handPoseStateLatency
	{
		get
		{
			return handPoseStateLatency;
		}
		set
		{
			handPoseStateLatency = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.sandwichCompositionRenderLatency
	{
		get
		{
			return sandwichCompositionRenderLatency;
		}
		set
		{
			sandwichCompositionRenderLatency = value;
		}
	}

	int OVRMixedRealityCaptureConfiguration.sandwichCompositionBufferedFrames
	{
		get
		{
			return sandwichCompositionBufferedFrames;
		}
		set
		{
			sandwichCompositionBufferedFrames = value;
		}
	}

	Color OVRMixedRealityCaptureConfiguration.chromaKeyColor
	{
		get
		{
			return chromaKeyColor;
		}
		set
		{
			chromaKeyColor = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.chromaKeySimilarity
	{
		get
		{
			return chromaKeySimilarity;
		}
		set
		{
			chromaKeySimilarity = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.chromaKeySmoothRange
	{
		get
		{
			return chromaKeySmoothRange;
		}
		set
		{
			chromaKeySmoothRange = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.chromaKeySpillRange
	{
		get
		{
			return chromaKeySpillRange;
		}
		set
		{
			chromaKeySpillRange = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.useDynamicLighting
	{
		get
		{
			return useDynamicLighting;
		}
		set
		{
			useDynamicLighting = value;
		}
	}

	DepthQuality OVRMixedRealityCaptureConfiguration.depthQuality
	{
		get
		{
			return depthQuality;
		}
		set
		{
			depthQuality = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.dynamicLightingSmoothFactor
	{
		get
		{
			return dynamicLightingSmoothFactor;
		}
		set
		{
			dynamicLightingSmoothFactor = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.dynamicLightingDepthVariationClampingValue
	{
		get
		{
			return dynamicLightingDepthVariationClampingValue;
		}
		set
		{
			dynamicLightingDepthVariationClampingValue = value;
		}
	}

	VirtualGreenScreenType OVRMixedRealityCaptureConfiguration.virtualGreenScreenType
	{
		get
		{
			return virtualGreenScreenType;
		}
		set
		{
			virtualGreenScreenType = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.virtualGreenScreenTopY
	{
		get
		{
			return virtualGreenScreenTopY;
		}
		set
		{
			virtualGreenScreenTopY = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.virtualGreenScreenBottomY
	{
		get
		{
			return virtualGreenScreenBottomY;
		}
		set
		{
			virtualGreenScreenBottomY = value;
		}
	}

	bool OVRMixedRealityCaptureConfiguration.virtualGreenScreenApplyDepthCulling
	{
		get
		{
			return virtualGreenScreenApplyDepthCulling;
		}
		set
		{
			virtualGreenScreenApplyDepthCulling = value;
		}
	}

	float OVRMixedRealityCaptureConfiguration.virtualGreenScreenDepthTolerance
	{
		get
		{
			return virtualGreenScreenDepthTolerance;
		}
		set
		{
			virtualGreenScreenDepthTolerance = value;
		}
	}

	MrcActivationMode OVRMixedRealityCaptureConfiguration.mrcActivationMode
	{
		get
		{
			return mrcActivationMode;
		}
		set
		{
			mrcActivationMode = value;
		}
	}

	InstantiateMrcCameraDelegate OVRMixedRealityCaptureConfiguration.instantiateMixedRealityCameraGameObject
	{
		get
		{
			return instantiateMixedRealityCameraGameObject;
		}
		set
		{
			instantiateMixedRealityCameraGameObject = value;
		}
	}

	public XrApi xrApi => (XrApi)OVRPlugin.nativeXrApi;

	public ulong xrInstance => OVRPlugin.GetNativeOpenXRInstance();

	public ulong xrSession => OVRPlugin.GetNativeOpenXRSession();

	public int vsyncCount
	{
		get
		{
			if (!isHmdPresent)
			{
				return 1;
			}
			return OVRPlugin.vsyncCount;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.vsyncCount = value;
			}
		}
	}

	[Obsolete("Deprecated. Please use SystemInfo.batteryLevel", false)]
	public static float batteryLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return 1f;
			}
			return OVRPlugin.batteryLevel;
		}
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static float batteryTemperature
	{
		get
		{
			if (!isHmdPresent)
			{
				return 0f;
			}
			return OVRPlugin.batteryTemperature;
		}
	}

	[Obsolete("Deprecated. Please use SystemInfo.batteryStatus", false)]
	public static int batteryStatus
	{
		get
		{
			if (!isHmdPresent)
			{
				return -1;
			}
			return (int)OVRPlugin.batteryStatus;
		}
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static float volumeLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return 0f;
			}
			return OVRPlugin.systemVolume;
		}
	}

	public static ProcessorPerformanceLevel suggestedCpuPerfLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return ProcessorPerformanceLevel.PowerSavings;
			}
			return (ProcessorPerformanceLevel)OVRPlugin.suggestedCpuPerfLevel;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.suggestedCpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)value;
			}
		}
	}

	public static ProcessorPerformanceLevel suggestedGpuPerfLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return ProcessorPerformanceLevel.PowerSavings;
			}
			return (ProcessorPerformanceLevel)OVRPlugin.suggestedGpuPerfLevel;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.suggestedGpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)value;
			}
		}
	}

	[Obsolete("Deprecated. Please use suggestedCpuPerfLevel", false)]
	public static int cpuLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return 2;
			}
			return OVRPlugin.cpuLevel;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.cpuLevel = value;
			}
		}
	}

	[Obsolete("Deprecated. Please use suggestedGpuPerfLevel", false)]
	public static int gpuLevel
	{
		get
		{
			if (!isHmdPresent)
			{
				return 2;
			}
			return OVRPlugin.gpuLevel;
		}
		set
		{
			if (isHmdPresent)
			{
				OVRPlugin.gpuLevel = value;
			}
		}
	}

	public static bool isPowerSavingActive
	{
		get
		{
			if (!isHmdPresent)
			{
				return false;
			}
			return OVRPlugin.powerSaving;
		}
	}

	public static EyeTextureFormat eyeTextureFormat
	{
		get
		{
			return (EyeTextureFormat)OVRPlugin.GetDesiredEyeTextureFormat();
		}
		set
		{
			OVRPlugin.SetDesiredEyeTextureFormat((OVRPlugin.EyeTextureFormat)value);
		}
	}

	public static bool fixedFoveatedRenderingSupported => OVRPlugin.fixedFoveatedRenderingSupported;

	public static FixedFoveatedRenderingLevel fixedFoveatedRenderingLevel
	{
		get
		{
			if (!OVRPlugin.fixedFoveatedRenderingSupported)
			{
				Debug.LogWarning("Fixed Foveated Rendering feature is not supported");
			}
			return (FixedFoveatedRenderingLevel)OVRPlugin.fixedFoveatedRenderingLevel;
		}
		set
		{
			if (!OVRPlugin.fixedFoveatedRenderingSupported)
			{
				Debug.LogWarning("Fixed Foveated Rendering feature is not supported");
			}
			OVRPlugin.fixedFoveatedRenderingLevel = (OVRPlugin.FixedFoveatedRenderingLevel)value;
		}
	}

	public static bool useDynamicFixedFoveatedRendering
	{
		get
		{
			if (!OVRPlugin.fixedFoveatedRenderingSupported)
			{
				Debug.LogWarning("Fixed Foveated Rendering feature is not supported");
			}
			return OVRPlugin.useDynamicFixedFoveatedRendering;
		}
		set
		{
			if (!OVRPlugin.fixedFoveatedRenderingSupported)
			{
				Debug.LogWarning("Fixed Foveated Rendering feature is not supported");
			}
			OVRPlugin.useDynamicFixedFoveatedRendering = value;
		}
	}

	[Obsolete("Please use fixedFoveatedRenderingSupported instead", false)]
	public static bool tiledMultiResSupported => OVRPlugin.tiledMultiResSupported;

	[Obsolete("Please use fixedFoveatedRenderingLevel instead", false)]
	public static TiledMultiResLevel tiledMultiResLevel
	{
		get
		{
			if (!OVRPlugin.tiledMultiResSupported)
			{
				Debug.LogWarning("Tiled-based Multi-resolution feature is not supported");
			}
			return (TiledMultiResLevel)OVRPlugin.tiledMultiResLevel;
		}
		set
		{
			if (!OVRPlugin.tiledMultiResSupported)
			{
				Debug.LogWarning("Tiled-based Multi-resolution feature is not supported");
			}
			OVRPlugin.tiledMultiResLevel = (OVRPlugin.TiledMultiResLevel)value;
		}
	}

	public static bool gpuUtilSupported => OVRPlugin.gpuUtilSupported;

	public static float gpuUtilLevel
	{
		get
		{
			if (!OVRPlugin.gpuUtilSupported)
			{
				Debug.LogWarning("GPU Util is not supported");
			}
			return OVRPlugin.gpuUtilLevel;
		}
	}

	public static SystemHeadsetType systemHeadsetType => (SystemHeadsetType)OVRPlugin.GetSystemHeadsetType();

	public TrackingOrigin trackingOriginType
	{
		get
		{
			if (!isHmdPresent)
			{
				return _trackingOriginType;
			}
			return (TrackingOrigin)OVRPlugin.GetTrackingOriginType();
		}
		set
		{
			if (isHmdPresent && OVRPlugin.SetTrackingOriginType((OVRPlugin.TrackingOrigin)value))
			{
				_trackingOriginType = value;
			}
		}
	}

	public bool isSupportedPlatform { get; private set; }

	public bool isUserPresent
	{
		get
		{
			if (!_isUserPresentCached)
			{
				_isUserPresentCached = true;
				_isUserPresent = OVRPlugin.userPresent;
			}
			return _isUserPresent;
		}
		private set
		{
			_isUserPresentCached = true;
			_isUserPresent = value;
		}
	}

	public static Version utilitiesVersion => OVRPlugin.wrapperVersion;

	public static Version pluginVersion => OVRPlugin.version;

	public static Version sdkVersion => OVRPlugin.nativeSDKVersion;

	public static event Action HMDAcquired;

	public static event Action HMDLost;

	public static event Action HMDMounted;

	public static event Action HMDUnmounted;

	public static event Action VrFocusAcquired;

	public static event Action VrFocusLost;

	public static event Action InputFocusAcquired;

	public static event Action InputFocusLost;

	public static event Action AudioOutChanged;

	public static event Action AudioInChanged;

	public static event Action TrackingAcquired;

	public static event Action TrackingLost;

	public static event Action<float, float> DisplayRefreshRateChanged;

	public static event Action<ulong, bool, OVRPlugin.SpatialEntityComponentType, ulong> SpatialEntitySetComponentEnabled;

	public static event Action<ulong, int, OVRPlugin.SpatialEntityQueryResult[]> SpatialEntityQueryResults;

	public static event Action<ulong, bool, int> SpatialEntityQueryComplete;

	public static event Action<ulong, ulong, bool, OVRPlugin.SpatialEntityUuid> SpatialEntityStorageSave;

	public static event Action<ulong, bool, OVRPlugin.SpatialEntityUuid, OVRPlugin.SpatialEntityStorageLocation> SpatialEntityStorageErase;

	[Obsolete]
	public static event Action HSWDismissed;

	public static bool IsAdaptiveResSupportedByEngine()
	{
		return true;
	}

	public static void SetColorScaleAndOffset(Vector4 colorScale, Vector4 colorOffset, bool applyToAllLayers)
	{
		OVRPlugin.SetColorScaleAndOffset(colorScale, colorOffset, applyToAllLayers);
	}

	public static void SetOpenVRLocalPose(Vector3 leftPos, Vector3 rightPos, Quaternion leftRot, Quaternion rightRot)
	{
		if (loadedXRDevice == XRDevice.OpenVR)
		{
			OVRInput.SetOpenVRLocalPose(leftPos, rightPos, leftRot, rightRot);
		}
	}

	public static OVRPose GetOpenVRControllerOffset(XRNode hand)
	{
		OVRPose identity = OVRPose.identity;
		if ((hand == XRNode.LeftHand || hand == XRNode.RightHand) && loadedXRDevice == XRDevice.OpenVR)
		{
			int num = ((hand != XRNode.LeftHand) ? 1 : 0);
			if (OVRInput.openVRControllerDetails[num].controllerType == OVRInput.OpenVRController.OculusTouch)
			{
				Vector3 vector = ((hand == XRNode.LeftHand) ? OpenVRTouchRotationOffsetEulerLeft : OpenVRTouchRotationOffsetEulerRight);
				identity.orientation = Quaternion.Euler(vector.x, vector.y, vector.z);
				identity.position = ((hand == XRNode.LeftHand) ? OpenVRTouchPositionOffsetLeft : OpenVRTouchPositionOffsetRight);
			}
		}
		return identity;
	}

	public static void SetSpaceWarp(bool enabled)
	{
		Camera camera = FindMainCamera();
		if (enabled)
		{
			m_CachedDepthTextureMode = camera.depthTextureMode;
			camera.depthTextureMode |= DepthTextureMode.Depth | DepthTextureMode.MotionVectors;
			if (camera.transform.parent == null)
			{
				m_AppSpaceTransform.position = Vector3.zero;
				m_AppSpaceTransform.rotation = Quaternion.identity;
			}
			else
			{
				m_AppSpaceTransform = camera.transform.parent;
			}
		}
		else
		{
			camera.depthTextureMode = m_CachedDepthTextureMode;
			m_AppSpaceTransform = null;
		}
		m_SpaceWarpEnabled = enabled;
	}

	public static bool GetSpaceWarp()
	{
		return m_SpaceWarpEnabled;
	}

	private static bool MixedRealityEnabledFromCmd()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].ToLower() == "-mixedreality")
			{
				return true;
			}
		}
		return false;
	}

	private static bool UseDirectCompositionFromCmd()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].ToLower() == "-directcomposition")
			{
				return true;
			}
		}
		return false;
	}

	private static bool UseExternalCompositionFromCmd()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].ToLower() == "-externalcomposition")
			{
				return true;
			}
		}
		return false;
	}

	private static bool CreateMixedRealityCaptureConfigurationFileFromCmd()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].ToLower() == "-create_mrc_config")
			{
				return true;
			}
		}
		return false;
	}

	private static bool LoadMixedRealityCaptureConfigurationFileFromCmd()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].ToLower() == "-load_mrc_config")
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsUnityAlphaOrBetaVersion()
	{
		string unityVersion = Application.unityVersion;
		int num = unityVersion.Length - 1;
		while (num >= 0 && unityVersion[num] >= '0' && unityVersion[num] <= '9')
		{
			num--;
		}
		if (num >= 0 && (unityVersion[num] == 'a' || unityVersion[num] == 'b'))
		{
			return true;
		}
		return false;
	}

	private void InitOVRManager()
	{
		if (instance != null)
		{
			base.enabled = false;
			UnityEngine.Object.DestroyImmediate(this);
			return;
		}
		instance = this;
		runtimeSettings = OVRRuntimeSettings.GetRuntimeSettings();
		Debug.Log(string.Concat("Unity v", Application.unityVersion, ", Oculus Utilities v", OVRPlugin.wrapperVersion, ", OVRPlugin v", OVRPlugin.version, ", SDK v", OVRPlugin.nativeSDKVersion, "."));
		Debug.LogFormat("SystemHeadset {0}, API {1}", systemHeadsetType.ToString(), xrApi.ToString());
		if (xrApi == XrApi.OpenXR)
		{
			Debug.LogFormat("OpenXR instance 0x{0:X} session 0x{1:X}", xrInstance, xrSession);
		}
		if (IsUnityAlphaOrBetaVersion())
		{
			Debug.LogWarning(UnityAlphaOrBetaVersionWarningMessage);
		}
		string text = GraphicsDeviceType.Direct3D11.ToString() + ", " + GraphicsDeviceType.Direct3D12;
		if (!text.Contains(SystemInfo.graphicsDeviceType.ToString()))
		{
			Debug.LogWarning("VR rendering requires one of the following device types: (" + text + "). Your graphics device: " + SystemInfo.graphicsDeviceType);
		}
		RuntimePlatform platform = Application.platform;
		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer || platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer)
		{
			isSupportedPlatform = true;
		}
		else
		{
			isSupportedPlatform = false;
		}
		if (!isSupportedPlatform)
		{
			Debug.LogWarning("This platform is unsupported");
			return;
		}
		enableMixedReality = false;
		if (!staticMixedRealityCaptureInitialized)
		{
			bool flag = LoadMixedRealityCaptureConfigurationFileFromCmd();
			bool flag2 = CreateMixedRealityCaptureConfigurationFileFromCmd();
			if (flag || flag2)
			{
				OVRMixedRealityCaptureSettings oVRMixedRealityCaptureSettings = ScriptableObject.CreateInstance<OVRMixedRealityCaptureSettings>();
				oVRMixedRealityCaptureSettings.ReadFrom(this);
				if (flag)
				{
					oVRMixedRealityCaptureSettings.CombineWithConfigurationFile();
					oVRMixedRealityCaptureSettings.ApplyTo(this);
				}
				if (flag2)
				{
					oVRMixedRealityCaptureSettings.WriteToConfigurationFile();
				}
				UnityEngine.Object.Destroy(oVRMixedRealityCaptureSettings);
			}
			if (MixedRealityEnabledFromCmd())
			{
				enableMixedReality = true;
			}
			if (enableMixedReality)
			{
				Debug.Log("OVR: Mixed Reality mode enabled");
				if (UseDirectCompositionFromCmd())
				{
					compositionMethod = CompositionMethod.Direct;
				}
				if (UseExternalCompositionFromCmd())
				{
					compositionMethod = CompositionMethod.External;
				}
				Debug.Log("OVR: CompositionMethod : " + compositionMethod);
			}
		}
		StaticInitializeMixedRealityCapture(this);
		Initialize();
		Debug.LogFormat("Current display frequency {0}, available frequencies [{1}]", display.displayFrequency, string.Join(", ", display.displayFrequenciesAvailable.Select((float f) => f.ToString()).ToArray()));
		if (resetTrackerOnLoad)
		{
			display.RecenterPose();
		}
		if (Debug.isDebugBuild)
		{
			if (GetComponent<OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer>() == null)
			{
				base.gameObject.AddComponent<OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer>();
			}
			OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer component = GetComponent<OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer>();
			component.listeningPort = profilerTcpPort;
			if (!component.enabled)
			{
				component.enabled = true;
			}
			OVRPlugin.SetDeveloperMode(OVRPlugin.Bool.True);
		}
		ColorSpace colorSpace = runtimeSettings.colorSpace;
		colorGamut = colorSpace;
		OVRPlugin.occlusionMesh = true;
		if (isInsightPassthroughEnabled)
		{
			InitializeInsightPassthrough();
		}
		OVRManagerinitialized = true;
	}

	private void Awake()
	{
		InitOVRManager();
	}

	private void SetCurrentXRDevice()
	{
		if (OVRPlugin.initialized)
		{
			loadedXRDevice = XRDevice.Oculus;
		}
		else if (XRSettings.enabled)
		{
			if (XRSettings.loadedDeviceName == OPENVR_UNITY_NAME_STR)
			{
				loadedXRDevice = XRDevice.OpenVR;
			}
			else
			{
				loadedXRDevice = XRDevice.Unknown;
			}
		}
		else
		{
			loadedXRDevice = XRDevice.Unknown;
		}
	}

	private void Initialize()
	{
		if (display == null)
		{
			display = new OVRDisplay();
		}
		if (tracker == null)
		{
			tracker = new OVRTracker();
		}
		if (boundary == null)
		{
			boundary = new OVRBoundary();
		}
		SetCurrentXRDevice();
	}

	private void Update()
	{
		SetCurrentXRDevice();
		if (OVRPlugin.shouldQuit)
		{
			Debug.Log("[OVRManager] OVRPlugin.shouldQuit detected");
			StaticShutdownMixedRealityCapture(instance);
			ShutdownInsightPassthrough();
			Application.Quit();
		}
		if (AllowRecenter && OVRPlugin.shouldRecenter)
		{
			display.RecenterPose();
		}
		if (trackingOriginType != _trackingOriginType)
		{
			trackingOriginType = _trackingOriginType;
		}
		tracker.isEnabled = usePositionTracking;
		OVRPlugin.rotation = useRotationTracking;
		OVRPlugin.useIPDInPositionTracking = useIPDInPositionTracking;
		isHmdPresent = OVRNodeStateProperties.IsHmdPresent();
		if (useRecommendedMSAALevel && QualitySettings.antiAliasing != display.recommendedMSAALevel)
		{
			Debug.Log("The current MSAA level is " + QualitySettings.antiAliasing + ", but the recommended MSAA level is " + display.recommendedMSAALevel + ". Switching to the recommended level.");
			QualitySettings.antiAliasing = display.recommendedMSAALevel;
		}
		if (monoscopic != _monoscopic)
		{
			monoscopic = _monoscopic;
		}
		if (headPoseRelativeOffsetRotation != _headPoseRelativeOffsetRotation)
		{
			headPoseRelativeOffsetRotation = _headPoseRelativeOffsetRotation;
		}
		if (headPoseRelativeOffsetTranslation != _headPoseRelativeOffsetTranslation)
		{
			headPoseRelativeOffsetTranslation = _headPoseRelativeOffsetTranslation;
		}
		if (_wasHmdPresent && !isHmdPresent)
		{
			try
			{
				Debug.Log("[OVRManager] HMDLost event");
				if (OVRManager.HMDLost != null)
				{
					OVRManager.HMDLost();
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Caught Exception: " + ex);
			}
		}
		if (!_wasHmdPresent && isHmdPresent)
		{
			try
			{
				Debug.Log("[OVRManager] HMDAcquired event");
				if (OVRManager.HMDAcquired != null)
				{
					OVRManager.HMDAcquired();
				}
			}
			catch (Exception ex2)
			{
				Debug.LogError("Caught Exception: " + ex2);
			}
		}
		_wasHmdPresent = isHmdPresent;
		isUserPresent = OVRPlugin.userPresent;
		if (_wasUserPresent && !isUserPresent)
		{
			try
			{
				Debug.Log("[OVRManager] HMDUnmounted event");
				if (OVRManager.HMDUnmounted != null)
				{
					OVRManager.HMDUnmounted();
				}
			}
			catch (Exception ex3)
			{
				Debug.LogError("Caught Exception: " + ex3);
			}
		}
		if (!_wasUserPresent && isUserPresent)
		{
			try
			{
				Debug.Log("[OVRManager] HMDMounted event");
				if (OVRManager.HMDMounted != null)
				{
					OVRManager.HMDMounted();
				}
			}
			catch (Exception ex4)
			{
				Debug.LogError("Caught Exception: " + ex4);
			}
		}
		_wasUserPresent = isUserPresent;
		hasVrFocus = OVRPlugin.hasVrFocus;
		if (_hadVrFocus && !hasVrFocus)
		{
			try
			{
				Debug.Log("[OVRManager] VrFocusLost event");
				if (OVRManager.VrFocusLost != null)
				{
					OVRManager.VrFocusLost();
				}
			}
			catch (Exception ex5)
			{
				Debug.LogError("Caught Exception: " + ex5);
			}
		}
		if (!_hadVrFocus && hasVrFocus)
		{
			try
			{
				Debug.Log("[OVRManager] VrFocusAcquired event");
				if (OVRManager.VrFocusAcquired != null)
				{
					OVRManager.VrFocusAcquired();
				}
			}
			catch (Exception ex6)
			{
				Debug.LogError("Caught Exception: " + ex6);
			}
		}
		_hadVrFocus = hasVrFocus;
		bool flag = OVRPlugin.hasInputFocus;
		if (_hadInputFocus && !flag)
		{
			try
			{
				Debug.Log("[OVRManager] InputFocusLost event");
				if (OVRManager.InputFocusLost != null)
				{
					OVRManager.InputFocusLost();
				}
			}
			catch (Exception ex7)
			{
				Debug.LogError("Caught Exception: " + ex7);
			}
		}
		if (!_hadInputFocus && flag)
		{
			try
			{
				Debug.Log("[OVRManager] InputFocusAcquired event");
				if (OVRManager.InputFocusAcquired != null)
				{
					OVRManager.InputFocusAcquired();
				}
			}
			catch (Exception ex8)
			{
				Debug.LogError("Caught Exception: " + ex8);
			}
		}
		_hadInputFocus = flag;
		string text = OVRPlugin.audioOutId;
		if (!prevAudioOutIdIsCached)
		{
			prevAudioOutId = text;
			prevAudioOutIdIsCached = true;
		}
		else if (text != prevAudioOutId)
		{
			try
			{
				Debug.Log("[OVRManager] AudioOutChanged event");
				if (OVRManager.AudioOutChanged != null)
				{
					OVRManager.AudioOutChanged();
				}
			}
			catch (Exception ex9)
			{
				Debug.LogError("Caught Exception: " + ex9);
			}
			prevAudioOutId = text;
		}
		string text2 = OVRPlugin.audioInId;
		if (!prevAudioInIdIsCached)
		{
			prevAudioInId = text2;
			prevAudioInIdIsCached = true;
		}
		else if (text2 != prevAudioInId)
		{
			try
			{
				Debug.Log("[OVRManager] AudioInChanged event");
				if (OVRManager.AudioInChanged != null)
				{
					OVRManager.AudioInChanged();
				}
			}
			catch (Exception ex10)
			{
				Debug.LogError("Caught Exception: " + ex10);
			}
			prevAudioInId = text2;
		}
		if (wasPositionTracked && !tracker.isPositionTracked)
		{
			try
			{
				Debug.Log("[OVRManager] TrackingLost event");
				if (OVRManager.TrackingLost != null)
				{
					OVRManager.TrackingLost();
				}
			}
			catch (Exception ex11)
			{
				Debug.LogError("Caught Exception: " + ex11);
			}
		}
		if (!wasPositionTracked && tracker.isPositionTracked)
		{
			try
			{
				Debug.Log("[OVRManager] TrackingAcquired event");
				if (OVRManager.TrackingAcquired != null)
				{
					OVRManager.TrackingAcquired();
				}
			}
			catch (Exception ex12)
			{
				Debug.LogError("Caught Exception: " + ex12);
			}
		}
		wasPositionTracked = tracker.isPositionTracked;
		display.Update();
		OVRInput.Update();
		UpdateHMDEvents();
		StaticUpdateMixedRealityCapture(this, base.gameObject, trackingOriginType);
		UpdateInsightPassthrough(isInsightPassthroughEnabled);
	}

	private void UpdateHMDEvents()
	{
		OVRPlugin.SpatialEntityUuid arg7 = default(OVRPlugin.SpatialEntityUuid);
		OVRPlugin.SpatialEntityUuid arg2 = default(OVRPlugin.SpatialEntityUuid);
		while (OVRPlugin.PollEvent(ref eventDataBuffer))
		{
			switch (eventDataBuffer.EventType)
			{
			case OVRPlugin.EventType.DisplayRefreshRateChanged:
				if (OVRManager.DisplayRefreshRateChanged != null)
				{
					float arg8 = BitConverter.ToSingle(eventDataBuffer.EventData, 0);
					float arg9 = BitConverter.ToSingle(eventDataBuffer.EventData, 4);
					OVRManager.DisplayRefreshRateChanged(arg8, arg9);
				}
				break;
			case OVRPlugin.EventType.SpatialEntitySetComponentEnabledResult:
				if (OVRManager.SpatialEntitySetComponentEnabled != null)
				{
					ulong arg12 = BitConverter.ToUInt64(eventDataBuffer.EventData, 0);
					int num6 = BitConverter.ToInt32(eventDataBuffer.EventData, 8);
					OVRPlugin.SpatialEntityComponentType arg13 = (OVRPlugin.SpatialEntityComponentType)BitConverter.ToInt32(eventDataBuffer.EventData, 12);
					ulong arg14 = BitConverter.ToUInt64(eventDataBuffer.EventData, 16);
					OVRManager.SpatialEntitySetComponentEnabled(arg12, num6 >= 0, arg13, arg14);
				}
				break;
			case OVRPlugin.EventType.SpatialEntityQueryResults:
				if (OVRManager.SpatialEntityQueryResults != null)
				{
					int num2 = 0;
					ulong arg4 = BitConverter.ToUInt64(eventDataBuffer.EventData, 0);
					num2 += 8;
					int num3 = BitConverter.ToInt32(eventDataBuffer.EventData, num2);
					num2 += 8;
					OVRPlugin.SpatialEntityQueryResult[] array = new OVRPlugin.SpatialEntityQueryResult[128];
					for (int i = 0; i < num3; i++)
					{
						array[i] = default(OVRPlugin.SpatialEntityQueryResult);
						array[i].space = BitConverter.ToUInt64(eventDataBuffer.EventData, num2);
						num2 += 8;
						array[i].uuid = default(OVRPlugin.SpatialEntityUuid);
						array[i].uuid.Value_0 = BitConverter.ToUInt64(eventDataBuffer.EventData, num2);
						num2 += 8;
						array[i].uuid.Value_1 = BitConverter.ToUInt64(eventDataBuffer.EventData, num2);
						num2 += 8;
					}
					OVRManager.SpatialEntityQueryResults(arg4, num3, array);
				}
				break;
			case OVRPlugin.EventType.SpatialEntityQueryComplete:
				if (OVRManager.SpatialEntityQueryComplete != null)
				{
					ulong arg10 = BitConverter.ToUInt64(eventDataBuffer.EventData, 0);
					int num5 = BitConverter.ToInt32(eventDataBuffer.EventData, 8);
					int arg11 = BitConverter.ToInt32(eventDataBuffer.EventData, 12);
					OVRManager.SpatialEntityQueryComplete(arg10, num5 >= 0, arg11);
				}
				break;
			case OVRPlugin.EventType.SpatialEntityStorageSaveResult:
				if (OVRManager.SpatialEntityStorageSave != null)
				{
					ulong arg5 = BitConverter.ToUInt64(eventDataBuffer.EventData, 0);
					ulong arg6 = BitConverter.ToUInt64(eventDataBuffer.EventData, 8);
					int num4 = BitConverter.ToInt32(eventDataBuffer.EventData, 16);
					arg7.Value_0 = BitConverter.ToUInt64(eventDataBuffer.EventData, 24);
					arg7.Value_1 = BitConverter.ToUInt64(eventDataBuffer.EventData, 32);
					OVRManager.SpatialEntityStorageSave(arg5, arg6, num4 >= 0, arg7);
				}
				break;
			case OVRPlugin.EventType.SpatialEntityStorageEraseResult:
				if (OVRManager.SpatialEntityStorageErase != null)
				{
					ulong arg = BitConverter.ToUInt64(eventDataBuffer.EventData, 0);
					int num = BitConverter.ToInt32(eventDataBuffer.EventData, 8);
					arg2.Value_0 = BitConverter.ToUInt64(eventDataBuffer.EventData, 16);
					arg2.Value_1 = BitConverter.ToUInt64(eventDataBuffer.EventData, 24);
					OVRPlugin.SpatialEntityStorageLocation arg3 = (OVRPlugin.SpatialEntityStorageLocation)BitConverter.ToInt32(eventDataBuffer.EventData, 32);
					OVRManager.SpatialEntityStorageErase(arg, num >= 0, arg2, arg3);
				}
				break;
			}
		}
	}

	private static Camera FindMainCamera()
	{
		if (lastFoundMainCamera != null && lastFoundMainCamera.TryGetTarget(out var target) && target != null && target.isActiveAndEnabled && target.CompareTag("MainCamera"))
		{
			return target;
		}
		Camera camera = null;
		GameObject[] array = GameObject.FindGameObjectsWithTag("MainCamera");
		List<Camera> list = new List<Camera>(4);
		GameObject[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Camera component = array2[i].GetComponent<Camera>();
			if (component != null && component.enabled)
			{
				OVRCameraRig componentInParent = component.GetComponentInParent<OVRCameraRig>();
				if (componentInParent != null && componentInParent.trackingSpace != null)
				{
					list.Add(component);
				}
			}
		}
		if (list.Count == 0)
		{
			camera = Camera.main;
		}
		else if (list.Count == 1)
		{
			camera = list[0];
		}
		else
		{
			if (!multipleMainCameraWarningPresented)
			{
				Debug.LogWarning("Multiple MainCamera found. Assume the real MainCamera is the camera with the least depth");
				multipleMainCameraWarningPresented = true;
			}
			list.Sort((Camera c0, Camera c1) => (!(c0.depth < c1.depth)) ? ((c0.depth > c1.depth) ? 1 : 0) : (-1));
			camera = list[0];
		}
		if (camera != null)
		{
			Debug.LogFormat("[OVRManager] mainCamera found for MRC: {0}", camera.gameObject.name);
			suppressUnableToFindMainCameraMessage = false;
		}
		else if (!suppressUnableToFindMainCameraMessage)
		{
			Debug.Log("[OVRManager] unable to find a valid camera");
			suppressUnableToFindMainCameraMessage = true;
		}
		lastFoundMainCamera = new WeakReference<Camera>(camera);
		return camera;
	}

	private void OnDisable()
	{
		OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer component = GetComponent<OVRSystemPerfMetrics.OVRSystemPerfMetricsTcpServer>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void LateUpdate()
	{
		OVRHaptics.Process();
		if (m_SpaceWarpEnabled)
		{
			_ = m_AppSpaceTransform != null;
		}
	}

	private void FixedUpdate()
	{
		OVRInput.FixedUpdate();
	}

	private void OnDestroy()
	{
		Debug.Log("[OVRManager] OnDestroy");
		OVRManagerinitialized = false;
	}

	private void OnApplicationPause(bool pause)
	{
		if (pause)
		{
			Debug.Log("[OVRManager] OnApplicationPause(true)");
		}
		else
		{
			Debug.Log("[OVRManager] OnApplicationPause(false)");
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
			Debug.Log("[OVRManager] OnApplicationFocus(true)");
		}
		else
		{
			Debug.Log("[OVRManager] OnApplicationFocus(false)");
		}
	}

	private void OnApplicationQuit()
	{
		Debug.Log("[OVRManager] OnApplicationQuit");
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public void ReturnToLauncher()
	{
		PlatformUIConfirmQuit();
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static void PlatformUIConfirmQuit()
	{
		if (isHmdPresent)
		{
			OVRPlugin.ShowUI(OVRPlugin.PlatformUI.ConfirmQuit);
		}
	}

	public static void StaticInitializeMixedRealityCapture(OVRMixedRealityCaptureConfiguration configuration)
	{
		if (!staticMixedRealityCaptureInitialized)
		{
			staticMrcSettings = ScriptableObject.CreateInstance<OVRMixedRealityCaptureSettings>();
			staticMrcSettings.ReadFrom(configuration);
			staticPrevEnableMixedRealityCapture = false;
			staticMixedRealityCaptureInitialized = true;
		}
		else
		{
			staticMrcSettings.ApplyTo(configuration);
		}
	}

	public static void StaticUpdateMixedRealityCapture(OVRMixedRealityCaptureConfiguration configuration, GameObject gameObject, TrackingOrigin trackingOrigin)
	{
		if (!staticMixedRealityCaptureInitialized)
		{
			return;
		}
		if (configuration.enableMixedReality)
		{
			Camera camera = FindMainCamera();
			if (camera != null)
			{
				if (!staticPrevEnableMixedRealityCapture)
				{
					OVRPlugin.SendEvent("mixed_reality_capture", "activated");
					Debug.Log("MixedRealityCapture: activate");
					staticPrevEnableMixedRealityCapture = true;
				}
				OVRMixedReality.Update(gameObject, camera, configuration, trackingOrigin);
				suppressDisableMixedRealityBecauseOfNoMainCameraWarning = false;
			}
			else if (!suppressDisableMixedRealityBecauseOfNoMainCameraWarning)
			{
				Debug.LogWarning("Main Camera is not set, Mixed Reality disabled");
				suppressDisableMixedRealityBecauseOfNoMainCameraWarning = true;
			}
		}
		else if (staticPrevEnableMixedRealityCapture)
		{
			Debug.Log("MixedRealityCapture: deactivate");
			staticPrevEnableMixedRealityCapture = false;
			OVRMixedReality.Cleanup();
		}
		staticMrcSettings.ReadFrom(configuration);
	}

	public static void StaticShutdownMixedRealityCapture(OVRMixedRealityCaptureConfiguration configuration)
	{
		if (staticMixedRealityCaptureInitialized)
		{
			UnityEngine.Object.Destroy(staticMrcSettings);
			staticMrcSettings = null;
			OVRMixedReality.Cleanup();
			staticMixedRealityCaptureInitialized = false;
		}
	}

	public static bool IsInsightPassthroughSupported()
	{
		return OVRPlugin.IsInsightPassthroughSupported();
	}

	private static bool PassthroughInitializedOrPending(PassthroughInitializationState state)
	{
		if (state != PassthroughInitializationState.Pending)
		{
			return state == PassthroughInitializationState.Initialized;
		}
		return true;
	}

	private static bool InitializeInsightPassthrough()
	{
		if (PassthroughInitializedOrPending(_passthroughInitializationState))
		{
			return false;
		}
		OVRPlugin.InitializeInsightPassthrough();
		OVRPlugin.Result insightPassthroughInitializationState = OVRPlugin.GetInsightPassthroughInitializationState();
		if (insightPassthroughInitializationState < OVRPlugin.Result.Success)
		{
			_passthroughInitializationState = PassthroughInitializationState.Failed;
			Debug.LogError("Failed to initialize Insight Passthrough. Passthrough will be unavailable. Error " + insightPassthroughInitializationState.ToString() + ".");
		}
		else if (insightPassthroughInitializationState == OVRPlugin.Result.Success_Pending)
		{
			_passthroughInitializationState = PassthroughInitializationState.Pending;
		}
		else
		{
			_passthroughInitializationState = PassthroughInitializationState.Initialized;
		}
		return PassthroughInitializedOrPending(_passthroughInitializationState);
	}

	private static void ShutdownInsightPassthrough()
	{
		if (PassthroughInitializedOrPending(_passthroughInitializationState))
		{
			if (OVRPlugin.ShutdownInsightPassthrough())
			{
				_passthroughInitializationState = PassthroughInitializationState.Unspecified;
			}
			else if (OVRPlugin.IsInsightPassthroughInitialized())
			{
				Debug.LogError("Failed to shut down passthrough. It may be still in use.");
			}
			else
			{
				_passthroughInitializationState = PassthroughInitializationState.Unspecified;
			}
		}
		else
		{
			_passthroughInitializationState = PassthroughInitializationState.Unspecified;
		}
	}

	private static void UpdateInsightPassthrough(bool shouldBeEnabled)
	{
		if (shouldBeEnabled != PassthroughInitializedOrPending(_passthroughInitializationState))
		{
			if (shouldBeEnabled)
			{
				if (_passthroughInitializationState != PassthroughInitializationState.Failed)
				{
					InitializeInsightPassthrough();
				}
			}
			else
			{
				ShutdownInsightPassthrough();
			}
		}
		else if (_passthroughInitializationState == PassthroughInitializationState.Pending)
		{
			OVRPlugin.Result insightPassthroughInitializationState = OVRPlugin.GetInsightPassthroughInitializationState();
			if (insightPassthroughInitializationState == OVRPlugin.Result.Success)
			{
				_passthroughInitializationState = PassthroughInitializationState.Initialized;
			}
			else if (insightPassthroughInitializationState < OVRPlugin.Result.Success)
			{
				_passthroughInitializationState = PassthroughInitializationState.Failed;
				Debug.LogError("Failed to initialize Insight Passthrough. Passthrough will be unavailable. Error " + insightPassthroughInitializationState.ToString() + ".");
			}
		}
	}

	public static bool IsInsightPassthroughInitialized()
	{
		return _passthroughInitializationState == PassthroughInitializationState.Initialized;
	}

	public static bool HasInsightPassthroughInitFailed()
	{
		return _passthroughInitializationState == PassthroughInitializationState.Failed;
	}

	public static bool IsInsightPassthroughInitPending()
	{
		return _passthroughInitializationState == PassthroughInitializationState.Pending;
	}
}
