using Unity.Burst;

namespace Simulation
{
	public class AnalogSwitch : CircuitModel
	{
		private double resistance;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public Circuit.Lead leadSwitch => null;

		public bool invert { get; set; }

		public double r_on { get; set; }

		public double r_off { get; set; }

		public bool open { get; protected set; }

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

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
