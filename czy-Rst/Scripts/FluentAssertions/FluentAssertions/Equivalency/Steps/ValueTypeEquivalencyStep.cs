using System;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class ValueTypeEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			Type expectationType = comparands.GetExpectedType(context.Options);
			EqualityStrategy strategy = context.Options.GetEqualityStrategy(expectationType);
			EqualityStrategy equalityStrategy = strategy;
			if ((equalityStrategy == EqualityStrategy.Equals || equalityStrategy == EqualityStrategy.ForceEquals) ? true : false)
			{
				context.Tracer.WriteLine(delegate(INode member)
				{
					string text = ((strategy == EqualityStrategy.Equals) ? $"{expectationType} overrides Equals" : "we are forced to use Equals");
					return "Treating " + member.Expectation.Description + " as a value type because " + text + ".";
				});
				AssertionChain.GetOrCreate().For(context).ReuseOnce();
				comparands.Subject.Should().Be(comparands.Expectation, context.Reason.FormattedMessage, context.Reason.Arguments);
				return EquivalencyResult.EquivalencyProven;
			}
			return EquivalencyResult.ContinueWithNext;
		}
	}
}
