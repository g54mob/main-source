namespace Simulation
{
	public class Resistor : CircuitModel
	{
		public double MaxPower;

		public double Resistance;

		public Resistor()
		{
		}

		public Resistor(double r)
		{
		}

		public override string GetName()
		{
			return null;
		}

		public override double GetPower()
		{
			return 0.0;
		}

		public override void CalculateCurrent()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override void CheckFail()
		{
		}
	}
}
