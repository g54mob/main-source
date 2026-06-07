namespace Utility
{
	public class FloatRollingQuantileEstimator : RollingQuantileEstimator<FloatGKQuantileEstimator, float>
	{
		public FloatRollingQuantileEstimator(int nEstimator, int rollPeriod, float epsilon)
			: base(nEstimator, rollPeriod, epsilon)
		{
		}

		protected override void InitEstimators(float epsilon)
		{
			for (int i = 0; i < nEstimator; i++)
			{
				estimators[i] = new FloatGKQuantileEstimator(epsilon);
			}
		}
	}
}
