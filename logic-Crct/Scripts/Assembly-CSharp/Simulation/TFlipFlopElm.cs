namespace Simulation
{
	public class TFlipFlopElm : Chip
	{
		private bool _hasReset;

		private bool _hasSet;

		private bool last_val;

		public Circuit.Lead leadT => null;

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
