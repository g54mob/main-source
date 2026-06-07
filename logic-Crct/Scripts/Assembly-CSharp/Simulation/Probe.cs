namespace Simulation
{
	public class Probe : CircuitModel
	{
		public Circuit.Lead leadIn => null;

		public Circuit.Lead leadOut => null;

		public override bool leadsAreConnected(int n1, int n2)
		{
			return false;
		}
	}
}
