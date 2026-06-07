namespace Gh.Tk
{
	public class StaffBedExpectation : StaffExpectationBase
	{
		protected StaffBedExpectation()
		{
		}

		public StaffBedExpectation(Staff owner)
		{
		}

		public override bool IsEnabled()
		{
			return false;
		}
	}
}
