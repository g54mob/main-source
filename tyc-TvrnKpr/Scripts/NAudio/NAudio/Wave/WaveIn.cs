using System;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.Mixer;

namespace NAudio.Wave
{
	public class WaveIn : IWaveIn, IDisposable
	{
		private IntPtr waveInHandle;

		private bool recording;

		private WaveInBuffer[] buffers;

		private readonly WaveInterop.WaveCallback callback;

		private WaveCallbackInfo callbackInfo;

		private readonly SynchronizationContext syncContext;

		private int lastReturnedBufferIndex;

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

		public WaveIn()
		{
		}

		public WaveIn(IntPtr windowHandle)
		{
		}

		public WaveIn(WaveCallbackInfo callbackInfo)
		{
		}

		public static WaveInCapabilities GetCapabilities(int devNumber)
		{
			return default(WaveInCapabilities);
		}

		private void CreateBuffers()
		{
		}

		private void Callback(IntPtr waveInHandle, WaveInterop.WaveMessage message, IntPtr userData, WaveHeader waveHeader, IntPtr reserved)
		{
		}

		private void RaiseDataAvailable(WaveInBuffer buffer)
		{
		}

		private void RaiseRecordingStopped(Exception e)
		{
		}

		private void OpenWaveInDevice()
		{
		}

		public void StartRecording()
		{
		}

		private void EnqueueBuffers()
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
