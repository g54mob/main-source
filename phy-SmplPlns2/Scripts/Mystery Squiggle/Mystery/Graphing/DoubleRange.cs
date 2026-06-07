namespace Mystery.Graphing
{
	public class DoubleRange : ValueRange<double>
	{
		private double min = double.MaxValue;

		private double max = double.MinValue;

		public override double Min
		{
			get
			{
				return min;
			}
			set
			{
				min = value;
			}
		}

		public override double Max
		{
			get
			{
				return max;
			}
			set
			{
				max = value;
			}
		}

		public override void UpdateMin(double value)
		{
			if (value < min)
			{
				min = value;
			}
		}

		public override void UpdateMax(double value)
		{
			if (value > max)
			{
				max = value;
			}
		}

		public override void Reset()
		{
			min = double.MaxValue;
			max = double.MinValue;
		}
	}
}
