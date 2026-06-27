using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	public abstract class NumericAssertionsBase<T, TSubject, TAssertions> where T : struct, IComparable<T> where TAssertions : NumericAssertionsBase<T, TSubject, TAssertions>
	{
		public abstract TSubject Subject { get; }

		public AssertionChain CurrentAssertionChain { get; }

		protected NumericAssertionsBase(AssertionChain assertionChain)
		{
			CurrentAssertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> Be(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && val.CompareTo(expected) == 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(T? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			int condition;
			if (expected.HasValue)
			{
				T valueOrDefault = expected.GetValueOrDefault();
				TSubject subject = Subject;
				condition = ((subject is T val && val.CompareTo(valueOrDefault) == 0) ? 1 : 0);
			}
			else
			{
				condition = ((!(Subject is T)) ? 1 : 0);
			}
			currentAssertionChain.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(!(subject is T val) || val.CompareTo(unexpected) != 0).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(T? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			int condition;
			if (unexpected.HasValue)
			{
				T valueOrDefault = unexpected.GetValueOrDefault();
				TSubject subject = Subject;
				condition = ((!(subject is T val) || val.CompareTo(valueOrDefault) != 0) ? 1 : 0);
			}
			else
			{
				condition = ((Subject is T) ? 1 : 0);
			}
			currentAssertionChain.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:value} to be {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BePositive([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && val.CompareTo(default(T)) > 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be positive{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNegative([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T value && !IsNaN(value) && value.CompareTo(default(T)) < 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be negative{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThan(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(expected))
			{
				throw new ArgumentException("A value can never be less than NaN", "expected");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T value && !IsNaN(value) && value.CompareTo(expected) < 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be less than {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThanOrEqualTo(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(expected))
			{
				throw new ArgumentException("A value can never be less than or equal to NaN", "expected");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T value && !IsNaN(value) && value.CompareTo(expected) <= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be less than or equal to {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThan(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(expected))
			{
				throw new ArgumentException("A value can never be greater than NaN", "expected");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && val.CompareTo(expected) > 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be greater than {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThanOrEqualTo(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(expected))
			{
				throw new ArgumentException("A value can never be greater than or equal to a NaN", "expected");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && val.CompareTo(expected) >= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be greater than or equal to {0}{reason}, but found {1}" + GenerateDifferenceMessage(expected), expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeInRange(T minimumValue, T maximumValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(minimumValue) || IsNaN(maximumValue))
			{
				throw new ArgumentException("A range cannot begin or end with NaN");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && val.CompareTo(minimumValue) >= 0 && val.CompareTo(maximumValue) <= 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be between {0} and {1}{reason}, but found {2}.", minimumValue, maximumValue, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeInRange(T minimumValue, T maximumValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (IsNaN(minimumValue) || IsNaN(maximumValue))
			{
				throw new ArgumentException("A range cannot begin or end with NaN");
			}
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T val && (val.CompareTo(minimumValue) < 0 || val.CompareTo(maximumValue) > 0)).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to not be between {0} and {1}{reason}, but found {2}.", minimumValue, maximumValue, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params T[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<T> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T value && validValues.Contains(value)).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to be one of {0}{reason}, but found {1}.", validValues, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOfType(Type expectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedType, "expectedType");
			TSubject subject = Subject;
			Type type = ((subject != null) ? subject.GetType() : null);
			if (expectedType.IsGenericTypeDefinition && (object)type != null && type.IsGenericType)
			{
				type.GetGenericTypeDefinition().Should().Be(expectedType, because, becauseArgs);
			}
			else
			{
				type.Should().Be(expectedType, because, becauseArgs);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOfType(Type unexpectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedType, "unexpectedType");
			CurrentAssertionChain.ForCondition(Subject is T).BecauseOf(because, becauseArgs).FailWith("Expected type not to be " + unexpectedType?.ToString() + "{reason}, but found <null>.");
			if (CurrentAssertionChain.Succeeded)
			{
				Subject.GetType().Should().NotBe(unexpectedType, because, becauseArgs);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Match(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			AssertionChain currentAssertionChain = CurrentAssertionChain;
			TSubject subject = Subject;
			currentAssertionChain.ForCondition(subject is T arg && predicate.Compile()(arg)).BecauseOf(because, becauseArgs).FailWith("Expected {context:value} to match {0}{reason}, but found {1}.", predicate.Body, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}

		private protected virtual bool IsNaN(T value)
		{
			return false;
		}

		private protected virtual string CalculateDifferenceForFailureMessage(T subject, T expected)
		{
			return null;
		}

		private string GenerateDifferenceMessage(T? expected)
		{
			TSubject subject = Subject;
			if (subject is T subject2 && expected.HasValue)
			{
				T valueOrDefault = expected.GetValueOrDefault();
				string text = CalculateDifferenceForFailureMessage(subject2, valueOrDefault);
				if (text != null)
				{
					return " (difference of " + text + ").";
				}
				return ".";
			}
			return ".";
		}
	}
}
