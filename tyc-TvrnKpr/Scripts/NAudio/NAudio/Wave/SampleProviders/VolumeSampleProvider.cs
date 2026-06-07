namespace NAudio.Wave.SampleProviders
{
	public class VolumeSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider source;

		private float volume;

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

		public VolumeSampleProvider(ISampleProvider source)
		{
		}

		public int Read(float[] buffer, int offset, int sampleCount)
		{
			return 0;
		}
	}
}
