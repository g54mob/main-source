using System;
using System.Runtime.CompilerServices;

namespace NAudio.Wave.SampleProviders
{
	public class MeteringSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider source;

		private readonly float[] maxSamples;

		private int sampleCount;

		private readonly int channels;

		private readonly StreamVolumeEventArgs args;

		public int SamplesPerNotification { get; set; }

		public WaveFormat WaveFormat => null;

		public event EventHandler<StreamVolumeEventArgs> StreamVolume
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

		public MeteringSampleProvider(ISampleProvider source)
		{
		}

		public MeteringSampleProvider(ISampleProvider source, int samplesPerNotification)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
