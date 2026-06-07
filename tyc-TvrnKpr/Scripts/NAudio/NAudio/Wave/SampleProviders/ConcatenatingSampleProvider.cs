using System.Collections.Generic;

namespace NAudio.Wave.SampleProviders
{
	public class ConcatenatingSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider[] providers;

		private int currentProviderIndex;

		public WaveFormat WaveFormat => null;

		public ConcatenatingSampleProvider(IEnumerable<ISampleProvider> providers)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
