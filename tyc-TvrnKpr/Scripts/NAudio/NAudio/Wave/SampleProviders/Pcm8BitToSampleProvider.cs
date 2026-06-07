namespace NAudio.Wave.SampleProviders
{
	public class Pcm8BitToSampleProvider : SampleProviderConverterBase
	{
		public Pcm8BitToSampleProvider(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
