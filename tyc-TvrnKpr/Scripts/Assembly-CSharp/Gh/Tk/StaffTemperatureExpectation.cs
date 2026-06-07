namespace Gh.Tk
{
	public class StaffTemperatureExpectation : StaffExpectationBase
	{
		protected StaffTemperatureExpectation()
		{
		}

		public StaffTemperatureExpectation(Staff owner)
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
