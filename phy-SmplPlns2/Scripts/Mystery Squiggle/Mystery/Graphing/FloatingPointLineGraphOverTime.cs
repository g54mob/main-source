namespace Mystery.Graphing
{
	public class FloatingPointLineGraphOverTime : LineGraphOverTime<double>
	{
		private static DoubleValueTransformer defaultRangeTransformer;

		public override ValueTransformer<double> ValueTransformerY
		{
			get
			{
				if (defaultRangeTransformer == null)
				{
					defaultRangeTransformer = new DoubleValueTransformer();
				}
				return defaultRangeTransformer;
			}
		}

		public override ValueRange<double> CreateRangeY()
		{
			return new DoubleRange();
		}
	}
}
