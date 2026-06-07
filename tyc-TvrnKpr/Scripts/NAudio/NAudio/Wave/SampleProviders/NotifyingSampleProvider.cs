using System;
using System.Runtime.CompilerServices;

namespace NAudio.Wave.SampleProviders
{
	public class NotifyingSampleProvider : ISampleProvider, ISampleNotifier
	{
		private readonly ISampleProvider source;

		private readonly SampleEventArgs sampleArgs;

		private readonly int channels;

		public WaveFormat WaveFormat => null;

		public event EventHandler<SampleEventArgs> Sample
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

		public NotifyingSampleProvider(ISampleProvider source)
		{
		}

		public int Read(float[] buffer, int offset, int sampleCount)
		{
			return 0;
		}
	}
}
