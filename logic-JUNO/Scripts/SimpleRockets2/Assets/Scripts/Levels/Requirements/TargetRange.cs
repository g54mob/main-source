namespace Assets.Scripts.Levels.Requirements
{
	public class TargetRange
	{
		public double HighMargin { get; }

		public double LowMargin { get; }

		public double Target { get; }

		public TargetRange(double target, double lowMargin = 0.0, double highMargin = 0.0)
		{
			Target = target;
			LowMargin = lowMargin;
			HighMargin = highMargin;
		}

		public bool IsValid(double currentValue)
		{
			if (currentValue >= Target - LowMargin)
			{
				return currentValue <= Target + HighMargin;
			}
			return false;
		}
	}
}
