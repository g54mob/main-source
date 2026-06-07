namespace Gh.Tk
{
	public class StaffCleanlinessExpectation : StaffExpectationBase
	{
		protected StaffCleanlinessExpectation()
		{
		}

		public StaffCleanlinessExpectation(Staff owner)
		{
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
