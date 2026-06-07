namespace NAudio.Wave
{
	public abstract class WaveProvider32 : IWaveProvider, ISampleProvider
	{
		private WaveFormat waveFormat;

		public WaveFormat WaveFormat => null;

		public WaveProvider32()
		{
		}

		public WaveProvider32(int sampleRate, int channels)
		{
		}

		public void SetWaveFormat(int sampleRate, int channels)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public abstract int Read(float[] buffer, int offset, int sampleCount);
	}
}
