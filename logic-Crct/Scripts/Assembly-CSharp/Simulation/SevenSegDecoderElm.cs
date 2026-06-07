namespace Simulation
{
	public class SevenSegDecoderElm : Chip
	{
		private static bool[,] symbols;

		public bool hasReset()
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
