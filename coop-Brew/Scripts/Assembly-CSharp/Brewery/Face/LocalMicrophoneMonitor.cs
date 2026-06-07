using UnityEngine;

namespace Brewery.Face
{
	public static class LocalMicrophoneMonitor
	{
		private const int SampleRate = 16000;

		private const int BufferLengthSec = 1;

		private const int ReadChunkSize = 256;

		private const float AmplitudeBoost = 12f;

		private const float SmoothingLerp = 0.45f;

		private static AudioClip _clip;

		private static string _device;

		private static int _lastReadPosition;

		private static readonly float[] _readBuffer;

		private static bool _started;

		private static bool _failed;

		private static int _lastSampleFrame;

		private static float _amplitude01;

		private static string _failReason;

		public static float Amplitude01 => 0f;

		public static bool IsAvailable => false;

		public static bool HasFailed => false;

		public static string FailReason => null;

		public static string DeviceName => null;

		public static void EnsureStarted()
		{
		}

		public static void TickIfNeeded()
		{
		}

		public static void Stop()
		{
		}
	}
}
