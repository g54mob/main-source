using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	[DebuggerNonUserCode]
	public class ActionAssertions : DelegateAssertions<Action, ActionAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "action";

		public ActionAssertions(Action subject, IExtractExceptions extractor, AssertionChain assertionChain)
			: base(subject, extractor, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public ActionAssertions(Action subject, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(subject, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<ActionAssertions> NotThrow([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				FailIfSubjectIsAsyncVoid();
				Exception exception = InvokeSubjectWithInterception();
				return NotThrowInternal(exception, because, becauseArgs);
			}
			return new AndConstraint<ActionAssertions>(this);
		}

		public AndConstraint<ActionAssertions> NotThrowAfter(TimeSpan waitTime, TimeSpan pollInterval, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(waitTime, "waitTime");
			Guard.ThrowIfArgumentIsNegative(pollInterval, "pollInterval");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw after {0}{reason}, but found <null>.", waitTime);
			if (assertionChain.Succeeded)
			{
				FailIfSubjectIsAsyncVoid();
				TimeSpan? timeSpan = null;
				Exception ex = null;
				ITimer timer = base.Clock.StartTimer();
				while (!timeSpan.HasValue || timeSpan < waitTime)
				{
					ex = InvokeSubjectWithInterception();
					if (ex == null)
					{
						break;
					}
					base.Clock.Delay(pollInterval);
					timeSpan = timer.Elapsed;
				}
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(ex == null).FailWith("Did not expect any exceptions after {0}{reason}, but found {1}.", waitTime, ex);
			}
			return new AndConstraint<ActionAssertions>(this);
		}

		protected override void InvokeSubject()
		{
			base.Subject();
		}
	}
}
