namespace NAudio.Wave.SampleProviders
{
	public class SampleToWaveProvider16 : IWaveProvider
	{
		private readonly ISampleProvider sourceProvider;

		private readonly WaveFormat waveFormat;

		private float volume;

		private float[] sourceBuffer;

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

		public SampleToWaveProvider16(ISampleProvider sourceProvider)
		{
		}

		public int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}
	}
}
