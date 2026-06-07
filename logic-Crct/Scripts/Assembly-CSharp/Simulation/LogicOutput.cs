namespace Simulation
{
	public class LogicOutput : Output
	{
		public double threshold { get; set; }

		public bool needsPullDown { get; set; }

		public override void MatrixInitialise()
		{
		}

		public bool isHigh()
		{
			return false;
		}
	}
}
