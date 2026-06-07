namespace Simulation
{
	public class Capacitor : CircuitModel
	{
		public bool Polarized;

		public bool IsTrapezoidal;

		private double _capacitance;

		private double _maximumReverseVoltage;

		private double _compResistance;

		private double _voltageDelta;

		private double _currentSourceValue;

		private int _rightSide0;

		private int _rightSide1;

		public double Capacitance
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public Capacitor()
		{
		}

		public Capacitor(double c)
		{
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
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

		public override void CheckFail()
		{
		}

		public override void Step()
		{
		}
	}
}
