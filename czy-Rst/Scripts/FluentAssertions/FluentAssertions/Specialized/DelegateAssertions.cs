using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	[DebuggerNonUserCode]
	public abstract class DelegateAssertions<TDelegate, TAssertions> : DelegateAssertionsBase<TDelegate, TAssertions> where TDelegate : Delegate where TAssertions : DelegateAssertions<TDelegate, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected DelegateAssertions(TDelegate @delegate, IExtractExceptions extractor, AssertionChain assertionChain)
			: base(@delegate, extractor, assertionChain, (IClock)new Clock())
		{
			this.assertionChain = assertionChain;
		}

		private protected DelegateAssertions(TDelegate @delegate, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(@delegate, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		public ExceptionAssertions<TException> Throw<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			assertionChain.ForCondition((object)base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to throw {0}{reason}, but found <null>.", typeof(TException));
			if (assertionChain.Succeeded)
			{
				FailIfSubjectIsAsyncVoid();
				Exception exception = InvokeSubjectWithInterception();
				return ThrowInternal<TException>(exception, because, becauseArgs);
			}
			return new ExceptionAssertions<TException>(Array.Empty<TException>(), assertionChain);
		}

		public AndConstraint<TAssertions> NotThrow<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			assertionChain.ForCondition((object)base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw {0}{reason}, but found <null>.", typeof(TException));
			if (assertionChain.Succeeded)
			{
				FailIfSubjectIsAsyncVoid();
				Exception exception = InvokeSubjectWithInterception();
				return NotThrowInternal<TException>(exception, because, becauseArgs);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public ExceptionAssertions<TException> ThrowExactly<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			assertionChain.ForCondition((object)base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to throw exactly {0}{reason}, but found <null>.", typeof(TException));
			if (assertionChain.Succeeded)
			{
				FailIfSubjectIsAsyncVoid();
				Exception ex = InvokeSubjectWithInterception();
				Type typeFromHandle = typeof(TException);
				assertionChain.ForCondition(ex != null).BecauseOf(because, becauseArgs).FailWith("Expected {0}{reason}, but no exception was thrown.", typeFromHandle);
				if (assertionChain.Succeeded)
				{
					AssertionExtensions.Should(ex).BeOfType(typeFromHandle, because, becauseArgs);
				}
				return new ExceptionAssertions<TException>(new _003C_003Ez__ReadOnlySingleElementList<TException>(ex as TException), assertionChain);
			}
			return new ExceptionAssertions<TException>(Array.Empty<TException>(), assertionChain);
		}

		protected abstract void InvokeSubject();

		private protected Exception InvokeSubjectWithInterception()
		{
			Exception result = null;
			try
			{
				using (CallerIdentifier.OnlyOneFluentAssertionScopeOnCallStack() ? CallerIdentifier.OverrideStackSearchUsingCurrentScope() : null)
				{
					InvokeSubject();
				}
			}
			catch (Exception ex)
			{
				result = ex;
			}
			return result;
		}

		private protected void FailIfSubjectIsAsyncVoid()
		{
			if (base.Subject.GetMethodInfo().IsDecoratedWithOrInherit<AsyncStateMachineAttribute>())
			{
				throw new InvalidOperationException("Cannot use action assertions on an async void method. Assign the async method to a variable of type Func<Task> instead of Action so that it can be awaited.");
			}
		}
	}
}
