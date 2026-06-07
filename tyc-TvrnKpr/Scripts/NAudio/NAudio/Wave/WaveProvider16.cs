namespace NAudio.Wave
{
	public abstract class WaveProvider16 : IWaveProvider
	{
		private WaveFormat waveFormat;

		public WaveFormat WaveFormat => null;

		public WaveProvider16()
		{
		}

		public WaveProvider16(int sampleRate, int channels)
		{
		}

		public void SetWaveFormat(int sampleRate, int channels)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public abstract int Read(short[] buffer, int offset, int sampleCount);
	}
}
