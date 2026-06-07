using Unity.Burst;

namespace Simulation
{
	public class TappedTransformer : CircuitModel
	{
		public double[] current;

		private double[] a;

		private double[] curSourceValue;

		private double[] voltdiff;

		public double inductance { get; set; }

		public double ratio { get; set; }

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
