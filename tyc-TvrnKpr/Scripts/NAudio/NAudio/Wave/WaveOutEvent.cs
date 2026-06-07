using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NAudio.Wave
{
	public class WaveOutEvent : IWavePlayer, IDisposable, IWavePosition
	{
		private readonly object waveOutLock;

		private readonly SynchronizationContext syncContext;

		private IntPtr hWaveOut;

		private WaveOutBuffer[] buffers;

		private IWaveProvider waveStream;

		private PlaybackState playbackState;

		private AutoResetEvent callbackEvent;

		private float volume;

		public int DesiredLatency { get; set; }

		public int NumberOfBuffers { get; set; }

		public int DeviceNumber { get; set; }

		public WaveFormat OutputWaveFormat => null;

		public PlaybackState PlaybackState => default(PlaybackState);

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event EventHandler<StoppedEventArgs> PlaybackStopped
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

		public void Init(IWaveProvider waveProvider)
		{
		}

		public void Play()
		{
		}

		private void PlaybackThread()
		{
		}

		private void DoPlayback()
		{
		}

		public void Pause()
		{
		}

		private void Resume()
		{
		}

		public void Stop()
		{
		}

		public long GetPosition()
		{
			return 0L;
		}

		public void Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		private void CloseWaveOut()
		{
		}

		private void DisposeBuffers()
		{
		}

		~WaveOutEvent()
		{
		}

		private void RaisePlaybackStoppedEvent(Exception e)
		{
		}
	}
}
