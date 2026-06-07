namespace Mystery.Graphing
{
	public abstract class LineGraphOverFrames<T> : LinearLineGraph<long, T>
	{
		private static LongValueTransformer ValueTransformer;

		public override ValueTransformer<long> ValueTransformerX
		{
			get
			{
				if (ValueTransformer == null)
				{
					ValueTransformer = new LongValueTransformer();
				}
				return ValueTransformer;
			}
		}

		public override ValueRange<long> CreateRangeX()
		{
			return new LongRange();
		}

		public void CleanUpBefore(long time)
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

		public void CleanUpAfter(long time)
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
