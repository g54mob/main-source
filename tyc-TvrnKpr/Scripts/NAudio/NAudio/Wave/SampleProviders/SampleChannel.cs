using System;

namespace NAudio.Wave.SampleProviders
{
	public class SampleChannel : ISampleProvider
	{
		private readonly VolumeSampleProvider volumeProvider;

		private readonly MeteringSampleProvider preVolumeMeter;

		private readonly WaveFormat waveFormat;

		public WaveFormat WaveFormat => null;

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

		public event EventHandler<StreamVolumeEventArgs> PreVolumeMeter
		{
			add
			{
			}
			remove
			{
			}
		}

		public SampleChannel(IWaveProvider waveProvider)
		{
		}

		public SampleChannel(IWaveProvider waveProvider, bool forceStereo)
		{
		}

		public int Read(float[] buffer, int offset, int sampleCount)
		{
			return 0;
		}
	}
}
