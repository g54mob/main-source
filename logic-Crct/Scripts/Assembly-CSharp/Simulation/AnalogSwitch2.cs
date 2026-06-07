using Unity.Burst;

namespace Simulation
{
	public class AnalogSwitch2 : AnalogSwitch
	{
		public override int GetLeadCount()
		{
			return 0;
		}

		public override void CalculateCurrent()
		{
		}

		public override void MatrixInitialise()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
