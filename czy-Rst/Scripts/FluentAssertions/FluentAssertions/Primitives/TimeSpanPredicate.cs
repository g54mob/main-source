using System;

namespace FluentAssertions.Primitives
{
	internal class TimeSpanPredicate
	{
		private readonly Func<TimeSpan, TimeSpan, bool> lambda;

		public string DisplayText { get; }

		public TimeSpanPredicate(Func<TimeSpan, TimeSpan, bool> lambda, string displayText)
		{
			this.lambda = lambda;
			DisplayText = displayText;
		}

		public bool IsMatchedBy(TimeSpan actual, TimeSpan expected)
		{
			if (lambda(actual, expected))
			{
				return actual >= TimeSpan.Zero;
			}
			return false;
		}
	}
}
