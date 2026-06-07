namespace Simulation
{
	public class JfetElm : MOSFET
	{
		public JfetElm(bool pnpflag)
		{
		}

		public override double GetDefaultThreshold()
		{
			return 0.0;
		}

		public override double GetBeta()
		{
			return 0.0;
		}
	}
}
