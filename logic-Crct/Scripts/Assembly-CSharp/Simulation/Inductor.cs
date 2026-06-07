namespace Simulation
{
	public class Inductor : CircuitModel
	{
		public bool IsTrapezoidal;

		private double _compResistance;

		private double _currentSourceValue;

		private double _voltageDelta;

		private double _henry;

		private int _rightSide0;

		private int _rightSide1;

		public double Henry
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public Inductor()
		{
		}

		public Inductor(double h)
		{
		}

		public override void Reset()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override void GetMatrixPointers()
		{
		}

		public override void InitStep()
		{
		}

		public override void CalculateCurrent()
		{
		}

		public override void Step()
		{
		}
	}
}
