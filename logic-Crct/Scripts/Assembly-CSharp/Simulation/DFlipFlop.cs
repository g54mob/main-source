namespace Simulation
{
	public class DFlipFlop : Chip
	{
		private bool _hasReset;

		private bool _hasSet;

		public Circuit.Lead leadD => null;

		public Circuit.Lead leadQ => null;

		public Circuit.Lead leadQL => null;

		public Circuit.Lead leadCLK => null;

		public bool hasResetPin
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool hasSetPin
		{
			get
			{
				return false;
			}
			set
			{
			}
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

		public override void Reset()
		{
		}

		public override void execute()
		{
		}
	}
}
