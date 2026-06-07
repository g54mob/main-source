namespace NAudio.Wave
{
	public class Wave16ToFloatProvider : IWaveProvider
	{
		private IWaveProvider sourceProvider;

		private readonly WaveFormat waveFormat;

		private float volume;

		private byte[] sourceBuffer;

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

		public Wave16ToFloatProvider(IWaveProvider sourceProvider)
		{
		}

		public int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}
	}
}
