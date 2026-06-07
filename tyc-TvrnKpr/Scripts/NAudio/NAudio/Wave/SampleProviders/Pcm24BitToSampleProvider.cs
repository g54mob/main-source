namespace NAudio.Wave.SampleProviders
{
	public class Pcm24BitToSampleProvider : SampleProviderConverterBase
	{
		public Pcm24BitToSampleProvider(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
