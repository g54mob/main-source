namespace NAudio.Wave
{
	public class WaveFloatTo16Provider : IWaveProvider
	{
		private readonly IWaveProvider sourceProvider;

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

		public WaveFloatTo16Provider(IWaveProvider sourceProvider)
		{
		}

		public int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}
	}
}
