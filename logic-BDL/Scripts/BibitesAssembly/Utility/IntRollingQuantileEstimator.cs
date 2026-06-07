namespace Utility
{
	public class IntRollingQuantileEstimator : RollingQuantileEstimator<IntGKQuantileEstimator, int>
	{
		public IntRollingQuantileEstimator(int nEstimator, int rollPeriod, float epsilon)
			: base(nEstimator, rollPeriod, epsilon)
		{
		}

		protected override void InitEstimators(float epsilon)
		{
			for (int i = 0; i < nEstimator; i++)
			{
				estimators[i] = new IntGKQuantileEstimator(epsilon);
			}
		}
	}
}
