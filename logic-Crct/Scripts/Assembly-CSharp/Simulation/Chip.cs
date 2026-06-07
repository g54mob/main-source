using Unity.Burst;

namespace Simulation
{
	public abstract class Chip : CircuitModel
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

		public Chip()
		{
		}

		public virtual void SetupPins()
		{
		}

		public virtual void execute()
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

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override bool FailCondition()
		{
			return false;
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
	}
}
