namespace NAudio.Wave
{
	public class StereoToMonoProvider16 : IWaveProvider
	{
		private readonly IWaveProvider sourceProvider;

		private byte[] sourceBuffer;

		public float LeftVolume { get; set; }

		public float RightVolume { get; set; }

		public WaveFormat WaveFormat { get; private set; }

		public StereoToMonoProvider16(IWaveProvider sourceProvider)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
