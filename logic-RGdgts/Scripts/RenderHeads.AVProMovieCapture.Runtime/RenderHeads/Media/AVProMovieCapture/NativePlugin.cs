using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class NativePlugin
	{
		public enum Platform
		{
			Unknown = -2,
			Current = -1,
			First = 0,
			Windows = 0,
			macOS = 1,
			iOS = 2,
			Android = 3,
			Count = 4
		}

		public enum PixelFormat
		{
			RGBA32 = 0,
			BGRA32 = 1,
			YCbCr422_YUY2 = 2,
			YCbCr422_UYVY = 3,
			YCbCr422_HDYC = 4
		}

		public enum PluginEvent
		{
			CaptureFrameBuffer = 0,
			FreeResources = 1,
			Setup = 2
		}

		[Flags]
		public enum MicrophoneRecordingOptions
		{
			None = 0,
			MixWithOthers = 1,
			DefaultToSpeaker = 2
		}

		public delegate void ErrorHandlerDelegate(int handle, int domain, int code, [In] string message);

		public const string ScriptVersion = "5.1.2";

		public const string ExpectedPluginVersion = "5.1.0";

		private const string PluginName = "AVProMovieCapture";

		public static string[] PlatformNames;

		public static readonly string[] VideoCodecNamesMacOS;

		public static readonly string[] AudioCodecNamesMacOS;

		public static readonly string[] VideoCodecNamesIOS;

		public static readonly string[] AudioCodecNamesIOS;

		public static readonly string[] VideoCodecNamesAndroid;

		public static readonly string[] AudioCodecNamesAndroid;

		public const int MaxRenderWidth = 16384;

		public const int MaxRenderHeight = 16384;

		private const int PluginID = 262340608;

		private static IntPtr _renderEventFunction;

		private static IntPtr _freeEventFunction;

		private static IntPtr RenderCaptureEventFunction => (IntPtr)0;

		private static IntPtr RenderFreeEventFunction => (IntPtr)0;

		[PreserveSig]
		public static extern IntPtr AddAmbisonicSourceInstance(int maxCoefficients);

		[PreserveSig]
		public static extern void RemoveAmbisonicSourceInstance(IntPtr instance);

		[PreserveSig]
		public static extern void UpdateAmbisonicWeights(IntPtr instance, float azimuth, float elevation, AmbisonicOrder order, AmbisonicChannelOrder channelOrder, float[] normalisationWeights);

		[PreserveSig]
		public static extern void EncodeMonoToAmbisonic(IntPtr instance, float[] inSamples, int inSamplesOffset, int inFrameCount, int inChannelCount, float[] outSamples, int outSamplesOffset, int outSamplesLength, AmbisonicOrder order);

		public static void RenderThreadEvent(PluginEvent renderEvent, int handle)
		{
		}

		[PreserveSig]
		private static extern IntPtr GetRenderEventFunc();

		[PreserveSig]
		private static extern IntPtr GetFreeResourcesEventFunc();

		[PreserveSig]
		public static extern bool Init();

		[PreserveSig]
		public static extern void Deinit();

		[PreserveSig]
		public static extern void SetMicrophoneRecordingHint(bool enabled, MicrophoneRecordingOptions options = MicrophoneRecordingOptions.None);

		public static string GetPluginVersionString()
		{
			return null;
		}

		[PreserveSig]
		public static extern bool IsTrialVersion();

		public static bool IsBasicEdition()
		{
			return false;
		}

		[PreserveSig]
		public static extern int GetVideoCodecCount();

		[PreserveSig]
		public static extern bool IsConfigureVideoCodecSupported(int codecIndex);

		[PreserveSig]
		public static extern MediaApi GetVideoCodecMediaApi(int codecIndex);

		[PreserveSig]
		public static extern void ConfigureVideoCodec(int codecIndex);

		public static string GetVideoCodecName(int codecIndex)
		{
			return null;
		}

		[PreserveSig]
		public static extern int GetAudioCodecCount();

		[PreserveSig]
		public static extern bool IsConfigureAudioCodecSupported(int codecIndex);

		[PreserveSig]
		public static extern MediaApi GetAudioCodecMediaApi(int codecIndex);

		[PreserveSig]
		public static extern void ConfigureAudioCodec(int codecIndex);

		public static string GetAudioCodecName(int codecIndex)
		{
			return null;
		}

		[PreserveSig]
		public static extern int GetAudioInputDeviceCount();

		public static string GetAudioInputDeviceName(int index)
		{
			return null;
		}

		[PreserveSig]
		public static extern MediaApi GetAudioInputDeviceMediaApi(int index);

		public static string[] GetContainerFileExtensions(int videoCodecIndex, int audioCodecIndex = -1)
		{
			return null;
		}

		[PreserveSig]
		public static extern int CreateRecorderVideo(string filename, uint width, uint height, float frameRate, int format, bool isRealTime, bool isTopDown, int videoCodecIndex, AudioCaptureSource audioSource, int audioSampleRate, int audioChannelCount, int audioInputDeviceIndex, int audioCodecIndex, bool forceGpuFlush, VideoEncoderHints hints);

		[PreserveSig]
		public static extern int CreateRecorderImages(string filename, uint width, uint height, float frameRate, int format, bool isRealTime, bool isTopDown, int imageFormatType, bool forceGpuFlush, int startFrame, ImageEncoderHints hints);

		[PreserveSig]
		public static extern int CreateRecorderPipe(string filename, uint width, uint height, float frameRate, int format, bool isTopDown, int transparencyMode, bool forceGpuFlush);

		[PreserveSig]
		public static extern bool Start(int handle);

		[PreserveSig]
		public static extern bool IsNewFrameDue(int handle);

		[PreserveSig]
		public static extern int SetEncodedFrameLimit(int handle, uint encodedFrameLimit);

		[PreserveSig]
		public static extern void EncodeFrame(int handle, IntPtr data);

		[PreserveSig]
		public static extern void EncodeAudio(int handle, IntPtr data, uint length);

		[PreserveSig]
		public static extern void EncodeFrameWithAudio(int handle, IntPtr videoData, IntPtr audioData, uint audioLength);

		[PreserveSig]
		public static extern void Pause(int handle);

		[PreserveSig]
		public static extern void Stop(int handle, bool skipPendingFrames);

		[PreserveSig]
		public static extern bool IsFileWritingComplete(int handle);

		[PreserveSig]
		public static extern void SetTexturePointer(int handle, IntPtr texture);

		[PreserveSig]
		public static extern void FreeRecorder(int handle);

		[PreserveSig]
		public static extern uint GetNumDroppedFrames(int handle);

		[PreserveSig]
		public static extern uint GetNumDroppedEncoderFrames(int handle);

		[PreserveSig]
		public static extern uint GetNumEncodedFrames(int handle);

		[PreserveSig]
		public static extern uint GetEncodedSeconds(int handle);

		[PreserveSig]
		public static extern uint GetFileSize(int handle);

		[PreserveSig]
		private static extern IntPtr GetPluginVersion();

		[PreserveSig]
		private static extern bool GetVideoCodecName(int index, StringBuilder name, int nameBufferLength);

		[PreserveSig]
		private static extern bool GetAudioCodecName(int index, StringBuilder name, int nameBufferLength);

		[PreserveSig]
		private static extern bool GetAudioInputDeviceName(int index, StringBuilder name, int nameBufferLength);

		[PreserveSig]
		private static extern bool GetContainerFileExtensions(int videoCodecIndex, int audioCodecIndex, StringBuilder extensions, int extensionsBufferLength);

		[PreserveSig]
		public static extern void SetLogFunction(IntPtr fn);

		[PreserveSig]
		public static extern void SetErrorHandler(int handle, IntPtr handler);
	}
}
