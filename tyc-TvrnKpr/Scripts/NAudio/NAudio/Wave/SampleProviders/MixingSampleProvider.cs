using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NAudio.Wave.SampleProviders
{
	public class MixingSampleProvider : ISampleProvider
	{
		private readonly List<ISampleProvider> sources;

		private float[] sourceBuffer;

		private const int MaxInputs = 1024;

		public IEnumerable<ISampleProvider> MixerInputs => null;

		public bool ReadFully { get; set; }

		public WaveFormat WaveFormat { get; private set; }

		public event EventHandler<SampleProviderEventArgs> MixerInputEnded
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

		public MixingSampleProvider(WaveFormat waveFormat)
		{
		}

		public MixingSampleProvider(IEnumerable<ISampleProvider> sources)
		{
		}

		public void AddMixerInput(IWaveProvider mixerInput)
		{
		}

		public void AddMixerInput(ISampleProvider mixerInput)
		{
		}

		public void RemoveMixerInput(ISampleProvider mixerInput)
		{
		}

		public void RemoveAllMixerInputs()
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
