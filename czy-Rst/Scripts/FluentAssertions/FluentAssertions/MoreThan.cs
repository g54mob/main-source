namespace FluentAssertions
{
	public static class MoreThan
	{
		private sealed class MoreThanTimesConstraint : OccurrenceConstraint
		{
			internal override string Mode => "more than";

			internal MoreThanTimesConstraint(int expectedCount)
				: base(expectedCount)
			{
			}

			internal override bool Assert(int actual)
			{
				return actual > base.ExpectedCount;
			}
		}

		public static OccurrenceConstraint Once()
		{
			return new MoreThanTimesConstraint(1);
		}

		public static OccurrenceConstraint Twice()
		{
			return new MoreThanTimesConstraint(2);
		}

		public static OccurrenceConstraint Thrice()
		{
			return new MoreThanTimesConstraint(3);
		}

		public static OccurrenceConstraint Times(int expected)
		{
			return new MoreThanTimesConstraint(expected);
		}
	}
}
