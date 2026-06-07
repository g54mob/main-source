namespace Simulation
{
	public class JumperWire : CircuitModel
	{
		private readonly double maxCurrent;

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override string GetName()
		{
			return null;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool IsWire()
		{
			return false;
		}

		public override void MatrixInitialise()
		{
		}

		public override void CheckFail()
		{
		}
	}
}
