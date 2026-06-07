using Unity.Burst;

namespace Simulation
{
	public class PhaseCompElm : Chip
	{
		private bool ff1;

		private bool ff2;

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
