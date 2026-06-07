namespace Simulation
{
	public class _74HC161Element : _74HCBase
	{
		private int _CLR;

		private int CLK;

		private int A;

		private int B;

		private int C;

		private int D;

		private int ENP;

		private int _LOAD;

		private int ENT;

		private int Qd;

		private int Qc;

		private int Qb;

		private int Qa;

		private int RCO;

		private Pin[] outputPins;

		private bool lastClock0;

		private bool lastClock1;

		private bool lastClock2;

		private bool lastClock3;

		private bool clockPulse;

		private bool wasMax;

		private int clockValue;

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
