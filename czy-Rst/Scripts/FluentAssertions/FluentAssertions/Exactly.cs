namespace FluentAssertions
{
	public static class Exactly
	{
		private sealed class ExactlyTimesConstraint : OccurrenceConstraint
		{
			internal override string Mode => "exactly";

			internal ExactlyTimesConstraint(int expectedCount)
				: base(expectedCount)
			{
			}

			internal override bool Assert(int actual)
			{
				return actual == base.ExpectedCount;
			}
		}

		public static OccurrenceConstraint Once()
		{
			return new ExactlyTimesConstraint(1);
		}

		public static OccurrenceConstraint Twice()
		{
			return new ExactlyTimesConstraint(2);
		}

		public static OccurrenceConstraint Thrice()
		{
			return new ExactlyTimesConstraint(3);
		}

		public static OccurrenceConstraint Times(int expected)
		{
			return new ExactlyTimesConstraint(expected);
		}
	}
}
