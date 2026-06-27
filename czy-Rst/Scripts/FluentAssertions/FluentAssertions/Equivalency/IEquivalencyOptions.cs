using System;
using System.Collections.Generic;
using FluentAssertions.Equivalency.Tracing;

namespace FluentAssertions.Equivalency
{
	public interface IEquivalencyOptions
	{
		IEnumerable<IMemberSelectionRule> SelectionRules { get; }

		IEnumerable<IMemberMatchingRule> MatchingRules { get; }

		bool IsRecursive { get; }

		bool AllowInfiniteRecursion { get; }

		CyclicReferenceHandling CyclicReferenceHandling { get; }

		OrderingRuleCollection OrderingRules { get; }

		ConversionSelector ConversionSelector { get; }

		EnumEquivalencyHandling EnumEquivalencyHandling { get; }

		IEnumerable<IEquivalencyStep> UserEquivalencySteps { get; }

		bool UseRuntimeTyping { get; }

		MemberVisibility IncludedProperties { get; }

		MemberVisibility IncludedFields { get; }

		bool IgnoreNonBrowsableOnSubject { get; }

		bool ExcludeNonBrowsableOnExpectation { get; }

		bool? CompareRecordsByValue { get; }

		ITraceWriter TraceWriter { get; }

		bool IgnoreLeadingWhitespace { get; }

		bool IgnoreTrailingWhitespace { get; }

		bool IgnoreCase { get; }

		bool IgnoreNewlineStyle { get; }

		EqualityStrategy GetEqualityStrategy(Type type);
	}
}
