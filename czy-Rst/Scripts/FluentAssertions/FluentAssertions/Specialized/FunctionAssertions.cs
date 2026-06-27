using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	[DebuggerNonUserCode]
	public class FunctionAssertions<T> : DelegateAssertions<Func<T>, FunctionAssertions<T>>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "function";

		public FunctionAssertions(Func<T> subject, IExtractExceptions extractor, AssertionChain assertionChain)
			: base(subject, extractor, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public FunctionAssertions(Func<T> subject, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(subject, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		protected override void InvokeSubject()
		{
			base.Subject();
		}

		public AndWhichConstraint<FunctionAssertions<T>, T> NotThrow([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw{reason}, but found <null>.");
			T subject = default(T);
			if (assertionChain.Succeeded)
			{
				try
				{
					subject = base.Subject();
				}
				catch (Exception ex)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect any exception{reason}, but found {0}.", ex);
					subject = default(T);
				}
			}
			return new AndWhichConstraint<FunctionAssertions<T>, T>(this, subject, assertionChain, ".Result");
		}

		public AndWhichConstraint<FunctionAssertions<T>, T> NotThrowAfter(TimeSpan waitTime, TimeSpan pollInterval, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw any exceptions after {0}{reason}, but found <null>.", waitTime);
			T subject = default(T);
			if (assertionChain.Succeeded)
			{
				subject = NotThrowAfter(base.Subject, base.Clock, waitTime, pollInterval, because, becauseArgs);
			}
			return new AndWhichConstraint<FunctionAssertions<T>, T>(this, subject, assertionChain, ".Result");
		}

		internal TResult NotThrowAfter<TResult>(Func<TResult> subject, IClock clock, TimeSpan waitTime, TimeSpan pollInterval, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(waitTime, "waitTime");
			Guard.ThrowIfArgumentIsNegative(pollInterval, "pollInterval");
			TimeSpan? timeSpan = null;
			Exception ex = null;
			ITimer timer = clock.StartTimer();
			while (!timeSpan.HasValue || timeSpan < waitTime)
			{
				try
				{
					return subject();
				}
				catch (Exception ex2)
				{
					ex = ex2;
				}
				clock.Delay(pollInterval);
				timeSpan = timer.Elapsed;
			}
			assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect any exceptions after {0}{reason}, but found {1}.", waitTime, ex);
			return default(TResult);
		}
	}
}
