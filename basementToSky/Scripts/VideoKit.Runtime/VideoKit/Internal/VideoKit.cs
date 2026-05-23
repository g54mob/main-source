using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Muna;

namespace VideoKit.Internal
{
	public static class VideoKit
	{
		[Flags]
		public enum MediaDeviceFlags
		{
			Internal = 1,
			External = 2,
			Default = 8,
			EchoCancellation = 4,
			FrontFacing = 0x40,
			Flash = 0x80,
			Torch = 0x100,
			Depth = 0x8000,
			ExposureContinuous = 0x10000,
			ExposureLock = 0x800,
			ExposureManual = 0x4000,
			ExposurePoint = 0x200,
			FocusContinuous = 0x20000,
			FocusLock = 0x1000,
			FocusPoint = 0x400,
			WhiteBalanceContinuous = 0x40000,
			WhiteBalanceLock = 0x2000,
			VideoStabilization = 0x80000
		}

		public enum PermissionType
		{
			Microphone = 1,
			Camera = 2
		}

		public enum Status
		{
			Ok = 0,
			InvalidArgument = 1,
			InvalidOperation = 2,
			NotImplemented = 3,
			InvalidSession = 101,
			InvalidPlan = 104
		}

		public delegate void SampleBufferHandler(IntPtr context, IntPtr sampleBuffer);

		public delegate void MediaAssetHandler(IntPtr context, IntPtr asset);

		public delegate void MediaAssetShareHandler(IntPtr context, IntPtr receiver);

		public delegate void MediaDeviceDiscoveryHandler(IntPtr context, IntPtr devices, int count);

		public delegate void MediaDeviceDisconnectHandler(IntPtr context, IntPtr device);

		public delegate void MediaDevicePermissionResultHandler(IntPtr context, MediaDevice.PermissionStatus result);

		public delegate void MultiCameraDeviceSystemPressureHandler(IntPtr context);

		public const string Assembly = "VideoKit";

		public static bool IsAppDomainLoaded => true;

