using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency.Ordering;
using FluentAssertions.Equivalency.Selection;
using FluentAssertions.Equivalency.Tracing;

namespace FluentAssertions.Equivalency.Execution
{
	internal class CollectionMemberOptionsDecorator : IEquivalencyOptions
	{
		private readonly IEquivalencyOptions inner;

		public IEnumerable<IMemberSelectionRule> SelectionRules => inner.SelectionRules.Select((IMemberSelectionRule rule) => new CollectionMemberSelectionRuleDecorator(rule)).ToArray();

		public IEnumerable<IMemberMatchingRule> MatchingRules => inner.MatchingRules.ToArray();

		public OrderingRuleCollection OrderingRules => new OrderingRuleCollection(inner.OrderingRules.Select((IOrderingRule rule) => new CollectionMemberOrderingRuleDecorator(rule)));

		public ConversionSelector ConversionSelector => inner.ConversionSelector;

		public IEnumerable<IEquivalencyStep> UserEquivalencySteps => inner.UserEquivalencySteps;

		public bool IsRecursive => inner.IsRecursive;

		public bool AllowInfiniteRecursion => inner.AllowInfiniteRecursion;

		public CyclicReferenceHandling CyclicReferenceHandling => inner.CyclicReferenceHandling;

		public EnumEquivalencyHandling EnumEquivalencyHandling => inner.EnumEquivalencyHandling;

		public bool UseRuntimeTyping => inner.UseRuntimeTyping;

		public MemberVisibility IncludedProperties => inner.IncludedProperties;

		public MemberVisibility IncludedFields => inner.IncludedFields;

		public bool IgnoreNonBrowsableOnSubject => inner.IgnoreNonBrowsableOnSubject;

		public bool ExcludeNonBrowsableOnExpectation => inner.ExcludeNonBrowsableOnExpectation;

		public bool? CompareRecordsByValue => inner.CompareRecordsByValue;

		public bool IgnoreLeadingWhitespace => inner.IgnoreLeadingWhitespace;

		public bool IgnoreTrailingWhitespace => inner.IgnoreTrailingWhitespace;

		public bool IgnoreCase => inner.IgnoreCase;

		public bool IgnoreNewlineStyle => inner.IgnoreNewlineStyle;

		public ITraceWriter TraceWriter => inner.TraceWriter;

		public CollectionMemberOptionsDecorator(IEquivalencyOptions inner)
		{
			this.inner = inner;
		}

		public EqualityStrategy GetEqualityStrategy(Type type)
		{
			return inner.GetEqualityStrategy(type);
		}
	}
}
