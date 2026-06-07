namespace Simulation
{
	public class SipoShiftElm : Chip
	{
		public short data;

		public bool clockstate;

		private bool hasReset()
		{
			return false;
		}

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

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override void execute()
		{
		}
	}
}
