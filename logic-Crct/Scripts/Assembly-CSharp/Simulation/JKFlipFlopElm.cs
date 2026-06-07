namespace Simulation
{
	public class JKFlipFlopElm : Chip
	{
		private bool _hasReset;

		public Circuit.Lead leadJ => null;

		public Circuit.Lead leadCLK => null;

		public Circuit.Lead leadK => null;

		public Circuit.Lead leadQ => null;

		public Circuit.Lead leadQL => null;

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
