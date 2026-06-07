namespace NAudio.Wave.SampleProviders
{
	public class StereoBalanceStrategy : IPanStrategy
	{
		public StereoSamplePair GetMultipliers(float pan)
		{
			return default(StereoSamplePair);
		}
	}
}
