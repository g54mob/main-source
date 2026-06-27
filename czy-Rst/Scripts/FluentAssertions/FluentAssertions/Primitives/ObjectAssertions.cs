using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	public class ObjectAssertions : ObjectAssertions<object, ObjectAssertions>
	{
		private readonly AssertionChain assertionChain;

		public ObjectAssertions(object value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<ObjectAssertions> Be<TExpectation>(TExpectation expected, IEqualityComparer<TExpectation> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject is TExpectation x && comparer.Equals(x, expected)).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<ObjectAssertions>(this);
		}

		public AndConstraint<ObjectAssertions> NotBe<TExpectation>(TExpectation unexpected, IEqualityComparer<TExpectation> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.ForCondition(!(base.Subject is TExpectation x) || !comparer.Equals(x, unexpected)).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Did not expect {context} to be equal to {0}{reason}.", unexpected);
			return new AndConstraint<ObjectAssertions>(this);
		}

		public AndConstraint<ObjectAssertions> BeOneOf<TExpectation>(IEnumerable<TExpectation> validValues, IEqualityComparer<TExpectation> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(validValues, "validValues");
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.ForCondition(base.Subject is TExpectation value && validValues.Contains(value, comparer)).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be one of {0}{reason}, but found {1}.", validValues, base.Subject);
			return new AndConstraint<ObjectAssertions>(this);
		}
	}
	public class ObjectAssertions<TSubject, TAssertions> : ReferenceTypeAssertions<TSubject, TAssertions> where TAssertions : ObjectAssertions<TSubject, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "object";

		public ObjectAssertions(TSubject value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> Be(TSubject expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(ObjectExtensions.GetComparer<TSubject>()(base.Subject, expected)).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(TSubject expected, IEqualityComparer<TSubject> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(comparer.Equals(base.Subject, expected)).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(TSubject unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!ObjectExtensions.GetComparer<TSubject>()(base.Subject, unexpected)).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Did not expect {context} to be equal to {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(TSubject unexpected, IEqualityComparer<TSubject> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.ForCondition(!comparer.Equals(base.Subject, unexpected)).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Did not expect {context} to be equal to {0}{reason}.", unexpected);
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

		public AndConstraint<TAssertions> NotBeEquivalentTo<TExpectation>(TExpectation unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeEquivalentTo(unexpected, (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo<TExpectation>(TExpectation unexpected, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			bool condition;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				BeEquivalentTo(unexpected, config, "");
				condition = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} not to be equivalent to {0}{reason}, but they are.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params TSubject[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<TSubject> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(validValues.Contains(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be one of {0}{reason}, but found {1}.", validValues, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<TSubject> validValues, IEqualityComparer<TSubject> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(validValues, "validValues");
			Guard.ThrowIfArgumentIsNull(comparer, "comparer");
			assertionChain.ForCondition(validValues.Contains(base.Subject, comparer)).BecauseOf(because, becauseArgs).FailWith("Expected {context:object} to be one of {0}{reason}, but found {1}.", validValues, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() or BeSameAs() instead?");
		}
	}
}
