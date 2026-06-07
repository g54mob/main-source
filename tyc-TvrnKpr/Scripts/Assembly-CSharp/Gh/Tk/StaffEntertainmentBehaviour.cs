namespace Gh.Tk
{
	public class StaffEntertainmentBehaviour : StaffBehaviour
	{
		private const int minDuration = 60;

		private const int maxDuration = 90;

		protected StaffEntertainmentBehaviour()
		{
		}

		public StaffEntertainmentBehaviour(Staff owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}
	}
}
