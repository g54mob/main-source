using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class MethodInfoAssertions : MethodBaseAssertions<MethodInfo, MethodInfoAssertions>
	{
		private readonly AssertionChain assertionChain;

		private protected override string SubjectDescription => GetDescriptionFor(base.Subject);

		protected override string Identifier => "method";

		public MethodInfoAssertions(MethodInfo methodInfo, AssertionChain assertionChain)
			: base(methodInfo, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<MethodInfoAssertions> BeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method to be virtual{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(!base.Subject.IsNonVirtual()).BecauseOf(because, becauseArgs).FailWith("Expected method " + SubjectDescription + " to be virtual{reason}, but it is not virtual.");
			}
			return new AndConstraint<MethodInfoAssertions>(this);
		}

		public AndConstraint<MethodInfoAssertions> NotBeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method not to be virtual{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(base.Subject.IsNonVirtual()).BecauseOf(because, becauseArgs).FailWith("Expected method " + SubjectDescription + " not to be virtual{reason}, but it is.");
			}
			return new AndConstraint<MethodInfoAssertions>(this);
		}

		public AndConstraint<MethodInfoAssertions> BeAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method to be async{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(base.Subject.IsAsync()).BecauseOf(because, becauseArgs).FailWith("Expected method " + SubjectDescription + " to be async{reason}, but it is not.");
			}
			return new AndConstraint<MethodInfoAssertions>(this);
		}

		public AndConstraint<MethodInfoAssertions> NotBeAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method not to be async{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(!base.Subject.IsAsync()).BecauseOf(because, becauseArgs).FailWith("Expected method " + SubjectDescription + " not to be async{reason}, but it is.");
			}
			return new AndConstraint<MethodInfoAssertions>(this);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> ReturnVoid([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected the return type of method to be void{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(typeof(void) == base.Subject.ReturnType).BecauseOf(because, becauseArgs).FailWith("Expected the return type of method " + base.Subject.Name + " to be void{reason}, but it is {0}.", base.Subject.ReturnType.FullName);
			}
			return new AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>>(this);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> Return(Type returnType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(returnType, "returnType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected the return type of method to be {0}{reason}, but {context:member} is <null>.", returnType);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(returnType == base.Subject.ReturnType).BecauseOf(because, becauseArgs).FailWith("Expected the return type of method " + base.Subject.Name + " to be {0}{reason}, but it is {1}.", returnType, base.Subject.ReturnType.FullName);
			}
			return new AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>>(this);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> Return<TReturn>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return Return(typeof(TReturn), because, becauseArgs);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> NotReturnVoid([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected the return type of method not to be void{reason}, but {context:member} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(typeof(void) != base.Subject.ReturnType).BecauseOf(because, becauseArgs).FailWith("Expected the return type of method " + base.Subject.Name + " not to be void{reason}, but it is.");
			}
			return new AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>>(this);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> NotReturn(Type returnType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(returnType, "returnType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected the return type of method not to be {0}{reason}, but {context:member} is <null>.", returnType);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(returnType != base.Subject.ReturnType).BecauseOf(because, becauseArgs).FailWith("Expected the return type of method " + base.Subject.Name + " not to be {0}{reason}, but it is.", returnType);
			}
			return new AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>>(this);
		}

		public AndConstraint<MethodBaseAssertions<MethodInfo, MethodInfoAssertions>> NotReturn<TReturn>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotReturn(typeof(TReturn), because, becauseArgs);
		}

		internal static string GetDescriptionFor(MethodInfo method)
		{
			if ((object)method == null)
			{
				return string.Empty;
			}
			string name = method.ReturnType.Name;
			return $"{name} {method.DeclaringType}.{method.Name}";
		}
	}
}
