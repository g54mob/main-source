namespace NAudio.Wave
{
	public class VolumeWaveProvider16 : IWaveProvider
	{
		private readonly IWaveProvider sourceProvider;

		private float volume;

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

		public WaveFormat WaveFormat => null;

		public VolumeWaveProvider16(IWaveProvider sourceProvider)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
