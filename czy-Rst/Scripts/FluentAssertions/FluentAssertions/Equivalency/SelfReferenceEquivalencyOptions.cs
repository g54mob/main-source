using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Matching;
using FluentAssertions.Equivalency.Ordering;
using FluentAssertions.Equivalency.Selection;
using FluentAssertions.Equivalency.Steps;
using FluentAssertions.Equivalency.Tracing;

namespace FluentAssertions.Equivalency
{
	public abstract class SelfReferenceEquivalencyOptions<TSelf> : IEquivalencyOptions where TSelf : SelfReferenceEquivalencyOptions<TSelf>
	{
		public class Restriction<TMember>
		{
			private readonly Action<IAssertionContext<TMember>> action;

			private readonly TSelf options;

			public Restriction(TSelf options, Action<IAssertionContext<TMember>> action)
			{
				this.options = options;
				this.action = action;
			}

			public TSelf WhenTypeIs<TMemberType>() where TMemberType : TMember
			{
				When((IObjectInfo info) => info.RuntimeType.IsSameOrInherits(typeof(TMemberType)));
				return options;
			}

			public TSelf When(Expression<Func<IObjectInfo, bool>> predicate)
			{
				options.userEquivalencySteps.Insert(0, new AssertionRuleEquivalencyStep<TMember>(predicate, action));
				return options;
			}
		}

		private readonly EqualityStrategyProvider equalityStrategyProvider;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly List<IMemberSelectionRule> selectionRules = new List<IMemberSelectionRule>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly List<IMemberMatchingRule> matchingRules = new List<IMemberMatchingRule>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly List<IEquivalencyStep> userEquivalencySteps = new List<IEquivalencyStep>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CyclicReferenceHandling cyclicReferenceHandling = CyclicReferenceHandling.ThrowException;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isRecursive;

		private bool allowInfiniteRecursion;

		private EnumEquivalencyHandling enumEquivalencyHandling;

		private bool useRuntimeTyping;

		private MemberVisibility includedProperties;

		private MemberVisibility includedFields;

		private bool ignoreNonBrowsableOnSubject;

		private bool excludeNonBrowsableOnExpectation;

		private IEqualityComparer<string> stringComparer;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected OrderingRuleCollection OrderingRules { get; } = new OrderingRuleCollection();

		IEnumerable<IMemberSelectionRule> IEquivalencyOptions.SelectionRules
		{
			get
			{
				bool hasConflictingRules = selectionRules.Exists((IMemberSelectionRule rule) => rule.IncludesMembers);
				if (includedProperties.HasFlag(MemberVisibility.Public) && !hasConflictingRules)
				{
					yield return new AllPropertiesSelectionRule();
				}
				if (includedFields.HasFlag(MemberVisibility.Public) && !hasConflictingRules)
				{
					yield return new AllFieldsSelectionRule();
				}
				if (excludeNonBrowsableOnExpectation)
				{
					yield return new ExcludeNonBrowsableMembersRule();
				}
				foreach (IMemberSelectionRule selectionRule in selectionRules)
				{
					yield return selectionRule;
				}
			}
		}

		IEnumerable<IMemberMatchingRule> IEquivalencyOptions.MatchingRules => matchingRules;

		IEnumerable<IEquivalencyStep> IEquivalencyOptions.UserEquivalencySteps => userEquivalencySteps;

		public ConversionSelector ConversionSelector { get; } = new ConversionSelector();

		OrderingRuleCollection IEquivalencyOptions.OrderingRules => OrderingRules;

		bool IEquivalencyOptions.IsRecursive => isRecursive;

		bool IEquivalencyOptions.AllowInfiniteRecursion => allowInfiniteRecursion;

		CyclicReferenceHandling IEquivalencyOptions.CyclicReferenceHandling => cyclicReferenceHandling;

		EnumEquivalencyHandling IEquivalencyOptions.EnumEquivalencyHandling => enumEquivalencyHandling;

		bool IEquivalencyOptions.UseRuntimeTyping => useRuntimeTyping;

		MemberVisibility IEquivalencyOptions.IncludedProperties => includedProperties;

		MemberVisibility IEquivalencyOptions.IncludedFields => includedFields;

		bool IEquivalencyOptions.IgnoreNonBrowsableOnSubject => ignoreNonBrowsableOnSubject;

		bool IEquivalencyOptions.ExcludeNonBrowsableOnExpectation => excludeNonBrowsableOnExpectation;

		public bool? CompareRecordsByValue => equalityStrategyProvider.CompareRecordsByValue;

		public bool IgnoreLeadingWhitespace { get; private set; }

		public bool IgnoreTrailingWhitespace { get; private set; }

		public bool IgnoreCase { get; private set; }

		public bool IgnoreNewlineStyle { get; private set; }

