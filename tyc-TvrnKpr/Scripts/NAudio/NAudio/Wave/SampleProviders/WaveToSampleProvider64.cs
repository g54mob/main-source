namespace NAudio.Wave.SampleProviders
{
	public class WaveToSampleProvider64 : SampleProviderConverterBase
	{
		public WaveToSampleProvider64(IWaveProvider source)
			: base(null)
		{
		}

		public override int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
