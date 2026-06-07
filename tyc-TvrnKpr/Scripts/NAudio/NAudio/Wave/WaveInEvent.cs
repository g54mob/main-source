using System;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.CoreAudioApi;
using NAudio.Mixer;

namespace NAudio.Wave
{
	public class WaveInEvent : IWaveIn, IDisposable
	{
		private readonly AutoResetEvent callbackEvent;

		private readonly SynchronizationContext syncContext;

		private IntPtr waveInHandle;

		private CaptureState captureState;

		private WaveInBuffer[] buffers;

		public static int DeviceCount => 0;

		public int BufferMilliseconds { get; set; }

		public int NumberOfBuffers { get; set; }

		public int DeviceNumber { get; set; }

		public WaveFormat WaveFormat { get; set; }

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

		public static WaveInCapabilities GetCapabilities(int devNumber)
		{
			return default(WaveInCapabilities);
		}

		private void CreateBuffers()
		{
		}

		private void OpenWaveInDevice()
		{
		}

		public void StartRecording()
		{
		}

		private void RecordThread()
		{
		}

		private void DoRecording()
		{
		}

		private void RaiseRecordingStoppedEvent(Exception e)
		{
		}

		public void StopRecording()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private void CloseWaveInDevice()
		{
		}

		public MixerLine GetMixerLine()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
