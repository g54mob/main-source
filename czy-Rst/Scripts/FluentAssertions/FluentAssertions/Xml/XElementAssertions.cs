using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions.Xml.Equivalency;

namespace FluentAssertions.Xml
{
	[DebuggerNonUserCode]
	public class XElementAssertions : ReferenceTypeAssertions<XElement, XElementAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "XML element";

		public XElementAssertions(XElement xElement, AssertionChain assertionChain)
			: base(xElement, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<XElementAssertions> Be(XElement expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(XNode.DeepEquals(base.Subject, expected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> NotBe(XElement unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition((base.Subject == null && unexpected != null) || !XNode.DeepEquals(base.Subject, unexpected)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:subject} to be {0}{reason}.", unexpected);
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> BeEquivalentTo(XElement expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlReader subjectReader = base.Subject?.CreateReader())
			{
				using XmlReader expectationReader = expected?.CreateReader();
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: true);
			}
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> NotBeEquivalentTo(XElement unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlReader subjectReader = base.Subject?.CreateReader())
			{
				using XmlReader expectationReader = unexpected?.CreateReader();
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: false);
			}
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> HaveValue(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the element to have value {0}{reason}, but {context:member} is <null>.", expected);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(base.Subject.Value == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} '{0}' to have value {1}{reason}, but found {2}.", base.Subject.Name, expected, base.Subject.Value);
			}
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> HaveAttribute(string expectedName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(expectedName, "expectedName");
			return HaveAttribute(XNamespace.None + expectedName, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> HaveAttribute(XName expectedName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedName, "expectedName");
			string arg = expectedName.ToString();
			assertionChain.WithExpectation("Expected attribute {0} in element to exist {reason}, ", arg, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("but {context:member} is <null>.");
			}).Then.WithExpectation("Expected {context:subject} to have attribute {0}{reason}, ", arg, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(() => base.Subject.Attribute(expectedName)).ForCondition((XAttribute attribute) => attribute != null)
					.FailWith("but found no such attribute in {0}.", base.Subject);
			});
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> NotHaveAttribute(string unexpectedName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(unexpectedName, "unexpectedName");
			return NotHaveAttribute(XNamespace.None + unexpectedName, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> NotHaveAttribute(XName unexpectedName, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedName, "unexpectedName");
			string unexpectedText = unexpectedName.ToString();
			assertionChain.WithExpectation("Did not expect attribute {0} in element to exist{reason}, ", unexpectedText, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("but {context:member} is <null>.", unexpectedText);
			}).Then.WithExpectation("Did not expect {context:subject} to have attribute {0}{reason}, ", unexpectedText, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(() => base.Subject.Attribute(unexpectedName)).ForCondition((XAttribute attribute) => attribute == null)
					.FailWith("but found such attribute in {0}.", base.Subject);
			});
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> HaveAttributeWithValue(string expectedName, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(expectedName, "expectedName");
			return HaveAttributeWithValue(XNamespace.None + expectedName, expectedValue, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> HaveAttributeWithValue(XName expectedName, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedName, "expectedName");
			string arg = expectedName.ToString();
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected attribute {0} in element to have value {1}{reason}, ", arg, expectedValue, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).FailWith("but {context:member} is <null>.");
			}).Then.WithExpectation("Expected {context:subject} to have attribute {0} with value {1}{reason}, ", arg, expectedValue, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(() => base.Subject.Attribute(expectedName)).ForCondition((XAttribute attr) => attr != null)
					.FailWith("but found no such attribute in {0}", base.Subject);
			}).Then.WithExpectation("Expected attribute {0} in {context:subject} to have value {1}{reason}, ", arg, expectedValue, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(() => base.Subject.Attribute(expectedName)).ForCondition((XAttribute attr) => attr.Value == expectedValue)
					.FailWith("but found {0}.", (XAttribute attr) => attr.Value);
			});
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndConstraint<XElementAssertions> NotHaveAttributeWithValue(string unexpectedName, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(unexpectedName, "unexpectedName");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			return NotHaveAttributeWithValue(XNamespace.None + unexpectedName, unexpectedValue, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> NotHaveAttributeWithValue(XName unexpectedName, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedName, "unexpectedName");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			string arg = unexpectedName.ToString();
			assertionChain.WithExpectation("Did not expect attribute {0} in element to have value {1}{reason}, ", arg, unexpectedValue, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("but {context:member} is <null>.");
			}).Then.WithExpectation("Did not expect {context:subject} to have attribute {0} with value {1}{reason}, ", arg, unexpectedValue, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(() => base.Subject.Attributes().FirstOrDefault((XAttribute a) => a.Name == unexpectedName && a.Value == unexpectedValue)).ForCondition((XAttribute attribute) => attribute == null)
					.FailWith("but found such attribute in {0}.", base.Subject);
			});
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndWhichConstraint<XElementAssertions, XElement> HaveElement(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(expected, "expected");
			return HaveElement(XNamespace.None + expected, because, becauseArgs);
		}

