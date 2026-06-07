namespace Simulation
{
	public class Ground : Output
	{
		public override void setCurrent(int x, double c)
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}
	}
}
