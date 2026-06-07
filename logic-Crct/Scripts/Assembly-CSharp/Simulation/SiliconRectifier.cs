using Unity.Burst;

namespace Simulation
{
	public class SiliconRectifier : CircuitModel
	{
		private static readonly int anode;

		private static readonly int cnode;

		private static readonly int gnode;

		private static readonly int inode;

		private Diode diode;

		private double ia;

		private double ic;

		private double ig;

		private double lastvac;

		private double lastvag;

		public double aresistance;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public Circuit.Lead leadGate => null;

		public double cresistance { get; set; }

		public double triggerI { get; set; }

		public double holdingI { get; set; }

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

		public override int getInternalLeadCount()
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

		public string[] getInfo()
		{
			return null;
		}

		public override void CalculateCurrent()
		{
		}
	}
}
