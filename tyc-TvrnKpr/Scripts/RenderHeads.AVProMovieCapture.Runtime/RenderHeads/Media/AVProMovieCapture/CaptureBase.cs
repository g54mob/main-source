using System;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class CaptureBase : MonoBehaviour
	{
		public enum Resolution
		{
			POW2_8192x8192 = 0,
			POW2_8192x4096 = 1,
			POW2_4096x4096 = 2,
			POW2_4096x2048 = 3,
			POW2_2048x4096 = 4,
			UHD_3840x2160 = 5,
			UHD_3840x2048 = 6,
			UHD_3840x1920 = 7,
			UHD_2560x1440 = 8,
			POW2_2048x2048 = 9,
			POW2_2048x1024 = 10,
			HD_1920x1080 = 11,
			HD_1280x720 = 12,
			SD_1024x768 = 13,
			SD_800x600 = 14,
			SD_800x450 = 15,
			SD_640x480 = 16,
			SD_640x360 = 17,
			SD_320x240 = 18,
			Original = 19,
			Custom = 20
		}

		public enum CubemapDepth
		{
			Depth_24 = 24,
			Depth_16 = 16,
			Depth_Zero = 0
		}

		public enum CubemapResolution
		{
			POW2_8192 = 8192,
			POW2_4096 = 4096,
			POW2_2048 = 2048,
			POW2_1024 = 1024,
			POW2_512 = 512,
			POW2_256 = 256
		}

		public enum AntiAliasingLevel
		{
			UseCurrent = 0,
			ForceNone = 1,
			ForceSample2 = 2,
			ForceSample4 = 3,
			ForceSample8 = 4
		}

		public enum DownScale
		{
			Original = 1,
			Half = 2,
			Quarter = 4,
			Eighth = 8,
			Sixteenth = 16,
			Custom = 100
		}

		public enum OutputPath
		{
			RelativeToProject = 0,
			RelativeToPersistentData = 1,
			Absolute = 2,
			RelativeToDesktop = 3,
			RelativeToPictures = 4,
			RelativeToVideos = 5,
			PhotoLibrary = 6,
			RelativeToTemporaryCachePath = 7,
			[Obsolete("Use RelativeToPersistentData")]
			RelativeToPeristentData = 1
		}

		public enum FrameUpdateMode
		{
			Automatic = 0,
			Manual = 1
		}

		public enum AudioCaptureDeviceAuthorisationStatus
		{
			Unavailable = -1,
			NotDetermined = 0,
			Denied = 1,
			Authorised = 2
		}

		public enum PhotoLibraryAccessLevel
		{
			AddOnly = 0,
			ReadWrite = 1
		}

		public enum PhotoLibraryAuthorisationStatus
		{
			Unavailable = -1,
			NotDetermined = 0,
			Denied = 1,
			Authorised = 2
		}

		private const string DocEditionsURL = "https://www.renderheads.com/content/docs/AVProMovieCapture/articles/download.html#editions";

		[SerializeField]
		private EncoderHints _encoderHintsWindows;

		[SerializeField]
		private EncoderHints _encoderHintsMacOS;

		[SerializeField]
		private EncoderHints _encoderHintsIOS;

		[SerializeField]
		private EncoderHints _encoderHintsAndroid;

		[SerializeField]
		private KeyCode _captureKey;

		[SerializeField]
		private bool _isRealTime;

		[SerializeField]
		private bool _persistAcrossSceneLoads;

		[SerializeField]
		private StartTriggerMode _startTrigger;

		[SerializeField]
		private StartDelayMode _startDelay;

		[SerializeField]
		private float _startDelaySeconds;

		[SerializeField]
		private StopMode _stopMode;

		[SerializeField]
		private int _stopFrames;

		[SerializeField]
		private float _stopSeconds;

		[SerializeField]
		private bool _pauseCaptureOnAppPause;

		public static readonly string[] DefaultVideoCodecPriorityWindows;

		public static readonly string[] DefaultVideoCodecPriorityMacOS;

		public static readonly string[] DefaultVideoCodecPriorityAndroid;

		public static readonly string[] DefaultAudioCodecPriorityWindows;

		public static readonly string[] DefaultAudioCodecPriorityMacOS;

		public static readonly string[] DefaultAudioCodecPriorityIOS;

		public static readonly string[] DefaultAudioCodecPriorityAndroid;

		public static readonly string[] DefaultAudioCaptureDevicePriorityWindow;

		public static readonly string[] DefaultAudioCaptureDevicePriorityMacOS;

		public static readonly string[] DefaultAudioCaptureDevicePriorityIOS;

		public static readonly string[] DefaultAudioCaptureDevicePriorityAndroid;

		[SerializeField]
		private string[] _videoCodecPriorityWindows;

		[SerializeField]
		private string[] _videoCodecPriorityMacOS;

		[SerializeField]
		private string[] _videoCodecPriorityAndroid;

		[SerializeField]
		private string[] _audioCodecPriorityWindows;

		[SerializeField]
		private string[] _audioCodecPriorityMacOS;

		[SerializeField]
		private string[] _audioCodecPriorityAndroid;

		[SerializeField]
		private float _frameRate;

		[Tooltip("Timelapse scale makes the frame capture run at a fraction of the target frame rate.  Default value is 1")]
		[SerializeField]
		private int _timelapseScale;

		[Tooltip("Manual update mode requires user to call FrameUpdate() each time a frame is ready")]
		[SerializeField]
		private FrameUpdateMode _frameUpdateMode;

		[SerializeField]
		private DownScale _downScale;

		[SerializeField]
		private Vector2 _maxVideoSize;

		[SerializeField]
		[Range(-1f, 128f)]
		private int _forceVideoCodecIndexWindows;

		[SerializeField]
		[Range(-1f, 128f)]
		private int _forceVideoCodecIndexMacOS;

		[SerializeField]
		[Range(0f, 128f)]
		private int _forceVideoCodecIndexIOS;

		[SerializeField]
		[Range(0f, 128f)]
		private int _forceVideoCodecIndexAndroid;

		[SerializeField]
		[Range(-1f, 128f)]
		private int _forceAudioCodecIndexWindows;

		[SerializeField]
		[Range(-1f, 128f)]
		private int _forceAudioCodecIndexMacOS;

		[SerializeField]
		[Range(0f, 128f)]
		private int _forceAudioCodecIndexIOS;

		[SerializeField]
		[Range(0f, 128f)]
		private int _forceAudioCodecIndexAndroid;

		[SerializeField]
		private bool _flipVertically;

		[Tooltip("Flushing the GPU during each capture results in less latency, but can slow down rendering performance for complex scenes.")]
		[SerializeField]
		private bool _forceGpuFlush;

		[Tooltip("This option can help issues where skinning is used, or other animation/rendering effects that only complete later in the frame.")]
		[SerializeField]
		protected bool _useWaitForEndOfFrame;

		[Tooltip("Update the media gallery")]
		[SerializeField]
		protected bool _androidUpdateMediaGallery;

		[Tooltip("Portrait captures may be rotated 90° to better utilise the encoder, check this to disable the rotation at the risk of not being able to capture the full vertical resolution.")]
		[SerializeField]
		private bool _androidNoCaptureRotation;

		[SerializeField]
		private bool _iOSSaveCaptureWhenAppLosesFocus;

		[Tooltip("Log the start and stop of the capture.  Disable this for less garbage generation.")]
		[SerializeField]
		private bool _logCaptureStartStop;

		[SerializeField]
		private AudioCaptureSource _audioCaptureSource;

		[SerializeField]
		private UnityAudioCapture _unityAudioCapture;

		[SerializeField]
		[Range(0f, 32f)]
		private int _forceAudioInputDeviceIndex;

		[SerializeField]
		[Range(8000f, 96000f)]
		private int _manualAudioSampleRate;

		[SerializeField]
		[Range(1f, 8f)]
		private int _manualAudioChannelCount;

		[SerializeField]
		protected OutputTarget _outputTarget;

		public const OutputPath DefaultOutputFolderType = OutputPath.RelativeToProject;

		private const string DefaultOutputFolderPath = "Captures";

		[SerializeField]
		private OutputPath _outputFolderType;

		[SerializeField]
		private string _outputFolderPath;

		[SerializeField]
		private string _filenamePrefix;

		[SerializeField]
		private bool _appendFilenameTimestamp;

		[SerializeField]
		private bool _allowManualFileExtension;

		[SerializeField]
		private string _filenameExtension;

		[SerializeField]
		private string _namedPipePath;

		[SerializeField]
		private bool _writeOrientationMetadata;

		[SerializeField]
		private int _imageSequenceStartFrame;

		[SerializeField]
		[Range(2f, 12f)]
		private int _imageSequenceZeroDigits;

		[SerializeField]
		private ImageSequenceFormat _imageSequenceFormatWindows;

		[SerializeField]
		private ImageSequenceFormat _imageSequenceFormatMacOS;

		[SerializeField]
		private ImageSequenceFormat _imageSequenceFormatIOS;

		[SerializeField]
		private ImageSequenceFormat _imageSequenceFormatAndroid;

		[SerializeField]
		protected Resolution _renderResolution;

		[SerializeField]
		protected Vector2 _renderSize;

		[SerializeField]
		protected int _renderAntiAliasing;

		[SerializeField]
		protected bool _useMotionBlur;

		[SerializeField]
		[Range(0f, 64f)]
		protected int _motionBlurSamples;

		[SerializeField]
		protected Camera[] _motionBlurCameras;

		[SerializeField]
		protected MotionBlur _motionBlur;

		[SerializeField]
		private bool _allowVSyncDisable;

		[SerializeField]
		protected bool _supportTextureRecreate;

		[SerializeField]
		private int _minimumDiskSpaceMB;

		[SerializeField]
		private TimelineController _timelineController;

		[SerializeField]
		private VideoPlayerController _videoPlayerController;

		protected Texture2D _texture;

		protected int _handle;

		protected int _sourceWidth;

		protected int _sourceHeight;

		protected int _targetWidth;

		protected int _targetHeight;

		protected bool _capturing;

		protected bool _paused;

		protected string _filePath;

		protected string _finalFilePath;

		protected FileInfo _fileInfo;

		protected NativePlugin.PixelFormat _pixelFormat;

		private Codec _selectedVideoCodec;

		private Codec _selectedAudioCodec;

		private Device _selectedAudioInputDevice;

		private int _oldVSyncCount;

		private float _oldFixedDeltaTime;

		protected bool _isTopDown;

		protected bool _isDirectX11;

		private bool _queuedStartCapture;

		private bool _queuedStopCapture;

		private float _captureStartTime;

		private float _capturePrePauseTotalTime;

		private float _timeSinceLastFrame;

		protected YieldInstruction _waitForEndOfFrame;

		private long _freeDiskSpaceMB;

		protected Transparency _Transparency;

		protected RenderTexture _sideBySideTexture;

		protected Material _sideBySideMaterial;

		private float _startDelayTimer;

		private bool _startPaused;

		private Action<FileWritingHandler> _beginFinalFileWritingAction;

		private Action<FileWritingHandler> _completedFileWritingAction;

		private List<FileWritingHandler> _pendingFileWrites;

		private static HashSet<string> _activeFilePaths;

		private UnityEvent _onCaptureStart;

		private CaptureStats _stats;

		private static bool _isInitialised;

		private static bool _isApplicationQuiting;

		public KeyCode CaptureKey
		{
			get
			{
				return default(KeyCode);
			}
			set
			{
			}
		}

		public OutputTarget OutputTarget
		{
			get
			{
				return default(OutputTarget);
			}
			set
			{
			}
		}

		public OutputPath OutputFolder
		{
			get
			{
				return default(OutputPath);
			}
			set
			{
			}
		}

		public string OutputFolderPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string FilenamePrefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AppendFilenameTimestamp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowManualFileExtension
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string FilenameExtension
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string NamedPipePath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool WriteOrientationMetadata
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int ImageSequenceStartFrame
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ImageSequenceZeroDigits
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool UseMotionBlur
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int MotionBlurSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Camera[] MotionBlurCameras
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MotionBlur MotionBlur
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transparency Transparency => default(Transparency);

		public static HashSet<string> ActiveFilePaths => null;

		public string LastFilePath => null;

		public UnityEvent OnCaptureStart => null;

		public Action<FileWritingHandler> BeginFinalFileWritingAction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Action<FileWritingHandler> CompletedFileWritingAction
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Resolution CameraRenderResolution
		{
			get
			{
				return default(Resolution);
			}
			set
			{
			}
		}

		public Vector2 CameraRenderCustomResolution
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public int CameraRenderAntiAliasing
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsRealTime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PersistAcrossSceneLoads
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AudioCaptureSource AudioCaptureSource
		{
			get
			{
				return default(AudioCaptureSource);
			}
			set
			{
			}
		}

		public int ManualAudioSampleRate
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ManualAudioChannelCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public UnityAudioCapture UnityAudioCapture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int ForceAudioInputDeviceIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float FrameRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public StartTriggerMode StartTrigger
		{
			get
			{
				return default(StartTriggerMode);
			}
			set
			{
			}
		}

		public StartDelayMode StartDelay
		{
			get
			{
				return default(StartDelayMode);
			}
			set
			{
			}
		}

		public float StartDelaySeconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public StopMode StopMode
		{
			get
			{
				return default(StopMode);
			}
			set
			{
			}
		}

		public int StopAfterFramesElapsed
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float StopAfterSecondsElapsed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool PauseCaptureOnAppPause
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CaptureStats CaptureStats => null;

		public string[] VideoCodecPriorityWindows
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] VideoCodecPriorityMacOS
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] AudioCodecPriorityWindows
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] AudioCodecPriorityMacOS
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int TimelapseScale
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public FrameUpdateMode FrameUpdate
		{
			get
			{
				return default(FrameUpdateMode);
			}
			set
			{
			}
		}

		public DownScale ResolutionDownScale
		{
			get
			{
				return default(DownScale);
			}
			set
			{
			}
		}

		public Vector2 ResolutionDownscaleCustom
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool FlipVertically
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseWaitForEndOfFrame
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LogCaptureStartStop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowOfflineVSyncDisable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SupportTextureRecreate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TimelineController TimelineController
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public VideoPlayerController VideoPlayerController
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Codec SelectedVideoCodec => null;

		public Codec SelectedAudioCodec => null;

		public Device SelectedAudioInputDevice => null;

		public int NativeForceVideoCodecIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int NativeForceAudioCodecIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ImageSequenceFormat NativeImageSequenceFormat
		{
			get
			{
				return default(ImageSequenceFormat);
			}
			set
			{
			}
		}

		public static string LastFileSaved
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected static NativePlugin.Platform GetCurrentPlatform()
		{
			return default(NativePlugin.Platform);
		}

		public EncoderHints GetEncoderHints(NativePlugin.Platform platform = NativePlugin.Platform.Current)
		{
			return null;
		}

		public void SetEncoderHints(EncoderHints hints, NativePlugin.Platform platform = NativePlugin.Platform.Current)
		{
		}

		public static void UpdateMediaGallery(string videoFilePath)
		{
		}

		protected virtual void Awake()
		{
		}

		static CaptureBase()
		{
		}

		public virtual void Start()
		{
		}

		private static bool SelectCodec(ref Codec codec, CodecList codecList, int forceCodecIndex, string[] codecPriorityList, MediaApi matchMediaApi, bool allowFallbackToFirstCodec, bool logFallbackWarning)
		{
			return false;
		}

		public Codec SelectVideoCodec(bool isStartingCapture = false)
		{
			return null;
		}

		public Codec SelectAudioCodec()
		{
			return null;
		}

		public Device SelectAudioInputDevice()
		{
			return null;
		}

		public static Vector2 GetRecordingResolution(int width, int height, DownScale downscale, Vector2 maxVideoSize)
		{
			return default(Vector2);
		}

		public void SelectRecordingResolution(int width, int height)
		{
		}

		public virtual void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void FreePendingFileWrites()
		{
		}

		private void OnApplicationQuit()
		{
		}

		protected void EncodeTexture(Texture2D texture)
		{
		}

		protected bool IsUsingUnityAudioComponent()
		{
			return false;
		}

		protected bool IsUsingMotionBlur()
		{
			return false;
		}

		public virtual void EncodePointer(IntPtr ptr)
		{
		}

		public bool IsPrepared()
		{
			return false;
		}

		public bool IsCapturing()
		{
			return false;
		}

		public bool IsPaused()
		{
			return false;
		}

		public int GetRecordingWidth()
		{
			return 0;
		}

		public int GetRecordingHeight()
		{
			return 0;
		}

		protected virtual string GenerateTimestampedFilename(string filenamePrefix, string filenameExtension)
		{
			return null;
		}

		private static string GetFolder(OutputPath outputPathType, string path)
		{
			return null;
		}

		private static string GenerateFilePath(OutputPath outputPathType, string path, string filename)
		{
			return null;
		}

		protected static bool HasExtension(string path, string extension)
		{
			return false;
		}

		protected void GenerateFilename()
		{
		}

		public UnityAudioCapture FindOrCreateUnityAudioCapture(bool logWarnings)
		{
			return null;
		}

		private bool ValidateEditionFeatures()
		{
			return false;
		}

		public virtual bool PrepareCapture()
		{
			return false;
		}

		public void QueueStartCapture()
		{
		}

		public bool IsStartCaptureQueued()
		{
			return false;
		}

		protected void UpdateInjectionOptions(StereoPacking stereoPacking, SphericalVideoLayout sphericalVideoLayout)
		{
		}

		public bool StartCapture()
		{
			return false;
		}

		public void PauseCapture()
		{
		}

		public void ResumeCapture()
		{
		}

		public void CancelCapture()
		{
		}

		public static void DeleteCapture(OutputTarget outputTarget, string path)
		{
		}

		public virtual void UnprepareCapture()
		{
		}

		protected void RenderThreadEvent(NativePlugin.PluginEvent renderEvent)
		{
		}

		public virtual void StopCapture(bool skipPendingFrames = false, bool ignorePendingFileWrites = false, bool deleteCapture = false)
		{
		}

		private static MP4FileProcessing.Options CreatePostOperationsOptions(VideoEncoderHints hints, string finalFilePath)
		{
			return default(MP4FileProcessing.Options);
		}

		private static bool CanApplyPostOperations(string filePath, VideoEncoderHints hints, string finalFilePath)
		{
			return false;
		}

		protected void ApplyPostOperations(string filePath, VideoEncoderHints hints, string finalFilePath)
		{
		}

		private void ToggleCapture()
		{
		}

		private bool IsEnoughDiskSpace()
		{
			return false;
		}

		protected bool CanContinue()
		{
			return false;
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void RemoveCompletedFileWrites()
		{
		}

		private void CheckFreeDiskSpace()
		{
		}

		protected bool IsStartDelayComplete()
		{
			return false;
		}

		protected bool IsStopTimeReached()
		{
			return false;
		}

		public float GetProgress()
		{
			return 0f;
		}

		protected float GetSecondsPerCaptureFrame()
		{
			return 0f;
		}

		protected bool CanOutputFrame()
		{
			return false;
		}

		protected void TickFrameTimer()
		{
		}

		protected void RenormTimer()
		{
		}

		public virtual Texture GetPreviewTexture()
		{
			return null;
		}

		public virtual Texture GetSideBySideTexture()
		{
			return null;
		}

		protected void EncodeUnityAudio()
		{
		}

		public void EncodeAudio(NativeArray<float> audioData)
		{
		}

		public void EncodeAudio(float[] audioData)
		{
		}

		public virtual void PreUpdateFrame()
		{
		}

		public virtual void UpdateFrame()
		{
		}

		protected bool InitialiseSideBySideTransparency(int width, int height, bool screenFlip = false, int antiAliasing = 1)
		{
			return false;
		}

		protected RenderTexture UpdateForSideBySideTransparency(Texture sourceTexture, bool screenFlip = false, int antiAliasing = 1)
		{
			return null;
		}

		protected void ResetFPS()
		{
		}

		public void UpdateFPS()
		{
		}

		protected int GetCameraAntiAliasingLevel(Camera camera)
		{
			return 0;
		}

		public long GetCaptureFileSize()
		{
			return 0L;
		}

		public static void GetResolution(Resolution res, ref int width, ref int height)
		{
		}

		protected static int NextMultipleOf4(int value)
		{
			return 0;
		}

		public void SetMicrophoneRecordingHint(bool enabled, MicrophoneRecordingOptions options = MicrophoneRecordingOptions.Defaults)
		{
		}
	}
}
