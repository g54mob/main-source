namespace FluentAssertions
{
	public static class LessThan
	{
		private sealed class LessThanTimesConstraint : OccurrenceConstraint
		{
			internal override string Mode => "less than";

			internal LessThanTimesConstraint(int expectedCount)
				: base(expectedCount)
			{
			}

			internal override bool Assert(int actual)
			{
				return actual < base.ExpectedCount;
			}
		}

		public static OccurrenceConstraint Twice()
		{
			return new LessThanTimesConstraint(2);
		}

		public static OccurrenceConstraint Thrice()
		{
			return new LessThanTimesConstraint(3);
		}

		public static OccurrenceConstraint Times(int expected)
		{
			return new LessThanTimesConstraint(expected);
		}
	}
}
