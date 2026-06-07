using Unity.Burst;

namespace Simulation
{
	public class InvertingSchmittTrigger : CircuitModel
	{
		protected bool state;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double slewRate { get; private set; }

		public double lowerTrigger { get; private set; }

		public double upperTrigger { get; private set; }

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}
	}
}
