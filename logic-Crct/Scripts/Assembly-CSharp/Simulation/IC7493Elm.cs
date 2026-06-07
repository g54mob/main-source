namespace Simulation
{
	public class IC7493Elm : Chip
	{
		private int CP0;

		private int CP1;

		private int MR1;

		private int MR2;

		private int Q0;

		private int Q1;

		private int Q2;

		private int Q3;

		private Pin[] outputPins;

		private bool lastClock0;

		private bool lastClock1;

		private bool lastClock2;

		private bool lastClock3;

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void execute()
		{
		}
	}
}
