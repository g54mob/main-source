using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public abstract class MethodBaseAssertions<TSubject, TAssertions> : MemberInfoAssertions<TSubject, TAssertions> where TSubject : MethodBase where TAssertions : MethodBaseAssertions<TSubject, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected MethodBaseAssertions(TSubject subject, AssertionChain assertionChain)
			: base(subject, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> HaveAccessModifier(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected method to be {accessModifier}{{reason}}, but {{context:method}} is <null>.");
			if (assertionChain.Succeeded)
			{
				CSharpAccessModifier subjectAccessModifier = base.Subject.GetCSharpAccessModifier();
				assertionChain.ForCondition(accessModifier == subjectAccessModifier).BecauseOf(because, becauseArgs).FailWith(delegate
				{
					string arg = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("method " + base.Subject.ToFormattedString()));
					return new FailReason($"Expected {arg} to be {accessModifier}{{reason}}, but it is {subjectAccessModifier}.");
				});
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveAccessModifier(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected method not to be {accessModifier}{{reason}}, but {{context:member}} is <null>.");
			if (assertionChain.Succeeded)
			{
				CSharpAccessModifier cSharpAccessModifier = base.Subject.GetCSharpAccessModifier();
				assertionChain.ForCondition(accessModifier != cSharpAccessModifier).BecauseOf(because, becauseArgs).FailWith(delegate
				{
					string arg = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("method " + base.Subject.ToFormattedString()));
					return new FailReason($"Expected {arg} not to be {accessModifier}{{reason}}, but it is.");
				});
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		internal static string GetParameterString(MethodBase methodBase)
		{
			IEnumerable<Type> source = from p in methodBase.GetParameters()
				select p.ParameterType;
			return string.Join(", ", source.Select((Type p) => p.FullName));
		}
	}
}
