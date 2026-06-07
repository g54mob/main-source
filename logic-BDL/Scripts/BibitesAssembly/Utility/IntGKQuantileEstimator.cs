namespace Utility
{
	public class IntGKQuantileEstimator : GKQuantileEstimator<int>
	{
		protected override int valueByteSize => 4;

		public IntGKQuantileEstimator(float epsilon)
			: base(epsilon)
		{
		}
	}
}
