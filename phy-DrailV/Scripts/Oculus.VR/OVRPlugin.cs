using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public static class OVRPlugin
{
	[StructLayout(LayoutKind.Sequential)]
	private class GUID
	{
		public int a;

		public short b;

		public short c;

		public byte d0;

		public byte d1;

		public byte d2;

		public byte d3;

		public byte d4;

		public byte d5;

		public byte d6;

		public byte d7;
	}

	public enum Bool
	{
		False = 0,
		True = 1
	}

	public enum Result
	{
		Success = 0,
		Success_EventUnavailable = 1,
		Success_Pending = 2,
		Failure = -1000,
		Failure_InvalidParameter = -1001,
		Failure_NotInitialized = -1002,
		Failure_InvalidOperation = -1003,
		Failure_Unsupported = -1004,
		Failure_NotYetImplemented = -1005,
		Failure_OperationFailed = -1006,
		Failure_InsufficientSize = -1007,
		Failure_DataIsInvalid = -1008,
		Failure_DeprecatedOperation = -1009
	}

	public enum LogLevel
	{
		Debug = 0,
		Info = 1,
		Error = 2
	}

	public delegate void LogCallback2DelegateType(LogLevel logLevel, IntPtr message, int size);

	public enum CameraStatus
	{
		CameraStatus_None = 0,
		CameraStatus_Connected = 1,
		CameraStatus_Calibrating = 2,
		CameraStatus_CalibrationFailed = 3,
		CameraStatus_Calibrated = 4,
		CameraStatus_ThirdPerson = 5,
		CameraStatus_EnumSize = int.MaxValue
	}

	public enum CameraAnchorType
	{
		CameraAnchorType_PreDefined = 0,
		CameraAnchorType_Custom = 1,
		CameraAnchorType_Count = 2,
		CameraAnchorType_EnumSize = int.MaxValue
	}

	public enum XrApi
	{
		Unknown = 0,
		CAPI = 1,
		VRAPI = 2,
		OpenXR = 3,
		EnumSize = int.MaxValue
	}

	public enum Eye
	{
		None = -1,
		Left = 0,
		Right = 1,
		Count = 2
	}

	public enum Tracker
	{
		None = -1,
		Zero = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Count = 4
	}

	public enum Node
	{
		None = -1,
		EyeLeft = 0,
		EyeRight = 1,
		EyeCenter = 2,
		HandLeft = 3,
		HandRight = 4,
		TrackerZero = 5,
		TrackerOne = 6,
		TrackerTwo = 7,
		TrackerThree = 8,
		Head = 9,
		DeviceObjectZero = 10,
		TrackedKeyboard = 11,
		Count = 12
	}

	public enum Controller
	{
		None = 0,
		LTouch = 1,
		RTouch = 2,
		Touch = 3,
		Remote = 4,
		Gamepad = 16,
		LHand = 32,
		RHand = 64,
		Hands = 96,
		Active = int.MinValue,
		All = -1
	}

	public enum Handedness
	{
		Unsupported = 0,
		LeftHanded = 1,
		RightHanded = 2
	}

	public enum TrackingOrigin
	{
		EyeLevel = 0,
		FloorLevel = 1,
		Stage = 2,
		View = 4,
		Count = 5
	}

	public enum RecenterFlags
	{
		Default = 0,
		IgnoreAll = int.MinValue,
		Count = -2147483647
	}

	public enum BatteryStatus
	{
		Charging = 0,
		Discharging = 1,
		Full = 2,
		NotCharging = 3,
		Unknown = 4
	}

	public enum EyeTextureFormat
	{
		Default = 0,
		R8G8B8A8_sRGB = 0,
		R8G8B8A8 = 1,
		R16G16B16A16_FP = 2,
		R11G11B10_FP = 3,
		B8G8R8A8_sRGB = 4,
		B8G8R8A8 = 5,
		R5G6B5 = 11,
		EnumSize = int.MaxValue
	}

	public enum PlatformUI
	{
		None = -1,
		ConfirmQuit = 1,
		GlobalMenuTutorial = 2
	}

	public enum SystemRegion
	{
		Unspecified = 0,
		Japan = 1,
		China = 2
	}

	public enum SystemHeadset
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

	public enum OverlayShape
	{
		Quad = 0,
		Cylinder = 1,
		Cubemap = 2,
		OffcenterCubemap = 4,
		Equirect = 5,
		ReconstructionPassthrough = 7,
		SurfaceProjectedPassthrough = 8,
		Fisheye = 9,
		KeyboardHandsPassthrough = 10
	}

	public enum Step
	{
		Render = -1,
		Physics = 0
	}

	public enum CameraDevice
	{
		None = 0,
		WebCamera0 = 100,
		WebCamera1 = 101,
		ZEDCamera = 300
	}

	public enum CameraDeviceDepthSensingMode
	{
		Standard = 0,
		Fill = 1
	}

	public enum CameraDeviceDepthQuality
	{
		Low = 0,
		Medium = 1,
		High = 2
	}

	public enum FixedFoveatedRenderingLevel
	{
		Off = 0,
		Low = 1,
		Medium = 2,
		High = 3,
		HighTop = 4,
		EnumSize = int.MaxValue
	}

	[Obsolete("Please use FixedFoveatedRenderingLevel instead", false)]
	public enum TiledMultiResLevel
	{
		Off = 0,
		LMSLow = 1,
		LMSMedium = 2,
		LMSHigh = 3,
		LMSHighTop = 4,
		EnumSize = int.MaxValue
	}

	public enum PerfMetrics
	{
		App_CpuTime_Float = 0,
		App_GpuTime_Float = 1,
		Compositor_CpuTime_Float = 3,
		Compositor_GpuTime_Float = 4,
		Compositor_DroppedFrameCount_Int = 5,
		System_GpuUtilPercentage_Float = 7,
		System_CpuUtilAveragePercentage_Float = 8,
		System_CpuUtilWorstPercentage_Float = 9,
		Device_CpuClockFrequencyInMHz_Float = 10,
		Device_GpuClockFrequencyInMHz_Float = 11,
		Device_CpuClockLevel_Int = 12,
		Device_GpuClockLevel_Int = 13,
		Count = 14,
		EnumSize = int.MaxValue
	}

	public enum ProcessorPerformanceLevel
	{
		PowerSavings = 0,
		SustainedLow = 1,
		SustainedHigh = 2,
		Boost = 3,
		EnumSize = int.MaxValue
	}

	public struct CameraDeviceIntrinsicsParameters
	{
		private float fx;

		private float fy;

		private float cx;

		private float cy;

		private double disto0;

		private double disto1;

		private double disto2;

		private double disto3;

		private double disto4;

		private float v_fov;

		private float h_fov;

		private float d_fov;

		private int w;

		private int h;
	}

	private enum OverlayFlag
	{
		None = 0,
		OnTop = 1,
		HeadLocked = 2,
		NoDepth = 4,
		ExpensiveSuperSample = 8,
		ShapeFlag_Quad = 0,
		ShapeFlag_Cylinder = 16,
		ShapeFlag_Cubemap = 32,
		ShapeFlag_OffcenterCubemap = 64,
		ShapeFlagRangeMask = 240,
		Hidden = 512
	}

	public struct Vector2f
	{
		public float x;

		public float y;
	}

	public struct Vector3f
	{
		public float x;

		public float y;

		public float z;

		public static readonly Vector3f zero = new Vector3f
		{
			x = 0f,
			y = 0f,
			z = 0f
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}", x, y, z);
		}
	}

	public struct Vector4f
	{
		public float x;

		public float y;

		public float z;

		public float w;

		public static readonly Vector4f zero = new Vector4f
		{
			x = 0f,
			y = 0f,
			z = 0f,
			w = 0f
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", x, y, z, w);
		}
	}

	public struct Vector4s
	{
		public short x;

		public short y;

		public short z;

		public short w;

		public static readonly Vector4s zero = new Vector4s
		{
			x = 0,
			y = 0,
			z = 0,
			w = 0
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", x, y, z, w);
		}
	}

	public struct Quatf
	{
		public float x;

		public float y;

		public float z;

		public float w;

		public static readonly Quatf identity = new Quatf
		{
			x = 0f,
			y = 0f,
			z = 0f,
			w = 1f
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", x, y, z, w);
		}
	}

	public struct Posef
	{
		public Quatf Orientation;

		public Vector3f Position;

		public static readonly Posef identity = new Posef
		{
			Orientation = Quatf.identity,
			Position = Vector3f.zero
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Position ({0}), Orientation({1})", Position, Orientation);
		}
	}

	public struct TextureRectMatrixf
	{
		public Rect leftRect;

		public Rect rightRect;

		public Vector4 leftScaleBias;

		public Vector4 rightScaleBias;

		public static readonly TextureRectMatrixf zero = new TextureRectMatrixf
		{
			leftRect = new Rect(0f, 0f, 1f, 1f),
			rightRect = new Rect(0f, 0f, 1f, 1f),
			leftScaleBias = new Vector4(1f, 1f, 0f, 0f),
			rightScaleBias = new Vector4(1f, 1f, 0f, 0f)
		};

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Rect Left ({0}), Rect Right({1}), Scale Bias Left ({2}), Scale Bias Right({3})", leftRect, rightRect, leftScaleBias, rightScaleBias);
		}
	}

	public struct PoseStatef
	{
		public Posef Pose;

		public Vector3f Velocity;

		public Vector3f Acceleration;

		public Vector3f AngularVelocity;

		public Vector3f AngularAcceleration;

		public double Time;

		public static readonly PoseStatef identity = new PoseStatef
		{
			Pose = Posef.identity,
			Velocity = Vector3f.zero,
			Acceleration = Vector3f.zero,
			AngularVelocity = Vector3f.zero,
			AngularAcceleration = Vector3f.zero
		};
	}

	public struct ControllerState4
	{
		public uint ConnectedControllers;

		public uint Buttons;

		public uint Touches;

		public uint NearTouches;

		public float LIndexTrigger;

		public float RIndexTrigger;

		public float LHandTrigger;

		public float RHandTrigger;

		public Vector2f LThumbstick;

		public Vector2f RThumbstick;

		public Vector2f LTouchpad;

		public Vector2f RTouchpad;

		public byte LBatteryPercentRemaining;

		public byte RBatteryPercentRemaining;

		public byte LRecenterCount;

		public byte RRecenterCount;

		public byte Reserved_27;

		public byte Reserved_26;

		public byte Reserved_25;

		public byte Reserved_24;

		public byte Reserved_23;

		public byte Reserved_22;

		public byte Reserved_21;

		public byte Reserved_20;

		public byte Reserved_19;

		public byte Reserved_18;

		public byte Reserved_17;

		public byte Reserved_16;

		public byte Reserved_15;

		public byte Reserved_14;

		public byte Reserved_13;

		public byte Reserved_12;

		public byte Reserved_11;

		public byte Reserved_10;

		public byte Reserved_09;

		public byte Reserved_08;

		public byte Reserved_07;

		public byte Reserved_06;

		public byte Reserved_05;

		public byte Reserved_04;

		public byte Reserved_03;

		public byte Reserved_02;

		public byte Reserved_01;

		public byte Reserved_00;

		public ControllerState4(ControllerState2 cs)
		{
			ConnectedControllers = cs.ConnectedControllers;
			Buttons = cs.Buttons;
			Touches = cs.Touches;
			NearTouches = cs.NearTouches;
			LIndexTrigger = cs.LIndexTrigger;
			RIndexTrigger = cs.RIndexTrigger;
			LHandTrigger = cs.LHandTrigger;
			RHandTrigger = cs.RHandTrigger;
			LThumbstick = cs.LThumbstick;
			RThumbstick = cs.RThumbstick;
			LTouchpad = cs.LTouchpad;
			RTouchpad = cs.RTouchpad;
			LBatteryPercentRemaining = 0;
			RBatteryPercentRemaining = 0;
			LRecenterCount = 0;
			RRecenterCount = 0;
			Reserved_27 = 0;
			Reserved_26 = 0;
			Reserved_25 = 0;
			Reserved_24 = 0;
			Reserved_23 = 0;
			Reserved_22 = 0;
			Reserved_21 = 0;
			Reserved_20 = 0;
			Reserved_19 = 0;
			Reserved_18 = 0;
			Reserved_17 = 0;
			Reserved_16 = 0;
			Reserved_15 = 0;
			Reserved_14 = 0;
			Reserved_13 = 0;
			Reserved_12 = 0;
			Reserved_11 = 0;
			Reserved_10 = 0;
			Reserved_09 = 0;
			Reserved_08 = 0;
			Reserved_07 = 0;
			Reserved_06 = 0;
			Reserved_05 = 0;
			Reserved_04 = 0;
			Reserved_03 = 0;
			Reserved_02 = 0;
			Reserved_01 = 0;
			Reserved_00 = 0;
		}
	}

	public struct ControllerState2
	{
		public uint ConnectedControllers;

		public uint Buttons;

		public uint Touches;

		public uint NearTouches;

		public float LIndexTrigger;

		public float RIndexTrigger;

		public float LHandTrigger;

		public float RHandTrigger;

		public Vector2f LThumbstick;

		public Vector2f RThumbstick;

		public Vector2f LTouchpad;

		public Vector2f RTouchpad;

		public ControllerState2(ControllerState cs)
		{
			ConnectedControllers = cs.ConnectedControllers;
			Buttons = cs.Buttons;
			Touches = cs.Touches;
			NearTouches = cs.NearTouches;
			LIndexTrigger = cs.LIndexTrigger;
			RIndexTrigger = cs.RIndexTrigger;
			LHandTrigger = cs.LHandTrigger;
			RHandTrigger = cs.RHandTrigger;
			LThumbstick = cs.LThumbstick;
			RThumbstick = cs.RThumbstick;
			LTouchpad = new Vector2f
			{
				x = 0f,
				y = 0f
			};
			RTouchpad = new Vector2f
			{
				x = 0f,
				y = 0f
			};
		}
	}

	public struct ControllerState
	{
		public uint ConnectedControllers;

		public uint Buttons;

		public uint Touches;

		public uint NearTouches;

		public float LIndexTrigger;

		public float RIndexTrigger;

		public float LHandTrigger;

		public float RHandTrigger;

		public Vector2f LThumbstick;

		public Vector2f RThumbstick;
	}

	public struct HapticsBuffer
	{
		public IntPtr Samples;

		public int SamplesCount;
	}

	public struct HapticsState
	{
		public int SamplesAvailable;

		public int SamplesQueued;
	}

	public struct HapticsDesc
	{
		public int SampleRateHz;

		public int SampleSizeInBytes;

		public int MinimumSafeSamplesQueued;

		public int MinimumBufferSamplesCount;

		public int OptimalBufferSamplesCount;

		public int MaximumBufferSamplesCount;
	}

	public struct AppPerfFrameStats
	{
		public int HmdVsyncIndex;

		public int AppFrameIndex;

		public int AppDroppedFrameCount;

		public float AppMotionToPhotonLatency;

		public float AppQueueAheadTime;

		public float AppCpuElapsedTime;

		public float AppGpuElapsedTime;

		public int CompositorFrameIndex;

		public int CompositorDroppedFrameCount;

		public float CompositorLatency;

		public float CompositorCpuElapsedTime;

		public float CompositorGpuElapsedTime;

		public float CompositorCpuStartToGpuEndElapsedTime;

		public float CompositorGpuEndToVsyncElapsedTime;
	}

	public struct AppPerfStats
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		public AppPerfFrameStats[] FrameStats;

		public int FrameStatsCount;

		public Bool AnyFrameStatsDropped;

		public float AdaptiveGpuPerformanceScale;
	}

	public struct Sizei : IEquatable<Sizei>
	{
		public int w;

		public int h;

		public static readonly Sizei zero = new Sizei
		{
			w = 0,
			h = 0
		};

		public bool Equals(Sizei other)
		{
			if (w == other.w)
			{
				return h == other.h;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Sizei other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (w * 397) ^ h;
		}
	}

	public struct Sizef
	{
		public float w;

		public float h;

		public static readonly Sizef zero = new Sizef
		{
			w = 0f,
			h = 0f
		};
	}

	public struct Size3f
	{
		public float w;

		public float h;

		public float d;

		public static readonly Size3f zero = new Size3f
		{
			w = 0f,
			h = 0f,
			d = 0f
		};
	}

	public struct Vector2i
	{
		public int x;

		public int y;
	}

	public struct Recti
	{
		private Vector2i Pos;

		private Sizei Size;
	}

	public struct Rectf
	{
		public Vector2f Pos;

		public Sizef Size;
	}

	public struct Boundsf
	{
		public Vector3f Pos;

		public Size3f Size;
	}

	public struct Frustumf
	{
		public float zNear;

		public float zFar;

		public float fovX;

		public float fovY;
	}

	public struct Frustumf2
	{
		public float zNear;

		public float zFar;

		public Fovf Fov;
	}

	public enum BoundaryType
	{
		[Obsolete("Deprecated. This enum value will not be supported in OpenXR", false)]
		OuterBoundary = 1,
		PlayArea = 0x100
	}

	[Obsolete("Deprecated. This struct will not be supported in OpenXR", false)]
	public struct BoundaryTestResult
	{
		public Bool IsTriggering;

		public float ClosestDistance;

		public Vector3f ClosestPoint;

		public Vector3f ClosestPointNormal;
	}

	public struct BoundaryGeometry
	{
		public BoundaryType BoundaryType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public Vector3f[] Points;

		public int PointsCount;
	}

	public struct Colorf
	{
		public float r;

		public float g;

		public float b;

		public float a;
	}

	public struct Fovf
	{
		public float UpTan;

		public float DownTan;

		public float LeftTan;

		public float RightTan;
	}

	public struct CameraIntrinsics
	{
		public Bool IsValid;

		public double LastChangedTimeSeconds;

		public Fovf FOVPort;

		public float VirtualNearPlaneDistanceMeters;

		public float VirtualFarPlaneDistanceMeters;

		public Sizei ImageSensorPixelResolution;
	}

	public struct CameraExtrinsics
	{
		public Bool IsValid;

		public double LastChangedTimeSeconds;

		public CameraStatus CameraStatusData;

		public Node AttachedToNode;

		public Posef RelativePose;
	}

	public enum LayerLayout
	{
		Stereo = 0,
		Mono = 1,
		DoubleWide = 2,
		Array = 3,
		EnumSize = 15
	}

	public enum LayerFlags
	{
		Static = 1,
		LoadingScreen = 2,
		SymmetricFov = 4,
		TextureOriginAtBottomLeft = 8,
		ChromaticAberrationCorrection = 0x10,
		NoAllocation = 0x20,
		ProtectedContent = 0x40,
		AndroidSurfaceSwapChain = 0x80,
		BicubicFiltering = 0x4000
	}

	public struct LayerDesc
	{
		public OverlayShape Shape;

		public LayerLayout Layout;

		public Sizei TextureSize;

		public int MipLevels;

		public int SampleCount;

		public EyeTextureFormat Format;

		public int LayerFlags;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public Fovf[] Fov;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public Rectf[] VisibleRect;

		public Sizei MaxViewportSize;

		public EyeTextureFormat DepthFormat;

		public EyeTextureFormat MotionVectorFormat;

		public EyeTextureFormat MotionVectorDepthFormat;

		public Sizei MotionVectorTextureSize;

		public override string ToString()
		{
			string text = ", ";
			return Shape.ToString() + text + Layout.ToString() + text + TextureSize.w + "x" + TextureSize.h + text + MipLevels + text + SampleCount + text + Format.ToString() + text + LayerFlags;
		}
	}

	public enum BlendFactor
	{
		Zero = 0,
		One = 1,
		SrcAlpha = 2,
		OneMinusSrcAlpha = 3,
		DstAlpha = 4,
		OneMinusDstAlpha = 5
	}

	public struct LayerSubmit
	{
		private int LayerId;

		private int TextureStage;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private Recti[] ViewportRect;

		private Posef Pose;

		private int LayerSubmitFlags;
	}

	public enum TrackingConfidence
	{
		Low = 0,
		High = 1065353216
	}

	public enum Hand
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	[Flags]
	public enum HandStatus
	{
		HandTracked = 1,
		InputStateValid = 2,
		SystemGestureInProgress = 0x40,
		DominantHand = 0x80,
		MenuPressed = 0x100
	}

	public enum BoneId
	{
		Invalid = -1,
		Hand_Start = 0,
		Hand_WristRoot = 0,
		Hand_ForearmStub = 1,
		Hand_Thumb0 = 2,
		Hand_Thumb1 = 3,
		Hand_Thumb2 = 4,
		Hand_Thumb3 = 5,
		Hand_Index1 = 6,
		Hand_Index2 = 7,
		Hand_Index3 = 8,
		Hand_Middle1 = 9,
		Hand_Middle2 = 10,
		Hand_Middle3 = 11,
		Hand_Ring1 = 12,
		Hand_Ring2 = 13,
		Hand_Ring3 = 14,
		Hand_Pinky0 = 15,
		Hand_Pinky1 = 16,
		Hand_Pinky2 = 17,
		Hand_Pinky3 = 18,
		Hand_MaxSkinnable = 19,
		Hand_ThumbTip = 19,
		Hand_IndexTip = 20,
		Hand_MiddleTip = 21,
		Hand_RingTip = 22,
		Hand_PinkyTip = 23,
		Hand_End = 24,
		Max = 50
	}

	public enum HandFinger
	{
		Thumb = 0,
		Index = 1,
		Middle = 2,
		Ring = 3,
		Pinky = 4,
		Max = 5
	}

	[Flags]
	public enum HandFingerPinch
	{
		Thumb = 1,
		Index = 2,
		Middle = 4,
		Ring = 8,
		Pinky = 0x10
	}

	public struct HandState
	{
		public HandStatus Status;

		public Posef RootPose;

		public Quatf[] BoneRotations;

		public HandFingerPinch Pinches;

		public float[] PinchStrength;

		public Posef PointerPose;

		public float HandScale;

		public TrackingConfidence HandConfidence;

		public TrackingConfidence[] FingerConfidences;

		public double RequestedTimeStamp;

		public double SampleTimeStamp;
	}

	private struct HandStateInternal
	{
		public HandStatus Status;

		public Posef RootPose;

		public Quatf BoneRotations_0;

		public Quatf BoneRotations_1;

		public Quatf BoneRotations_2;

		public Quatf BoneRotations_3;

		public Quatf BoneRotations_4;

		public Quatf BoneRotations_5;

		public Quatf BoneRotations_6;

		public Quatf BoneRotations_7;

		public Quatf BoneRotations_8;

		public Quatf BoneRotations_9;

		public Quatf BoneRotations_10;

		public Quatf BoneRotations_11;

		public Quatf BoneRotations_12;

		public Quatf BoneRotations_13;

		public Quatf BoneRotations_14;

		public Quatf BoneRotations_15;

		public Quatf BoneRotations_16;

		public Quatf BoneRotations_17;

		public Quatf BoneRotations_18;

		public Quatf BoneRotations_19;

		public Quatf BoneRotations_20;

		public Quatf BoneRotations_21;

		public Quatf BoneRotations_22;

		public Quatf BoneRotations_23;

		public HandFingerPinch Pinches;

		public float PinchStrength_0;

		public float PinchStrength_1;

		public float PinchStrength_2;

		public float PinchStrength_3;

		public float PinchStrength_4;

		public Posef PointerPose;

		public float HandScale;

		public TrackingConfidence HandConfidence;

		public TrackingConfidence FingerConfidences_0;

		public TrackingConfidence FingerConfidences_1;

		public TrackingConfidence FingerConfidences_2;

		public TrackingConfidence FingerConfidences_3;

		public TrackingConfidence FingerConfidences_4;

		public double RequestedTimeStamp;

		public double SampleTimeStamp;
	}

	public struct BoneCapsule
	{
		public short BoneIndex;

		public Vector3f StartPoint;

		public Vector3f EndPoint;

		public float Radius;
	}

	public struct Bone
	{
		public BoneId Id;

		public short ParentBoneIndex;

		public Posef Pose;
	}

	public enum SkeletonConstants
	{
		MaxHandBones = 24,
		MaxBones = 50,
		MaxBoneCapsules = 19
	}

	public enum SkeletonType
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	public struct Skeleton
	{
		public SkeletonType Type;

		public uint NumBones;

		public uint NumBoneCapsules;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
		public Bone[] Bones;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
		public BoneCapsule[] BoneCapsules;
	}

	public struct Skeleton2
	{
		public SkeletonType Type;

		public uint NumBones;

		public uint NumBoneCapsules;

		public Bone[] Bones;

		public BoneCapsule[] BoneCapsules;
	}

	private struct Skeleton2Internal
	{
		public SkeletonType Type;

		public uint NumBones;

		public uint NumBoneCapsules;

		public Bone Bones_0;

		public Bone Bones_1;

		public Bone Bones_2;

		public Bone Bones_3;

		public Bone Bones_4;

		public Bone Bones_5;

		public Bone Bones_6;

		public Bone Bones_7;

		public Bone Bones_8;

		public Bone Bones_9;

		public Bone Bones_10;

		public Bone Bones_11;

		public Bone Bones_12;

		public Bone Bones_13;

		public Bone Bones_14;

		public Bone Bones_15;

		public Bone Bones_16;

		public Bone Bones_17;

		public Bone Bones_18;

		public Bone Bones_19;

		public Bone Bones_20;

		public Bone Bones_21;

		public Bone Bones_22;

		public Bone Bones_23;

		public Bone Bones_24;

		public Bone Bones_25;

		public Bone Bones_26;

		public Bone Bones_27;

		public Bone Bones_28;

		public Bone Bones_29;

		public Bone Bones_30;

		public Bone Bones_31;

		public Bone Bones_32;

		public Bone Bones_33;

		public Bone Bones_34;

		public Bone Bones_35;

		public Bone Bones_36;

		public Bone Bones_37;

		public Bone Bones_38;

		public Bone Bones_39;

		public Bone Bones_40;

		public Bone Bones_41;

		public Bone Bones_42;

		public Bone Bones_43;

		public Bone Bones_44;

		public Bone Bones_45;

		public Bone Bones_46;

		public Bone Bones_47;

		public Bone Bones_48;

		public Bone Bones_49;

		public BoneCapsule BoneCapsules_0;

		public BoneCapsule BoneCapsules_1;

		public BoneCapsule BoneCapsules_2;

		public BoneCapsule BoneCapsules_3;

		public BoneCapsule BoneCapsules_4;

		public BoneCapsule BoneCapsules_5;

		public BoneCapsule BoneCapsules_6;

		public BoneCapsule BoneCapsules_7;

		public BoneCapsule BoneCapsules_8;

		public BoneCapsule BoneCapsules_9;

		public BoneCapsule BoneCapsules_10;

		public BoneCapsule BoneCapsules_11;

		public BoneCapsule BoneCapsules_12;

		public BoneCapsule BoneCapsules_13;

		public BoneCapsule BoneCapsules_14;

		public BoneCapsule BoneCapsules_15;

		public BoneCapsule BoneCapsules_16;

		public BoneCapsule BoneCapsules_17;

		public BoneCapsule BoneCapsules_18;
	}

	public enum MeshConstants
	{
		MaxVertices = 3000,
		MaxIndices = 18000
	}

	public enum MeshType
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	[StructLayout(LayoutKind.Sequential)]
	public class Mesh
	{
		public MeshType Type;

		public uint NumVertices;

		public uint NumIndices;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000)]
		public Vector3f[] VertexPositions;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18000)]
		public short[] Indices;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000)]
		public Vector3f[] VertexNormals;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000)]
		public Vector2f[] VertexUV0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000)]
		public Vector4s[] BlendIndices;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3000)]
		public Vector4f[] BlendWeights;
	}

	public struct KeyboardState
	{
		public Bool IsActive;

		public Bool OrientationValid;

		public Bool PositionValid;

		public Bool OrientationTracked;

		public Bool PositionTracked;

		public PoseStatef PoseState;

		public Vector4f ContrastParameters;
	}

	public enum KeyboardDescriptionConstants
	{
		NameMaxLength = 0x80
	}

	public enum TrackedKeyboardPresentationStyles
	{
		Unknown = 0,
		Opaque = 1,
		KeyLabel = 2
	}

	public enum TrackedKeyboardFlags
	{
		Exists = 1,
		Local = 2,
		Remote = 4,
		Connected = 8
	}

	public enum TrackedKeyboardQueryFlags
	{
		Local = 2,
		Remote = 4
	}

	public struct KeyboardDescription
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[] Name;

		public ulong TrackedKeyboardId;

		public Vector3f Dimensions;

		public TrackedKeyboardFlags KeyboardFlags;

		public TrackedKeyboardPresentationStyles SupportedPresentationStyles;
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

	public enum EventType
	{
		Unknown = 0,
		DisplayRefreshRateChanged = 1,
		SpatialEntitySetComponentEnabledResult = 50,
		SpatialEntityQueryResults = 51,
		SpatialEntityQueryComplete = 52,
		SpatialEntityStorageSaveResult = 53,
		SpatialEntityStorageEraseResult = 54
	}

	public struct EventDataBuffer
	{
		public EventType EventType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4000)]
		public byte[] EventData;
	}

	public struct RenderModelProperties
	{
		public string ModelName;

		public ulong ModelKey;

		public uint VendorId;

		public uint ModelVersion;
	}

	private struct RenderModelPropertiesInternal
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] ModelName;

		public ulong ModelKey;

		public uint VendorId;

		public uint ModelVersion;
	}

	public enum InsightPassthroughColorMapType
	{
		None = 0,
		MonoToRgba = 1,
		MonoToMono = 2
	}

	public enum InsightPassthroughStyleFlags
	{
		HasTextureOpacityFactor = 1,
		HasEdgeColor = 2,
		HasTextureColorMap = 4
	}

	public struct InsightPassthroughStyle
	{
		public InsightPassthroughStyleFlags Flags;

		public float TextureOpacityFactor;

		public Colorf EdgeColor;

		public InsightPassthroughColorMapType TextureColorMapType;

		public uint TextureColorMapDataSize;

		public IntPtr TextureColorMapData;
	}

	public struct InsightPassthroughKeyboardHandsIntensity
	{
		public float LeftHandIntensity;

		public float RightHandIntensity;
	}

	public enum SpatialEntityComponentType
	{
		Locatable = 0,
		Storable = 1
	}

	public enum SpatialEntityStorageLocation
	{
		Invalid = 0,
		Local = 1
	}

	public enum SpatialEntityStoragePersistenceMode
	{
		Invalid = 0,
		IndefiniteHighPri = 1
	}

	public enum SpatialEntityQueryActionType
	{
		Load = 0
	}

	public enum SpatialEntityQueryType
	{
		Action = 0
	}

	public enum SpatialEntityQueryFilterType
	{
		None = 0,
		Ids = 1
	}

	public struct SpatialEntityAnchorCreateInfo
	{
		public TrackingOrigin BaseTracking;

		public Posef PoseInSpace;

		public double Time;
	}

	public struct SpatialEntityUuid
	{
		public ulong Value_0;

		public ulong Value_1;
	}

	public struct SpatialEntityFilterInfoIds
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
		public SpatialEntityUuid[] Ids;

		public int NumIds;
	}

	public struct SpatialEntityQueryInfo
	{
		public SpatialEntityQueryType QueryType;

		public int MaxQuerySpaces;

		public double Timeout;

		public SpatialEntityStorageLocation Location;

		public SpatialEntityQueryActionType ActionType;

		public SpatialEntityQueryFilterType FilterType;

		public SpatialEntityFilterInfoIds IdInfo;
	}

	public struct SpatialEntityQueryResult
	{
		public ulong space;

		public SpatialEntityUuid uuid;
	}

	public class Media
	{
		public enum MrcActivationMode
		{
			Automatic = 0,
			Disabled = 1,
			EnumSize = int.MaxValue
		}

		public enum PlatformCameraMode
		{
			Disabled = -1,
			Initialized = 0,
			UserControlled = 1,
			SmartNavigated = 2,
			StabilizedPoV = 3,
			RemoteDroneControlled = 4,
			RemoteSpatialMapped = 5,
			SpectatorMode = 6,
			MobileMRC = 7,
			EnumSize = int.MaxValue
		}

		public enum InputVideoBufferType
		{
			Memory = 0,
			TextureHandle = 1,
			EnumSize = int.MaxValue
		}

		private static Texture2D cachedTexture;

		public static bool Initialize()
		{
			if (version >= OVRP_1_38_0.version)
			{
				return OVRP_1_38_0.ovrp_Media_Initialize() == Result.Success;
			}
			return false;
		}

		public static bool Shutdown()
		{
			if (version >= OVRP_1_38_0.version)
			{
				return OVRP_1_38_0.ovrp_Media_Shutdown() == Result.Success;
			}
			return false;
		}

		public static bool GetInitialized()
		{
			if (version >= OVRP_1_38_0.version)
			{
				Bool initialized = Bool.False;
				if (OVRP_1_38_0.ovrp_Media_GetInitialized(out initialized) == Result.Success)
				{
					if (initialized != Bool.True)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool Update()
		{
			if (version >= OVRP_1_38_0.version)
			{
				return OVRP_1_38_0.ovrp_Media_Update() == Result.Success;
			}
			return false;
		}

		public static MrcActivationMode GetMrcActivationMode()
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_GetMrcActivationMode(out var activationMode) == Result.Success)
				{
					return activationMode;
				}
				return MrcActivationMode.Automatic;
			}
			return MrcActivationMode.Automatic;
		}

		public static bool SetMrcActivationMode(MrcActivationMode mode)
		{
			if (version >= OVRP_1_38_0.version)
			{
				return OVRP_1_38_0.ovrp_Media_SetMrcActivationMode(mode) == Result.Success;
			}
			return false;
		}

		public static bool SetPlatformInitialized()
		{
			if (version >= OVRP_1_54_0.version)
			{
				return OVRP_1_54_0.ovrp_Media_SetPlatformInitialized() == Result.Success;
			}
			return false;
		}

		public static PlatformCameraMode GetPlatformCameraMode()
		{
			if (version >= OVRP_1_57_0.version)
			{
				if (OVRP_1_57_0.ovrp_Media_GetPlatformCameraMode(out var platformCameraMode) == Result.Success)
				{
					return platformCameraMode;
				}
				return PlatformCameraMode.Initialized;
			}
			return PlatformCameraMode.Initialized;
		}

		public static bool SetPlatformCameraMode(PlatformCameraMode mode)
		{
			if (version >= OVRP_1_57_0.version)
			{
				return OVRP_1_57_0.ovrp_Media_SetPlatformCameraMode(mode) == Result.Success;
			}
			return false;
		}

		public static bool IsMrcEnabled()
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_IsMrcEnabled(out var mrcEnabled) == Result.Success)
				{
					if (mrcEnabled != Bool.True)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool IsMrcActivated()
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_IsMrcActivated(out var mrcActivated) == Result.Success)
				{
					if (mrcActivated != Bool.True)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool UseMrcDebugCamera()
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_UseMrcDebugCamera(out var useMrcDebugCamera) == Result.Success)
				{
					if (useMrcDebugCamera != Bool.True)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool SetMrcInputVideoBufferType(InputVideoBufferType videoBufferType)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_SetMrcInputVideoBufferType(videoBufferType) == Result.Success)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static InputVideoBufferType GetMrcInputVideoBufferType()
		{
			if (version >= OVRP_1_38_0.version)
			{
				InputVideoBufferType inputVideoBufferType = InputVideoBufferType.Memory;
				OVRP_1_38_0.ovrp_Media_GetMrcInputVideoBufferType(ref inputVideoBufferType);
				return inputVideoBufferType;
			}
			return InputVideoBufferType.Memory;
		}

		public static bool SetMrcFrameSize(int frameWidth, int frameHeight)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_SetMrcFrameSize(frameWidth, frameHeight) == Result.Success)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static void GetMrcFrameSize(out int frameWidth, out int frameHeight)
		{
			frameWidth = -1;
			frameHeight = -1;
			if (version >= OVRP_1_38_0.version)
			{
				OVRP_1_38_0.ovrp_Media_GetMrcFrameSize(ref frameWidth, ref frameHeight);
			}
		}

		public static bool SetMrcAudioSampleRate(int sampleRate)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_SetMrcAudioSampleRate(sampleRate) == Result.Success)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static int GetMrcAudioSampleRate()
		{
			int sampleRate = 0;
			if (version >= OVRP_1_38_0.version)
			{
				OVRP_1_38_0.ovrp_Media_GetMrcAudioSampleRate(ref sampleRate);
			}
			return sampleRate;
		}

		public static bool SetMrcFrameImageFlipped(bool imageFlipped)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (OVRP_1_38_0.ovrp_Media_SetMrcFrameImageFlipped(imageFlipped ? Bool.True : Bool.False) == Result.Success)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool GetMrcFrameImageFlipped()
		{
			Bool flipped = Bool.False;
			if (version >= OVRP_1_38_0.version)
			{
				OVRP_1_38_0.ovrp_Media_GetMrcFrameImageFlipped(ref flipped);
			}
			if (flipped != Bool.True)
			{
				return false;
			}
			return true;
		}

		public static bool EncodeMrcFrame(IntPtr textureHandle, IntPtr fgTextureHandle, float[] audioData, int audioFrames, int audioChannels, double timestamp, double poseTime, ref int outSyncId)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (textureHandle == IntPtr.Zero)
				{
					Debug.LogError("EncodeMrcFrame: textureHandle is null");
					return false;
				}
				if (GetMrcInputVideoBufferType() != InputVideoBufferType.TextureHandle)
				{
					Debug.LogError("EncodeMrcFrame: videoBufferType mismatch");
					return false;
				}
				GCHandle gCHandle = default(GCHandle);
				IntPtr intPtr = IntPtr.Zero;
				int audioDataLen = 0;
				if (audioData != null)
				{
					gCHandle = GCHandle.Alloc(audioData, GCHandleType.Pinned);
					intPtr = gCHandle.AddrOfPinnedObject();
					audioDataLen = audioFrames * 4;
				}
				Result result = ((fgTextureHandle == IntPtr.Zero) ? ((!(version >= OVRP_1_49_0.version)) ? OVRP_1_38_0.ovrp_Media_EncodeMrcFrame(textureHandle, intPtr, audioDataLen, audioChannels, timestamp, ref outSyncId) : OVRP_1_49_0.ovrp_Media_EncodeMrcFrameWithPoseTime(textureHandle, intPtr, audioDataLen, audioChannels, timestamp, poseTime, ref outSyncId)) : ((!(version >= OVRP_1_49_0.version)) ? OVRP_1_38_0.ovrp_Media_EncodeMrcFrameWithDualTextures(textureHandle, fgTextureHandle, intPtr, audioDataLen, audioChannels, timestamp, ref outSyncId) : OVRP_1_49_0.ovrp_Media_EncodeMrcFrameDualTexturesWithPoseTime(textureHandle, fgTextureHandle, intPtr, audioDataLen, audioChannels, timestamp, poseTime, ref outSyncId)));
				if (audioData != null)
				{
					gCHandle.Free();
				}
				return result == Result.Success;
			}
			return false;
		}

		public static bool EncodeMrcFrame(RenderTexture frame, float[] audioData, int audioFrames, int audioChannels, double timestamp, double poseTime, ref int outSyncId)
		{
			if (version >= OVRP_1_38_0.version)
			{
				if (frame == null)
				{
					Debug.LogError("EncodeMrcFrame: frame is null");
					return false;
				}
				if (GetMrcInputVideoBufferType() != InputVideoBufferType.Memory)
				{
					Debug.LogError("EncodeMrcFrame: videoBufferType mismatch");
					return false;
				}
				GCHandle gCHandle = default(GCHandle);
				IntPtr zero = IntPtr.Zero;
				if (cachedTexture == null || cachedTexture.width != frame.width || cachedTexture.height != frame.height)
				{
					cachedTexture = new Texture2D(frame.width, frame.height, TextureFormat.ARGB32, mipChain: false);
				}
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = frame;
				cachedTexture.ReadPixels(new Rect(0f, 0f, frame.width, frame.height), 0, 0);
				RenderTexture.active = active;
				gCHandle = GCHandle.Alloc(cachedTexture.GetPixels32(0), GCHandleType.Pinned);
				zero = gCHandle.AddrOfPinnedObject();
				GCHandle gCHandle2 = default(GCHandle);
				IntPtr audioDataPtr = IntPtr.Zero;
				int audioDataLen = 0;
				if (audioData != null)
				{
					gCHandle2 = GCHandle.Alloc(audioData, GCHandleType.Pinned);
					audioDataPtr = gCHandle2.AddrOfPinnedObject();
					audioDataLen = audioFrames * 4;
				}
				Result result = ((!(version >= OVRP_1_49_0.version)) ? OVRP_1_38_0.ovrp_Media_EncodeMrcFrame(zero, audioDataPtr, audioDataLen, audioChannels, timestamp, ref outSyncId) : OVRP_1_49_0.ovrp_Media_EncodeMrcFrameWithPoseTime(zero, audioDataPtr, audioDataLen, audioChannels, timestamp, poseTime, ref outSyncId));
				gCHandle.Free();
				if (audioData != null)
				{
					gCHandle2.Free();
				}
				return result == Result.Success;
			}
			return false;
		}

		public static bool SyncMrcFrame(int syncId)
		{
			if (version >= OVRP_1_38_0.version)
			{
				return OVRP_1_38_0.ovrp_Media_SyncMrcFrame(syncId) == Result.Success;
			}
			return false;
		}

		public static bool SetAvailableQueueIndexVulkan(uint queueIndexVk)
		{
			if (version >= OVRP_1_45_0.version)
			{
				return OVRP_1_45_0.ovrp_Media_SetAvailableQueueIndexVulkan(queueIndexVk) == Result.Success;
			}
			return false;
		}

		public static bool SetMrcHeadsetControllerPose(Posef headsetPose, Posef leftControllerPose, Posef rightControllerPose)
		{
			if (version >= OVRP_1_49_0.version)
			{
				return OVRP_1_49_0.ovrp_Media_SetHeadsetControllerPose(headsetPose, leftControllerPose, rightControllerPose) == Result.Success;
			}
			return false;
		}

		public static bool IsCastingToRemoteClient()
		{
			if (version >= OVRP_1_66_0.version)
			{
				Bool isCasting = Bool.False;
				if (OVRP_1_66_0.ovrp_Media_IsCastingToRemoteClient(out isCasting) == Result.Success)
				{
					return isCasting == Bool.True;
				}
				return false;
			}
			return false;
		}
	}

	public class Ktx
	{
		public static IntPtr LoadKtxFromMemory(IntPtr dataPtr, uint length)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return IntPtr.Zero;
			}
			if (version >= OVRP_1_65_0.version)
			{
				IntPtr texture = IntPtr.Zero;
				OVRP_1_65_0.ovrp_KtxLoadFromMemory(ref dataPtr, length, ref texture);
				return texture;
			}
			return IntPtr.Zero;
		}

		public static uint GetKtxTextureWidth(IntPtr texture)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return 0u;
			}
			if (version >= OVRP_1_65_0.version)
			{
				uint width = 0u;
				OVRP_1_65_0.ovrp_KtxTextureWidth(texture, ref width);
				return width;
			}
			return 0u;
		}

		public static uint GetKtxTextureHeight(IntPtr texture)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return 0u;
			}
			if (version >= OVRP_1_65_0.version)
			{
				uint height = 0u;
				OVRP_1_65_0.ovrp_KtxTextureHeight(texture, ref height);
				return height;
			}
			return 0u;
		}

		public static bool TranscodeKtxTexture(IntPtr texture, uint format)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return false;
			}
			if (version >= OVRP_1_65_0.version)
			{
				return OVRP_1_65_0.ovrp_KtxTranscode(texture, format) == Result.Success;
			}
			return false;
		}

		public static uint GetKtxTextureSize(IntPtr texture)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return 0u;
			}
			if (version >= OVRP_1_65_0.version)
			{
				uint size = 0u;
				OVRP_1_65_0.ovrp_KtxTextureSize(texture, ref size);
				return size;
			}
			return 0u;
		}

		public static bool GetKtxTextureData(IntPtr texture, IntPtr textureData, uint bufferSize)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return false;
			}
			if (version >= OVRP_1_65_0.version)
			{
				return OVRP_1_65_0.ovrp_KtxGetTextureData(texture, textureData, bufferSize) == Result.Success;
			}
			return false;
		}

		public static bool DestroyKtxTexture(IntPtr texture)
		{
			if (nativeXrApi != XrApi.OpenXR)
			{
				Debug.LogWarning("KTX features are only supported in OpenXR.");
				return false;
			}
			if (version >= OVRP_1_65_0.version)
			{
				return OVRP_1_65_0.ovrp_KtxDestroy(texture) == Result.Success;
			}
			return false;
		}
	}

	public class UnityOpenXR
	{
		public static bool Enabled;

		public static void SetClientVersion()
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_SetClientVersion(wrapperVersion.Major, wrapperVersion.Minor, wrapperVersion.Build);
			}
		}

		public static IntPtr HookGetInstanceProcAddr(IntPtr func)
		{
			if (version >= OVRP_1_71_0.version)
			{
				return OVRP_1_71_0.ovrp_UnityOpenXR_HookGetInstanceProcAddr(func);
			}
			return func;
		}

		public static bool OnInstanceCreate(ulong xrInstance)
		{
			if (version >= OVRP_1_71_0.version)
			{
				return OVRP_1_71_0.ovrp_UnityOpenXR_OnInstanceCreate(xrInstance) == Result.Success;
			}
			return false;
		}

		public static void OnInstanceDestroy(ulong xrInstance)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnInstanceDestroy(xrInstance);
			}
		}

		public static void OnSessionCreate(ulong xrSession)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionCreate(xrSession);
			}
		}

		public static void OnAppSpaceChange(ulong xrSpace)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnAppSpaceChange(xrSpace);
			}
		}

		public static void OnSessionStateChange(int oldState, int newState)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionStateChange(oldState, newState);
			}
		}

		public static void OnSessionBegin(ulong xrSession)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionBegin(xrSession);
			}
		}

		public static void OnSessionEnd(ulong xrSession)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionEnd(xrSession);
			}
		}

		public static void OnSessionExiting(ulong xrSession)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionExiting(xrSession);
			}
		}

		public static void OnSessionDestroy(ulong xrSession)
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_UnityOpenXR_OnSessionDestroy(xrSession);
			}
		}
	}

	private static class OVRP_0_1_0
	{
		public static readonly Version version = new Version(0, 1, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Sizei ovrp_GetEyeTextureSize(Eye eyeId);
	}

	private static class OVRP_0_1_1
	{
		public static readonly Version version = new Version(0, 1, 1);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetOverlayQuad2(Bool onTop, Bool headLocked, IntPtr texture, IntPtr device, Posef pose, Vector3f scale);
	}

	private static class OVRP_0_1_2
	{
		public static readonly Version version = new Version(0, 1, 2);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodePose(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetControllerVibration(uint controllerMask, float frequency, float amplitude);
	}

	private static class OVRP_0_1_3
	{
		public static readonly Version version = new Version(0, 1, 3);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodeVelocity(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodeAcceleration(Node nodeId);
	}

	private static class OVRP_0_5_0
	{
		public static readonly Version version = new Version(0, 5, 0);
	}

	private static class OVRP_1_0_0
	{
		public static readonly Version version = new Version(1, 0, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern TrackingOrigin ovrp_GetTrackingOriginType();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetTrackingOriginType(TrackingOrigin originType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetTrackingCalibratedOrigin();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_RecenterTrackingOrigin(uint flags);
	}

	private static class OVRP_1_1_0
	{
		public static readonly Version version = new Version(1, 1, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetInitialized();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrp_GetVersion")]
		private static extern IntPtr _ovrp_GetVersion();

		public static string ovrp_GetVersion()
		{
			return Marshal.PtrToStringAnsi(_ovrp_GetVersion());
		}

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrp_GetNativeSDKVersion")]
		private static extern IntPtr _ovrp_GetNativeSDKVersion();

		public static string ovrp_GetNativeSDKVersion()
		{
			return Marshal.PtrToStringAnsi(_ovrp_GetNativeSDKVersion());
		}

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrp_GetAudioOutId();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrp_GetAudioInId();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetEyeTextureScale();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetEyeTextureScale(float value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetTrackingOrientationSupported();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetTrackingOrientationEnabled();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetTrackingOrientationEnabled(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetTrackingPositionSupported();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetTrackingPositionEnabled();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetTrackingPositionEnabled(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetNodePresent(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetNodeOrientationTracked(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetNodePositionTracked(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Frustumf ovrp_GetNodeFrustum(Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern ControllerState ovrp_GetControllerState(uint controllerMask);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. Replaced by ovrp_GetSuggestedCpuPerformanceLevel", false)]
		public static extern int ovrp_GetSystemCpuLevel();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. Replaced by ovrp_SetSuggestedCpuPerformanceLevel", false)]
		public static extern Bool ovrp_SetSystemCpuLevel(int value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. Replaced by ovrp_GetSuggestedGpuPerformanceLevel", false)]
		public static extern int ovrp_GetSystemGpuLevel();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. Replaced by ovrp_SetSuggestedGpuPerformanceLevel", false)]
		public static extern Bool ovrp_SetSystemGpuLevel(int value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetSystemPowerSavingMode();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetSystemDisplayFrequency();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovrp_GetSystemVSyncCount();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetSystemVolume();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern BatteryStatus ovrp_GetSystemBatteryStatus();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetSystemBatteryLevel();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetSystemBatteryTemperature();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrp_GetSystemProductName")]
		private static extern IntPtr _ovrp_GetSystemProductName();

		public static string ovrp_GetSystemProductName()
		{
			return Marshal.PtrToStringAnsi(_ovrp_GetSystemProductName());
		}

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_ShowSystemUI(PlatformUI ui);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetAppMonoscopic();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetAppMonoscopic(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetAppHasVrFocus();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetAppShouldQuit();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetAppShouldRecenter();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovrp_GetAppLatencyTimings")]
		private static extern IntPtr _ovrp_GetAppLatencyTimings();

		public static string ovrp_GetAppLatencyTimings()
		{
			return Marshal.PtrToStringAnsi(_ovrp_GetAppLatencyTimings());
		}

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetUserPresent();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetUserIPD();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetUserIPD(float value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetUserEyeDepth();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetUserEyeDepth(float value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetUserEyeHeight();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetUserEyeHeight(float value);
	}

	private static class OVRP_1_2_0
	{
		public static readonly Version version = new Version(1, 2, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetSystemVSyncCount(int vsyncCount);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrpi_SetTrackingCalibratedOrigin();
	}

	private static class OVRP_1_3_0
	{
		public static readonly Version version = new Version(1, 3, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetEyeOcclusionMeshEnabled();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetEyeOcclusionMeshEnabled(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetSystemHeadphonesPresent();
	}

	private static class OVRP_1_5_0
	{
		public static readonly Version version = new Version(1, 5, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern SystemRegion ovrp_GetSystemRegion();
	}

	private static class OVRP_1_6_0
	{
		public static readonly Version version = new Version(1, 6, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetTrackingIPDEnabled();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetTrackingIPDEnabled(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern HapticsDesc ovrp_GetControllerHapticsDesc(uint controllerMask);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern HapticsState ovrp_GetControllerHapticsState(uint controllerMask);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetControllerHaptics(uint controllerMask, HapticsBuffer hapticsBuffer);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetOverlayQuad3(uint flags, IntPtr textureLeft, IntPtr textureRight, IntPtr device, Posef pose, Vector3f scale, int layerIndex);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetEyeRecommendedResolutionScale();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetAppCpuStartToGpuEndTime();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovrp_GetSystemRecommendedMSAALevel();
	}

	private static class OVRP_1_7_0
	{
		public static readonly Version version = new Version(1, 7, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetAppChromaticCorrection();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetAppChromaticCorrection(Bool value);
	}

	private static class OVRP_1_8_0
	{
		public static readonly Version version = new Version(1, 8, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetBoundaryConfigured();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
		public static extern BoundaryTestResult ovrp_TestBoundaryNode(Node nodeId, BoundaryType boundaryType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
		public static extern BoundaryTestResult ovrp_TestBoundaryPoint(Vector3f point, BoundaryType boundaryType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern BoundaryGeometry ovrp_GetBoundaryGeometry(BoundaryType boundaryType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Vector3f ovrp_GetBoundaryDimensions(BoundaryType boundaryType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
		public static extern Bool ovrp_GetBoundaryVisible();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
		public static extern Bool ovrp_SetBoundaryVisible(Bool value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_Update2(int stateId, int frameIndex, double predictionSeconds);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodePose2(int stateId, Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodeVelocity2(int stateId, Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Posef ovrp_GetNodeAcceleration2(int stateId, Node nodeId);
	}

	private static class OVRP_1_9_0
	{
		public static readonly Version version = new Version(1, 9, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern SystemHeadset ovrp_GetSystemHeadsetType();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Controller ovrp_GetActiveController();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Controller ovrp_GetConnectedControllers();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetBoundaryGeometry2(BoundaryType boundaryType, IntPtr points, ref int pointsCount);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern AppPerfStats ovrp_GetAppPerfStats();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_ResetAppPerfStats();
	}

	private static class OVRP_1_10_0
	{
		public static readonly Version version = new Version(1, 10, 0);
	}

	private static class OVRP_1_11_0
	{
		public static readonly Version version = new Version(1, 11, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_SetDesiredEyeTextureFormat(EyeTextureFormat value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern EyeTextureFormat ovrp_GetDesiredEyeTextureFormat();
	}

	private static class OVRP_1_12_0
	{
		public static readonly Version version = new Version(1, 12, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovrp_GetAppFramerate();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern PoseStatef ovrp_GetNodePoseState(Step stepId, Node nodeId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern ControllerState2 ovrp_GetControllerState2(uint controllerMask);
	}

	private static class OVRP_1_15_0
	{
		public static readonly Version version = new Version(1, 15, 0);

		public const int OVRP_EXTERNAL_CAMERA_NAME_SIZE = 32;

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_InitializeMixedReality();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_ShutdownMixedReality();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetMixedRealityInitialized();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_UpdateExternalCamera();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetExternalCameraCount(out int cameraCount);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetExternalCameraName(int cameraId, [MarshalAs(UnmanagedType.LPArray, SizeConst = 32)] char[] cameraName);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetExternalCameraIntrinsics(int cameraId, out CameraIntrinsics cameraIntrinsics);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetExternalCameraExtrinsics(int cameraId, out CameraExtrinsics cameraExtrinsics);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_CalculateLayerDesc(OverlayShape shape, LayerLayout layout, ref Sizei textureSize, int mipLevels, int sampleCount, EyeTextureFormat format, int layerFlags, ref LayerDesc layerDesc);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnqueueSetupLayer(ref LayerDesc desc, IntPtr layerId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnqueueDestroyLayer(IntPtr layerId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetLayerTextureStageCount(int layerId, ref int layerTextureStageCount);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetLayerTexturePtr(int layerId, int stage, Eye eyeId, ref IntPtr textureHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnqueueSubmitLayer(uint flags, IntPtr textureLeft, IntPtr textureRight, int layerId, int frameIndex, ref Posef pose, ref Vector3f scale, int layerIndex);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNodeFrustum2(Node nodeId, out Frustumf2 nodeFrustum);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetEyeTextureArrayEnabled();
	}

	private static class OVRP_1_16_0
	{
		public static readonly Version version = new Version(1, 16, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_UpdateCameraDevices();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_IsCameraDeviceAvailable(CameraDevice cameraDevice);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetCameraDevicePreferredColorFrameSize(CameraDevice cameraDevice, Sizei preferredColorFrameSize);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_OpenCameraDevice(CameraDevice cameraDevice);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_CloseCameraDevice(CameraDevice cameraDevice);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_HasCameraDeviceOpened(CameraDevice cameraDevice);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_IsCameraDeviceColorFrameAvailable(CameraDevice cameraDevice);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceColorFrameSize(CameraDevice cameraDevice, out Sizei colorFrameSize);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceColorFrameBgraPixels(CameraDevice cameraDevice, out IntPtr colorFrameBgraPixels, out int colorFrameRowPitch);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetControllerState4(uint controllerMask, ref ControllerState4 controllerState);
	}

	private static class OVRP_1_17_0
	{
		public static readonly Version version = new Version(1, 17, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetExternalCameraPose(CameraDevice camera, out Posef cameraPose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_ConvertPoseToCameraSpace(CameraDevice camera, ref Posef trackingSpacePose, out Posef cameraSpacePose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceIntrinsicsParameters(CameraDevice camera, out Bool supportIntrinsics, out CameraDeviceIntrinsicsParameters intrinsicsParameters);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_DoesCameraDeviceSupportDepth(CameraDevice camera, out Bool supportDepth);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceDepthSensingMode(CameraDevice camera, out CameraDeviceDepthSensingMode depthSensoringMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetCameraDeviceDepthSensingMode(CameraDevice camera, CameraDeviceDepthSensingMode depthSensoringMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDevicePreferredDepthQuality(CameraDevice camera, out CameraDeviceDepthQuality depthQuality);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetCameraDevicePreferredDepthQuality(CameraDevice camera, CameraDeviceDepthQuality depthQuality);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_IsCameraDeviceDepthFrameAvailable(CameraDevice camera, out Bool available);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceDepthFrameSize(CameraDevice camera, out Sizei depthFrameSize);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceDepthFramePixels(CameraDevice cameraDevice, out IntPtr depthFramePixels, out int depthFrameRowPitch);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCameraDeviceDepthConfidencePixels(CameraDevice cameraDevice, out IntPtr depthConfidencePixels, out int depthConfidenceRowPitch);
	}

	private static class OVRP_1_18_0
	{
		public static readonly Version version = new Version(1, 18, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetHandNodePoseStateLatency(double latencyInSeconds);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetHandNodePoseStateLatency(out double latencyInSeconds);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetAppHasInputFocus(out Bool appHasInputFocus);
	}

	private static class OVRP_1_19_0
	{
		public static readonly Version version = new Version(1, 19, 0);
	}

	private static class OVRP_1_21_0
	{
		public static readonly Version version = new Version(1, 21, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTiledMultiResSupported(out Bool foveationSupported);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTiledMultiResLevel(out FixedFoveatedRenderingLevel level);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetTiledMultiResLevel(FixedFoveatedRenderingLevel level);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetGPUUtilSupported(out Bool gpuUtilSupported);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetGPUUtilLevel(out float gpuUtil);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSystemDisplayFrequency2(out float systemDisplayFrequency);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSystemDisplayAvailableFrequencies(IntPtr systemDisplayAvailableFrequencies, ref int numFrequencies);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetSystemDisplayFrequency(float requestedFrequency);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetAppAsymmetricFov(out Bool useAsymmetricFov);
	}

	private static class OVRP_1_28_0
	{
		public static readonly Version version = new Version(1, 28, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetDominantHand(out Handedness dominantHand);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SendEvent(string name, string param);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnqueueSetupLayer2(ref LayerDesc desc, int compositionDepth, IntPtr layerId);
	}

	private static class OVRP_1_29_0
	{
		public static readonly Version version = new Version(1, 29, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetLayerAndroidSurfaceObject(int layerId, ref IntPtr surfaceObject);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetHeadPoseModifier(ref Quatf relativeRotation, ref Vector3f relativeTranslation);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetHeadPoseModifier(out Quatf relativeRotation, out Vector3f relativeTranslation);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNodePoseStateRaw(Step stepId, int frameIndex, Node nodeId, out PoseStatef nodePoseState);
	}

	private static class OVRP_1_30_0
	{
		public static readonly Version version = new Version(1, 30, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetCurrentTrackingTransformPose(out Posef trackingTransformPose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTrackingTransformRawPose(out Posef trackingTransformRawPose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SendEvent2(string name, string param, string source);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_IsPerfMetricsSupported(PerfMetrics perfMetrics, out Bool isSupported);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetPerfMetricsFloat(PerfMetrics perfMetrics, out float value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetPerfMetricsInt(PerfMetrics perfMetrics, out int value);
	}

	private static class OVRP_1_31_0
	{
		public static readonly Version version = new Version(1, 31, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTimeInSeconds(out double value);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetColorScaleAndOffset(Vector4 colorScale, Vector4 colorOffset, Bool applyToAllLayers);
	}

	private static class OVRP_1_32_0
	{
		public static readonly Version version = new Version(1, 32, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_AddCustomMetadata(string name, string param);
	}

	private static class OVRP_1_34_0
	{
		public static readonly Version version = new Version(1, 34, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnqueueSubmitLayer2(uint flags, IntPtr textureLeft, IntPtr textureRight, int layerId, int frameIndex, ref Posef pose, ref Vector3f scale, int layerIndex, Bool overrideTextureRectMatrix, ref TextureRectMatrixf textureRectMatrix, Bool overridePerLayerColorScaleAndOffset, ref Vector4 colorScale, ref Vector4 colorOffset);
	}

	private static class OVRP_1_35_0
	{
		public static readonly Version version = new Version(1, 35, 0);
	}

	private static class OVRP_1_36_0
	{
		public static readonly Version version = new Version(1, 36, 0);
	}

	private static class OVRP_1_37_0
	{
		public static readonly Version version = new Version(1, 37, 0);
	}

	private static class OVRP_1_38_0
	{
		public static readonly Version version = new Version(1, 38, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTrackingTransformRelativePose(ref Posef trackingTransformRelativePose, TrackingOrigin trackingOrigin);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_Initialize();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_Shutdown();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetInitialized(out Bool initialized);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_Update();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetMrcActivationMode(out Media.MrcActivationMode activationMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetMrcActivationMode(Media.MrcActivationMode activationMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_IsMrcEnabled(out Bool mrcEnabled);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_IsMrcActivated(out Bool mrcActivated);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_UseMrcDebugCamera(out Bool useMrcDebugCamera);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetMrcInputVideoBufferType(Media.InputVideoBufferType inputVideoBufferType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetMrcInputVideoBufferType(ref Media.InputVideoBufferType inputVideoBufferType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetMrcFrameSize(int frameWidth, int frameHeight);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetMrcFrameSize(ref int frameWidth, ref int frameHeight);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetMrcAudioSampleRate(int sampleRate);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetMrcAudioSampleRate(ref int sampleRate);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetMrcFrameImageFlipped(Bool flipped);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetMrcFrameImageFlipped(ref Bool flipped);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_EncodeMrcFrame(IntPtr rawBuffer, IntPtr audioDataPtr, int audioDataLen, int audioChannels, double timestamp, ref int outSyncId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_EncodeMrcFrameWithDualTextures(IntPtr backgroundTextureHandle, IntPtr foregroundTextureHandle, IntPtr audioData, int audioDataLen, int audioChannels, double timestamp, ref int outSyncId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SyncMrcFrame(int syncId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetDeveloperMode(Bool active);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNodeOrientationValid(Node nodeId, ref Bool nodeOrientationValid);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNodePositionValid(Node nodeId, ref Bool nodePositionValid);
	}

	private static class OVRP_1_39_0
	{
		public static readonly Version version = new Version(1, 39, 0);
	}

	private static class OVRP_1_40_0
	{
		public static readonly Version version = new Version(1, 40, 0);
	}

	private static class OVRP_1_41_0
	{
		public static readonly Version version = new Version(1, 41, 0);
	}

	private static class OVRP_1_42_0
	{
		public static readonly Version version = new Version(1, 42, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetAdaptiveGpuPerformanceScale2(ref float adaptiveGpuPerformanceScale);
	}

	private static class OVRP_1_43_0
	{
		public static readonly Version version = new Version(1, 43, 0);
	}

	private static class OVRP_1_44_0
	{
		public static readonly Version version = new Version(1, 44, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetHandTrackingEnabled(ref Bool handTrackingEnabled);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetHandState(Step stepId, Hand hand, out HandStateInternal handState);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSkeleton(SkeletonType skeletonType, out Skeleton skeleton);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetMesh(MeshType meshType, IntPtr meshPtr);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_OverrideExternalCameraFov(int cameraId, Bool useOverriddenFov, ref Fovf fov);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetUseOverriddenExternalCameraFov(int cameraId, out Bool useOverriddenFov);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_OverrideExternalCameraStaticPose(int cameraId, Bool useOverriddenPose, ref Posef poseInStageOrigin);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetUseOverriddenExternalCameraStaticPose(int cameraId, out Bool useOverriddenStaticPose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_ResetDefaultExternalCamera();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetDefaultExternalCamera(string cameraName, ref CameraIntrinsics cameraIntrinsics, ref CameraExtrinsics cameraExtrinsics);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetLocalTrackingSpaceRecenterCount(ref int recenterCount);
	}

	private static class OVRP_1_45_0
	{
		public static readonly Version version = new Version(1, 45, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSystemHmd3DofModeEnabled(ref Bool enabled);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetAvailableQueueIndexVulkan(uint queueIndexVk);
	}

	private static class OVRP_1_46_0
	{
		public static readonly Version version = new Version(1, 46, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetTiledMultiResDynamic(out Bool isDynamic);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetTiledMultiResDynamic(Bool isDynamic);
	}

	private static class OVRP_1_47_0
	{
		public static readonly Version version = new Version(1, 47, 0);
	}

	private static class OVRP_1_48_0
	{
		public static readonly Version version = new Version(1, 48, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetExternalCameraProperties(string cameraName, ref CameraIntrinsics cameraIntrinsics, ref CameraExtrinsics cameraExtrinsics);
	}

	private static class OVRP_1_49_0
	{
		public static readonly Version version = new Version(1, 49, 0);

		public const int OVRP_ANCHOR_NAME_SIZE = 32;

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetClientColorDesc(ColorSpace colorSpace);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetHmdColorDesc(ref ColorSpace colorSpace);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_EncodeMrcFrameWithPoseTime(IntPtr rawBuffer, IntPtr audioDataPtr, int audioDataLen, int audioChannels, double timestamp, double poseTime, ref int outSyncId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_EncodeMrcFrameDualTexturesWithPoseTime(IntPtr backgroundTextureHandle, IntPtr foregroundTextureHandle, IntPtr audioData, int audioDataLen, int audioChannels, double timestamp, double poseTime, ref int outSyncId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetHeadsetControllerPose(Posef headsetPose, Posef leftControllerPose, Posef rightControllerPose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_EnumerateCameraAnchorHandles(ref int anchorCount, ref IntPtr CameraAnchorHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCurrentCameraAnchorHandle(ref IntPtr anchorHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCameraAnchorName(IntPtr anchorHandle, [MarshalAs(UnmanagedType.LPArray, SizeConst = 32)] char[] cameraName);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCameraAnchorHandle(IntPtr anchorName, ref IntPtr anchorHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCameraAnchorType(IntPtr anchorHandle, ref CameraAnchorType anchorType);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_CreateCustomCameraAnchor(IntPtr anchorName, ref IntPtr anchorHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_DestroyCustomCameraAnchor(IntPtr anchorHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCustomCameraAnchorPose(IntPtr anchorHandle, ref Posef pose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetCustomCameraAnchorPose(IntPtr anchorHandle, Posef pose);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetCameraMinMaxDistance(IntPtr anchorHandle, ref double minDistance, ref double maxDistance);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetCameraMinMaxDistance(IntPtr anchorHandle, double minDistance, double maxDistance);
	}

	private static class OVRP_1_50_0
	{
		public static readonly Version version = new Version(1, 50, 0);
	}

	private static class OVRP_1_51_0
	{
		public static readonly Version version = new Version(1, 51, 0);
	}

	private static class OVRP_1_52_0
	{
		public static readonly Version version = new Version(1, 52, 0);
	}

	private static class OVRP_1_53_0
	{
		public static readonly Version version = new Version(1, 53, 0);
	}

	private static class OVRP_1_54_0
	{
		public static readonly Version version = new Version(1, 54, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetPlatformInitialized();
	}

	private static class OVRP_1_55_0
	{
		public static readonly Version version = new Version(1, 55, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSkeleton2(SkeletonType skeletonType, out Skeleton2Internal skeleton);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_PollEvent(ref EventDataBuffer eventDataBuffer);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNativeXrApiType(out XrApi xrApi);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNativeOpenXRHandles(out ulong xrInstance, out ulong xrSession);
	}

	private static class OVRP_1_55_1
	{
		public static readonly Version version = new Version(1, 55, 1);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_PollEvent2(ref EventType eventType, ref IntPtr eventData);
	}

	private static class OVRP_1_56_0
	{
		public static readonly Version version = new Version(1, 56, 0);
	}

	private static class OVRP_1_57_0
	{
		public static readonly Version version = new Version(1, 57, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_GetPlatformCameraMode(out Media.PlatformCameraMode platformCameraMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_SetPlatformCameraMode(Media.PlatformCameraMode platformCameraMode);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetEyeFovPremultipliedAlphaMode(Bool enabled);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetEyeFovPremultipliedAlphaMode(ref Bool enabled);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetKeyboardOverlayUV(Vector2f uv);
	}

	private static class OVRP_1_58_0
	{
		public static readonly Version version = new Version(1, 58, 0);
	}

	private static class OVRP_1_59_0
	{
		public static readonly Version version = new Version(1, 59, 0);
	}

	private static class OVRP_1_60_0
	{
		public static readonly Version version = new Version(1, 60, 0);
	}

	private static class OVRP_1_61_0
	{
		public static readonly Version version = new Version(1, 61, 0);
	}

	private static class OVRP_1_62_0
	{
		public static readonly Version version = new Version(1, 62, 0);
	}

	private static class OVRP_1_63_0
	{
		public static readonly Version version = new Version(1, 63, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_CreateSpatialAnchor(ref SpatialEntityAnchorCreateInfo createInfo, out ulong space);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetComponentEnabled(ref ulong space, SpatialEntityComponentType componentType, Bool enable, double timeout, out ulong requestId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetComponentEnabled(ref ulong space, SpatialEntityComponentType componentType, out Bool enabled, out Bool changePending);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EnumerateSupportedComponents(ref ulong space, uint componentTypesCapacityInput, out uint componentTypesCountOutput, [In][Out][MarshalAs(UnmanagedType.LPArray)] SpatialEntityComponentType[] componentTypes);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_TerminateSpatialEntityQuery(ref ulong requestId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SaveSpatialEntity(ref ulong space, SpatialEntityStorageLocation location, SpatialEntityStoragePersistenceMode mode, out ulong requestId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_EraseSpatialEntity(ref ulong space, SpatialEntityStorageLocation location, out ulong requestId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_InitializeInsightPassthrough();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_ShutdownInsightPassthrough();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Bool ovrp_GetInsightPassthroughInitialized();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetInsightPassthroughStyle(int layerId, InsightPassthroughStyle style);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_CreateInsightTriangleMesh(int layerId, IntPtr vertices, int vertexCount, IntPtr triangles, int triangleCount, out ulong meshHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_DestroyInsightTriangleMesh(ulong meshHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_AddInsightPassthroughSurfaceGeometry(int layerId, ulong meshHandle, Matrix4x4 T_world_model, out ulong geometryInstanceHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_DestroyInsightPassthroughGeometryInstance(ulong geometryInstanceHandle);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_UpdateInsightPassthroughGeometryTransform(ulong geometryInstanceHandle, Matrix4x4 T_world_model);
	}

	private static class OVRP_1_64_0
	{
		public static readonly Version version = new Version(1, 64, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_LocateSpace(ref Posef location, ref ulong space, TrackingOrigin trackingOrigin);
	}

	private static class OVRP_1_65_0
	{
		public static readonly Version version = new Version(1, 65, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxLoadFromMemory(ref IntPtr data, uint length, ref IntPtr texture);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxTextureWidth(IntPtr texture, ref uint width);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxTextureHeight(IntPtr texture, ref uint height);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxTranscode(IntPtr texture, uint format);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxGetTextureData(IntPtr texture, IntPtr data, uint bufferSize);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxTextureSize(IntPtr texture, ref uint size);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_KtxDestroy(IntPtr texture);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_DestroySpace(ref ulong space);
	}

	private static class OVRP_1_66_0
	{
		public static readonly Version version = new Version(1, 66, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetInsightPassthroughInitializationState();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_Media_IsCastingToRemoteClient(out Bool isCasting);
	}

	private static class OVRP_1_67_0
	{
		public static readonly Version version = new Version(1, 67, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_QuerySpatialEntity(ref SpatialEntityQueryInfo queryInfo, out ulong requestId);
	}

	private static class OVRP_1_68_0
	{
		public static readonly Version version = new Version(1, 68, 0);

		public const int OVRP_RENDER_MODEL_MAX_PATH_LENGTH = 256;

		public const int OVRP_RENDER_MODEL_MAX_NAME_LENGTH = 64;

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_LoadRenderModel(ulong modelKey, uint bufferInputCapacity, ref uint bufferCountOutput, IntPtr buffer);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetRenderModelPaths(uint index, IntPtr path);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetRenderModelProperties(string path, out RenderModelPropertiesInternal properties);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetInsightPassthroughKeyboardHandsIntensity(int layerId, InsightPassthroughKeyboardHandsIntensity intensity);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_StartKeyboardTracking(ulong trackedKeyboardId);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_StopKeyboardTracking();

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSystemKeyboardDescription(TrackedKeyboardQueryFlags keyboardQueryFlags, out KeyboardDescription keyboardDescription);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetKeyboardState(Step stepId, int frameIndex, out KeyboardState keyboardState);
	}

	private static class OVRP_1_69_0
	{
		public static readonly Version version = new Version(1, 69, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetNodePoseStateImmediate(Node nodeId, out PoseStatef nodePoseState);
	}

	private static class OVRP_1_70_0
	{
		public static readonly Version version = new Version(1, 70, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetLogCallback2(LogCallback2DelegateType logCallback);
	}

	private static class OVRP_1_71_0
	{
		public static readonly Version version = new Version(1, 71, 0);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_IsInsightPassthroughSupported(ref Bool supported);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_SetClientVersion(int majorVersion, int minorVersion, int patchVersion);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovrp_UnityOpenXR_HookGetInstanceProcAddr(IntPtr func);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_UnityOpenXR_OnInstanceCreate(ulong xrInstance);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnInstanceDestroy(ulong xrInstance);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionCreate(ulong xrSession);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnAppSpaceChange(ulong xrSpace);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionStateChange(int oldState, int newState);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionBegin(ulong xrSession);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionEnd(ulong xrSession);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionExiting(ulong xrSession);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovrp_UnityOpenXR_OnSessionDestroy(ulong xrSession);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetSuggestedCpuPerformanceLevel(ProcessorPerformanceLevel perfLevel);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSuggestedCpuPerformanceLevel(out ProcessorPerformanceLevel perfLevel);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_SetSuggestedGpuPerformanceLevel(ProcessorPerformanceLevel perfLevel);

		[DllImport("OVRPlugin", CallingConvention = CallingConvention.Cdecl)]
		public static extern Result ovrp_GetSuggestedGpuPerformanceLevel(out ProcessorPerformanceLevel perfLevel);
	}

	public const bool isSupportedPlatform = true;

	public static readonly Version wrapperVersion = OVRP_1_71_0.version;

	private static Version _version;

	private static Version _nativeSDKVersion;

	private const int OverlayShapeFlagShift = 4;

	public const int AppPerfFrameStatsMaxCount = 5;

	private const int EventDataBufferSize = 4000;

	public const int RENDER_MODEL_NULL_KEY = 0;

	public const int SpatialEntityFilterInfoIdsMaxSize = 1024;

	public const int SpatialEntityMaxQueryResultsPerEvent = 128;

	private static XrApi? _nativeXrApi = null;

	private static GUID _nativeAudioOutGuid = new GUID();

	private static Guid _cachedAudioOutGuid;

	private static string _cachedAudioOutString;

	private static GUID _nativeAudioInGuid = new GUID();

	private static Guid _cachedAudioInGuid;

	private static string _cachedAudioInString;

	private static bool perfStatWarningPrinted = false;

	private static bool resetPerfStatWarningPrinted = false;

	private static Texture2D cachedCameraFrameTexture = null;

	private static Texture2D cachedCameraDepthTexture = null;

	private static Texture2D cachedCameraDepthConfidenceTexture = null;

	private static OVRNativeBuffer _nativeSystemDisplayFrequenciesAvailable = null;

	private static float[] _cachedSystemDisplayFrequenciesAvailable = null;

	private static HandStateInternal cachedHandState = default(HandStateInternal);

	private static Skeleton cachedSkeleton = default(Skeleton);

	private static Skeleton2Internal cachedSkeleton2 = default(Skeleton2Internal);

	private const string pluginName = "OVRPlugin";

	private static Version _versionZero = new Version(0, 0, 0);

	public static Version version
	{
		get
		{
			if (_version == null)
			{
				try
				{
					string text = OVRP_1_1_0.ovrp_GetVersion();
					if (text != null)
					{
						text = text.Split('-')[0];
						_version = new Version(text);
					}
					else
					{
						_version = _versionZero;
					}
				}
				catch
				{
					_version = _versionZero;
				}
				if (_version == OVRP_0_5_0.version)
				{
					_version = OVRP_0_1_0.version;
				}
				if (_version > _versionZero && _version < OVRP_1_3_0.version)
				{
					throw new PlatformNotSupportedException(string.Concat("Oculus Utilities version ", wrapperVersion, " is too new for OVRPlugin version ", _version.ToString(), ". Update to the latest version of Unity."));
				}
			}
			return _version;
		}
	}

	public static Version nativeSDKVersion
	{
		get
		{
			if (_nativeSDKVersion == null)
			{
				try
				{
					string empty = string.Empty;
					empty = ((!(version >= OVRP_1_1_0.version)) ? _versionZero.ToString() : OVRP_1_1_0.ovrp_GetNativeSDKVersion());
					if (empty != null)
					{
						empty = empty.Split('-')[0];
						_nativeSDKVersion = new Version(empty);
					}
					else
					{
						_nativeSDKVersion = _versionZero;
					}
				}
				catch
				{
					_nativeSDKVersion = _versionZero;
				}
			}
			return _nativeSDKVersion;
		}
	}

	public static bool initialized => OVRP_1_1_0.ovrp_GetInitialized() == Bool.True;

	public static XrApi nativeXrApi
	{
		get
		{
			if (!_nativeXrApi.HasValue)
			{
				_nativeXrApi = XrApi.Unknown;
				if (version >= OVRP_1_55_0.version && OVRP_1_55_0.ovrp_GetNativeXrApiType(out var xrApi) == Result.Success)
				{
					_nativeXrApi = xrApi;
				}
			}
			return _nativeXrApi.Value;
		}
	}

	public static bool chromatic
	{
		get
		{
			if (version >= OVRP_1_7_0.version)
			{
				if (initialized)
				{
					return OVRP_1_7_0.ovrp_GetAppChromaticCorrection() == Bool.True;
				}
				return false;
			}
			return true;
		}
		set
		{
			if (initialized && version >= OVRP_1_7_0.version)
			{
				OVRP_1_7_0.ovrp_SetAppChromaticCorrection(ToBool(value));
			}
		}
	}

	public static bool monoscopic
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetAppMonoscopic() == Bool.True;
			}
			return false;
		}
		set
		{
			if (initialized)
			{
				OVRP_1_1_0.ovrp_SetAppMonoscopic(ToBool(value));
			}
		}
	}

	public static bool rotation
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetTrackingOrientationEnabled() == Bool.True;
			}
			return false;
		}
		set
		{
			if (initialized)
			{
				OVRP_1_1_0.ovrp_SetTrackingOrientationEnabled(ToBool(value));
			}
		}
	}

	public static bool position
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetTrackingPositionEnabled() == Bool.True;
			}
			return false;
		}
		set
		{
			if (initialized)
			{
				OVRP_1_1_0.ovrp_SetTrackingPositionEnabled(ToBool(value));
			}
		}
	}

	public static bool useIPDInPositionTracking
	{
		get
		{
			if (initialized && version >= OVRP_1_6_0.version)
			{
				return OVRP_1_6_0.ovrp_GetTrackingIPDEnabled() == Bool.True;
			}
			return true;
		}
		set
		{
			if (initialized && version >= OVRP_1_6_0.version)
			{
				OVRP_1_6_0.ovrp_SetTrackingIPDEnabled(ToBool(value));
			}
		}
	}

	public static bool positionSupported
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetTrackingPositionSupported() == Bool.True;
			}
			return false;
		}
	}

	public static bool positionTracked
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetNodePositionTracked(Node.EyeCenter) == Bool.True;
			}
			return false;
		}
	}

	public static bool powerSaving
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetSystemPowerSavingMode() == Bool.True;
			}
			return false;
		}
	}

	public static bool hmdPresent
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetNodePresent(Node.EyeCenter) == Bool.True;
			}
			return false;
		}
	}

	public static bool userPresent
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_1_0.ovrp_GetUserPresent() == Bool.True;
			}
			return false;
		}
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static bool headphonesPresent
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_3_0.ovrp_GetSystemHeadphonesPresent() == Bool.True;
			}
			return false;
		}
	}

	public static int recommendedMSAALevel
	{
		get
		{
			if (initialized && version >= OVRP_1_6_0.version)
			{
				return OVRP_1_6_0.ovrp_GetSystemRecommendedMSAALevel();
			}
			return 2;
		}
	}

	public static SystemRegion systemRegion
	{
		get
		{
			if (initialized && version >= OVRP_1_5_0.version)
			{
				return OVRP_1_5_0.ovrp_GetSystemRegion();
			}
			return SystemRegion.Unspecified;
		}
	}

	public static string audioOutId
	{
		get
		{
			try
			{
				if (_nativeAudioOutGuid == null)
				{
					_nativeAudioOutGuid = new GUID();
				}
				IntPtr intPtr = OVRP_1_1_0.ovrp_GetAudioOutId();
				if (intPtr != IntPtr.Zero)
				{
					Marshal.PtrToStructure(intPtr, _nativeAudioOutGuid);
					Guid guid = new Guid(_nativeAudioOutGuid.a, _nativeAudioOutGuid.b, _nativeAudioOutGuid.c, _nativeAudioOutGuid.d0, _nativeAudioOutGuid.d1, _nativeAudioOutGuid.d2, _nativeAudioOutGuid.d3, _nativeAudioOutGuid.d4, _nativeAudioOutGuid.d5, _nativeAudioOutGuid.d6, _nativeAudioOutGuid.d7);
					if (guid != _cachedAudioOutGuid)
					{
						_cachedAudioOutGuid = guid;
						_cachedAudioOutString = _cachedAudioOutGuid.ToString();
					}
					return _cachedAudioOutString;
				}
			}
			catch
			{
			}
			return string.Empty;
		}
	}

	public static string audioInId
	{
		get
		{
			try
			{
				if (_nativeAudioInGuid == null)
				{
					_nativeAudioInGuid = new GUID();
				}
				IntPtr intPtr = OVRP_1_1_0.ovrp_GetAudioInId();
				if (intPtr != IntPtr.Zero)
				{
					Marshal.PtrToStructure(intPtr, _nativeAudioInGuid);
					Guid guid = new Guid(_nativeAudioInGuid.a, _nativeAudioInGuid.b, _nativeAudioInGuid.c, _nativeAudioInGuid.d0, _nativeAudioInGuid.d1, _nativeAudioInGuid.d2, _nativeAudioInGuid.d3, _nativeAudioInGuid.d4, _nativeAudioInGuid.d5, _nativeAudioInGuid.d6, _nativeAudioInGuid.d7);
					if (guid != _cachedAudioInGuid)
					{
						_cachedAudioInGuid = guid;
						_cachedAudioInString = _cachedAudioInGuid.ToString();
					}
					return _cachedAudioInString;
				}
			}
			catch
			{
			}
			return string.Empty;
		}
	}

	public static bool hasVrFocus => OVRP_1_1_0.ovrp_GetAppHasVrFocus() == Bool.True;

	public static bool hasInputFocus
	{
		get
		{
			if (version >= OVRP_1_18_0.version)
			{
				Bool appHasInputFocus = Bool.False;
				if (OVRP_1_18_0.ovrp_GetAppHasInputFocus(out appHasInputFocus) == Result.Success)
				{
					return appHasInputFocus == Bool.True;
				}
				return false;
			}
			return true;
		}
	}

	public static bool shouldQuit => OVRP_1_1_0.ovrp_GetAppShouldQuit() == Bool.True;

	public static bool shouldRecenter => OVRP_1_1_0.ovrp_GetAppShouldRecenter() == Bool.True;

	public static string productName => OVRP_1_1_0.ovrp_GetSystemProductName();

	public static string latency
	{
		get
		{
			if (!initialized)
			{
				return string.Empty;
			}
			return OVRP_1_1_0.ovrp_GetAppLatencyTimings();
		}
	}

	public static float eyeDepth
	{
		get
		{
			if (!initialized)
			{
				return 0f;
			}
			return OVRP_1_1_0.ovrp_GetUserEyeDepth();
		}
		set
		{
			OVRP_1_1_0.ovrp_SetUserEyeDepth(value);
		}
	}

	public static float eyeHeight
	{
		get
		{
			return OVRP_1_1_0.ovrp_GetUserEyeHeight();
		}
		set
		{
			OVRP_1_1_0.ovrp_SetUserEyeHeight(value);
		}
	}

	[Obsolete("Deprecated. Please use SystemInfo.batteryLevel", false)]
	public static float batteryLevel => OVRP_1_1_0.ovrp_GetSystemBatteryLevel();

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static float batteryTemperature => OVRP_1_1_0.ovrp_GetSystemBatteryTemperature();

	public static ProcessorPerformanceLevel suggestedCpuPerfLevel
	{
		get
		{
			if (version >= OVRP_1_71_0.version && OVRP_1_71_0.ovrp_GetSuggestedCpuPerformanceLevel(out var perfLevel) == Result.Success)
			{
				return perfLevel;
			}
			return ProcessorPerformanceLevel.SustainedHigh;
		}
		set
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_SetSuggestedCpuPerformanceLevel(value);
			}
		}
	}

	public static ProcessorPerformanceLevel suggestedGpuPerfLevel
	{
		get
		{
			if (version >= OVRP_1_71_0.version && OVRP_1_71_0.ovrp_GetSuggestedGpuPerformanceLevel(out var perfLevel) == Result.Success)
			{
				return perfLevel;
			}
			return ProcessorPerformanceLevel.SustainedHigh;
		}
		set
		{
			if (version >= OVRP_1_71_0.version)
			{
				OVRP_1_71_0.ovrp_SetSuggestedGpuPerformanceLevel(value);
			}
		}
	}

	[Obsolete("Deprecated. Please use suggestedCpuPerfLevel.", false)]
	public static int cpuLevel
	{
		get
		{
			return OVRP_1_1_0.ovrp_GetSystemCpuLevel();
		}
		set
		{
			OVRP_1_1_0.ovrp_SetSystemCpuLevel(value);
		}
	}

	[Obsolete("Deprecated. Please use suggestedGpuPerfLevel.", false)]
	public static int gpuLevel
	{
		get
		{
			return OVRP_1_1_0.ovrp_GetSystemGpuLevel();
		}
		set
		{
			OVRP_1_1_0.ovrp_SetSystemGpuLevel(value);
		}
	}

	public static int vsyncCount
	{
		get
		{
			return OVRP_1_1_0.ovrp_GetSystemVSyncCount();
		}
		set
		{
			OVRP_1_2_0.ovrp_SetSystemVSyncCount(value);
		}
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static float systemVolume => OVRP_1_1_0.ovrp_GetSystemVolume();

	public static float ipd
	{
		get
		{
			return OVRP_1_1_0.ovrp_GetUserIPD();
		}
		set
		{
			OVRP_1_1_0.ovrp_SetUserIPD(value);
		}
	}

	public static bool occlusionMesh
	{
		get
		{
			if (initialized)
			{
				return OVRP_1_3_0.ovrp_GetEyeOcclusionMeshEnabled() == Bool.True;
			}
			return false;
		}
		set
		{
			if (initialized)
			{
				OVRP_1_3_0.ovrp_SetEyeOcclusionMeshEnabled(ToBool(value));
			}
		}
	}

	[Obsolete("Deprecated. Please use SystemInfo.batteryStatus", false)]
	public static BatteryStatus batteryStatus => OVRP_1_1_0.ovrp_GetSystemBatteryStatus();

	public static bool fixedFoveatedRenderingSupported
	{
		get
		{
			if (version >= OVRP_1_21_0.version)
			{
				if (OVRP_1_21_0.ovrp_GetTiledMultiResSupported(out var foveationSupported) == Result.Success)
				{
					return foveationSupported == Bool.True;
				}
				return false;
			}
			return false;
		}
	}

	public static FixedFoveatedRenderingLevel fixedFoveatedRenderingLevel
	{
		get
		{
			if (version >= OVRP_1_21_0.version && fixedFoveatedRenderingSupported)
			{
				OVRP_1_21_0.ovrp_GetTiledMultiResLevel(out var level);
				return level;
			}
			return FixedFoveatedRenderingLevel.Off;
		}
		set
		{
			if (version >= OVRP_1_21_0.version && fixedFoveatedRenderingSupported)
			{
				OVRP_1_21_0.ovrp_SetTiledMultiResLevel(value);
			}
		}
	}

	public static bool useDynamicFixedFoveatedRendering
	{
		get
		{
			if (version >= OVRP_1_46_0.version && fixedFoveatedRenderingSupported)
			{
				Bool isDynamic = Bool.False;
				OVRP_1_46_0.ovrp_GetTiledMultiResDynamic(out isDynamic);
				return isDynamic != Bool.False;
			}
			return false;
		}
		set
		{
			if (version >= OVRP_1_46_0.version && fixedFoveatedRenderingSupported)
			{
				OVRP_1_46_0.ovrp_SetTiledMultiResDynamic(value ? Bool.True : Bool.False);
			}
		}
	}

	[Obsolete("Please use fixedFoveatedRenderingSupported instead", false)]
	public static bool tiledMultiResSupported => fixedFoveatedRenderingSupported;

	[Obsolete("Please use fixedFoveatedRenderingLevel instead", false)]
	public static TiledMultiResLevel tiledMultiResLevel
	{
		get
		{
			return (TiledMultiResLevel)fixedFoveatedRenderingLevel;
		}
		set
		{
			fixedFoveatedRenderingLevel = (FixedFoveatedRenderingLevel)value;
		}
	}

	public static bool gpuUtilSupported
	{
		get
		{
			if (version >= OVRP_1_21_0.version)
			{
				if (OVRP_1_21_0.ovrp_GetGPUUtilSupported(out var obj) == Result.Success)
				{
					return obj == Bool.True;
				}
				return false;
			}
			return false;
		}
	}

	public static float gpuUtilLevel
	{
		get
		{
			if (version >= OVRP_1_21_0.version && gpuUtilSupported)
			{
				if (OVRP_1_21_0.ovrp_GetGPUUtilLevel(out var gpuUtil) == Result.Success)
				{
					return gpuUtil;
				}
				return 0f;
			}
			return 0f;
		}
	}

	public static float[] systemDisplayFrequenciesAvailable
	{
		get
		{
			if (_cachedSystemDisplayFrequenciesAvailable == null)
			{
				_cachedSystemDisplayFrequenciesAvailable = new float[0];
				if (version >= OVRP_1_21_0.version)
				{
					int numFrequencies = 0;
					if (OVRP_1_21_0.ovrp_GetSystemDisplayAvailableFrequencies(IntPtr.Zero, ref numFrequencies) == Result.Success && numFrequencies > 0)
					{
						int num = numFrequencies;
						_nativeSystemDisplayFrequenciesAvailable = new OVRNativeBuffer(4 * num);
						if (OVRP_1_21_0.ovrp_GetSystemDisplayAvailableFrequencies(_nativeSystemDisplayFrequenciesAvailable.GetPointer(), ref numFrequencies) == Result.Success)
						{
							int num2 = ((numFrequencies <= num) ? numFrequencies : num);
							if (num2 > 0)
							{
								_cachedSystemDisplayFrequenciesAvailable = new float[num2];
								Marshal.Copy(_nativeSystemDisplayFrequenciesAvailable.GetPointer(), _cachedSystemDisplayFrequenciesAvailable, 0, num2);
							}
						}
					}
				}
			}
			return _cachedSystemDisplayFrequenciesAvailable;
		}
	}

	public static float systemDisplayFrequency
	{
		get
		{
			if (version >= OVRP_1_21_0.version)
			{
				if (OVRP_1_21_0.ovrp_GetSystemDisplayFrequency2(out var result) == Result.Success)
				{
					return result;
				}
				return 0f;
			}
			if (version >= OVRP_1_1_0.version)
			{
				return OVRP_1_1_0.ovrp_GetSystemDisplayFrequency();
			}
			return 0f;
		}
		set
		{
			if (version >= OVRP_1_21_0.version)
			{
				OVRP_1_21_0.ovrp_SetSystemDisplayFrequency(value);
			}
		}
	}

	public static bool eyeFovPremultipliedAlphaModeEnabled
	{
		get
		{
			Bool enabled = Bool.True;
			if (version >= OVRP_1_57_0.version)
			{
				OVRP_1_57_0.ovrp_GetEyeFovPremultipliedAlphaMode(ref enabled);
			}
			if (enabled != Bool.True)
			{
				return false;
			}
			return true;
		}
		set
		{
			if (version >= OVRP_1_57_0.version)
			{
				OVRP_1_57_0.ovrp_SetEyeFovPremultipliedAlphaMode(ToBool(value));
			}
		}
	}

	public static bool AsymmetricFovEnabled
	{
		get
		{
			if (version >= OVRP_1_21_0.version)
			{
				Bool useAsymmetricFov = Bool.False;
				if (OVRP_1_21_0.ovrp_GetAppAsymmetricFov(out useAsymmetricFov) != Result.Success)
				{
					return false;
				}
				return useAsymmetricFov == Bool.True;
			}
			return false;
		}
	}

	public static bool EyeTextureArrayEnabled
	{
		get
		{
			if (version >= OVRP_1_15_0.version)
			{
				return OVRP_1_15_0.ovrp_GetEyeTextureArrayEnabled() == Bool.True;
			}
			return false;
		}
	}

	public static void SetLogCallback2(LogCallback2DelegateType logCallback)
	{
		if (version >= OVRP_1_70_0.version && OVRP_1_70_0.ovrp_SetLogCallback2(logCallback) != Result.Success)
		{
			Debug.LogWarning("OVRPlugin.SetLogCallback2() failed");
		}
	}

	public static Frustumf GetEyeFrustum(Eye eyeId)
	{
		return OVRP_1_1_0.ovrp_GetNodeFrustum((Node)eyeId);
	}

	public static Sizei GetEyeTextureSize(Eye eyeId)
	{
		return OVRP_0_1_0.ovrp_GetEyeTextureSize(eyeId);
	}

	public static Posef GetTrackerPose(Tracker trackerId)
	{
		return GetNodePose((Node)(trackerId + 5), Step.Render);
	}

	public static Frustumf GetTrackerFrustum(Tracker trackerId)
	{
		return OVRP_1_1_0.ovrp_GetNodeFrustum((Node)(trackerId + 5));
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static bool ShowUI(PlatformUI ui)
	{
		return OVRP_1_1_0.ovrp_ShowSystemUI(ui) == Bool.True;
	}

	public static bool EnqueueSubmitLayer(bool onTop, bool headLocked, bool noDepthBufferTesting, IntPtr leftTexture, IntPtr rightTexture, int layerId, int frameIndex, Posef pose, Vector3f scale, int layerIndex = 0, OverlayShape shape = OverlayShape.Quad, bool overrideTextureRectMatrix = false, TextureRectMatrixf textureRectMatrix = default(TextureRectMatrixf), bool overridePerLayerColorScaleAndOffset = false, Vector4 colorScale = default(Vector4), Vector4 colorOffset = default(Vector4), bool expensiveSuperSample = false, bool hidden = false)
	{
		if (!initialized)
		{
			return false;
		}
		if (version >= OVRP_1_6_0.version)
		{
			uint num = 0u;
			if (onTop)
			{
				num |= 1;
			}
			if (headLocked)
			{
				num |= 2;
			}
			if (noDepthBufferTesting)
			{
				num |= 4;
			}
			if (expensiveSuperSample)
			{
				num |= 8;
			}
			if (hidden)
			{
				num |= 0x200;
			}
			if (shape == OverlayShape.Cylinder || shape == OverlayShape.Cubemap)
			{
				if (shape == OverlayShape.Cubemap && version >= OVRP_1_10_0.version)
				{
					num |= (uint)((int)shape << 4);
				}
				else
				{
					if (shape != OverlayShape.Cylinder || !(version >= OVRP_1_16_0.version))
					{
						return false;
					}
					num |= (uint)((int)shape << 4);
				}
			}
			switch (shape)
			{
			case OverlayShape.OffcenterCubemap:
				return false;
			case OverlayShape.Equirect:
				return false;
			case OverlayShape.Fisheye:
				return false;
			default:
				if (version >= OVRP_1_34_0.version && layerId != -1)
				{
					return OVRP_1_34_0.ovrp_EnqueueSubmitLayer2(num, leftTexture, rightTexture, layerId, frameIndex, ref pose, ref scale, layerIndex, overrideTextureRectMatrix ? Bool.True : Bool.False, ref textureRectMatrix, overridePerLayerColorScaleAndOffset ? Bool.True : Bool.False, ref colorScale, ref colorOffset) == Result.Success;
				}
				if (version >= OVRP_1_15_0.version && layerId != -1)
				{
					return OVRP_1_15_0.ovrp_EnqueueSubmitLayer(num, leftTexture, rightTexture, layerId, frameIndex, ref pose, ref scale, layerIndex) == Result.Success;
				}
				return OVRP_1_6_0.ovrp_SetOverlayQuad3(num, leftTexture, rightTexture, IntPtr.Zero, pose, scale, layerIndex) == Bool.True;
			}
		}
		if (layerIndex != 0)
		{
			return false;
		}
		return OVRP_0_1_1.ovrp_SetOverlayQuad2(ToBool(onTop), ToBool(headLocked), leftTexture, IntPtr.Zero, pose, scale) == Bool.True;
	}

	public static LayerDesc CalculateLayerDesc(OverlayShape shape, LayerLayout layout, Sizei textureSize, int mipLevels, int sampleCount, EyeTextureFormat format, int layerFlags)
	{
		LayerDesc layerDesc = default(LayerDesc);
		if (!initialized)
		{
			return layerDesc;
		}
		if (version >= OVRP_1_15_0.version)
		{
			OVRP_1_15_0.ovrp_CalculateLayerDesc(shape, layout, ref textureSize, mipLevels, sampleCount, format, layerFlags, ref layerDesc);
		}
		return layerDesc;
	}

	public static bool EnqueueSetupLayer(LayerDesc desc, int compositionDepth, IntPtr layerID)
	{
		if (!initialized)
		{
			return false;
		}
		if (version >= OVRP_1_28_0.version)
		{
			return OVRP_1_28_0.ovrp_EnqueueSetupLayer2(ref desc, compositionDepth, layerID) == Result.Success;
		}
		if (version >= OVRP_1_15_0.version)
		{
			if (compositionDepth != 0)
			{
				Debug.LogWarning("Use Oculus Plugin 1.28.0 or above to support non-zero compositionDepth");
			}
			return OVRP_1_15_0.ovrp_EnqueueSetupLayer(ref desc, layerID) == Result.Success;
		}
		return false;
	}

	public static bool EnqueueDestroyLayer(IntPtr layerID)
	{
		if (!initialized)
		{
			return false;
		}
		if (version >= OVRP_1_15_0.version)
		{
			return OVRP_1_15_0.ovrp_EnqueueDestroyLayer(layerID) == Result.Success;
		}
		return false;
	}

	public static IntPtr GetLayerTexture(int layerId, int stage, Eye eyeId)
	{
		IntPtr textureHandle = IntPtr.Zero;
		if (!initialized)
		{
			return textureHandle;
		}
		if (version >= OVRP_1_15_0.version)
		{
			OVRP_1_15_0.ovrp_GetLayerTexturePtr(layerId, stage, eyeId, ref textureHandle);
		}
		return textureHandle;
	}

	public static int GetLayerTextureStageCount(int layerId)
	{
		if (!initialized)
		{
			return 1;
		}
		int layerTextureStageCount = 1;
		if (version >= OVRP_1_15_0.version)
		{
			OVRP_1_15_0.ovrp_GetLayerTextureStageCount(layerId, ref layerTextureStageCount);
		}
		return layerTextureStageCount;
	}

	public static IntPtr GetLayerAndroidSurfaceObject(int layerId)
	{
		IntPtr surfaceObject = IntPtr.Zero;
		if (!initialized)
		{
			return surfaceObject;
		}
		if (version >= OVRP_1_29_0.version)
		{
			OVRP_1_29_0.ovrp_GetLayerAndroidSurfaceObject(layerId, ref surfaceObject);
		}
		return surfaceObject;
	}

	public static bool UpdateNodePhysicsPoses(int frameIndex, double predictionSeconds)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_Update2(0, frameIndex, predictionSeconds) == Bool.True;
		}
		return false;
	}

	public static Posef GetNodePose(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId).Pose;
		}
		if (version >= OVRP_1_8_0.version && stepId == Step.Physics)
		{
			return OVRP_1_8_0.ovrp_GetNodePose2(0, nodeId);
		}
		return OVRP_0_1_2.ovrp_GetNodePose(nodeId);
	}

	public static Vector3f GetNodeVelocity(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId).Velocity;
		}
		if (version >= OVRP_1_8_0.version && stepId == Step.Physics)
		{
			return OVRP_1_8_0.ovrp_GetNodeVelocity2(0, nodeId).Position;
		}
		return OVRP_0_1_3.ovrp_GetNodeVelocity(nodeId).Position;
	}

	public static Vector3f GetNodeAngularVelocity(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId).AngularVelocity;
		}
		return default(Vector3f);
	}

	public static Vector3f GetNodeAcceleration(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId).Acceleration;
		}
		if (version >= OVRP_1_8_0.version && stepId == Step.Physics)
		{
			return OVRP_1_8_0.ovrp_GetNodeAcceleration2(0, nodeId).Position;
		}
		return OVRP_0_1_3.ovrp_GetNodeAcceleration(nodeId).Position;
	}

	public static Vector3f GetNodeAngularAcceleration(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId).AngularAcceleration;
		}
		return default(Vector3f);
	}

	public static bool GetNodePresent(Node nodeId)
	{
		return OVRP_1_1_0.ovrp_GetNodePresent(nodeId) == Bool.True;
	}

	public static bool GetNodeOrientationTracked(Node nodeId)
	{
		return OVRP_1_1_0.ovrp_GetNodeOrientationTracked(nodeId) == Bool.True;
	}

	public static bool GetNodeOrientationValid(Node nodeId)
	{
		if (version >= OVRP_1_38_0.version)
		{
			Bool nodeOrientationValid = Bool.False;
			if (OVRP_1_38_0.ovrp_GetNodeOrientationValid(nodeId, ref nodeOrientationValid) == Result.Success)
			{
				return nodeOrientationValid == Bool.True;
			}
			return false;
		}
		return GetNodeOrientationTracked(nodeId);
	}

	public static bool GetNodePositionTracked(Node nodeId)
	{
		return OVRP_1_1_0.ovrp_GetNodePositionTracked(nodeId) == Bool.True;
	}

	public static bool GetNodePositionValid(Node nodeId)
	{
		if (version >= OVRP_1_38_0.version)
		{
			Bool nodePositionValid = Bool.False;
			if (OVRP_1_38_0.ovrp_GetNodePositionValid(nodeId, ref nodePositionValid) == Result.Success)
			{
				return nodePositionValid == Bool.True;
			}
			return false;
		}
		return GetNodePositionTracked(nodeId);
	}

	public static PoseStatef GetNodePoseStateRaw(Node nodeId, Step stepId)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_29_0.version)
		{
			if (OVRP_1_29_0.ovrp_GetNodePoseStateRaw(stepId, -1, nodeId, out var nodePoseState) == Result.Success)
			{
				return nodePoseState;
			}
			return PoseStatef.identity;
		}
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetNodePoseState(stepId, nodeId);
		}
		return PoseStatef.identity;
	}

	public static PoseStatef GetNodePoseStateImmediate(Node nodeId)
	{
		if (version >= OVRP_1_69_0.version)
		{
			if (OVRP_1_69_0.ovrp_GetNodePoseStateImmediate(nodeId, out var nodePoseState) == Result.Success)
			{
				return nodePoseState;
			}
			return PoseStatef.identity;
		}
		return PoseStatef.identity;
	}

	public static Posef GetCurrentTrackingTransformPose()
	{
		if (version >= OVRP_1_30_0.version)
		{
			if (OVRP_1_30_0.ovrp_GetCurrentTrackingTransformPose(out var trackingTransformPose) == Result.Success)
			{
				return trackingTransformPose;
			}
			return Posef.identity;
		}
		return Posef.identity;
	}

	public static Posef GetTrackingTransformRawPose()
	{
		if (version >= OVRP_1_30_0.version)
		{
			if (OVRP_1_30_0.ovrp_GetTrackingTransformRawPose(out var trackingTransformRawPose) == Result.Success)
			{
				return trackingTransformRawPose;
			}
			return Posef.identity;
		}
		return Posef.identity;
	}

	public static Posef GetTrackingTransformRelativePose(TrackingOrigin trackingOrigin)
	{
		if (version >= OVRP_1_38_0.version)
		{
			Posef trackingTransformRelativePose = Posef.identity;
			if (OVRP_1_38_0.ovrp_GetTrackingTransformRelativePose(ref trackingTransformRelativePose, trackingOrigin) == Result.Success)
			{
				return trackingTransformRelativePose;
			}
			return Posef.identity;
		}
		return Posef.identity;
	}

	public static ControllerState GetControllerState(uint controllerMask)
	{
		return OVRP_1_1_0.ovrp_GetControllerState(controllerMask);
	}

	public static ControllerState2 GetControllerState2(uint controllerMask)
	{
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetControllerState2(controllerMask);
		}
		return new ControllerState2(OVRP_1_1_0.ovrp_GetControllerState(controllerMask));
	}

	public static ControllerState4 GetControllerState4(uint controllerMask)
	{
		if (version >= OVRP_1_16_0.version)
		{
			ControllerState4 controllerState = default(ControllerState4);
			OVRP_1_16_0.ovrp_GetControllerState4(controllerMask, ref controllerState);
			return controllerState;
		}
		return new ControllerState4(GetControllerState2(controllerMask));
	}

	public static bool SetControllerVibration(uint controllerMask, float frequency, float amplitude)
	{
		return OVRP_0_1_2.ovrp_SetControllerVibration(controllerMask, frequency, amplitude) == Bool.True;
	}

	public static HapticsDesc GetControllerHapticsDesc(uint controllerMask)
	{
		if (version >= OVRP_1_6_0.version)
		{
			return OVRP_1_6_0.ovrp_GetControllerHapticsDesc(controllerMask);
		}
		return default(HapticsDesc);
	}

	public static HapticsState GetControllerHapticsState(uint controllerMask)
	{
		if (version >= OVRP_1_6_0.version)
		{
			return OVRP_1_6_0.ovrp_GetControllerHapticsState(controllerMask);
		}
		return default(HapticsState);
	}

	public static bool SetControllerHaptics(uint controllerMask, HapticsBuffer hapticsBuffer)
	{
		if (version >= OVRP_1_6_0.version)
		{
			return OVRP_1_6_0.ovrp_SetControllerHaptics(controllerMask, hapticsBuffer) == Bool.True;
		}
		return false;
	}

	public static float GetEyeRecommendedResolutionScale()
	{
		if (version >= OVRP_1_6_0.version)
		{
			return OVRP_1_6_0.ovrp_GetEyeRecommendedResolutionScale();
		}
		return 1f;
	}

	public static float GetAppCpuStartToGpuEndTime()
	{
		if (version >= OVRP_1_6_0.version)
		{
			return OVRP_1_6_0.ovrp_GetAppCpuStartToGpuEndTime();
		}
		return 0f;
	}

	public static bool GetBoundaryConfigured()
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_GetBoundaryConfigured() == Bool.True;
		}
		return false;
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static BoundaryTestResult TestBoundaryNode(Node nodeId, BoundaryType boundaryType)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_TestBoundaryNode(nodeId, boundaryType);
		}
		return default(BoundaryTestResult);
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static BoundaryTestResult TestBoundaryPoint(Vector3f point, BoundaryType boundaryType)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_TestBoundaryPoint(point, boundaryType);
		}
		return default(BoundaryTestResult);
	}

	public static BoundaryGeometry GetBoundaryGeometry(BoundaryType boundaryType)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_GetBoundaryGeometry(boundaryType);
		}
		return default(BoundaryGeometry);
	}

	public static bool GetBoundaryGeometry2(BoundaryType boundaryType, IntPtr points, ref int pointsCount)
	{
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_GetBoundaryGeometry2(boundaryType, points, ref pointsCount) == Bool.True;
		}
		pointsCount = 0;
		return false;
	}

	public static AppPerfStats GetAppPerfStats()
	{
		if (nativeXrApi == XrApi.OpenXR)
		{
			if (!perfStatWarningPrinted)
			{
				Debug.LogWarning("GetAppPerfStats is currently unsupported on OpenXR.");
				perfStatWarningPrinted = true;
			}
			return default(AppPerfStats);
		}
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_GetAppPerfStats();
		}
		return default(AppPerfStats);
	}

	public static bool ResetAppPerfStats()
	{
		if (nativeXrApi == XrApi.OpenXR)
		{
			if (!resetPerfStatWarningPrinted)
			{
				Debug.LogWarning("ResetAppPerfStats is currently unsupported on OpenXR.");
				resetPerfStatWarningPrinted = true;
			}
			return false;
		}
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_ResetAppPerfStats() == Bool.True;
		}
		return false;
	}

	public static float GetAppFramerate()
	{
		if (version >= OVRP_1_12_0.version)
		{
			return OVRP_1_12_0.ovrp_GetAppFramerate();
		}
		return 0f;
	}

	public static bool SetHandNodePoseStateLatency(double latencyInSeconds)
	{
		if (version >= OVRP_1_18_0.version)
		{
			if (OVRP_1_18_0.ovrp_SetHandNodePoseStateLatency(latencyInSeconds) == Result.Success)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static double GetHandNodePoseStateLatency()
	{
		if (version >= OVRP_1_18_0.version)
		{
			double latencyInSeconds = 0.0;
			if (OVRP_1_18_0.ovrp_GetHandNodePoseStateLatency(out latencyInSeconds) == Result.Success)
			{
				return latencyInSeconds;
			}
			return 0.0;
		}
		return 0.0;
	}

	public static EyeTextureFormat GetDesiredEyeTextureFormat()
	{
		if (version >= OVRP_1_11_0.version)
		{
			uint num = (uint)OVRP_1_11_0.ovrp_GetDesiredEyeTextureFormat();
			if (num == 1)
			{
				num = 0u;
			}
			return (EyeTextureFormat)num;
		}
		return EyeTextureFormat.Default;
	}

	public static bool SetDesiredEyeTextureFormat(EyeTextureFormat value)
	{
		if (version >= OVRP_1_11_0.version)
		{
			return OVRP_1_11_0.ovrp_SetDesiredEyeTextureFormat(value) == Bool.True;
		}
		return false;
	}

	public static bool InitializeMixedReality()
	{
		if (version >= OVRP_1_15_0.version)
		{
			return OVRP_1_15_0.ovrp_InitializeMixedReality() == Result.Success;
		}
		return false;
	}

	public static bool ShutdownMixedReality()
	{
		if (version >= OVRP_1_15_0.version)
		{
			return OVRP_1_15_0.ovrp_ShutdownMixedReality() == Result.Success;
		}
		return false;
	}

	public static bool IsMixedRealityInitialized()
	{
		if (version >= OVRP_1_15_0.version)
		{
			return OVRP_1_15_0.ovrp_GetMixedRealityInitialized() == Bool.True;
		}
		return false;
	}

	public static int GetExternalCameraCount()
	{
		if (version >= OVRP_1_15_0.version)
		{
			int cameraCount = 0;
			if (OVRP_1_15_0.ovrp_GetExternalCameraCount(out cameraCount) != Result.Success)
			{
				return 0;
			}
			return cameraCount;
		}
		return 0;
	}

	public static bool UpdateExternalCamera()
	{
		if (version >= OVRP_1_15_0.version)
		{
			return OVRP_1_15_0.ovrp_UpdateExternalCamera() == Result.Success;
		}
		return false;
	}

	public static bool GetMixedRealityCameraInfo(int cameraId, out CameraExtrinsics cameraExtrinsics, out CameraIntrinsics cameraIntrinsics)
	{
		cameraExtrinsics = default(CameraExtrinsics);
		cameraIntrinsics = default(CameraIntrinsics);
		if (version >= OVRP_1_15_0.version)
		{
			bool result = true;
			if (OVRP_1_15_0.ovrp_GetExternalCameraExtrinsics(cameraId, out cameraExtrinsics) != Result.Success)
			{
				result = false;
			}
			if (OVRP_1_15_0.ovrp_GetExternalCameraIntrinsics(cameraId, out cameraIntrinsics) != Result.Success)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	public static bool OverrideExternalCameraFov(int cameraId, bool useOverriddenFov, Fovf fov)
	{
		if (version >= OVRP_1_44_0.version)
		{
			bool result = true;
			if (OVRP_1_44_0.ovrp_OverrideExternalCameraFov(cameraId, useOverriddenFov ? Bool.True : Bool.False, ref fov) != Result.Success)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	public static bool GetUseOverriddenExternalCameraFov(int cameraId)
	{
		if (version >= OVRP_1_44_0.version)
		{
			bool result = true;
			Bool useOverriddenFov = Bool.False;
			if (OVRP_1_44_0.ovrp_GetUseOverriddenExternalCameraFov(cameraId, out useOverriddenFov) != Result.Success)
			{
				result = false;
			}
			if (useOverriddenFov == Bool.False)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	public static bool OverrideExternalCameraStaticPose(int cameraId, bool useOverriddenPose, Posef poseInStageOrigin)
	{
		if (version >= OVRP_1_44_0.version)
		{
			bool result = true;
			if (OVRP_1_44_0.ovrp_OverrideExternalCameraStaticPose(cameraId, useOverriddenPose ? Bool.True : Bool.False, ref poseInStageOrigin) != Result.Success)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	public static bool GetUseOverriddenExternalCameraStaticPose(int cameraId)
	{
		if (version >= OVRP_1_44_0.version)
		{
			bool result = true;
			Bool useOverriddenStaticPose = Bool.False;
			if (OVRP_1_44_0.ovrp_GetUseOverriddenExternalCameraStaticPose(cameraId, out useOverriddenStaticPose) != Result.Success)
			{
				result = false;
			}
			if (useOverriddenStaticPose == Bool.False)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	public static bool ResetDefaultExternalCamera()
	{
		if (version >= OVRP_1_44_0.version)
		{
			if (OVRP_1_44_0.ovrp_ResetDefaultExternalCamera() != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool SetDefaultExternalCamera(string cameraName, ref CameraIntrinsics cameraIntrinsics, ref CameraExtrinsics cameraExtrinsics)
	{
		if (version >= OVRP_1_44_0.version)
		{
			if (OVRP_1_44_0.ovrp_SetDefaultExternalCamera(cameraName, ref cameraIntrinsics, ref cameraExtrinsics) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool SetExternalCameraProperties(string cameraName, ref CameraIntrinsics cameraIntrinsics, ref CameraExtrinsics cameraExtrinsics)
	{
		if (version >= OVRP_1_48_0.version)
		{
			if (OVRP_1_48_0.ovrp_SetExternalCameraProperties(cameraName, ref cameraIntrinsics, ref cameraExtrinsics) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsInsightPassthroughSupported()
	{
		if (version >= OVRP_1_71_0.version)
		{
			Bool supported = Bool.False;
			Result result = OVRP_1_71_0.ovrp_IsInsightPassthroughSupported(ref supported);
			if (result == Result.Success)
			{
				return supported == Bool.True;
			}
			Debug.LogError("Unable to determine whether passthrough is supported. Try calling IsInsightPassthroughSupported() while the XR plug-in is initialized. Failed with reason: " + result);
			return false;
		}
		return false;
	}

	public static bool InitializeInsightPassthrough()
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_InitializeInsightPassthrough() != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool ShutdownInsightPassthrough()
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_ShutdownInsightPassthrough() != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool IsInsightPassthroughInitialized()
	{
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_GetInsightPassthroughInitialized() == Bool.True;
		}
		return false;
	}

	public static Result GetInsightPassthroughInitializationState()
	{
		if (version >= OVRP_1_66_0.version)
		{
			return OVRP_1_66_0.ovrp_GetInsightPassthroughInitializationState();
		}
		return Result.Failure_Unsupported;
	}

	public static bool CreateInsightTriangleMesh(int layerId, Vector3[] vertices, int[] triangles, out ulong meshHandle)
	{
		meshHandle = 0uL;
		if (version >= OVRP_1_63_0.version)
		{
			if (vertices == null || triangles == null || vertices.Length == 0 || triangles.Length == 0)
			{
				return false;
			}
			int vertexCount = vertices.Length;
			int triangleCount = triangles.Length / 3;
			GCHandle gCHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
			IntPtr vertices2 = gCHandle.AddrOfPinnedObject();
			GCHandle gCHandle2 = GCHandle.Alloc(triangles, GCHandleType.Pinned);
			IntPtr triangles2 = gCHandle2.AddrOfPinnedObject();
			Result num = OVRP_1_63_0.ovrp_CreateInsightTriangleMesh(layerId, vertices2, vertexCount, triangles2, triangleCount, out meshHandle);
			gCHandle2.Free();
			gCHandle.Free();
			if (num != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool DestroyInsightTriangleMesh(ulong meshHandle)
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_DestroyInsightTriangleMesh(meshHandle) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool AddInsightPassthroughSurfaceGeometry(int layerId, ulong meshHandle, Matrix4x4 T_world_model, out ulong geometryInstanceHandle)
	{
		geometryInstanceHandle = 0uL;
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_AddInsightPassthroughSurfaceGeometry(layerId, meshHandle, T_world_model, out geometryInstanceHandle) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool DestroyInsightPassthroughGeometryInstance(ulong geometryInstanceHandle)
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_DestroyInsightPassthroughGeometryInstance(geometryInstanceHandle) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool UpdateInsightPassthroughGeometryTransform(ulong geometryInstanceHandle, Matrix4x4 transform)
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_UpdateInsightPassthroughGeometryTransform(geometryInstanceHandle, transform) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool SetInsightPassthroughStyle(int layerId, InsightPassthroughStyle style)
	{
		if (version >= OVRP_1_63_0.version)
		{
			if (OVRP_1_63_0.ovrp_SetInsightPassthroughStyle(layerId, style) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool SetInsightPassthroughKeyboardHandsIntensity(int layerId, InsightPassthroughKeyboardHandsIntensity intensity)
	{
		if (version >= OVRP_1_68_0.version)
		{
			if (OVRP_1_68_0.ovrp_SetInsightPassthroughKeyboardHandsIntensity(layerId, intensity) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static Vector3f GetBoundaryDimensions(BoundaryType boundaryType)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_GetBoundaryDimensions(boundaryType);
		}
		return default(Vector3f);
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static bool GetBoundaryVisible()
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_GetBoundaryVisible() == Bool.True;
		}
		return false;
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static bool SetBoundaryVisible(bool value)
	{
		if (version >= OVRP_1_8_0.version)
		{
			return OVRP_1_8_0.ovrp_SetBoundaryVisible(ToBool(value)) == Bool.True;
		}
		return false;
	}

	public static SystemHeadset GetSystemHeadsetType()
	{
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_GetSystemHeadsetType();
		}
		return SystemHeadset.None;
	}

	public static Controller GetActiveController()
	{
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_GetActiveController();
		}
		return Controller.None;
	}

	public static Controller GetConnectedControllers()
	{
		if (version >= OVRP_1_9_0.version)
		{
			return OVRP_1_9_0.ovrp_GetConnectedControllers();
		}
		return Controller.None;
	}

	private static Bool ToBool(bool b)
	{
		if (!b)
		{
			return Bool.False;
		}
		return Bool.True;
	}

	public static TrackingOrigin GetTrackingOriginType()
	{
		return OVRP_1_0_0.ovrp_GetTrackingOriginType();
	}

	public static bool SetTrackingOriginType(TrackingOrigin originType)
	{
		return OVRP_1_0_0.ovrp_SetTrackingOriginType(originType) == Bool.True;
	}

	public static Posef GetTrackingCalibratedOrigin()
	{
		return OVRP_1_0_0.ovrp_GetTrackingCalibratedOrigin();
	}

	public static bool SetTrackingCalibratedOrigin()
	{
		return OVRP_1_2_0.ovrpi_SetTrackingCalibratedOrigin() == Bool.True;
	}

	public static bool RecenterTrackingOrigin(RecenterFlags flags)
	{
		return OVRP_1_0_0.ovrp_RecenterTrackingOrigin((uint)flags) == Bool.True;
	}

	public static bool UpdateCameraDevices()
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_UpdateCameraDevices() == Result.Success;
		}
		return false;
	}

	public static bool IsCameraDeviceAvailable(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_IsCameraDeviceAvailable(cameraDevice) == Bool.True;
		}
		return false;
	}

	public static bool SetCameraDevicePreferredColorFrameSize(CameraDevice cameraDevice, int width, int height)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_SetCameraDevicePreferredColorFrameSize(cameraDevice, new Sizei
			{
				w = width,
				h = height
			}) == Result.Success;
		}
		return false;
	}

	public static bool OpenCameraDevice(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_OpenCameraDevice(cameraDevice) == Result.Success;
		}
		return false;
	}

	public static bool CloseCameraDevice(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_CloseCameraDevice(cameraDevice) == Result.Success;
		}
		return false;
	}

	public static bool HasCameraDeviceOpened(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_HasCameraDeviceOpened(cameraDevice) == Bool.True;
		}
		return false;
	}

	public static bool IsCameraDeviceColorFrameAvailable(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			return OVRP_1_16_0.ovrp_IsCameraDeviceColorFrameAvailable(cameraDevice) == Bool.True;
		}
		return false;
	}

	public static Texture2D GetCameraDeviceColorFrameTexture(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_16_0.version)
		{
			Sizei colorFrameSize = default(Sizei);
			if (OVRP_1_16_0.ovrp_GetCameraDeviceColorFrameSize(cameraDevice, out colorFrameSize) != Result.Success)
			{
				return null;
			}
			if (OVRP_1_16_0.ovrp_GetCameraDeviceColorFrameBgraPixels(cameraDevice, out var colorFrameBgraPixels, out var colorFrameRowPitch) != Result.Success)
			{
				return null;
			}
			if (colorFrameRowPitch != colorFrameSize.w * 4)
			{
				return null;
			}
			if (!cachedCameraFrameTexture || cachedCameraFrameTexture.width != colorFrameSize.w || cachedCameraFrameTexture.height != colorFrameSize.h)
			{
				cachedCameraFrameTexture = new Texture2D(colorFrameSize.w, colorFrameSize.h, TextureFormat.BGRA32, mipChain: false);
			}
			cachedCameraFrameTexture.LoadRawTextureData(colorFrameBgraPixels, colorFrameRowPitch * colorFrameSize.h);
			cachedCameraFrameTexture.Apply();
			return cachedCameraFrameTexture;
		}
		return null;
	}

	public static bool DoesCameraDeviceSupportDepth(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_17_0.version)
		{
			if (OVRP_1_17_0.ovrp_DoesCameraDeviceSupportDepth(cameraDevice, out var supportDepth) == Result.Success)
			{
				return supportDepth == Bool.True;
			}
			return false;
		}
		return false;
	}

	public static bool SetCameraDeviceDepthSensingMode(CameraDevice camera, CameraDeviceDepthSensingMode depthSensoringMode)
	{
		if (version >= OVRP_1_17_0.version)
		{
			return OVRP_1_17_0.ovrp_SetCameraDeviceDepthSensingMode(camera, depthSensoringMode) == Result.Success;
		}
		return false;
	}

	public static bool SetCameraDevicePreferredDepthQuality(CameraDevice camera, CameraDeviceDepthQuality depthQuality)
	{
		if (version >= OVRP_1_17_0.version)
		{
			return OVRP_1_17_0.ovrp_SetCameraDevicePreferredDepthQuality(camera, depthQuality) == Result.Success;
		}
		return false;
	}

	public static bool IsCameraDeviceDepthFrameAvailable(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_17_0.version)
		{
			if (OVRP_1_17_0.ovrp_IsCameraDeviceDepthFrameAvailable(cameraDevice, out var available) == Result.Success)
			{
				return available == Bool.True;
			}
			return false;
		}
		return false;
	}

	public static Texture2D GetCameraDeviceDepthFrameTexture(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_17_0.version)
		{
			Sizei depthFrameSize = default(Sizei);
			if (OVRP_1_17_0.ovrp_GetCameraDeviceDepthFrameSize(cameraDevice, out depthFrameSize) != Result.Success)
			{
				return null;
			}
			if (OVRP_1_17_0.ovrp_GetCameraDeviceDepthFramePixels(cameraDevice, out var depthFramePixels, out var depthFrameRowPitch) != Result.Success)
			{
				return null;
			}
			if (depthFrameRowPitch != depthFrameSize.w * 4)
			{
				return null;
			}
			if (!cachedCameraDepthTexture || cachedCameraDepthTexture.width != depthFrameSize.w || cachedCameraDepthTexture.height != depthFrameSize.h)
			{
				cachedCameraDepthTexture = new Texture2D(depthFrameSize.w, depthFrameSize.h, TextureFormat.RFloat, mipChain: false);
				cachedCameraDepthTexture.filterMode = FilterMode.Point;
			}
			cachedCameraDepthTexture.LoadRawTextureData(depthFramePixels, depthFrameRowPitch * depthFrameSize.h);
			cachedCameraDepthTexture.Apply();
			return cachedCameraDepthTexture;
		}
		return null;
	}

	public static Texture2D GetCameraDeviceDepthConfidenceTexture(CameraDevice cameraDevice)
	{
		if (version >= OVRP_1_17_0.version)
		{
			Sizei depthFrameSize = default(Sizei);
			if (OVRP_1_17_0.ovrp_GetCameraDeviceDepthFrameSize(cameraDevice, out depthFrameSize) != Result.Success)
			{
				return null;
			}
			if (OVRP_1_17_0.ovrp_GetCameraDeviceDepthConfidencePixels(cameraDevice, out var depthConfidencePixels, out var depthConfidenceRowPitch) != Result.Success)
			{
				return null;
			}
			if (depthConfidenceRowPitch != depthFrameSize.w * 4)
			{
				return null;
			}
			if (!cachedCameraDepthConfidenceTexture || cachedCameraDepthConfidenceTexture.width != depthFrameSize.w || cachedCameraDepthConfidenceTexture.height != depthFrameSize.h)
			{
				cachedCameraDepthConfidenceTexture = new Texture2D(depthFrameSize.w, depthFrameSize.h, TextureFormat.RFloat, mipChain: false);
			}
			cachedCameraDepthConfidenceTexture.LoadRawTextureData(depthConfidencePixels, depthConfidenceRowPitch * depthFrameSize.h);
			cachedCameraDepthConfidenceTexture.Apply();
			return cachedCameraDepthConfidenceTexture;
		}
		return null;
	}

	public static bool GetNodeFrustum2(Node nodeId, out Frustumf2 frustum)
	{
		frustum = default(Frustumf2);
		if (version >= OVRP_1_15_0.version)
		{
			if (OVRP_1_15_0.ovrp_GetNodeFrustum2(nodeId, out frustum) != Result.Success)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static Handedness GetDominantHand()
	{
		if (version >= OVRP_1_28_0.version && OVRP_1_28_0.ovrp_GetDominantHand(out var dominantHand) == Result.Success)
		{
			return dominantHand;
		}
		return Handedness.Unsupported;
	}

	public static bool SendEvent(string name, string param = "", string source = "")
	{
		if (version >= OVRP_1_30_0.version)
		{
			return OVRP_1_30_0.ovrp_SendEvent2(name, param, (source.Length == 0) ? "integration" : source) == Result.Success;
		}
		if (version >= OVRP_1_28_0.version)
		{
			return OVRP_1_28_0.ovrp_SendEvent(name, param) == Result.Success;
		}
		return false;
	}

	public static bool SetHeadPoseModifier(ref Quatf relativeRotation, ref Vector3f relativeTranslation)
	{
		if (version >= OVRP_1_29_0.version)
		{
			return OVRP_1_29_0.ovrp_SetHeadPoseModifier(ref relativeRotation, ref relativeTranslation) == Result.Success;
		}
		return false;
	}

	public static bool GetHeadPoseModifier(out Quatf relativeRotation, out Vector3f relativeTranslation)
	{
		if (version >= OVRP_1_29_0.version)
		{
			return OVRP_1_29_0.ovrp_GetHeadPoseModifier(out relativeRotation, out relativeTranslation) == Result.Success;
		}
		relativeRotation = Quatf.identity;
		relativeTranslation = Vector3f.zero;
		return false;
	}

	public static bool IsPerfMetricsSupported(PerfMetrics perfMetrics)
	{
		if (version >= OVRP_1_30_0.version)
		{
			if (OVRP_1_30_0.ovrp_IsPerfMetricsSupported(perfMetrics, out var isSupported) == Result.Success)
			{
				return isSupported == Bool.True;
			}
			return false;
		}
		return false;
	}

	public static float? GetPerfMetricsFloat(PerfMetrics perfMetrics)
	{
		if (version >= OVRP_1_30_0.version)
		{
			if (OVRP_1_30_0.ovrp_GetPerfMetricsFloat(perfMetrics, out var value) == Result.Success)
			{
				return value;
			}
			return null;
		}
		return null;
	}

	public static int? GetPerfMetricsInt(PerfMetrics perfMetrics)
	{
		if (version >= OVRP_1_30_0.version)
		{
			if (OVRP_1_30_0.ovrp_GetPerfMetricsInt(perfMetrics, out var value) == Result.Success)
			{
				return value;
			}
			return null;
		}
		return null;
	}

	public static double GetTimeInSeconds()
	{
		if (version >= OVRP_1_31_0.version)
		{
			if (OVRP_1_31_0.ovrp_GetTimeInSeconds(out var value) == Result.Success)
			{
				return value;
			}
			return 0.0;
		}
		return 0.0;
	}

	public static bool SetColorScaleAndOffset(Vector4 colorScale, Vector4 colorOffset, bool applyToAllLayers)
	{
		if (version >= OVRP_1_31_0.version)
		{
			Bool applyToAllLayers2 = (applyToAllLayers ? Bool.True : Bool.False);
			return OVRP_1_31_0.ovrp_SetColorScaleAndOffset(colorScale, colorOffset, applyToAllLayers2) == Result.Success;
		}
		return false;
	}

	public static bool AddCustomMetadata(string name, string param = "")
	{
		if (version >= OVRP_1_32_0.version)
		{
			return OVRP_1_32_0.ovrp_AddCustomMetadata(name, param) == Result.Success;
		}
		return false;
	}

	public static bool SetDeveloperMode(Bool active)
	{
		if (version >= OVRP_1_38_0.version)
		{
			return OVRP_1_38_0.ovrp_SetDeveloperMode(active) == Result.Success;
		}
		return false;
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static float GetAdaptiveGPUPerformanceScale()
	{
		if (version >= OVRP_1_42_0.version)
		{
			float adaptiveGpuPerformanceScale = 1f;
			if (OVRP_1_42_0.ovrp_GetAdaptiveGpuPerformanceScale2(ref adaptiveGpuPerformanceScale) == Result.Success)
			{
				return adaptiveGpuPerformanceScale;
			}
			return 1f;
		}
		return 1f;
	}

	public static bool GetHandTrackingEnabled()
	{
		if (version >= OVRP_1_44_0.version)
		{
			Bool handTrackingEnabled = Bool.False;
			if (OVRP_1_44_0.ovrp_GetHandTrackingEnabled(ref handTrackingEnabled) == Result.Success)
			{
				return handTrackingEnabled == Bool.True;
			}
			return false;
		}
		return false;
	}

	public static bool GetHandState(Step stepId, Hand hand, ref HandState handState)
	{
		if (nativeXrApi == XrApi.OpenXR && stepId == Step.Physics)
		{
			Debug.LogWarning("Step.Physics is deprecated when using OpenXR");
			stepId = Step.Render;
		}
		if (version >= OVRP_1_44_0.version)
		{
			if (OVRP_1_44_0.ovrp_GetHandState(stepId, hand, out cachedHandState) == Result.Success)
			{
				if (handState.BoneRotations == null || handState.BoneRotations.Length != 24)
				{
					handState.BoneRotations = new Quatf[24];
				}
				if (handState.PinchStrength == null || handState.PinchStrength.Length != 5)
				{
					handState.PinchStrength = new float[5];
				}
				if (handState.FingerConfidences == null || handState.FingerConfidences.Length != 5)
				{
					handState.FingerConfidences = new TrackingConfidence[5];
				}
				handState.Status = cachedHandState.Status;
				handState.RootPose = cachedHandState.RootPose;
				handState.BoneRotations[0] = cachedHandState.BoneRotations_0;
				handState.BoneRotations[1] = cachedHandState.BoneRotations_1;
				handState.BoneRotations[2] = cachedHandState.BoneRotations_2;
				handState.BoneRotations[3] = cachedHandState.BoneRotations_3;
				handState.BoneRotations[4] = cachedHandState.BoneRotations_4;
				handState.BoneRotations[5] = cachedHandState.BoneRotations_5;
				handState.BoneRotations[6] = cachedHandState.BoneRotations_6;
				handState.BoneRotations[7] = cachedHandState.BoneRotations_7;
				handState.BoneRotations[8] = cachedHandState.BoneRotations_8;
				handState.BoneRotations[9] = cachedHandState.BoneRotations_9;
				handState.BoneRotations[10] = cachedHandState.BoneRotations_10;
				handState.BoneRotations[11] = cachedHandState.BoneRotations_11;
				handState.BoneRotations[12] = cachedHandState.BoneRotations_12;
				handState.BoneRotations[13] = cachedHandState.BoneRotations_13;
				handState.BoneRotations[14] = cachedHandState.BoneRotations_14;
				handState.BoneRotations[15] = cachedHandState.BoneRotations_15;
				handState.BoneRotations[16] = cachedHandState.BoneRotations_16;
				handState.BoneRotations[17] = cachedHandState.BoneRotations_17;
				handState.BoneRotations[18] = cachedHandState.BoneRotations_18;
				handState.BoneRotations[19] = cachedHandState.BoneRotations_19;
				handState.BoneRotations[20] = cachedHandState.BoneRotations_20;
				handState.BoneRotations[21] = cachedHandState.BoneRotations_21;
				handState.BoneRotations[22] = cachedHandState.BoneRotations_22;
				handState.BoneRotations[23] = cachedHandState.BoneRotations_23;
				handState.Pinches = cachedHandState.Pinches;
				handState.PinchStrength[0] = cachedHandState.PinchStrength_0;
				handState.PinchStrength[1] = cachedHandState.PinchStrength_1;
				handState.PinchStrength[2] = cachedHandState.PinchStrength_2;
				handState.PinchStrength[3] = cachedHandState.PinchStrength_3;
				handState.PinchStrength[4] = cachedHandState.PinchStrength_4;
				handState.PointerPose = cachedHandState.PointerPose;
				handState.HandScale = cachedHandState.HandScale;
				handState.HandConfidence = cachedHandState.HandConfidence;
				handState.FingerConfidences[0] = cachedHandState.FingerConfidences_0;
				handState.FingerConfidences[1] = cachedHandState.FingerConfidences_1;
				handState.FingerConfidences[2] = cachedHandState.FingerConfidences_2;
				handState.FingerConfidences[3] = cachedHandState.FingerConfidences_3;
				handState.FingerConfidences[4] = cachedHandState.FingerConfidences_4;
				handState.RequestedTimeStamp = cachedHandState.RequestedTimeStamp;
				handState.SampleTimeStamp = cachedHandState.SampleTimeStamp;
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool GetSkeleton(SkeletonType skeletonType, out Skeleton skeleton)
	{
		if (version >= OVRP_1_44_0.version)
		{
			return OVRP_1_44_0.ovrp_GetSkeleton(skeletonType, out skeleton) == Result.Success;
		}
		skeleton = default(Skeleton);
		return false;
	}

	public static bool GetSkeleton2(SkeletonType skeletonType, ref Skeleton2 skeleton)
	{
		if (version >= OVRP_1_55_0.version)
		{
			if (OVRP_1_55_0.ovrp_GetSkeleton2(skeletonType, out cachedSkeleton2) == Result.Success)
			{
				if (skeleton.Bones == null || skeleton.Bones.Length != 50)
				{
					skeleton.Bones = new Bone[50];
				}
				if (skeleton.BoneCapsules == null || skeleton.BoneCapsules.Length != 19)
				{
					skeleton.BoneCapsules = new BoneCapsule[19];
				}
				skeleton.Type = cachedSkeleton2.Type;
				skeleton.NumBones = cachedSkeleton2.NumBones;
				skeleton.NumBoneCapsules = cachedSkeleton2.NumBoneCapsules;
				skeleton.Bones[0] = cachedSkeleton2.Bones_0;
				skeleton.Bones[1] = cachedSkeleton2.Bones_1;
				skeleton.Bones[2] = cachedSkeleton2.Bones_2;
				skeleton.Bones[3] = cachedSkeleton2.Bones_3;
				skeleton.Bones[4] = cachedSkeleton2.Bones_4;
				skeleton.Bones[5] = cachedSkeleton2.Bones_5;
				skeleton.Bones[6] = cachedSkeleton2.Bones_6;
				skeleton.Bones[7] = cachedSkeleton2.Bones_7;
				skeleton.Bones[8] = cachedSkeleton2.Bones_8;
				skeleton.Bones[9] = cachedSkeleton2.Bones_9;
				skeleton.Bones[10] = cachedSkeleton2.Bones_10;
				skeleton.Bones[11] = cachedSkeleton2.Bones_11;
				skeleton.Bones[12] = cachedSkeleton2.Bones_12;
				skeleton.Bones[13] = cachedSkeleton2.Bones_13;
				skeleton.Bones[14] = cachedSkeleton2.Bones_14;
				skeleton.Bones[15] = cachedSkeleton2.Bones_15;
				skeleton.Bones[16] = cachedSkeleton2.Bones_16;
				skeleton.Bones[17] = cachedSkeleton2.Bones_17;
				skeleton.Bones[18] = cachedSkeleton2.Bones_18;
				skeleton.Bones[19] = cachedSkeleton2.Bones_19;
				skeleton.Bones[20] = cachedSkeleton2.Bones_20;
				skeleton.Bones[21] = cachedSkeleton2.Bones_21;
				skeleton.Bones[22] = cachedSkeleton2.Bones_22;
				skeleton.Bones[23] = cachedSkeleton2.Bones_23;
				skeleton.Bones[24] = cachedSkeleton2.Bones_24;
				skeleton.Bones[25] = cachedSkeleton2.Bones_25;
				skeleton.Bones[26] = cachedSkeleton2.Bones_26;
				skeleton.Bones[27] = cachedSkeleton2.Bones_27;
				skeleton.Bones[28] = cachedSkeleton2.Bones_28;
				skeleton.Bones[29] = cachedSkeleton2.Bones_29;
				skeleton.Bones[30] = cachedSkeleton2.Bones_30;
				skeleton.Bones[31] = cachedSkeleton2.Bones_31;
				skeleton.Bones[32] = cachedSkeleton2.Bones_32;
				skeleton.Bones[33] = cachedSkeleton2.Bones_33;
				skeleton.Bones[34] = cachedSkeleton2.Bones_34;
				skeleton.Bones[35] = cachedSkeleton2.Bones_35;
				skeleton.Bones[36] = cachedSkeleton2.Bones_36;
				skeleton.Bones[37] = cachedSkeleton2.Bones_37;
				skeleton.Bones[38] = cachedSkeleton2.Bones_38;
				skeleton.Bones[39] = cachedSkeleton2.Bones_39;
				skeleton.Bones[40] = cachedSkeleton2.Bones_40;
				skeleton.Bones[41] = cachedSkeleton2.Bones_41;
				skeleton.Bones[42] = cachedSkeleton2.Bones_42;
				skeleton.Bones[43] = cachedSkeleton2.Bones_43;
				skeleton.Bones[44] = cachedSkeleton2.Bones_44;
				skeleton.Bones[45] = cachedSkeleton2.Bones_45;
				skeleton.Bones[46] = cachedSkeleton2.Bones_46;
				skeleton.Bones[47] = cachedSkeleton2.Bones_47;
				skeleton.Bones[48] = cachedSkeleton2.Bones_48;
				skeleton.Bones[49] = cachedSkeleton2.Bones_49;
				skeleton.BoneCapsules[0] = cachedSkeleton2.BoneCapsules_0;
				skeleton.BoneCapsules[1] = cachedSkeleton2.BoneCapsules_1;
				skeleton.BoneCapsules[2] = cachedSkeleton2.BoneCapsules_2;
				skeleton.BoneCapsules[3] = cachedSkeleton2.BoneCapsules_3;
				skeleton.BoneCapsules[4] = cachedSkeleton2.BoneCapsules_4;
				skeleton.BoneCapsules[5] = cachedSkeleton2.BoneCapsules_5;
				skeleton.BoneCapsules[6] = cachedSkeleton2.BoneCapsules_6;
				skeleton.BoneCapsules[7] = cachedSkeleton2.BoneCapsules_7;
				skeleton.BoneCapsules[8] = cachedSkeleton2.BoneCapsules_8;
				skeleton.BoneCapsules[9] = cachedSkeleton2.BoneCapsules_9;
				skeleton.BoneCapsules[10] = cachedSkeleton2.BoneCapsules_10;
				skeleton.BoneCapsules[11] = cachedSkeleton2.BoneCapsules_11;
				skeleton.BoneCapsules[12] = cachedSkeleton2.BoneCapsules_12;
				skeleton.BoneCapsules[13] = cachedSkeleton2.BoneCapsules_13;
				skeleton.BoneCapsules[14] = cachedSkeleton2.BoneCapsules_14;
				skeleton.BoneCapsules[15] = cachedSkeleton2.BoneCapsules_15;
				skeleton.BoneCapsules[16] = cachedSkeleton2.BoneCapsules_16;
				skeleton.BoneCapsules[17] = cachedSkeleton2.BoneCapsules_17;
				skeleton.BoneCapsules[18] = cachedSkeleton2.BoneCapsules_18;
				return true;
			}
			return false;
		}
		if (GetSkeleton(skeletonType, out cachedSkeleton))
		{
			if (skeleton.Bones == null || skeleton.Bones.Length != 50)
			{
				skeleton.Bones = new Bone[50];
			}
			if (skeleton.BoneCapsules == null || skeleton.BoneCapsules.Length != 19)
			{
				skeleton.BoneCapsules = new BoneCapsule[19];
			}
			skeleton.Type = cachedSkeleton.Type;
			skeleton.NumBones = cachedSkeleton.NumBones;
			skeleton.NumBoneCapsules = cachedSkeleton.NumBoneCapsules;
			for (int i = 0; i < skeleton.NumBones; i++)
			{
				skeleton.Bones[i] = cachedSkeleton.Bones[i];
			}
			for (int j = 0; j < skeleton.NumBoneCapsules; j++)
			{
				skeleton.BoneCapsules[j] = cachedSkeleton.BoneCapsules[j];
			}
			return true;
		}
		return false;
	}

	public static bool GetMesh(MeshType meshType, out Mesh mesh)
	{
		if (version >= OVRP_1_44_0.version)
		{
			mesh = new Mesh();
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(mesh));
			Result num = OVRP_1_44_0.ovrp_GetMesh(meshType, intPtr);
			if (num == Result.Success)
			{
				Marshal.PtrToStructure(intPtr, mesh);
			}
			Marshal.FreeHGlobal(intPtr);
			return num == Result.Success;
		}
		mesh = new Mesh();
		return false;
	}

	public static bool StartKeyboardTracking(ulong trackedKeyboardId)
	{
		if (version >= OVRP_1_68_0.version)
		{
			return OVRP_1_68_0.ovrp_StartKeyboardTracking(trackedKeyboardId) == Result.Success;
		}
		return false;
	}

	public static bool StopKeyboardTracking()
	{
		if (version >= OVRP_1_68_0.version)
		{
			return OVRP_1_68_0.ovrp_StopKeyboardTracking() == Result.Success;
		}
		return false;
	}

	public static bool GetKeyboardState(Step stepId, out KeyboardState keyboardState)
	{
		keyboardState = default(KeyboardState);
		if (version >= OVRP_1_68_0.version)
		{
			return OVRP_1_68_0.ovrp_GetKeyboardState(stepId, -1, out keyboardState) == Result.Success;
		}
		return false;
	}

	public static bool GetSystemKeyboardDescription(TrackedKeyboardQueryFlags keyboardQueryFlags, out KeyboardDescription keyboardDescription)
	{
		keyboardDescription = default(KeyboardDescription);
		if (version >= OVRP_1_68_0.version)
		{
			return OVRP_1_68_0.ovrp_GetSystemKeyboardDescription(keyboardQueryFlags, out keyboardDescription) == Result.Success;
		}
		return false;
	}

	public static int GetLocalTrackingSpaceRecenterCount()
	{
		if (version >= OVRP_1_44_0.version)
		{
			int recenterCount = 0;
			if (OVRP_1_44_0.ovrp_GetLocalTrackingSpaceRecenterCount(ref recenterCount) == Result.Success)
			{
				return recenterCount;
			}
			return 0;
		}
		return 0;
	}

	public static bool GetSystemHmd3DofModeEnabled()
	{
		if (version >= OVRP_1_45_0.version)
		{
			Bool enabled = Bool.False;
			if (OVRP_1_45_0.ovrp_GetSystemHmd3DofModeEnabled(ref enabled) == Result.Success)
			{
				return enabled == Bool.True;
			}
			return false;
		}
		return false;
	}

	public static bool SetClientColorDesc(ColorSpace colorSpace)
	{
		if (version >= OVRP_1_49_0.version)
		{
			if (colorSpace == ColorSpace.Unknown)
			{
				Debug.LogWarning("A color gamut of Unknown is not supported. Defaulting to Rift CV1 color space instead.");
				colorSpace = ColorSpace.Rift_CV1;
			}
			return OVRP_1_49_0.ovrp_SetClientColorDesc(colorSpace) == Result.Success;
		}
		return false;
	}

	public static ColorSpace GetHmdColorDesc()
	{
		ColorSpace colorSpace = ColorSpace.Unknown;
		if (version >= OVRP_1_49_0.version)
		{
			if (OVRP_1_49_0.ovrp_GetHmdColorDesc(ref colorSpace) != Result.Success)
			{
				Debug.LogError("GetHmdColorDesc: Failed to get Hmd color description");
			}
			return colorSpace;
		}
		Debug.LogError("GetHmdColorDesc: Not supported on this version of OVRPlugin");
		return colorSpace;
	}

	public static bool PollEvent(ref EventDataBuffer eventDataBuffer)
	{
		if (version >= OVRP_1_55_1.version)
		{
			IntPtr eventData = IntPtr.Zero;
			if (eventDataBuffer.EventData == null)
			{
				eventDataBuffer.EventData = new byte[4000];
			}
			if (OVRP_1_55_1.ovrp_PollEvent2(ref eventDataBuffer.EventType, ref eventData) != Result.Success || eventData == IntPtr.Zero)
			{
				return false;
			}
			Marshal.Copy(eventData, eventDataBuffer.EventData, 0, 4000);
			return true;
		}
		if (version >= OVRP_1_55_0.version)
		{
			return OVRP_1_55_0.ovrp_PollEvent(ref eventDataBuffer) == Result.Success;
		}
		eventDataBuffer = default(EventDataBuffer);
		return false;
	}

	public static ulong GetNativeOpenXRInstance()
	{
		if (version >= OVRP_1_55_0.version && OVRP_1_55_0.ovrp_GetNativeOpenXRHandles(out var xrInstance, out var _) == Result.Success)
		{
			return xrInstance;
		}
		return 0uL;
	}

	public static ulong GetNativeOpenXRSession()
	{
		if (version >= OVRP_1_55_0.version && OVRP_1_55_0.ovrp_GetNativeOpenXRHandles(out var _, out var xrSession) == Result.Success)
		{
			return xrSession;
		}
		return 0uL;
	}

	public static bool SetKeyboardOverlayUV(Vector2f uv)
	{
		if (version >= OVRP_1_57_0.version)
		{
			return OVRP_1_57_0.ovrp_SetKeyboardOverlayUV(uv) == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntityCreateSpatialAnchor(SpatialEntityAnchorCreateInfo createInfo, ref ulong space)
	{
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_CreateSpatialAnchor(ref createInfo, out space) == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntitySetComponentEnabled(ref ulong space, SpatialEntityComponentType componentType, bool enable, double timeout, ref ulong requestId)
	{
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_SetComponentEnabled(ref space, componentType, ToBool(enable), timeout, out requestId) == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntityGetComponentEnabled(ref ulong space, SpatialEntityComponentType componentType, out bool enabled, out bool changePending)
	{
		enabled = false;
		changePending = false;
		if (version >= OVRP_1_63_0.version)
		{
			Bool enabled2;
			Bool changePending2;
			Result num = OVRP_1_63_0.ovrp_GetComponentEnabled(ref space, componentType, out enabled2, out changePending2);
			enabled = enabled2 == Bool.True;
			changePending = changePending2 == Bool.True;
			return num == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntityEnumerateSupportedComponents(ref ulong space, out uint numSupportedComponents, SpatialEntityComponentType[] supportedComponents)
	{
		numSupportedComponents = 0u;
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_EnumerateSupportedComponents(ref space, (uint)supportedComponents.Length, out numSupportedComponents, supportedComponents) == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntityQuerySpatialEntity(SpatialEntityQueryInfo queryInfo, ref ulong requestId)
	{
		if (version >= OVRP_1_67_0.version)
		{
			return OVRP_1_67_0.ovrp_QuerySpatialEntity(ref queryInfo, out requestId) == Result.Success;
		}
		return false;
	}

	[Obsolete("Deprecated. This function will not be supported in OpenXR", false)]
	public static bool SpatialEntityTerminateSpatialEntityQuery(ref ulong requestId)
	{
		return false;
	}

	public static bool SpatialEntitySaveSpatialEntity(ref ulong space, SpatialEntityStorageLocation location, SpatialEntityStoragePersistenceMode mode, ref ulong requestId)
	{
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_SaveSpatialEntity(ref space, location, mode, out requestId) == Result.Success;
		}
		return false;
	}

	public static bool SpatialEntityEraseSpatialEntity(ref ulong space, SpatialEntityStorageLocation location, ref ulong requestId)
	{
		if (version >= OVRP_1_63_0.version)
		{
			return OVRP_1_63_0.ovrp_EraseSpatialEntity(ref space, location, out requestId) == Result.Success;
		}
		return false;
	}

	public static Posef LocateSpace(ref ulong space, TrackingOrigin baseOrigin)
	{
		if (version >= OVRP_1_64_0.version)
		{
			Posef location = Posef.identity;
			if (OVRP_1_64_0.ovrp_LocateSpace(ref location, ref space, baseOrigin) == Result.Success)
			{
				return location;
			}
			return Posef.identity;
		}
		return Posef.identity;
	}

	public static bool DestroySpace(ref ulong space)
	{
		if (version >= OVRP_1_65_0.version)
		{
			return OVRP_1_65_0.ovrp_DestroySpace(ref space) == Result.Success;
		}
		return false;
	}

	public static string[] GetRenderModelPaths()
	{
		if (version >= OVRP_1_68_0.version)
		{
			uint num = 0u;
			List<string> list = new List<string>();
			IntPtr intPtr;
			for (intPtr = Marshal.AllocHGlobal(256); OVRP_1_68_0.ovrp_GetRenderModelPaths(num, intPtr) == Result.Success; num++)
			{
				list.Add(Marshal.PtrToStringAnsi(intPtr));
			}
			Marshal.FreeHGlobal(intPtr);
			return list.ToArray();
		}
		return null;
	}

	public static bool GetRenderModelProperties(string modelPath, ref RenderModelProperties modelProperties)
	{
		if (version >= OVRP_1_68_0.version)
		{
			if (OVRP_1_68_0.ovrp_GetRenderModelProperties(modelPath, out var properties) != Result.Success)
			{
				return false;
			}
			modelProperties.ModelName = Encoding.Default.GetString(properties.ModelName);
			modelProperties.ModelKey = properties.ModelKey;
			modelProperties.VendorId = properties.VendorId;
			modelProperties.ModelVersion = properties.ModelVersion;
			return true;
		}
		return false;
	}

	public static byte[] LoadRenderModel(ulong modelKey)
	{
		if (version >= OVRP_1_68_0.version)
		{
			uint bufferCountOutput = 0u;
			if (OVRP_1_68_0.ovrp_LoadRenderModel(modelKey, 0u, ref bufferCountOutput, IntPtr.Zero) != Result.Success)
			{
				return null;
			}
			if (bufferCountOutput == 0)
			{
				return null;
			}
			IntPtr intPtr = Marshal.AllocHGlobal((int)bufferCountOutput);
			if (OVRP_1_68_0.ovrp_LoadRenderModel(modelKey, bufferCountOutput, ref bufferCountOutput, intPtr) != Result.Success)
			{
				Marshal.FreeHGlobal(intPtr);
				return null;
			}
			byte[] array = new byte[bufferCountOutput];
			Marshal.Copy(intPtr, array, 0, (int)bufferCountOutput);
			Marshal.FreeHGlobal(intPtr);
			return array;
		}
		return null;
	}
}
