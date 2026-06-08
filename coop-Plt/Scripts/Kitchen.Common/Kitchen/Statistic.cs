using System.Collections.Generic;

namespace Kitchen
{
	public class Statistic<TIndex, TValue> : IStatistic<TValue>, IStatistic
	{
		protected struct ReportedValue
		{
			public TIndex Index;

			public TValue Value;

			public ReportedValue(TIndex i, TValue v)
			{
				Index = i;
				Value = v;
			}
		}

		protected List<ReportedValue> Values = new List<ReportedValue>();

		public virtual TValue ResultValue()
		{
			if (Values.Count == 0)
			{
				return default(TValue);
			}
			return Values[Values.Count - 1].Value;
		}

		public virtual void Report(TIndex time, TValue value)
		{
			Values.Add(new ReportedValue(time, value));
		}

		public void Clear()
		{
			Values.Clear();
		}

		public virtual string Summarise()
		{
			if (Values.Count == 0)
			{
				return "No values";
			}
			return $"Last: {ResultValue()}";
		}
	}
}
