namespace Simulation
{
	public class ADCElm : Chip
	{
		public override string GetName()
		{
			return null;
		}

		public override bool needsBits()
		{
			return false;
		}

		public override void SetupPins()
		{
		}

		public override void execute()
		{
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override int GetLeadCount()
		{
			return 0;
		}
	}
}