		[DllImport("VideoKit", EntryPoint = "VKTSessionGetIdentifier")]
		public static extern Status GetSessionIdentifier([MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder dest, int size);

		[DllImport("VideoKit", EntryPoint = "VKTSessionSetToken")]
		public static extern Status SetSessionToken([MarshalAs(UnmanagedType.LPUTF8Str)] string? token);

		[DllImport("VideoKit", EntryPoint = "VKTSampleBufferRelease")]
		public static extern Status ReleaseSampleBuffer(this IntPtr sampleBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTSampleBufferGetTimestamp")]
		public static extern Status GetSampleBufferTimestamp(this IntPtr audioBuffer, out long timestamp);

		[DllImport("VideoKit", EntryPoint = "VKTSampleBufferGetCurrentTimestamp")]
		public static extern Status GetCurrentTimestamp(out long timestamp);

		[DllImport("VideoKit", EntryPoint = "VKTAudioBufferCreate")]
		public unsafe static extern Status CreateAudioBuffer(int sampleRate, int channelCount, float* data, int sampleCount, long timestamp, out IntPtr audioBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTAudioBufferGetData")]
		public unsafe static extern Status GetAudioBufferData(this IntPtr audioBuffer, out float* data);

		[DllImport("VideoKit", EntryPoint = "VKTAudioBufferGetSampleCount")]
		public static extern Status GetAudioBufferSampleCount(this IntPtr audioBuffer, out int sampleCount);

		[DllImport("VideoKit", EntryPoint = "VKTAudioBufferGetSampleRate")]
		public static extern Status GetAudioBufferSampleRate(this IntPtr audioBuffer, out int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTAudioBufferGetChannelCount")]
		public static extern Status GetAudioBufferChannelCount(this IntPtr audioBuffer, out int channelCount);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferCreate")]
		public unsafe static extern Status CreatePixelBuffer(int width, int height, PixelBuffer.Format format, byte* data, int rowStride, long timestamp, [MarshalAs(UnmanagedType.I1)] bool mirrored, out IntPtr pixelBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferCreatePlanar")]
		public static extern Status CreatePlanarPixelBuffer(int width, int height, PixelBuffer.Format format, int planeCount, [In] IntPtr[] planeData, [In] int[] planeWidth, [In] int[] planeHeight, [In] int[] planeRowStride, [In] int[] planePixelStride, long timestamp, [MarshalAs(UnmanagedType.I1)] bool mirrored, out IntPtr pixelBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetData")]
		public unsafe static extern Status GetPixelBufferData(this IntPtr pixelBuffer, out byte* data);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetDataSize")]
		public static extern Status GetPixelBufferDataSize(this IntPtr pixelBuffer, out int size);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetFormat")]
		public static extern Status GetPixelBufferFormat(this IntPtr pixelBuffer, out PixelBuffer.Format format);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetWidth")]
		public static extern Status GetPixelBufferWidth(this IntPtr pixelBuffer, out int width);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetHeight")]
		public static extern Status GetPixelBufferHeight(this IntPtr pixelBuffer, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetRowStride")]
		public static extern Status GetPixelBufferRowStride(this IntPtr pixelBuffer, out int rowStride);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferIsVerticallyMirrored")]
		public static extern Status GetPixelBufferIsVerticallyMirrored(this IntPtr pixelBuffer, [MarshalAs(UnmanagedType.I1)] out bool mirrored);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneCount")]
		public static extern Status GetPixelBufferPlaneCount(this IntPtr pixelBuffer, out int planeCount);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneData")]
		public unsafe static extern Status GetPixelBufferPlaneData(this IntPtr pixelBuffer, int planeIdx, out byte* planeData);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneDataSize")]
		public static extern Status GetPixelBufferPlaneDataSize(this IntPtr pixelBuffer, int planeIdx, out int dataSize);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneWidth")]
		public static extern Status GetPixelBufferPlaneWidth(this IntPtr pixelBuffer, int planeIdx, out int width);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneHeight")]
		public static extern Status GetPixelBufferPlaneHeight(this IntPtr pixelBuffer, int planeIdx, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlanePixelStride")]
		public static extern Status GetPixelBufferPlanePixelStride(this IntPtr pixelBuffer, int planeIdx, out int pixelStride);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferGetPlaneRowStride")]
		public static extern Status GetPixelBufferPlaneRowStride(this IntPtr pixelBuffer, int planeIdx, out int rowStride);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferCopyMetadata")]
		public static extern Status CopyPixelBufferMetadata(this IntPtr pixelBuffer, [MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder dest, int size);

		[DllImport("VideoKit", EntryPoint = "VKTPixelBufferCopyTo")]
		public static extern Status CopyToPixelBuffer(this IntPtr source, IntPtr destination, PixelBuffer.Rotation rotation);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetCreate")]
		public static extern Status CreateMediaAsset([MarshalAs(UnmanagedType.LPUTF8Str)] string path, MediaAssetHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetCreateFromCameraRoll")]
		public static extern Status CreateMediaAssetFromCameraRoll(MediaAsset.MediaType type, MediaAssetHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetRelease")]
		public static extern Status ReleaseMediaAsset(this IntPtr asset);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetPath")]
		public static extern Status GetMediaAssetPath(this IntPtr asset, [MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder path, int size);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetMediaType")]
		public static extern Status GetMediaAssetMediaType(this IntPtr asset, out MediaAsset.MediaType type);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetWidth")]
		public static extern Status GetMediaAssetWidth(this IntPtr asset, out int width);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetHeight")]
		public static extern Status GetMediaAssetHeight(this IntPtr asset, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetFrameRate")]
		public static extern Status GetMediaAssetFrameRate(this IntPtr asset, out float frameRate);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetSampleRate")]
		public static extern Status GetMediaAssetSampleRate(this IntPtr asset, out int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetChannelCount")]
		public static extern Status GetMediaAssetChannelCount(this IntPtr asset, out int channelCount);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetDuration")]
		public static extern Status GetMediaAssetDuration(this IntPtr asset, out float duration);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetSubAssetCount")]
		public static extern Status GetMediaAssetSubAssetCount(this IntPtr asset, out int count);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetGetSubAsset")]
		public static extern Status GetMediaAssetSubAsset(this IntPtr asset, int index, out IntPtr subAsset);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetShare")]
		public static extern Status ShareMediaAsset(this IntPtr asset, [MarshalAs(UnmanagedType.LPUTF8Str)] string? message, MediaAssetShareHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaAssetSaveToCameraRoll")]
		public static extern Status SaveMediaAssetToCameraRoll(this IntPtr asset, [MarshalAs(UnmanagedType.LPUTF8Str)] string? album, MediaAssetShareHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaReaderCreate")]
		public static extern Status CreateMediaReader(this IntPtr asset, MediaAsset.MediaType type, out IntPtr reader);

		[DllImport("VideoKit", EntryPoint = "VKTMediaReaderRelease")]
		public static extern Status ReleaseMediaReader(this IntPtr reader);

		[DllImport("VideoKit", EntryPoint = "VKTMediaReaderReadNextSampleBuffer")]
		public static extern Status ReadNextSampleBuffer(this IntPtr reader, out IntPtr sampleBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderIsFormatSupported")]
		public static extern Status IsMediaRecorderFormatSupported(MediaRecorder.Format format);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderGetFormat")]
		public static extern Status GetMediaRecorderFormat(this IntPtr recorder, out MediaRecorder.Format format);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderGetWidth")]
		public static extern Status GetMediaRecorderWidth(this IntPtr recorder, out int width);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderGetHeight")]
		public static extern Status GetMediaRecorderHeight(this IntPtr recorder, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderGetSampleRate")]
		public static extern Status GetMediaRecorderSampleRate(this IntPtr recorder, out int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderGetChannelCount")]
		public static extern Status GetMediaRecorderChannelCount(this IntPtr recorder, out int channelCount);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCanAppendPixelBuffer")]
		public static extern Status CanAppendPixelBuffer(this IntPtr recorder, out bool result);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderAppendPixelBuffer")]
		public static extern Status AppendPixelBuffer(this IntPtr recorder, IntPtr pixelBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCanAppendAudioBuffer")]
		public static extern Status CanAppendAudioBuffer(this IntPtr recorder, out bool result);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderAppendAudioBuffer")]
		public static extern Status AppendSampleBuffer(this IntPtr recorder, IntPtr audioBuffer);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderFinishWriting")]
		public static extern Status FinishWriting(this IntPtr recorder, MediaAssetHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateMP4")]
		public static extern Status CreateMP4Recorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitrate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateHEVC")]
		public static extern Status CreateHEVCRecorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitRate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateGIF")]
		public static extern Status CreateGIFRecorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float delay, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateWAV")]
		public static extern Status CreateWAVRecorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int sampleRate, int channelCount, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateWEBM")]
		public static extern Status CreateWEBMRecorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitRate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateJPEG")]
		public static extern Status CreateJPEGRecorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float quality, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateAV1")]
		public static extern Status CreateAV1Recorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitrate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaRecorderCreateProRes4444")]
		public static extern Status CreateProRes4444Recorder([MarshalAs(UnmanagedType.LPUTF8Str)] string path, int width, int height, int sampleRate, int channelCount, int audioBitRate, out IntPtr recorder);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceRelease")]
		public static extern Status ReleaseMediaDevice(this IntPtr device);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceGetUniqueID")]
		public static extern Status GetMediaDeviceUniqueID(this IntPtr device, [MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder dest, int size);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceGetName")]
		public static extern Status GetMediaDeviceName(this IntPtr device, [MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder dest, int size);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceGetFlags")]
		public static extern Status GetMediaDeviceFlags(this IntPtr device, out MediaDeviceFlags flags);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceIsRunning")]
		public static extern Status GetMediaDeviceIsRunning(this IntPtr device, [MarshalAs(UnmanagedType.I1)] out bool running);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceStartRunning")]
		public static extern Status StartRunning(this IntPtr device, SampleBufferHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceStopRunning")]
		public static extern Status StopRunning(this IntPtr device);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceSetDisconnectHandler")]
		public static extern Status SetDisconnectHandler(this IntPtr device, MediaDeviceDisconnectHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMediaDeviceCheckPermissions")]
		public static extern Status CheckPermissions(PermissionType type, bool request, MediaDevicePermissionResultHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceDiscoverDevices")]
		public static extern Status DiscoverAudioDevices(MediaDeviceDiscoveryHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceGetEchoCancellation")]
		public static extern Status GetAudioDeviceEchoCancellation(this IntPtr audioDevice, [MarshalAs(UnmanagedType.I1)] out bool echoCancellation);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceSetEchoCancellation")]
		public static extern Status SetAudioDeviceEchoCancellation(this IntPtr audioDevice, [MarshalAs(UnmanagedType.I1)] bool mode);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceGetSampleRate")]
		public static extern Status GetAudioDeviceSampleRate(this IntPtr audioDevice, out int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceSetSampleRate")]
		public static extern Status SetAudioDeviceSampleRate(this IntPtr audioDevice, int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceGetChannelCount")]
		public static extern Status GetAudioDeviceChannelCount(this IntPtr audioDevice, out int channelCount);

		[DllImport("VideoKit", EntryPoint = "VKTAudioDeviceSetChannelCount")]
		public static extern Status SetAudioDeviceChannelCount(this IntPtr audioDevice, int sampleRate);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceDiscoverDevices")]
		public static extern Status DiscoverCameraDevices(MediaDeviceDiscoveryHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetFieldOfView")]
		public static extern Status GetCameraDeviceFieldOfView(this IntPtr camera, out float x, out float y);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetExposureBiasRange")]
		public static extern Status GetCameraDeviceExposureBiasRange(this IntPtr camera, out float min, out float max);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetExposureDurationRange")]
		public static extern Status GetCameraDeviceExposureDurationRange(this IntPtr camera, out float min, out float max);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetISORange")]
		public static extern Status GetCameraDeviceISORange(this IntPtr device, out float min, out float max);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetZoomRange")]
		public static extern Status GetCameraDeviceZoomRange(this IntPtr camera, out float min, out float max);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetPreviewResolution")]
		public static extern Status GetCameraDevicePreviewResolution(this IntPtr camera, out int width, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetPreviewResolution")]
		public static extern Status SetCameraDevicePreviewResolution(this IntPtr camera, int width, int height);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetPhotoResolution")]
		public static extern Status GetCameraDevicePhotoResolution(this IntPtr camera, out int width, out int height);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetPhotoResolution")]
		public static extern Status SetCameraDevicePhotoResolution(this IntPtr camera, int width, int height);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetFrameRate")]
		public static extern Status GetCameraDeviceFrameRate(this IntPtr camera, out float frameRate);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetFrameRate")]
		public static extern Status SetCameraDeviceFrameRate(this IntPtr camera, float frameRate);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetExposureMode")]
		public static extern Status GetCameraDeviceExposureMode(this IntPtr camera, out CameraDevice.ExposureMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetExposureMode")]
		public static extern Status SetCameraDeviceExposureMode(this IntPtr camera, CameraDevice.ExposureMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetExposureBias")]
		public static extern Status GetCameraDeviceExposureBias(this IntPtr camera, out float bias);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetExposureBias")]
		public static extern Status SetCameraDeviceExposureBias(this IntPtr camera, float bias);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetExposureDuration")]
		public static extern Status GetCameraDeviceExposureDuration(this IntPtr camera, out float duration);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetISO")]
		public static extern Status GetCameraDeviceISO(this IntPtr camera, out float ISO);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetExposureDuration")]
		public static extern Status SetCameraDeviceExposureDuration(this IntPtr camera, float duration, float ISO);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetExposurePoint")]
		public static extern Status SetCameraDeviceExposurePoint(this IntPtr camera, float x, float y);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetFlashMode")]
		public static extern Status GetCameraDeviceFlashMode(this IntPtr camera, out CameraDevice.FlashMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetFlashMode")]
		public static extern Status SetCameraDeviceFlashMode(this IntPtr camera, CameraDevice.FlashMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetFocusMode")]
		public static extern Status GetCameraDeviceFocusMode(this IntPtr camera, out CameraDevice.FocusMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetFocusMode")]
		public static extern Status SetCameraDeviceFocusMode(this IntPtr camera, CameraDevice.FocusMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetFocusPoint")]
		public static extern Status SetCameraDeviceFocusPoint(this IntPtr camera, float x, float y);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetTorchMode")]
		public static extern Status GetCameraDeviceTorchMode(this IntPtr camera, out CameraDevice.TorchMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetTorchMode")]
		public static extern Status SetCameraDeviceTorchMode(this IntPtr camera, CameraDevice.TorchMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetWhiteBalanceMode")]
		public static extern Status GetCameraDeviceWhiteBalanceMode(this IntPtr camera, out CameraDevice.WhiteBalanceMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetWhiteBalanceMode")]
		public static extern Status SetCameraDeviceWhiteBalanceMode(this IntPtr camera, CameraDevice.WhiteBalanceMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetVideoStabilizationMode")]
		public static extern Status GetCameraDeviceVideoStabilizationMode(this IntPtr camera, out CameraDevice.VideoStabilizationMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetVideoStabilizationMode")]
		public static extern Status SetCameraDeviceVideoStabilizationMode(this IntPtr camera, CameraDevice.VideoStabilizationMode mode);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceGetZoomRatio")]
		public static extern Status GetCameraDeviceZoomRatio(this IntPtr camera, out float zoom);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceSetZoomRatio")]
		public static extern Status SetCameraDeviceZoomRatio(this IntPtr camera, float ratio);

		[DllImport("VideoKit", EntryPoint = "VKTCameraDeviceCapturePhoto")]
		public static extern Status CapturePhoto(this IntPtr camera, SampleBufferHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceDiscoverDevices")]
		public static extern Status DiscoverMultiCameraDevices(MediaDeviceDiscoveryHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceGetCameraDeviceCount")]
		public static extern Status GetMultiCameraDeviceCameraCount(this IntPtr device, out int count);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceGetCameraDevice")]
		public static extern Status GetMultiCameraDeviceCamera(this IntPtr device, int index, out IntPtr camera);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceIsCameraDeviceRunning")]
		public static extern Status GetMultiCameraDeviceIsRunning(this IntPtr device, IntPtr camera, out bool running);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceStartCameraDevice")]
		public static extern Status StartRunning(this IntPtr device, IntPtr camera);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceStopCameraDevice")]
		public static extern Status StopRunning(this IntPtr device, IntPtr camera);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceGetHardwareCost")]
		public static extern Status GetMultiCameraDeviceHardwareCost(this IntPtr device, out float cost);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceGetSystemPressureCost")]
		public static extern Status GetMultiCameraDeviceSystemPressureCost(this IntPtr device, out float cost);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraDeviceSetSystemPressureChangeHandler")]
		public static extern Status SetMultiCameraDeviceSystemPressureChangeHandler(this IntPtr device, MultiCameraDeviceSystemPressureHandler handler, IntPtr context);

		[DllImport("VideoKit", EntryPoint = "VKTMultiCameraPixelBufferGetCameraDevice")]
		public static extern Status GetMultiCameraPixelBufferCamera(this IntPtr pixelBuffer, out IntPtr camera);

		[DllImport("VideoKit", EntryPoint = "VKTGetVersion")]
		public static extern IntPtr GetVersion();

		public static void ConfigureAudioSession()
		{
		}

		public static Status Throw(this Status status)
		{
			return status switch
			{
				Status.Ok => status, 
				Status.InvalidArgument => throw new ArgumentException(), 
				Status.InvalidOperation => throw new InvalidOperationException(), 
				Status.NotImplemented => throw new NotImplementedException(), 
				Status.InvalidSession => throw new InvalidOperationException("VideoKit session token is invalid. Get your VideoKit access key at https://videokit.ai"), 
				Status.InvalidPlan => throw new InvalidOperationException("VideoKit plan does not support this operation. Check your plan and upgrade at https://videokit.ai"), 
				_ => throw new InvalidOperationException(), 
			};
		}

		public static async Task<Prediction> Throw(this Task<Prediction> task)
		{
			Prediction prediction = await task;
			if (!string.IsNullOrEmpty(prediction.error))
			{
				throw new InvalidOperationException(prediction.error);
			}
			return prediction;
		}
	}
}
