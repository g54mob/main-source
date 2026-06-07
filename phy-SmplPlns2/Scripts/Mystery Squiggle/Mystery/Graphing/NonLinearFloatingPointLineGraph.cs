namespace Mystery.Graphing
{
	public class NonLinearFloatingPointLineGraph : NonLinearLineGraph<float, float>
	{
		private static FloatValueTransformer defaultRangeTransformer;

		public override ValueTransformer<float> ValueTransformerX
		{
			get
			{
				if (defaultRangeTransformer == null)
				{
					defaultRangeTransformer = new FloatValueTransformer();
				}
				return defaultRangeTransformer;
			}
		}

		public override ValueTransformer<float> ValueTransformerY
		{
			get
			{
				if (defaultRangeTransformer == null)
				{
					defaultRangeTransformer = new FloatValueTransformer();
				}
				return defaultRangeTransformer;
			}
		}

		public override ValueRange<float> CreateRangeX()
		{
			return new FloatRange();
		}

		public override ValueRange<float> CreateRangeY()
		{
			return new FloatRange();
		}
	}
}
