namespace Gh.Tk
{
	public class StaffBrightnessExpectation : StaffExpectationBase
	{
		protected StaffBrightnessExpectation()
		{
		}

		public StaffBrightnessExpectation(Staff owner)
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
