namespace Simulation
{
	public class IC7448Elm : Chip
	{
		private int LT;

		private int BIRBO;

		private int RBI;

		private Pin[] outputPins;

		private bool[,] truthTable;

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
