using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Numeric
{
	[DebuggerNonUserCode]
	public class NullableNumericAssertions<T> : NullableNumericAssertions<T, NullableNumericAssertions<T>> where T : struct, IComparable<T>
	{
		public NullableNumericAssertions(T? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class NullableNumericAssertions<T, TAssertions> : NumericAssertionsBase<T, T?, TAssertions> where T : struct, IComparable<T> where TAssertions : NullableNumericAssertions<T, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public override T? Subject { get; }

		public NullableNumericAssertions(T? value, AssertionChain assertionChain)
			: base(assertionChain)
		{
			Subject = value;
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> HaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected a value{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotHaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Did not expect a value{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> Match(Expression<Func<T?, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.ForCondition(predicate.Compile()(Subject)).BecauseOf(because, becauseArgs).FailWith("Expected value to match {0}{reason}, but found {1}.", predicate, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
