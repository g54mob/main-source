namespace Mystery.Graphing
{
	public abstract class LineGraphOverTime<T> : LinearLineGraph<float, T>, ILineGraphOverTime, ILinearLineGraph, IPlottableGraph
	{
		private static FloatValueTransformer ValueTransformer;

		public override ValueTransformer<float> ValueTransformerX
		{
			get
			{
				if (ValueTransformer == null)
				{
					ValueTransformer = new FloatValueTransformer();
				}
				return ValueTransformer;
			}
		}

		public override ValueRange<float> CreateRangeX()
		{
			return new TimeRange();
		}

		public void CleanUpBefore(float time)
		{
			while (base.Count > 0)
			{
				if (base.First.ValueX < time)
				{
					RemoveFirst();
					continue;
				}
				base.DefaultRangeX.Min = base.First.ValueX;
				break;
			}
			base.DefaultRangeX.Min = time;
		}

		public void CleanUpAfter(float time)
		{
			while (base.Count > 0)
			{
				if (base.Last.ValueX > time)
				{
					RemoveLast();
					continue;
				}
				base.DefaultRangeX.Max = base.Last.ValueX;
				break;
			}
			base.DefaultRangeX.Max = time;
		}
	}
}
