using System;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.CoreAudioApi;

namespace NAudio.Wave
{
	public class WasapiOut : IWavePlayer, IDisposable, IWavePosition
	{
		private AudioClient audioClient;

		private readonly MMDevice mmDevice;

		private readonly AudioClientShareMode shareMode;

		private AudioRenderClient renderClient;

		private IWaveProvider sourceProvider;

		private int latencyMilliseconds;

		private int bufferFrameCount;

		private int bytesPerFrame;

		private readonly bool isUsingEventSync;

		private EventWaitHandle frameEventWaitHandle;

		private byte[] readBuffer;

		private PlaybackState playbackState;

		private Thread playThread;

		private WaveFormat outputFormat;

		private bool dmoResamplerNeeded;

		private readonly SynchronizationContext syncContext;

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

		public AudioStreamVolume AudioStreamVolume => null;

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

		public WasapiOut()
		{
		}

		public WasapiOut(AudioClientShareMode shareMode, int latency)
		{
		}

		public WasapiOut(AudioClientShareMode shareMode, bool useEventSync, int latency)
		{
		}

		public WasapiOut(MMDevice device, AudioClientShareMode shareMode, bool useEventSync, int latency)
		{
		}

		private static MMDevice GetDefaultAudioEndpoint()
		{
			return null;
		}

		private void PlayThread()
		{
		}

		private void RaisePlaybackStopped(Exception e)
		{
		}

		private void FillBuffer(IWaveProvider playbackProvider, int frameCount)
		{
		}

		public long GetPosition()
		{
			return 0L;
		}

		public void Play()
		{
		}

		public void Stop()
		{
		}

		public void Pause()
		{
		}

		public void Init(IWaveProvider waveProvider)
		{
		}

		public void Dispose()
		{
		}
	}
}
