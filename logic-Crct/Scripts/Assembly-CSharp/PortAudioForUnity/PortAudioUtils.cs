using System.Collections.Generic;
using PortAudioSharp;
using UnityEngine;

namespace PortAudioForUnity
{
	public static class PortAudioUtils
	{
		public delegate void PcmReaderCallback(float[] data);

		private static bool isInitialized;

		private static bool failedToInitialize;

		private static readonly Dictionary<int, InputDeviceControl> globalDeviceIndexToInputDeviceControl;

		private static readonly Dictionary<int, OutputDeviceControl> globalDeviceIndexToOutputDeviceControl;

		private static GameObject portAudioDisposeOnDestroyGameObject;

		private static List<HostApiInfo> hostApiInfos;

		private static List<DeviceInfo> deviceInfos;

		private static int defaultHostApiAsInt;

		public static uint SamplesPerBuffer { get; set; }

		public static List<HostApi> HostApis => null;

		public static List<HostApiInfo> HostApiInfos => null;

		public static List<DeviceInfo> DeviceInfos => null;

		private static HostApi DefaultHostApi => default(HostApi);

		public static HostApiInfo DefaultHostApiInfo => null;

		public static DeviceInfo DefaultInputDeviceInfo => null;

		public static DeviceInfo DefaultOutputDeviceInfo => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void StaticInit()
		{
		}

		public static void StartRecording(DeviceInfo inputDeviceInfo, bool loop, int bufferLengthInSeconds, int sampleRate, DeviceInfo outputDeviceInfo = null, float outputAmplificationFactor = 1f)
		{
		}

		public static void StartPlayback(DeviceInfo outputDeviceInfo, int outputChannelCount, int bufferLengthInSeconds, int sampleRate, PcmReaderCallback pcmReaderCallback)
		{
		}

		public static void StopPlayback(DeviceInfo deviceInfo)
		{
		}

		public static void SetOutputAmplificationFactor(DeviceInfo deviceInfo, float outputAmplificationFactor)
		{
		}

		public static void StopRecording(DeviceInfo deviceInfo)
		{
		}

		public static bool IsRecording(DeviceInfo deviceInfo)
		{
			return false;
		}

		private static List<HostApiInfo> GetHostApiInfos()
		{
			return null;
		}

		public static HostApiInfo GetHostApiInfo(HostApi hostApi)
		{
			return null;
		}

		private static List<DeviceInfo> GetDeviceInfos()
		{
			return null;
		}

		public static DeviceInfo GetDeviceInfo(int globalDeviceIndex)
		{
			return null;
		}

		public static DeviceInfo GetDeviceInfo(HostApi hostApi, int hostApiDeviceIndex)
		{
			return null;
		}

		public static void Dispose()
		{
		}

		private static void DisposeInputOutputDeviceControls()
		{
		}

		public static void GetAllRecordedSamples(DeviceInfo deviceInfo, float[] bufferToBeFilled)
		{
		}

		public static void GetRecordedSamples(DeviceInfo deviceInfo, int channelIndex, float[] bufferToBeFilled)
		{
		}

		public static int GetSingleChannelRecordingPosition(DeviceInfo deviceInfo)
		{
			return 0;
		}

		private static void InitializeIfNotDoneYet()
		{
		}

		private static bool CheckAndLogError(string actionName, PortAudio.PaError errorCode)
		{
			return false;
		}

		internal static void Log(string message, LogType logType = LogType.Log)
		{
		}

		private static void ThrowIfNotOnMainThread()
		{
		}
	}
}
