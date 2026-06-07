namespace Mirror
{
	public class ExponentialMovingAverage
	{
		private readonly float alpha;

		private bool initialized;

		public double Value { get; private set; }

		public double Var { get; private set; }

		public ExponentialMovingAverage(int n)
		{
		}

		public void Add(double newValue)
		{
		}
	}
}