		public ITraceWriter TraceWriter { get; private set; }

		private protected SelfReferenceEquivalencyOptions()
		{
			equalityStrategyProvider = new EqualityStrategyProvider();
			AddMatchingRule(new MustMatchByNameRule());
			OrderingRules.Add(new ByteArrayOrderingRule());
		}

		protected SelfReferenceEquivalencyOptions(IEquivalencyOptions defaults)
		{
			equalityStrategyProvider = new EqualityStrategyProvider(defaults.GetEqualityStrategy)
			{
				CompareRecordsByValue = defaults.CompareRecordsByValue
			};
			isRecursive = defaults.IsRecursive;
			cyclicReferenceHandling = defaults.CyclicReferenceHandling;
			allowInfiniteRecursion = defaults.AllowInfiniteRecursion;
			enumEquivalencyHandling = defaults.EnumEquivalencyHandling;
			useRuntimeTyping = defaults.UseRuntimeTyping;
			includedProperties = defaults.IncludedProperties;
			includedFields = defaults.IncludedFields;
			ignoreNonBrowsableOnSubject = defaults.IgnoreNonBrowsableOnSubject;
			excludeNonBrowsableOnExpectation = defaults.ExcludeNonBrowsableOnExpectation;
			IgnoreLeadingWhitespace = defaults.IgnoreLeadingWhitespace;
			IgnoreTrailingWhitespace = defaults.IgnoreTrailingWhitespace;
			IgnoreCase = defaults.IgnoreCase;
			IgnoreNewlineStyle = defaults.IgnoreNewlineStyle;
			ConversionSelector = defaults.ConversionSelector.Clone();
			selectionRules.AddRange(defaults.SelectionRules);
			userEquivalencySteps.AddRange(defaults.UserEquivalencySteps);
			matchingRules.AddRange(defaults.MatchingRules);
			OrderingRules = new OrderingRuleCollection(defaults.OrderingRules);
			TraceWriter = defaults.TraceWriter;
			RemoveSelectionRule<AllPropertiesSelectionRule>();
			RemoveSelectionRule<AllFieldsSelectionRule>();
		}

		EqualityStrategy IEquivalencyOptions.GetEqualityStrategy(Type type)
		{
			return equalityStrategyProvider.GetEqualityStrategy(type);
		}

		public TSelf IncludingAllDeclaredProperties()
		{
			PreferringDeclaredMemberTypes();
			ExcludingFields();
			IncludingProperties();
			WithoutSelectionRules();
			return (TSelf)this;
		}

		public TSelf IncludingAllRuntimeProperties()
		{
			PreferringRuntimeMemberTypes();
			ExcludingFields();
			IncludingProperties();
			WithoutSelectionRules();
			return (TSelf)this;
		}

		public TSelf IncludingFields()
		{
			includedFields = MemberVisibility.Public;
			return (TSelf)this;
		}

		public TSelf IncludingInternalFields()
		{
			includedFields = MemberVisibility.Internal | MemberVisibility.Public;
			return (TSelf)this;
		}

		public TSelf ExcludingFields()
		{
			includedFields = MemberVisibility.None;
			return (TSelf)this;
		}

		public TSelf IncludingProperties()
		{
			includedProperties = MemberVisibility.Public | MemberVisibility.ExplicitlyImplemented | MemberVisibility.DefaultInterfaceProperties;
			return (TSelf)this;
		}

		public TSelf IncludingInternalProperties()
		{
			includedProperties = MemberVisibility.Internal | MemberVisibility.Public | MemberVisibility.ExplicitlyImplemented | MemberVisibility.DefaultInterfaceProperties;
			return (TSelf)this;
		}

		public TSelf ExcludingProperties()
		{
			includedProperties = MemberVisibility.None;
			return (TSelf)this;
		}

		public TSelf ExcludingExplicitlyImplementedProperties()
		{
			includedProperties &= ~MemberVisibility.ExplicitlyImplemented;
			return (TSelf)this;
		}

		public TSelf ExcludingNonBrowsableMembers()
		{
			excludeNonBrowsableOnExpectation = true;
			return (TSelf)this;
		}

		public TSelf IgnoringNonBrowsableMembersOnSubject()
		{
			ignoreNonBrowsableOnSubject = true;
			return (TSelf)this;
		}

		public TSelf PreferringRuntimeMemberTypes()
		{
			useRuntimeTyping = true;
			return (TSelf)this;
		}

		public TSelf PreferringDeclaredMemberTypes()
		{
			useRuntimeTyping = false;
			return (TSelf)this;
		}

		public TSelf Excluding(Expression<Func<IMemberInfo, bool>> predicate)
		{
			AddSelectionRule(new ExcludeMemberByPredicateSelectionRule(predicate));
			return (TSelf)this;
		}

