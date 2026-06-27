using System;
using System.Collections.Generic;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class EqualityComparerEquivalencyStep<T> : IEquivalencyStep
	{
		private readonly IEqualityComparer<T> comparer;

		public EqualityComparerEquivalencyStep(IEqualityComparer<T> comparer)
		{
			this.comparer = comparer ?? throw new ArgumentNullException("comparer");
		}

		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if ((context.Options.UseRuntimeTyping ? comparands.RuntimeType : comparands.CompileTimeType) != typeof(T))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			if (comparands.Subject == null || comparands.Expectation == null)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain.GetOrCreate().For(context).BecauseOf(context.Reason.FormattedMessage, context.Reason.Arguments)
				.ForCondition(comparands.Subject is T)
				.FailWith("Expected {context:object} to be of type {0}{because}, but found {1}", typeof(T), comparands.Subject)
				.Then.Given(() => comparer.Equals((T)comparands.Subject, (T)comparands.Expectation)).ForCondition((bool isEqual) => isEqual).FailWith("Expected {context:object} to be equal to {1} according to {0}{because}, but {2} was not.", comparer.ToString(), comparands.Expectation, comparands.Subject);
			return EquivalencyResult.EquivalencyProven;
		}

		public override string ToString()
		{
			return $"Use {comparer} for objects of type {typeof(T)}";
		}
	}
}
