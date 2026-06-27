using System.Xml.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class XElementEquivalencyStep : EquivalencyStep<XElement>
	{
		protected override EquivalencyResult OnHandle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency nestedValidator)
		{
			XElement actualValue = (XElement)comparands.Subject;
			XElement expected = (XElement)comparands.Expectation;
			AssertionChain.GetOrCreate().For(context).ReuseOnce();
			actualValue.Should().BeEquivalentTo(expected, context.Reason.FormattedMessage, context.Reason.Arguments);
			return EquivalencyResult.EquivalencyProven;
		}
	}
}