		public AndWhichConstraint<XElementAssertions, XElement> HaveElement(XName expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected the element to have child element {0}{reason}, but {context:member} is <null>.", expected.ToString().EscapePlaceholders());
			XElement xElement = null;
			if (assertionChain.Succeeded)
			{
				xElement = base.Subject.Element(expected);
				assertionChain.ForCondition(xElement != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have child element {0}{reason}, but no such child element was found.", expected.ToString().EscapePlaceholders());
			}
			return new AndWhichConstraint<XElementAssertions, XElement>(this, xElement, assertionChain, "/" + expected);
		}

		public AndWhichConstraint<XElementAssertions, IEnumerable<XElement>> HaveElement(XName expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the element has an element count if the element name is <null>.");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have an element with count of {0}{reason}, but the element itself is <null>.", expected.ToString());
			IEnumerable<XElement> enumerable = Array.Empty<XElement>();
			if (assertionChain.Succeeded)
			{
				enumerable = base.Subject.Elements(expected);
				int num = enumerable.Count();
				assertionChain.ForConstraint(occurrenceConstraint, num).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have an element {0} {expectedOccurrence}{reason}, but found it " + num.Times() + ".", expected.ToString());
			}
			return new AndWhichConstraint<XElementAssertions, IEnumerable<XElement>>(this, enumerable, assertionChain, "/" + expected);
		}

		public AndWhichConstraint<XElementAssertions, IEnumerable<XElement>> HaveElement(string expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the element has an element if the expected name is <null>.");
			return HaveElement(XNamespace.None + expected, occurrenceConstraint, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> NotHaveElement(string unexpectedElement, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			return NotHaveElement(XNamespace.None + unexpectedElement, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> NotHaveElement(XName unexpectedElement, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:subject} to have an element {0}{reason}, but the element itself is <null>.", unexpectedElement.ToString());
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.Elements(unexpectedElement).Any()).FailWith("Did not expect {context:subject} to have an element {0}{reason}, but the element {0} was found.", unexpectedElement);
			}
			return new AndConstraint<XElementAssertions>(this);
		}

		public AndWhichConstraint<XElementAssertions, XElement> HaveElementWithValue(string expectedElement, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedElement, "expectedElement");
			Guard.ThrowIfArgumentIsNull(expectedValue, "expectedValue");
			return HaveElementWithValue(XNamespace.None + expectedElement, expectedValue, because, becauseArgs);
		}

		public AndWhichConstraint<XElementAssertions, XElement> HaveElementWithValue(XName expectedElement, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedElement, "expectedElement");
			Guard.ThrowIfArgumentIsNull(expectedValue, "expectedValue");
			IEnumerable<XElement> xElements = Array.Empty<XElement>();
			assertionChain.WithExpectation("Expected {context:subject} to have an element {0} with value {1}{reason}, ", expectedElement.ToString(), expectedValue, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("but the element itself is <null>.");
			}).Then.WithExpectation("Expected {context:subject} to have an element {0} with value {1}{reason}, ", expectedElement, expectedValue, delegate(AssertionChain chain)
			{
				chain.BecauseOf(because, becauseArgs).Given(delegate
				{
					xElements = base.Subject.Elements(expectedElement);
					return xElements;
				}).ForCondition((IEnumerable<XElement> elements) => elements.Any())
					.FailWith("but the element {0} isn't found.", expectedElement)
					.Then.ForCondition((IEnumerable<XElement> elements) => elements.Any((XElement e) => e.Value == expectedValue)).FailWith("but the element {0} does not have such a value.", expectedElement);
			});
			return new AndWhichConstraint<XElementAssertions, XElement>(this, xElements.FirstOrDefault());
		}

		public AndConstraint<XElementAssertions> NotHaveElementWithValue(string unexpectedElement, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			return NotHaveElementWithValue(XNamespace.None + unexpectedElement, unexpectedValue, because, becauseArgs);
		}

		public AndConstraint<XElementAssertions> NotHaveElementWithValue(XName unexpectedElement, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			assertionChain.WithExpectation("Did not expect {context:subject} to have an element {0} with value {1}{reason}, ", unexpectedElement.ToString(), unexpectedValue, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("but the element itself is <null>.")
					.Then.ForCondition(!base.Subject.Elements(unexpectedElement).Any((XElement e) => e.Value == unexpectedValue)).FailWith("but the element {0} does have this value.", unexpectedElement);
			});
			return new AndConstraint<XElementAssertions>(this);
		}
	}
}
