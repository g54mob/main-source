using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Xml
{
	[DebuggerNonUserCode]
	public class XmlElementAssertions : XmlNodeAssertions<XmlElement, XmlElementAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "XML element";

		public XmlElementAssertions(XmlElement xmlElement, AssertionChain assertionChain)
			: base(xmlElement, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<XmlElementAssertions> HaveInnerText(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.InnerText == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have value {0}{reason}, but found {1}.", expected, base.Subject.InnerText);
			return new AndConstraint<XmlElementAssertions>(this);
		}

		public AndConstraint<XmlElementAssertions> HaveAttribute(string expectedName, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveAttributeWithNamespace(expectedName, string.Empty, expectedValue, because, becauseArgs);
		}

		public AndConstraint<XmlElementAssertions> HaveAttributeWithNamespace(string expectedName, string expectedNamespace, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			XmlAttribute xmlAttribute = base.Subject.Attributes[expectedName, expectedNamespace];
			string text = (string.IsNullOrEmpty(expectedNamespace) ? string.Empty : ("{" + expectedNamespace + "}")) + expectedName;
			assertionChain.ForCondition(xmlAttribute != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have attribute {0} with value {1}{reason}, but found no such attribute in {2}", text, expectedValue, base.Subject);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(xmlAttribute.Value == expectedValue).BecauseOf(because, becauseArgs).FailWith("Expected attribute {0} in {context:subject} to have value {1}{reason}, but found {2}.", text, expectedValue, xmlAttribute.Value);
			}
			return new AndConstraint<XmlElementAssertions>(this);
		}

		public AndWhichConstraint<XmlElementAssertions, XmlElement> HaveElement(string expectedName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveElementWithNamespace(expectedName, null, because, becauseArgs);
		}

		public AndWhichConstraint<XmlElementAssertions, XmlElement> HaveElementWithNamespace(string expectedName, string expectedNamespace, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			XmlElement xmlElement = ((expectedNamespace == null) ? base.Subject[expectedName] : base.Subject[expectedName, expectedNamespace]);
			string value = (string.IsNullOrEmpty(expectedNamespace) ? string.Empty : ("{" + expectedNamespace + "}")) + expectedName;
			assertionChain.ForCondition(xmlElement != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have child element {0}{reason}, but no such child element was found.", value.EscapePlaceholders());
			return new AndWhichConstraint<XmlElementAssertions, XmlElement>(this, xmlElement, assertionChain, "/" + expectedName);
		}
	}
}
