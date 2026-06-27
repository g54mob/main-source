using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	public class EnumAssertions<TEnum> : EnumAssertions<TEnum, EnumAssertions<TEnum>> where TEnum : struct, Enum
	{
		public EnumAssertions(TEnum subject, AssertionChain assertionChain)
			: base(subject, assertionChain)
		{
		}
	}
	public class EnumAssertions<TEnum, TAssertions> where TEnum : struct, Enum where TAssertions : EnumAssertions<TEnum, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public TEnum? Subject { get; }

		public EnumAssertions(TEnum subject, AssertionChain assertionChain)
			: this((TEnum?)subject, assertionChain)
		{
		}

		private protected EnumAssertions(TEnum? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> Be(TEnum expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject?.Equals(expected) ?? false).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(TEnum? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Nullable.Equals(Subject, expected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(TEnum unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			obj.ForCondition(!subject.HasValue || !subject.GetValueOrDefault().Equals(unexpected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} not to be {0}{reason}, but it is.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(TEnum? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!Nullable.Equals(Subject, unexpected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} not to be {0}{reason}, but it is.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeDefined([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the enum} to be defined in {0}{reason}, ", typeof(TEnum), delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found <null>.").Then.ForCondition(Enum.IsDefined(typeof(TEnum), Subject)).FailWith("but it is not.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeDefined([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect {context:the enum} to be defined in {0}{reason}, ", typeof(TEnum), delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found <null>.").Then.ForCondition(!Enum.IsDefined(typeof(TEnum), Subject)).FailWith("but it is.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveValue(decimal expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((GetValue(valueOrDefault) == expected) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to have value {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveValue(decimal unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((!(GetValue(valueOrDefault) == unexpected)) ? 1 : 0);
			}
			else
			{
				condition = 1;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to not have value {0}{reason}, but found {1}.", unexpected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveSameValueAs<T>(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : struct, Enum
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((GetValue(valueOrDefault) == GetValue(expected)) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to have same value as {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveSameValueAs<T>(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : struct, Enum
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((!(GetValue(valueOrDefault) == GetValue(unexpected))) ? 1 : 0);
			}
			else
			{
				condition = 1;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to not have same value as {0}{reason}, but found {1}.", unexpected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveSameNameAs<T>(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : struct, Enum
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((GetName(valueOrDefault) == GetName(expected)) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to have same name as {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveSameNameAs<T>(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : struct, Enum
		{
			AssertionChain obj = assertionChain;
			TEnum? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				TEnum valueOrDefault = subject.GetValueOrDefault();
				condition = ((!(GetName(valueOrDefault) == GetName(unexpected))) ? 1 : 0);
			}
			else
			{
				condition = 1;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to not have same name as {0}{reason}, but found {1}.", unexpected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveFlag(TEnum expectedFlag, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject?.HasFlag(expectedFlag) ?? false).FailWith("Expected {context:the enum} to have flag {0}{reason}, but found {1}.", expectedFlag, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveFlag(TEnum unexpectedFlag, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain.BecauseOf(because, becauseArgs);
			TEnum? subject = Subject;
			obj.ForCondition(!subject.HasValue || !subject.GetValueOrDefault().HasFlag(unexpectedFlag)).FailWith("Expected {context:the enum} to not have flag {0}{reason}.", unexpectedFlag);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Match(Expression<Func<TEnum?, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate", "Cannot match an enum against a <null> predicate.");
			assertionChain.ForCondition(predicate.Compile()(Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to match {1}{reason}, but found {0}.", Subject, predicate.Body);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params TEnum[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<TEnum> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(validValues, "validValues", "Cannot assert that an enum is one of a null list of enums");
			Guard.ThrowIfArgumentIsEmpty(validValues, "validValues", "Cannot assert that an enum is one of an empty list of enums");
			assertionChain.ForCondition(Subject.HasValue).FailWith("Expected {context:the enum} to be one of {0}{reason}, but found <null>", validValues).Then.ForCondition(validValues.Contains(Subject.Value)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the enum} to be one of {0}{reason}, but found {1}.", validValues, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private static decimal GetValue<T>(T @enum) where T : struct, Enum
		{
			return Convert.ToDecimal(@enum, CultureInfo.InvariantCulture);
		}

		private static string GetName<T>(T @enum) where T : struct, Enum
		{
			return @enum.ToString();
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
