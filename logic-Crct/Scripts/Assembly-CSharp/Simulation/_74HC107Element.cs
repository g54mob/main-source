namespace Simulation
{
	public class _74HC107Element : _74HCBase
	{
		private const int J1 = 0;

		private const int _Q1 = 1;

		private const int Q1 = 2;

		private const int K1 = 3;

		private const int Q2 = 4;

		private const int _Q2 = 5;

		private const int J2 = 7;

		private const int _CP2 = 8;

		private const int _R2 = 9;

		private const int K2 = 10;

		private const int _CP1 = 11;

		private const int _R1 = 12;

		private bool last_CP1;

		private bool last_CP2;

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

		public override void ExecuteLogic()
		{
		}
	}
}
