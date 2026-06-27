using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public abstract class MemberInfoAssertions<TSubject, TAssertions> : ReferenceTypeAssertions<TSubject, TAssertions> where TSubject : MemberInfo where TAssertions : MemberInfoAssertions<TSubject, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "member";

		private protected virtual string SubjectDescription => $"{base.Subject.DeclaringType}.{base.Subject.Name}";

		protected MemberInfoAssertions(TSubject subject, AssertionChain assertionChain)
			: base(subject, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndWhichConstraint<MemberInfoAssertions<TSubject, TAssertions>, TAttribute> BeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			return BeDecoratedWith((TAttribute _) => true, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			return NotBeDecoratedWith((TAttribute _) => true, because, becauseArgs);
		}

		public AndWhichConstraint<MemberInfoAssertions<TSubject, TAssertions>, TAttribute> BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {Identifier} to be decorated with {typeof(TAttribute)}{{reason}}" + ", but {context:member} is <null>.");
			IEnumerable<TAttribute> enumerable = Array.Empty<TAttribute>();
			if (assertionChain.Succeeded)
			{
				enumerable = base.Subject.GetMatchingAttributes(isMatchingAttributePredicate);
				assertionChain.ForCondition(enumerable.Any()).BecauseOf(because, becauseArgs).FailWith($"Expected {Identifier} {SubjectDescription} to be decorated with {typeof(TAttribute)}{{reason}}" + ", but that attribute was not found.");
			}
			return new AndWhichConstraint<MemberInfoAssertions<TSubject, TAssertions>, TAttribute>(this, enumerable, assertionChain);
		}

		public AndConstraint<TAssertions> NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {Identifier} to not be decorated with {typeof(TAttribute)}{{reason}}" + ", but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				IEnumerable<TAttribute> matchingAttributes = base.Subject.GetMatchingAttributes(isMatchingAttributePredicate);
				assertionChain.ForCondition(!matchingAttributes.Any()).BecauseOf(because, becauseArgs).FailWith($"Expected {Identifier} {SubjectDescription} to not be decorated with {typeof(TAttribute)}{{reason}}" + ", but that attribute was found.");
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
