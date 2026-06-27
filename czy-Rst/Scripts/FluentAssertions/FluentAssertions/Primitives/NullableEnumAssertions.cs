using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	public class NullableEnumAssertions<TEnum> : NullableEnumAssertions<TEnum, NullableEnumAssertions<TEnum>> where TEnum : struct, Enum
	{
		public NullableEnumAssertions(TEnum? subject, AssertionChain assertionChain)
			: base(subject, assertionChain)
		{
		}
	}
	public class NullableEnumAssertions<TEnum, TAssertions> : EnumAssertions<TEnum, TAssertions> where TEnum : struct, Enum where TAssertions : NullableEnumAssertions<TEnum, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public NullableEnumAssertions(TEnum? subject, AssertionChain assertionChain)
			: base(subject, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndWhichConstraint<TAssertions, TEnum> HaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:nullable enum} to have a value{reason}, but found {0}.", base.Subject);
			return new AndWhichConstraint<TAssertions, TEnum>((TAssertions)this, base.Subject.GetValueOrDefault(), assertionChain, ".Value");
		}

		public AndWhichConstraint<TAssertions, TEnum> NotBeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotHaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:nullable enum} to have a value{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveValue(because, becauseArgs);
		}
	}
}
