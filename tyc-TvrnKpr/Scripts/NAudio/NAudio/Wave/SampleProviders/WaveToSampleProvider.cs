namespace NAudio.Wave.SampleProviders
{
	public class WaveToSampleProvider : SampleProviderConverterBase
	{
		public WaveToSampleProvider(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
