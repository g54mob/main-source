using System;
using System.Runtime.CompilerServices;
using System.Threading;
using NAudio.Wave.Asio;

namespace NAudio.Wave
{
	public class AsioOut : IWavePlayer, IDisposable
	{
		private AsioDriverExt driver;

		private IWaveProvider sourceStream;

		private PlaybackState playbackState;

		private int nbSamples;

		private byte[] waveBuffer;

		private AsioSampleConvertor.SampleConvertor convertor;

		private string driverName;

		private readonly SynchronizationContext syncContext;

		private bool isInitialized;

		public int PlaybackLatency => 0;

		public PlaybackState PlaybackState => default(PlaybackState);

		public string DriverName => null;

		public int NumberOfOutputChannels { get; private set; }

		public int NumberOfInputChannels { get; private set; }

		public int DriverInputChannelCount => 0;

		public int DriverOutputChannelCount => 0;

		public int FramesPerBuffer => 0;

		public int ChannelOffset { get; set; }

		public int InputChannelOffset { get; set; }

		[Obsolete("this function will be removed in a future NAudio as ASIO does not support setting the volume on the device")]
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

		public event EventHandler<AsioAudioAvailableEventArgs> AudioAvailable
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

		public AsioOut()
		{
		}

		public AsioOut(string driverName)
		{
		}

		public AsioOut(int driverIndex)
		{
		}

		~AsioOut()
		{
		}

		public void Dispose()
		{
		}

		public static string[] GetDriverNames()
		{
			return null;
		}

		public static bool isSupported()
		{
			return false;
		}

		private void InitFromName(string driverName)
		{
		}

		public void ShowControlPanel()
		{
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

		public void InitRecordAndPlayback(IWaveProvider waveProvider, int recordChannels, int recordOnlySampleRate)
		{
		}

		private void driver_BufferUpdate(IntPtr[] inputChannels, IntPtr[] outputChannels)
		{
		}

		private void RaisePlaybackStopped(Exception e)
		{
		}

		public string AsioInputChannelName(int channel)
		{
			return null;
		}

		public string AsioOutputChannelName(int channel)
		{
			return null;
		}
	}
}
