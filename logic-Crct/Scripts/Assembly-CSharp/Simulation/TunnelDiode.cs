using Unity.Burst;

namespace Simulation
{
	public class TunnelDiode : CircuitModel
	{
		private static readonly double pvp;

		private static readonly double pip;

		private static readonly double pvv;

		private static readonly double pvt;

		private static readonly double pvpp;

		private static readonly double piv;

		private double lastvoltdiff;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void Reset()
		{
		}

		public double limitStep(double vnew, double vold)
		{
			return 0.0;
		}

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override void CalculateCurrent()
		{
		}
	}
}
