namespace Simulation
{
	public class FullAdder : Chip
	{
		public Circuit.Lead leadOut1 => null;

		public Circuit.Lead leadOut2 => null;

		public Circuit.Lead leadIn0 => null;

		public Circuit.Lead leadIn1 => null;

		public Circuit.Lead leadIn2 => null;

		public override string GetName()
		{
			return null;
		}

		private bool hasReset()
		{
			return false;
		}

		public override void SetupPins()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override void execute()
		{
		}
	}
}
