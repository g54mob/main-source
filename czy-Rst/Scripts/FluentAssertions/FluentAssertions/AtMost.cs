namespace FluentAssertions
{
	public static class AtMost
	{
		private sealed class AtMostTimesConstraint : OccurrenceConstraint
		{
			internal override string Mode => "at most";

			internal AtMostTimesConstraint(int expectedCount)
				: base(expectedCount)
			{
			}

			internal override bool Assert(int actual)
			{
				return actual <= base.ExpectedCount;
			}
		}

		public static OccurrenceConstraint Once()
		{
			return new AtMostTimesConstraint(1);
		}

		public static OccurrenceConstraint Twice()
		{
			return new AtMostTimesConstraint(2);
		}

		public static OccurrenceConstraint Thrice()
		{
			return new AtMostTimesConstraint(3);
		}

		public static OccurrenceConstraint Times(int expected)
		{
			return new AtMostTimesConstraint(expected);
		}
	}
}
