using System.Xml.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class XAttributeEquivalencyStep : EquivalencyStep<XAttribute>
	{
		protected override EquivalencyResult OnHandle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency nestedValidator)
		{
			XAttribute actualValue = (XAttribute)comparands.Subject;
			XAttribute expected = (XAttribute)comparands.Expectation;
			AssertionChain.GetOrCreate().For(context).ReuseOnce();
			actualValue.Should().Be(expected, context.Reason.FormattedMessage, context.Reason.Arguments);
			return EquivalencyResult.EquivalencyProven;
		}
	}
}
