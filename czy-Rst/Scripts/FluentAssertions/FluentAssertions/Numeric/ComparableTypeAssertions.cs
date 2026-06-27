using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	public class ComparableTypeAssertions<T> : ComparableTypeAssertions<T, ComparableTypeAssertions<T>>
	{
		public ComparableTypeAssertions(IComparable<T> value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class ComparableTypeAssertions<T, TAssertions> : ReferenceTypeAssertions<IComparable<T>, TAssertions> where TAssertions : ComparableTypeAssertions<T, TAssertions>
	{
		private const int Equal = 0;

		private readonly AssertionChain assertionChain;

		protected override string Identifier => "object";

		public ComparableTypeAssertions(IComparable<T> value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> Be(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(object.Equals(base.Subject, expected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be equal to {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(TExpectation expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeEquivalentTo(expectation, (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(TExpectation expectation, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<TExpectation> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<TExpectation>());
			EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<TExpectation>(() => base.CurrentAssertionChain.CallerIdentifier), equivalencyOptions)
			{
				Reason = new Reason(because, becauseArgs),
				TraceWriter = equivalencyOptions.TraceWriter
			};
			Comparands comparands = new Comparands
			{
				Subject = base.Subject,
				Expectation = expectation,
				CompileTimeType = typeof(TExpectation)
			};
			new EquivalencyValidator().AssertEquality(comparands, context);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!object.Equals(base.Subject, unexpected)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:object} to be equal to {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeRankedEquallyTo(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(expected) == 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} to be ranked as equal to {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeRankedEquallyTo(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(unexpected) != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} not to be ranked as equal to {1}{reason}.", base.Subject, unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThan(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(expected) < 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} to be less than {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThanOrEqualTo(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(expected) <= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} to be less than or equal to {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThan(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(expected) > 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} to be greater than {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThanOrEqualTo(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(expected) >= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} {0} to be greater than or equal to {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeInRange(T minimumValue, T maximumValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(minimumValue) >= 0 && base.Subject.CompareTo(maximumValue) <= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be between {0} and {1}{reason}, but found {2}.", minimumValue, maximumValue, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeInRange(T minimumValue, T maximumValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.CompareTo(minimumValue) < 0 || base.Subject.CompareTo(maximumValue) > 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to not be between {0} and {1}{reason}, but found {2}.", minimumValue, maximumValue, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params T[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<T> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(validValues.Any((T val) => object.Equals(base.Subject, val))).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be one of {0}{reason}, but found {1}.", validValues, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
