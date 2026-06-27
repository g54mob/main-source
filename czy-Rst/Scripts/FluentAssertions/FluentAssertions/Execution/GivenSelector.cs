using System;
using System.Linq;
using FluentAssertions.Common;

namespace FluentAssertions.Execution
{
	public class GivenSelector<T>
	{
		private readonly AssertionChain assertionChain;

		private readonly T selector;

		public bool Succeeded => assertionChain.Succeeded;

		internal GivenSelector(Func<T> selector, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			this.selector = (assertionChain.Succeeded ? selector() : default(T));
		}

		public GivenSelector<T> ForCondition(Func<T, bool> predicate)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(predicate(selector));
			}
			return this;
		}

		public GivenSelector<TOut> Given<TOut>(Func<T, TOut> selector)
		{
			Guard.ThrowIfArgumentIsNull(selector, "selector");
			return new GivenSelector<TOut>(() => selector(this.selector), assertionChain);
		}

		public ContinuationOfGiven<T> FailWith(string message)
		{
			return FailWith(message, Array.Empty<object>());
		}

		public ContinuationOfGiven<T> FailWith(string message, params Func<T, object>[] args)
		{
			if (assertionChain.PreviousAssertionSucceeded)
			{
				object[] args2 = args.Select((Func<T, object> a) => a(selector)).ToArray();
				return FailWith(message, args2);
			}
			return new ContinuationOfGiven<T>(this);
		}

		public ContinuationOfGiven<T> FailWith(string message, params object[] args)
		{
			assertionChain.FailWith(message, args);
			return new ContinuationOfGiven<T>(this);
		}
	}
}
