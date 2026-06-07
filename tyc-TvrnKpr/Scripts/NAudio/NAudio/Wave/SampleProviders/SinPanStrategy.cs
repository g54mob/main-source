using System;

namespace NAudio.Wave.SampleProviders
{
	public class SinPanStrategy : IPanStrategy
	{
		private const float HalfPi = (float)Math.PI / 2f;

		public StereoSamplePair GetMultipliers(float pan)
		{
			return default(StereoSamplePair);
		}
	}
}
