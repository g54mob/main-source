using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Xml
{
	[DebuggerNonUserCode]
	public class XAttributeAssertions : ReferenceTypeAssertions<XAttribute, XAttributeAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "XML attribute";

		public XAttributeAssertions(XAttribute attribute, AssertionChain assertionChain)
			: base(attribute, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<XAttributeAssertions> Be(XAttribute expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject?.Name == expected?.Name && base.Subject?.Value == expected?.Value).BecauseOf(because, becauseArgs).FailWith("Expected {context} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<XAttributeAssertions>(this);
		}

		public AndConstraint<XAttributeAssertions> NotBe(XAttribute unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!(base.Subject?.Name == unexpected?.Name) || !(base.Subject?.Value == unexpected?.Value)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context} to be {0}{reason}.", unexpected);
			return new AndConstraint<XAttributeAssertions>(this);
		}

		public AndConstraint<XAttributeAssertions> HaveValue(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the attribute to have value {0}{reason}, but {context:member} is <null>.", expected);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(base.Subject.Value == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context} \"{0}\" to have value {1}{reason}, but found {2}.", base.Subject.Name, expected, base.Subject.Value);
			}
			return new AndConstraint<XAttributeAssertions>(this);
		}
	}
}
