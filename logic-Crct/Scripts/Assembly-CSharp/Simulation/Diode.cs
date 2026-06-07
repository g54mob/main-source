namespace Simulation
{
	public class Diode
	{
		private ConductanceStamp_t _conductanceStamp;

		private int _rightSide0;

		private int _rightSide1;

		private int[] lead_node;

		public double Leakage;

		private double vt;

		private double vdcoef;

		private double fwdrop;

		private double zvoltage;

		private double zoffset;

		private double lastvoltdiff;

		private double vcrit;

		public void Reset()
		{
		}

		public void MatrixInitialise(int n0, int n1)
		{
		}

		public void DefineMatrixUnknowns(int n0, int n1)
		{
		}

		public void GetMatrixPointers()
		{
		}

		public void Initialise(double fw, double zv, double l)
		{
		}

		public void reset()
		{
		}

		public double limitStep(double vnew, double vold)
		{
			return 0.0;
		}

		public void Step(double voltdiff, double accuracy = 0.01)
		{
		}

		public double CalculateCurrent(double voltdiff)
		{
			return 0.0;
		}
	}
}
