namespace Gh.Tk
{
	public class StaffTakesShortErraticBreaksBehaviour : StaffTakesErraticBreaksBehaviour
	{
		protected StaffTakesShortErraticBreaksBehaviour()
		{
		}

		public StaffTakesShortErraticBreaksBehaviour(Staff owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}
	}
}
