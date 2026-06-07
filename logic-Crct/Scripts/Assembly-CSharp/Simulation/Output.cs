namespace Simulation
{
	public class Output : CircuitModel
	{
		public Circuit.Lead leadIn => null;

		public override int GetLeadCount()
		{
			return 0;
		}

		public override double GetVoltageDelta()
		{
			return 0.0;
		}
	}
}
