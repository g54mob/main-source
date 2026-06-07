namespace NAudio.Wave.SampleProviders
{
	public class SampleToWaveProvider : IWaveProvider
	{
		private readonly ISampleProvider source;

		public WaveFormat WaveFormat => null;

		public SampleToWaveProvider(ISampleProvider source)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
