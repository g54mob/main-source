namespace NAudio.Wave.SampleProviders
{
	public abstract class SampleProviderConverterBase : ISampleProvider
	{
		protected IWaveProvider source;

		private readonly WaveFormat waveFormat;

		protected byte[] sourceBuffer;

		public WaveFormat WaveFormat => null;

		public SampleProviderConverterBase(IWaveProvider source)
		{
		}

		public abstract int Read(float[] buffer, int offset, int count);

		protected void EnsureSourceBuffer(int sourceBytesRequired)
		{
		}
	}
}
