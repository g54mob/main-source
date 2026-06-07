namespace Gh.Tk
{
	public class StaffBedroomStarExpectation : StaffExpectationBase
	{
		protected StaffBedroomStarExpectation()
		{
		}

		public StaffBedroomStarExpectation(Staff owner)
		{
		}

		private int GetExpectedStars()
		{
			return 0;
		}

		public override bool IsEnabled()
		{
			return false;
		}

		protected override void UpdateInternal()
		{
		}
	}
}
