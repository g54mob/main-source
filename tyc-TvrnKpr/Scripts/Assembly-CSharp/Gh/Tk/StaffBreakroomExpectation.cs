namespace Gh.Tk
{
	public class StaffBreakroomExpectation : StaffExpectationBase
	{
		protected StaffBreakroomExpectation()
		{
		}

		public StaffBreakroomExpectation(Staff owner)
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
