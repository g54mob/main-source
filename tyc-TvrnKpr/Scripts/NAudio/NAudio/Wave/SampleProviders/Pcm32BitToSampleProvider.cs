namespace NAudio.Wave.SampleProviders
{
	public class Pcm32BitToSampleProvider : SampleProviderConverterBase
	{
		public Pcm32BitToSampleProvider(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
