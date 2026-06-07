using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NAudio.Wave
{
	public class WaveOut : IWavePlayer, IDisposable, IWavePosition
	{
		private IntPtr hWaveOut;

		private WaveOutBuffer[] buffers;

		private IWaveProvider waveStream;

		private PlaybackState playbackState;

		private readonly WaveInterop.WaveCallback callback;

		private float volume;

		private readonly WaveCallbackInfo callbackInfo;

		private readonly object waveOutLock;

		private int queuedBuffers;

		private readonly SynchronizationContext syncContext;

		public static int DeviceCount => 0;

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

		public static WaveOutCapabilities GetCapabilities(int devNumber)
		{
			return default(WaveOutCapabilities);
		}

		public WaveOut()
		{
		}

		public WaveOut(IntPtr windowHandle)
		{
		}

		public WaveOut(WaveCallbackInfo callbackInfo)
		{
		}

		public void Init(IWaveProvider waveProvider)
		{
		}

		public void Play()
		{
		}

		private void EnqueueBuffers()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void Stop()
		{
		}

		public long GetPosition()
		{
			return 0L;
		}

		internal static void SetWaveOutVolume(float value, IntPtr hWaveOut, object lockObject)
		{
		}

		public void Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		~WaveOut()
		{
		}

		private void Callback(IntPtr hWaveOut, WaveInterop.WaveMessage uMsg, IntPtr dwInstance, WaveHeader wavhdr, IntPtr dwReserved)
		{
		}

		private void RaisePlaybackStoppedEvent(Exception e)
		{
		}
	}
}
