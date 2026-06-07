namespace Simulation
{
	public class IC7476Elm : Chip
	{
		private int CLK1;

		private int PRE1;

		private int CLR1;

		private int J1;

		private int K1;

		private int Q1;

		private int iQ1;

		private int CLK2;

		private int PRE2;

		private int CLR2;

		private int J2;

		private int K2;

		private int Q2;

		private int iQ2;

		private Pin[] outputPins;

		private bool lastClock1;

		private bool lastClock2;

		private bool clockPulse1;

		private bool clockPulse2;

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

		public override void Reset()
		{
		}

		public override void execute()
		{
		}
	}
}
