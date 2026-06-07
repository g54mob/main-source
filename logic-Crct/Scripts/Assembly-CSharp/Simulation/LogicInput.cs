namespace Simulation
{
	public class LogicInput : TactileSwitch
	{
		public Circuit.Lead leadOut => null;

		public double highVoltage { get; set; }

		public double lowVoltage { get; set; }

		public bool isTernary { get; set; }

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void setCurrent(int vs, double c)
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override bool IsLeadGround(int n1)
		{
			return false;
		}
	}
}
