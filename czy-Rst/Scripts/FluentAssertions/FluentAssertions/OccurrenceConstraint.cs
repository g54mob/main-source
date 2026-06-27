using System;
using FluentAssertions.Common;

namespace FluentAssertions
{
	public abstract class OccurrenceConstraint
	{
		internal int ExpectedCount { get; }

		internal abstract string Mode { get; }

		protected OccurrenceConstraint(int expectedCount)
		{
			if (expectedCount < 0)
			{
				throw new ArgumentOutOfRangeException("expectedCount", "Expected count cannot be negative.");
			}
			ExpectedCount = expectedCount;
		}

		internal abstract bool Assert(int actual);

		internal void RegisterContextData(Action<string, object> register)
		{
			register("expectedOccurrence", Mode + " " + ExpectedCount.Times());
		}
	}
}