		public TSelf Including(Expression<Func<IMemberInfo, bool>> predicate)
		{
			AddSelectionRule(new IncludeMemberByPredicateSelectionRule(predicate));
			return (TSelf)this;
		}

		public TSelf ExcludingMissingMembers()
		{
			matchingRules.RemoveAll((IMemberMatchingRule x) => x is MustMatchByNameRule);
			matchingRules.Add(new TryMatchByNameRule());
			return (TSelf)this;
		}

		public TSelf ThrowingOnMissingMembers()
		{
			matchingRules.RemoveAll((IMemberMatchingRule x) => x is TryMatchByNameRule);
			matchingRules.Add(new MustMatchByNameRule());
			return (TSelf)this;
		}

		public Restriction<TProperty> Using<TProperty>(Action<IAssertionContext<TProperty>> action)
		{
			return new Restriction<TProperty>((TSelf)this, action);
		}

		public TSelf IncludingNestedObjects()
		{
			isRecursive = true;
			return (TSelf)this;
		}

		public TSelf WithoutRecursing()
		{
			isRecursive = false;
			return (TSelf)this;
		}

		public TSelf IgnoringCyclicReferences()
		{
			cyclicReferenceHandling = CyclicReferenceHandling.Ignore;
			return (TSelf)this;
		}

		public TSelf AllowingInfiniteRecursion()
		{
			allowInfiniteRecursion = true;
			return (TSelf)this;
		}

		public TSelf WithoutSelectionRules()
		{
			selectionRules.Clear();
			return (TSelf)this;
		}

		public TSelf WithoutMatchingRules()
		{
			matchingRules.Clear();
			return (TSelf)this;
		}

		public TSelf Using(IMemberSelectionRule selectionRule)
		{
			return AddSelectionRule(selectionRule);
		}

		public TSelf Using(IMemberMatchingRule matchingRule)
		{
			return AddMatchingRule(matchingRule);
		}

		public TSelf Using(IOrderingRule orderingRule)
		{
			return AddOrderingRule(orderingRule);
		}

		public TSelf Using(IEquivalencyStep equivalencyStep)
		{
			return AddEquivalencyStep(equivalencyStep);
		}

		public TSelf Using<T, TEqualityComparer>() where TEqualityComparer : IEqualityComparer<T>, new()
		{
			return Using(new TEqualityComparer());
		}

		public TSelf Using<T>(IEqualityComparer<T> comparer)
		{
			userEquivalencySteps.Insert(0, new EqualityComparerEquivalencyStep<T>(comparer));
			return (TSelf)this;
		}

		public TSelf Using(IEqualityComparer<string> comparer)
		{
			userEquivalencySteps.Insert(0, new EqualityComparerEquivalencyStep<string>(comparer));
			stringComparer = comparer;
			return (TSelf)this;
		}

		public TSelf WithStrictOrdering()
		{
			OrderingRules.Clear();
			OrderingRules.Add(new MatchAllOrderingRule());
			return (TSelf)this;
		}

		public TSelf WithStrictOrderingFor(Expression<Func<IObjectInfo, bool>> predicate)
		{
			OrderingRules.Add(new PredicateBasedOrderingRule(predicate));
			return (TSelf)this;
		}

		public TSelf WithoutStrictOrdering()
		{
			OrderingRules.Clear();
			OrderingRules.Add(new ByteArrayOrderingRule());
			return (TSelf)this;
		}

		public TSelf WithoutStrictOrderingFor(Expression<Func<IObjectInfo, bool>> predicate)
		{
			OrderingRules.Add(new PredicateBasedOrderingRule(predicate)
			{
				Invert = true
			});
			return (TSelf)this;
		}

		public TSelf ComparingEnumsByName()
		{
			enumEquivalencyHandling = EnumEquivalencyHandling.ByName;
			return (TSelf)this;
		}

		public TSelf ComparingEnumsByValue()
		{
			enumEquivalencyHandling = EnumEquivalencyHandling.ByValue;
			return (TSelf)this;
		}

		public TSelf ComparingRecordsByValue()
		{
			equalityStrategyProvider.CompareRecordsByValue = true;
			return (TSelf)this;
		}

		public TSelf ComparingRecordsByMembers()
		{
			equalityStrategyProvider.CompareRecordsByValue = false;
			return (TSelf)this;
		}

		public TSelf ComparingByMembers<T>()
		{
			return ComparingByMembers(typeof(T));
		}

		public TSelf ComparingByMembers(Type type)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			if (type.IsPrimitive)
			{
				throw new InvalidOperationException("Cannot compare a primitive type such as " + type.Name + " by its members");
			}
			if (!equalityStrategyProvider.AddReferenceType(type))
			{
				throw new InvalidOperationException("Can't compare " + type.Name + " by its members if it already setup to be compared by value");
			}
			return (TSelf)this;
		}

