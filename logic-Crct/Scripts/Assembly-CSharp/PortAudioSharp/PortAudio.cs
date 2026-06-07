using System;
using System.Runtime.InteropServices;

namespace PortAudioSharp
{
	public class PortAudio
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate PaStreamCallbackResult PaStreamCallbackDelegate(IntPtr input, IntPtr output, uint frameCount, ref PaStreamCallbackTimeInfo timeInfo, PaStreamCallbackFlags statusFlags, IntPtr userData);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void PaStreamFinishedCallbackDelegate(IntPtr userData);

		public struct PaDeviceInfo
		{
			public int structVersion;

			public string name;

			public int hostApi;

			public int maxInputChannels;

			public int maxOutputChannels;

			public double defaultLowInputLatency;

			public double defaultLowOutputLatency;

			public double defaultHighInputLatency;

			public double defaultHighOutputLatency;

			public double defaultSampleRate;

			public override string ToString()
			{
				return null;
			}
		}

		public struct PaHostApiInfo
		{
			public int structVersion;

			public PaHostApiTypeId type;

			public string name;

			public int deviceCount;

			public int defaultInputDevice;

			public int defaultOutputDevice;

			public override string ToString()
			{
				return null;
			}
		}

		public struct PaHostErrorInfo
		{
			public PaHostApiTypeId hostApiType;

			public int errorCode;

			public string errorText;

			public override string ToString()
			{
				return null;
			}
		}

		public struct PaStreamCallbackTimeInfo
		{
			public double inputBufferAdcTime;

			public double currentTime;

			public double outputBufferDacTime;

			public override string ToString()
			{
				return null;
			}
		}

		public struct PaStreamInfo
		{
			public int structVersion;

			public double inputLatency;

			public double outputLatency;

			public double sampleRate;

			public override string ToString()
			{
				return null;
			}
		}

		public struct PaStreamParameters
		{
			public int device;

			public int channelCount;

			public PaSampleFormat sampleFormat;

			public double suggestedLatency;

			public IntPtr hostApiSpecificStreamInfo;

			public override string ToString()
			{
				return null;
			}
		}

		public enum PaDeviceIndex
		{
			paNoDevice = -1,
			paUseHostApiSpecificDeviceSpecification = -2
		}

		public enum PaSampleFormat : uint
		{
			paFloat32 = 1u,
			paInt32 = 2u,
			paInt24 = 4u,
			paInt16 = 8u,
			paInt8 = 0x10u,
			paUInt8 = 0x20u,
			paCustomFormat = 0x10000u,
			paNonInterleaved = 0x80000000u
		}

		public enum PaStreamFlags : uint
		{
			paNoFlag = 0u,
			paClipOff = 1u,
			paDitherOff = 2u,
			paNeverDropInput = 4u,
			paPrimeOutputBuffersUsingStreamCallback = 8u,
			paPlatformSpecificFlags = 4294901760u
		}

		public enum PaStreamCallbackFlags : uint
		{
			paInputUnderflow = 1u,
			paInputOverflow = 2u,
			paOutputUnderflow = 4u,
			paOutputOverflow = 8u,
			paPrimingOutput = 0x10u
		}

		public enum PaError
		{
			paNoError = 0,
			paNotInitialized = -10000,
			paUnanticipatedHostError = -9999,
			paInvalidChannelCount = -9998,
			paInvalidSampleRate = -9997,
			paInvalidDevice = -9996,
			paInvalidFlag = -9995,
			paSampleFormatNotSupported = -9994,
			paBadIODeviceCombination = -9993,
			paInsufficientMemory = -9992,
			paBufferTooBig = -9991,
			paBufferTooSmall = -9990,
			paNullCallback = -9989,
			paBadStreamPtr = -9988,
			paTimedOut = -9987,
			paInternalError = -9986,
			paDeviceUnavailable = -9985,
			paIncompatibleHostApiSpecificStreamInfo = -9984,
			paStreamIsStopped = -9983,
			paStreamIsNotStopped = -9982,
			paInputOverflowed = -9981,
			paOutputUnderflowed = -9980,
			paHostApiNotFound = -9979,
			paInvalidHostApi = -9978,
			paCanNotReadFromACallbackStream = -9977,
			paCanNotWriteToACallbackStream = -9976,
			paCanNotReadFromAnOutputOnlyStream = -9975,
			paCanNotWriteToAnInputOnlyStream = -9974,
			paIncompatibleStreamHostApi = -9973,
			paBadBufferPtr = -9972
		}

		public enum PaHostApiTypeId : uint
		{
			paInDevelopment = 0u,
			paDirectSound = 1u,
			paMME = 2u,
			paASIO = 3u,
			paSoundManager = 4u,
			paCoreAudio = 5u,
			paOSS = 7u,
			paALSA = 8u,
			paAL = 9u,
			paBeOS = 10u,
			paWDMKS = 11u,
			paJACK = 12u,
			paWASAPI = 13u,
			paAudioScienceHPI = 14u
		}

		public enum PaStreamCallbackResult : uint
		{
			paContinue = 0u,
			paComplete = 1u,
			paAbort = 2u
		}

