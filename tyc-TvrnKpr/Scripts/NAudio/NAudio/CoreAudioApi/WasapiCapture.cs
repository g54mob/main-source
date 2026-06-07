using System;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.Wave;

namespace NAudio.CoreAudioApi
{
	public class WasapiCapture : IWaveIn, IDisposable
	{
		private const long ReftimesPerSec = 10000000L;

		private const long ReftimesPerMillisec = 10000L;

		private CaptureState captureState;

		private byte[] recordBuffer;

		private Thread captureThread;

		private AudioClient audioClient;

		private int bytesPerFrame;

		private WaveFormat waveFormat;

		private bool initialized;

		private readonly SynchronizationContext syncContext;

		private readonly bool isUsingEventSync;

		private EventWaitHandle frameEventWaitHandle;

		private readonly int audioBufferMillisecondsLength;

		public AudioClientShareMode ShareMode { get; set; }

		public CaptureState CaptureState => default(CaptureState);

		public virtual WaveFormat WaveFormat
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler<WaveInEventArgs> DataAvailable
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<StoppedEventArgs> RecordingStopped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public WasapiCapture()
		{
		}

		public WasapiCapture(MMDevice captureDevice)
		{
		}

		public WasapiCapture(MMDevice captureDevice, bool useEventSync)
		{
		}

		public WasapiCapture(MMDevice captureDevice, bool useEventSync, int audioBufferMillisecondsLength)
		{
		}

		public static MMDevice GetDefaultCaptureDevice()
		{
			return null;
		}

		private void InitializeCaptureDevice()
		{
		}

		protected virtual AudioClientStreamFlags GetAudioClientStreamFlags()
		{
			return default(AudioClientStreamFlags);
		}

		public void StartRecording()
		{
		}

		public void StopRecording()
		{
		}

		private void CaptureThread(AudioClient client)
		{
		}

		private void DoRecording(AudioClient client)
		{
		}

		private void RaiseRecordingStopped(Exception e)
		{
		}

		private void ReadNextPacket(AudioCaptureClient capture)
		{
		}

		public void Dispose()
		{
		}
	}
}
