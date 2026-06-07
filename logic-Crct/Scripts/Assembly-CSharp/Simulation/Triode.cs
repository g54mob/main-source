using Unity.Burst;

namespace Simulation
{
	public class Triode : CircuitModel
	{
		public double currentp;

		public double currentg;

		public double currentc;

		private double mu;

		private double kg1;

		private double gridCurrentR;

		private double lastv0;

		private double lastv1;

		private double lastv2;

		public Circuit.Lead leadPlate => null;

		public Circuit.Lead leadGrid => null;

		public Circuit.Lead leadCath => null;

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void Reset()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
