namespace Simulation
{
	public class SevenSegmentDisplayElement : Chip
	{
		public double forwardV;

		public double leakage;

		public bool anode;

		private Diode[] segDiodes;

		private int[] segNodes;

		private double[] currents;

		private int[] failCounters;

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override void Reset()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void MatrixInitialise()
		{
		}

		public override void DefineMatrixUnknowns()
		{
		}

		public override void GetMatrixPointers()
		{
		}

		public override void CheckFail()
		{
		}

		public override void Step()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public double[] ReturnCurrents()
		{
			return null;
		}

		public override bool IsNonLinear()
		{
			return false;
		}
	}
}
