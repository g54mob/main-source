using System.Xml.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class XDocumentEquivalencyStep : EquivalencyStep<XDocument>
	{
		protected override EquivalencyResult OnHandle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency nestedValidator)
		{
			XDocument actualValue = (XDocument)comparands.Subject;
			XDocument expected = (XDocument)comparands.Expectation;
			AssertionChain.GetOrCreate().For(context).ReuseOnce();
			actualValue.Should().BeEquivalentTo(expected, context.Reason.FormattedMessage, context.Reason.Arguments);
			return EquivalencyResult.EquivalencyProven;
		}
	}
}