		public TSelf ComparingByValue<T>()
		{
			return ComparingByValue(typeof(T));
		}

		public TSelf ComparingByValue(Type type)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			if (!equalityStrategyProvider.AddValueType(type))
			{
				throw new InvalidOperationException("Can't compare " + type.Name + " by value if it already setup to be compared by its members");
			}
			return (TSelf)this;
		}

		public TSelf WithTracing(ITraceWriter writer = null)
		{
			TraceWriter = writer ?? new StringBuilderTraceWriter();
			return (TSelf)this;
		}

		public TSelf WithAutoConversion()
		{
			ConversionSelector.IncludeAll();
			return (TSelf)this;
		}

		public TSelf WithAutoConversionFor(Expression<Func<IObjectInfo, bool>> predicate)
		{
			ConversionSelector.Include(predicate);
			return (TSelf)this;
		}

		public TSelf WithoutAutoConversionFor(Expression<Func<IObjectInfo, bool>> predicate)
		{
			ConversionSelector.Exclude(predicate);
			return (TSelf)this;
		}

		public TSelf IgnoringLeadingWhitespace()
		{
			IgnoreLeadingWhitespace = true;
			return (TSelf)this;
		}

		public TSelf IgnoringTrailingWhitespace()
		{
			IgnoreTrailingWhitespace = true;
			return (TSelf)this;
		}

		public TSelf IgnoringCase()
		{
			IgnoreCase = true;
			return (TSelf)this;
		}

		public TSelf IgnoringNewlineStyle()
		{
			IgnoreNewlineStyle = true;
			return (TSelf)this;
		}

		internal IEqualityComparer<string> GetStringComparerOrDefault()
		{
			object ordinalIgnoreCase = stringComparer;
			if (ordinalIgnoreCase == null)
			{
				if (!IgnoreCase)
				{
					return StringComparer.Ordinal;
				}
				ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
			}
			return (IEqualityComparer<string>)ordinalIgnoreCase;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("- Prefer the ").Append(useRuntimeTyping ? "runtime" : "declared").AppendLine(" type of the members");
			if (ignoreNonBrowsableOnSubject)
			{
				stringBuilder.AppendLine("- Do not consider members marked non-browsable on the subject");
			}
			if (isRecursive && allowInfiniteRecursion)
			{
				stringBuilder.AppendLine("- Recurse indefinitely");
			}
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "- Compare enums by {0}" + Environment.NewLine, (enumEquivalencyHandling == EnumEquivalencyHandling.ByName) ? "name" : "value");
			if (cyclicReferenceHandling == CyclicReferenceHandling.Ignore)
			{
				stringBuilder.AppendLine("- Ignoring cyclic references");
			}
			stringBuilder.AppendLine("- Compare tuples by their properties").AppendLine("- Compare anonymous types by their properties").Append(equalityStrategyProvider);
			if (excludeNonBrowsableOnExpectation)
			{
				stringBuilder.AppendLine("- Exclude non-browsable members");
			}
			else
			{
				stringBuilder.AppendLine("- Include non-browsable members");
			}
			foreach (IMemberSelectionRule selectionRule in selectionRules)
			{
				stringBuilder.Append("- ").AppendLine(selectionRule.ToString());
			}
			foreach (IMemberMatchingRule matchingRule in matchingRules)
			{
				stringBuilder.Append("- ").AppendLine(matchingRule.ToString());
			}
			foreach (IEquivalencyStep userEquivalencyStep in userEquivalencySteps)
			{
				stringBuilder.Append("- ").AppendLine(userEquivalencyStep.ToString());
			}
			foreach (IOrderingRule orderingRule in OrderingRules)
			{
				stringBuilder.Append("- ").AppendLine(orderingRule.ToString());
			}
			stringBuilder.Append("- ").AppendLine(ConversionSelector.ToString());
			return stringBuilder.ToString();
		}

		private void RemoveSelectionRule<T>() where T : IMemberSelectionRule
		{
			selectionRules.RemoveAll((IMemberSelectionRule selectionRule) => selectionRule is T);
		}

		protected internal TSelf AddSelectionRule(IMemberSelectionRule selectionRule)
		{
			selectionRules.Add(selectionRule);
			return (TSelf)this;
		}

		protected TSelf AddMatchingRule(IMemberMatchingRule matchingRule)
		{
			matchingRules.Insert(0, matchingRule);
			return (TSelf)this;
		}

		private TSelf AddOrderingRule(IOrderingRule orderingRule)
		{
			OrderingRules.Add(orderingRule);
			return (TSelf)this;
		}

		private TSelf AddEquivalencyStep(IEquivalencyStep equivalencyStep)
		{
			userEquivalencySteps.Add(equivalencyStep);
			return (TSelf)this;
		}
	}
}
