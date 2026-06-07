using Unity.Burst;

namespace Simulation
{
	public class Transformer : CircuitModel
	{
		public double[] current;

		private double a1;

		private double a2;

		private double a3;

		private double a4;

		private double curSourceValue1;

		private double curSourceValue2;

		public double inductance { get; set; }

		public double ratio { get; set; }

		public double couplingCoef { get; set; }

		public bool isTrapezoidal { get; set; }

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void Reset()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override void InitStep()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
