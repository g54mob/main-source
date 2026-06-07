using System;
using NAudio.CoreAudioApi.Interfaces;
using NAudio.Wave;

namespace NAudio.CoreAudioApi
{
	public class AudioClient : IDisposable
	{
		private IAudioClient audioClientInterface;

		private WaveFormat mixFormat;

		private AudioRenderClient audioRenderClient;

		private AudioCaptureClient audioCaptureClient;

		private AudioClockClient audioClockClient;

		private AudioStreamVolume audioStreamVolume;

		private AudioClientShareMode shareMode;

		public WaveFormat MixFormat => null;

		public int BufferSize => 0;

		public long StreamLatency => 0L;

		public int CurrentPadding => 0;

		public long DefaultDevicePeriod => 0L;

		public long MinimumDevicePeriod => 0L;

		public AudioStreamVolume AudioStreamVolume => null;

		public AudioClockClient AudioClockClient => null;

		public AudioRenderClient AudioRenderClient => null;

		public AudioCaptureClient AudioCaptureClient => null;

		internal AudioClient(IAudioClient audioClientInterface)
		{
		}

		public void Initialize(AudioClientShareMode shareMode, AudioClientStreamFlags streamFlags, long bufferDuration, long periodicity, WaveFormat waveFormat, Guid audioSessionGuid)
		{
		}

		public bool IsFormatSupported(AudioClientShareMode shareMode, WaveFormat desiredFormat)
		{
			return false;
		}

		private IntPtr GetPointerToPointer()
		{
			return (IntPtr)0;
		}

		public bool IsFormatSupported(AudioClientShareMode shareMode, WaveFormat desiredFormat, out WaveFormatExtensible closestMatchFormat)
		{
			closestMatchFormat = null;
			return false;
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void SetEventHandle(IntPtr eventWaitHandle)
		{
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
