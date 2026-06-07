namespace NAudio.Wave.SampleProviders
{
	public class StereoToMonoSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider sourceProvider;

		private float[] sourceBuffer;

		public float LeftVolume { get; set; }

		public float RightVolume { get; set; }

		public WaveFormat WaveFormat { get; }

		public StereoToMonoSampleProvider(ISampleProvider sourceProvider)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
