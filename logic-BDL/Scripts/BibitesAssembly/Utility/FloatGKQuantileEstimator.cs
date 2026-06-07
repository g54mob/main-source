namespace Utility
{
	public class FloatGKQuantileEstimator : GKQuantileEstimator<float>
	{
		protected override int valueByteSize => 4;

		public FloatGKQuantileEstimator(float epsilon)
			: base(epsilon)
		{
		}
	}
}
