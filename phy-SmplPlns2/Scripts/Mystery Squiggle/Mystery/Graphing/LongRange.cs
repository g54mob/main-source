namespace Mystery.Graphing
{
	public class LongRange : ValueRange<long>
	{
		private long min = long.MaxValue;

		private long max = long.MinValue;

		public override long Min
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

		public override long Max
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

		public override void UpdateMin(long value)
		{
			if (value < min)
			{
				min = value;
			}
		}

		public override void UpdateMax(long value)
		{
			if (value > max)
			{
				max = value;
			}
		}

		public override void Reset()
		{
			min = long.MaxValue;
			max = long.MinValue;
		}
	}
}
