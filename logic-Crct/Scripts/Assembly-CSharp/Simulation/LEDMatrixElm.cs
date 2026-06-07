namespace Simulation
{
	public class LEDMatrixElm : Chip
	{
		public bool negateRows { get; set; }

		public bool negateColumns { get; set; }

		public double colorR { get; set; }

		public double colorG { get; set; }

		public double colorB { get; set; }

		public override string GetName()
		{
			return null;
		}

		public override void SetupPins()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override int GetVoltageSourceCount()
		{
			return 0;
		}
	}
}
