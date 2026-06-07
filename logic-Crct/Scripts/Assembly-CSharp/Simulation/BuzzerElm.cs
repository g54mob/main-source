namespace Simulation
{
	public class BuzzerElm : CircuitModel
	{
		public int type;

		public int soundCounter;

		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public override void MatrixInitialise()
		{
		}

		public override void CheckFail()
		{
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}

		public override void Reset()
		{
		}
	}
}
