using UnityEngine;

namespace PortAudioForUnity
{
	public static class MicrophoneAdapter
	{
		public static bool UsePortAudio;

		private static int selectedHostApiAsInt;

		public static DeviceInfo DefaultInputDeviceInfo => null;

		public static DeviceInfo DefaultOutputDeviceInfo => null;

		public static string[] Devices => null;

		public static void SetHostApi(HostApi hostApi)
		{
		}

		public static HostApi GetHostApi()
		{
			return default(HostApi);
		}

		public static HostApiInfo GetHostApiInfo()
		{
			return null;
		}

		public static bool IsRecording(string deviceName)
		{
			return false;
		}

		public static AudioClip Start(string inputDeviceName, bool loop, int bufferLengthSec, int sampleRate, string outputDeviceName = "", float directOutputAmplificationFactor = 1f)
		{
			return null;
		}

		public static void End(string deviceName)
		{
		}

		private static bool TryGetSelectedHostApiDeviceInfo(string deviceName, out DeviceInfo deviceInfo)
		{
			deviceInfo = null;
			return false;
		}

		public static int GetPosition(string deviceName)
		{
			return 0;
		}

		public static void GetRecordedSamples(string deviceName, int channelIndex, AudioClip microphoneAudioClip, int recordingPosition, float[] bufferToBeFilled)
		{
		}

		public static void GetDeviceCaps(string deviceName, out int minFreq, out int maxFreq, out int channelCount)
		{
			minFreq = default(int);
			maxFreq = default(int);
			channelCount = default(int);
		}
	}
}
