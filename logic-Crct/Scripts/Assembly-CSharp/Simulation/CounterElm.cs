namespace Simulation
{
	public class CounterElm : Chip
	{
		private bool _hasEnable;

		public bool hasEnable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool invertReset { get; set; }

		public override bool needsBits()
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
