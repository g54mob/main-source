namespace FluentAssertions
{
	public static class AtLeast
	{
		private sealed class AtLeastTimesConstraint : OccurrenceConstraint
		{
			internal override string Mode => "at least";

			internal AtLeastTimesConstraint(int expectedCount)
				: base(expectedCount)
			{
			}

			internal override bool Assert(int actual)
			{
				return actual >= base.ExpectedCount;
			}
		}

		public static OccurrenceConstraint Once()
		{
			return new AtLeastTimesConstraint(1);
		}

		public static OccurrenceConstraint Twice()
		{
			return new AtLeastTimesConstraint(2);
		}

		public static OccurrenceConstraint Thrice()
		{
			return new AtLeastTimesConstraint(3);
		}

		public static OccurrenceConstraint Times(int expected)
		{
			return new AtLeastTimesConstraint(expected);
		}
	}
}