		public const int paFormatIsSupported = 0;

		public const int paFramesPerBufferUnspecified = 0;

		[PreserveSig]
		public static extern int Pa_GetVersion();

		[PreserveSig]
		private static extern IntPtr IntPtr_Pa_GetVersionText();

		public static string Pa_GetVersionText()
		{
			return null;
		}

		[PreserveSig]
		public static extern IntPtr IntPtr_Pa_GetErrorText(PaError errorCode);

		public static string Pa_GetErrorText(PaError errorCode)
		{
			return null;
		}

		[PreserveSig]
		public static extern PaError Pa_Initialize();

		[PreserveSig]
		public static extern PaError Pa_Terminate();

		[PreserveSig]
		public static extern int Pa_GetHostApiCount();

		[PreserveSig]
		public static extern int Pa_GetDefaultHostApi();

		[PreserveSig]
		public static extern IntPtr IntPtr_Pa_GetHostApiInfo(int hostApi);

		public static PaHostApiInfo Pa_GetHostApiInfo(int hostApi)
		{
			return default(PaHostApiInfo);
		}

		[PreserveSig]
		public static extern int Pa_HostApiTypeIdToHostApiIndex(PaHostApiTypeId type);

		[PreserveSig]
		public static extern int Pa_HostApiDeviceIndexToDeviceIndex(int hostApi, int hostApiDeviceIndex);

		[PreserveSig]
		public static extern IntPtr IntPtr_Pa_GetLastHostErrorInfo();

		public static PaHostErrorInfo Pa_GetLastHostErrorInfo()
		{
			return default(PaHostErrorInfo);
		}

		[PreserveSig]
		public static extern int Pa_GetDeviceCount();

		[PreserveSig]
		public static extern int Pa_GetDefaultInputDevice();

		[PreserveSig]
		public static extern int Pa_GetDefaultOutputDevice();

		[PreserveSig]
		public static extern IntPtr IntPtr_Pa_GetDeviceInfo(int device);

		public static PaDeviceInfo Pa_GetDeviceInfo(int device)
		{
			return default(PaDeviceInfo);
		}

		[PreserveSig]
		public static extern PaError Pa_IsFormatSupported(ref PaStreamParameters inputParameters, ref PaStreamParameters outputParameters, double sampleRate);

		[PreserveSig]
		public static extern PaError Pa_OpenStream(out IntPtr stream, ref PaStreamParameters inputParameters, ref PaStreamParameters outputParameters, double sampleRate, uint framesPerBuffer, PaStreamFlags streamFlags, PaStreamCallbackDelegate streamCallback, IntPtr userData);

		[PreserveSig]
		private static extern PaError Pa_OpenStream(out IntPtr stream, IntPtr inputParameters, IntPtr outputParameters, double sampleRate, uint framesPerBuffer, PaStreamFlags streamFlags, PaStreamCallbackDelegate streamCallback, IntPtr userData);

		public static PaError Pa_OpenStream(out IntPtr stream, ref PaStreamParameters? inputParameters, ref PaStreamParameters? outputParameters, double sampleRate, uint framesPerBuffer, PaStreamFlags streamFlags, PaStreamCallbackDelegate streamCallback, IntPtr userData)
		{
			stream = default(IntPtr);
			return default(PaError);
		}

		[PreserveSig]
		public static extern PaError Pa_OpenDefaultStream(out IntPtr stream, int numInputChannels, int numOutputChannels, uint sampleFormat, double sampleRate, uint framesPerBuffer, PaStreamCallbackDelegate streamCallback, IntPtr userData);

		[PreserveSig]
		public static extern PaError Pa_CloseStream(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_SetStreamFinishedCallback(ref IntPtr stream, PaStreamFinishedCallbackDelegate streamFinishedCallback);

		[PreserveSig]
		public static extern PaError Pa_StartStream(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_StopStream(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_AbortStream(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_IsStreamStopped(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_IsStreamActive(IntPtr stream);

		[PreserveSig]
		public static extern IntPtr IntPtr_Pa_GetStreamInfo(IntPtr stream);

		public static PaStreamInfo Pa_GetStreamInfo(IntPtr stream)
		{
			return default(PaStreamInfo);
		}

		[PreserveSig]
		public static extern double Pa_GetStreamTime(IntPtr stream);

		[PreserveSig]
		public static extern double Pa_GetStreamCpuLoad(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] float[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] byte[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] sbyte[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] ushort[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] short[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] uint[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_ReadStream(IntPtr stream, [Out] int[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] float[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] byte[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] sbyte[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] ushort[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] short[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] uint[] buffer, uint frames);

		[PreserveSig]
		public static extern PaError Pa_WriteStream(IntPtr stream, [In] int[] buffer, uint frames);

		[PreserveSig]
		public static extern int Pa_GetStreamReadAvailable(IntPtr stream);

		[PreserveSig]
		public static extern int Pa_GetStreamWriteAvailable(IntPtr stream);

		[PreserveSig]
		public static extern PaError Pa_GetSampleSize(PaSampleFormat format);

		[PreserveSig]
		public static extern void Pa_Sleep(int msec);

		private PortAudio()
		{
		}
	}
}
