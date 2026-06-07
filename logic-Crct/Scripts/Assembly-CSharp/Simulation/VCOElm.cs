using Unity.Burst;

namespace Simulation
{
	public class VCOElm : Chip
	{
		public double cResistance;

		public double cCurrent;

		public int cDir;

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public void computeCurrent()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}
	}
}
