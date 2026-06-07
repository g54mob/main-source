namespace NAudio.Wave.SampleProviders
{
	public class MonoToStereoSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider source;

		private float[] sourceBuffer;

		public WaveFormat WaveFormat { get; }

		public float LeftVolume { get; set; }

		public float RightVolume { get; set; }

		public MonoToStereoSampleProvider(ISampleProvider source)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		private void EnsureSourceBuffer(int count)
		{
		}
	}
}
