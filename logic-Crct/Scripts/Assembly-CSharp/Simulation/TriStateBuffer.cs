using Unity.Burst;

namespace Simulation
{
	public class TriStateBuffer : CircuitModel
	{
		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public Circuit.Lead leadGate => null;

		public double resistance { get; private set; }

		public double r_on { get; set; }

		public double r_off { get; set; }

		public bool open { get; private set; }

		public override void CalculateCurrent()
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

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
