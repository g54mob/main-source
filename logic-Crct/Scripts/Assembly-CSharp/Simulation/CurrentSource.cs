namespace Simulation
{
	public class CurrentSource : CircuitModel
	{
		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public double sourceCurrent { get; set; }

		public override void MatrixInitialise()
		{
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}
	}
}
