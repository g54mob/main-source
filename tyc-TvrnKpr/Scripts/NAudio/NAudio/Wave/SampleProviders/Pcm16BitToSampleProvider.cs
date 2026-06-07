namespace NAudio.Wave.SampleProviders
{
	public class Pcm16BitToSampleProvider : SampleProviderConverterBase
	{
		public Pcm16BitToSampleProvider(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
