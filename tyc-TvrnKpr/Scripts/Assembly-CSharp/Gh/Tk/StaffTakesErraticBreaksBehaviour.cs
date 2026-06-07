namespace Gh.Tk
{
	public abstract class StaffTakesErraticBreaksBehaviour : StaffBehaviour
	{
		protected StaffTakesErraticBreaksBehaviour()
		{
		}

		protected StaffTakesErraticBreaksBehaviour(Staff owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
