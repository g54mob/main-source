namespace Simulation
{
	public abstract class _74HCBase : CircuitModel
	{
		public double VIN_MAX;

		public double VIN_MIN;

		public double SINK_MAX;

		public double SOURCE_MAX;

		public double V_HL;

		public double V_LL;

		public double GND_VL;

		protected int bits;

		protected Pin[] pins;

		protected bool lastClock;

		protected int Vcc;

		protected int GND;

		protected double maxVcc;

		protected double macCurr;

		private ConductanceStamp_t[] _conductanceStamps_On;

		private ConductanceStamp_t[] _conductanceStamps_Off;

		private double _r;

		private int[] failCounters;

		public _74HCBase()
		{
		}

		public virtual void SetupPins()
		{
		}

		public virtual void ExecuteLogic()
		{
		}

		public virtual bool needsBits()
		{
			return false;
		}

		public override void MatrixInitialise()
		{
		}

		public override void DefineMatrixUnknowns()
		{
		}

		public override void GetMatrixPointers()
		{
		}

		public override void Step()
		{
		}

		public override void Reset()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public override string GetName()
		{
			return null;
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}

		public override void CheckFail()
		{
		}
	}
}
