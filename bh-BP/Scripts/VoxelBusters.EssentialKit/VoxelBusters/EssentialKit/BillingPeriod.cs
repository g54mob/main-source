namespace VoxelBusters.EssentialKit
{
	public class BillingPeriod
	{
		public double Duration { get; private set; }

		public BillingPeriodUnit Unit { get; private set; }

		public BillingPeriod(double duration, BillingPeriodUnit unit)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
