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
	public class XDocumentAssertions : ReferenceTypeAssertions<XDocument, XDocumentAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "XML document";

		public XDocumentAssertions(XDocument document, AssertionChain assertionChain)
			: base(document, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<XDocumentAssertions> Be(XDocument expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(object.Equals(base.Subject, expected)).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<XDocumentAssertions>(this);
		}

		public AndConstraint<XDocumentAssertions> NotBe(XDocument unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!object.Equals(base.Subject, unexpected)).FailWith("Did not expect {context:subject} to be {0}{reason}.", unexpected);
			return new AndConstraint<XDocumentAssertions>(this);
		}

		public AndConstraint<XDocumentAssertions> BeEquivalentTo(XDocument expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlReader subjectReader = base.Subject?.CreateReader())
			{
				using XmlReader expectationReader = expected?.CreateReader();
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: true);
			}
			return new AndConstraint<XDocumentAssertions>(this);
		}

		public AndConstraint<XDocumentAssertions> NotBeEquivalentTo(XDocument unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlReader subjectReader = base.Subject?.CreateReader())
			{
				using XmlReader expectationReader = unexpected?.CreateReader();
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: false);
			}
			return new AndConstraint<XDocumentAssertions>(this);
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveRoot(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has a root element if the expected name is <null>.");
			return HaveRoot(XNamespace.None + expected, because, becauseArgs);
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveRoot(XName expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (base.Subject == null)
			{
				throw new InvalidOperationException("Cannot assert the document has a root element if the document itself is <null>.");
			}
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has a root element if the expected name is <null>.");
			XElement root = base.Subject.Root;
			assertionChain.ForCondition(root != null && root.Name == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have root element {0}{reason}, but found {1}.", expected.ToString(), base.Subject);
			return new AndWhichConstraint<XDocumentAssertions, XElement>(this, root, assertionChain, $"/{expected}");
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveElement(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has an element if the expected name is <null>.");
			return HaveElement(XNamespace.None + expected, because, becauseArgs);
		}

		public AndWhichConstraint<XDocumentAssertions, IEnumerable<XElement>> HaveElement(string expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has an element if the expected name is <null>.");
			return HaveElement(XNamespace.None + expected, occurrenceConstraint, because, becauseArgs);
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveElement(XName expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (base.Subject == null)
			{
				throw new InvalidOperationException("Cannot assert the document has an element if the document itself is <null>.");
			}
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has an element if the expected name is <null>.");
			assertionChain.ForCondition(base.Subject.Root != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have root element with child {0}{reason}, but it has no root element.", expected.ToString());
			XElement xElement = null;
			if (assertionChain.Succeeded)
			{
				xElement = base.Subject.Root.Element(expected);
				assertionChain.ForCondition(xElement != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have root element with child {0}{reason}, but no such child element was found.", expected.ToString());
			}
			return new AndWhichConstraint<XDocumentAssertions, XElement>(this, xElement, assertionChain, "/" + expected);
		}

		public AndWhichConstraint<XDocumentAssertions, IEnumerable<XElement>> HaveElement(XName expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert the document has an element count if the element name is <null>.");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Cannot assert the count if the document itself is <null>.");
			IEnumerable<XElement> enumerable = Array.Empty<XElement>();
			if (assertionChain.Succeeded)
			{
				XElement root = base.Subject.Root;
				assertionChain.ForCondition(root != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have root element containing a child {0}{reason}, but it has no root element.", expected.ToString());
				if (assertionChain.Succeeded)
				{
					enumerable = root.Elements(expected);
					int num = enumerable.Count();
					assertionChain.ForConstraint(occurrenceConstraint, num).BecauseOf(because, becauseArgs).FailWith("Expected {context:subject} to have a root element containing a child {0} {expectedOccurrence}{reason}, but found it " + num.Times() + ".", expected.ToString());
				}
			}
			return new AndWhichConstraint<XDocumentAssertions, IEnumerable<XElement>>(this, enumerable, assertionChain, "/" + expected);
		}

		public AndConstraint<XDocumentAssertions> NotHaveElement(string unexpectedElement, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			return NotHaveElement(XNamespace.None + unexpectedElement, because, becauseArgs);
		}

		public AndConstraint<XDocumentAssertions> NotHaveElement(XName unexpectedElement, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect {context:subject} to have an element {0}{reason}, ", unexpectedElement, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).FailWith("but the element itself is <null>.").Then.ForCondition(!base.Subject.Root.Elements(unexpectedElement).Any()).FailWith(" but the element {0} was found.", unexpectedElement);
			});
			return new AndConstraint<XDocumentAssertions>(this);
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveElementWithValue(string expectedElement, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedElement, "expectedElement");
			Guard.ThrowIfArgumentIsNull(expectedValue, "expectedValue");
			return HaveElementWithValue(XNamespace.None + expectedElement, expectedValue, because, becauseArgs);
		}

		public AndWhichConstraint<XDocumentAssertions, XElement> HaveElementWithValue(XName expectedElement, string expectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedElement, "expectedElement");
			Guard.ThrowIfArgumentIsNull(expectedValue, "expectedValue");
			IEnumerable<XElement> xElements = Array.Empty<XElement>();
			assertionChain.WithExpectation("Expected {context:subject} to have an element {0} with value {1}{reason}, ", expectedElement.ToString(), expectedValue, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("but the element itself is <null>.", expectedElement.ToString(), expectedValue)
					.Then.Given(delegate
				{
					xElements = base.Subject.Root.Elements(expectedElement).ToList();
					return xElements;
				}).ForCondition((IEnumerable<XElement> collection) => collection.Any()).FailWith("but the element {0} isn't found.", expectedElement)
					.Then.ForCondition((IEnumerable<XElement> collection) => collection.Any((XElement e) => e.Value == expectedValue)).FailWith("but the element {0} does not have such a value.", expectedElement);
			});
			return new AndWhichConstraint<XDocumentAssertions, XElement>(this, xElements.FirstOrDefault());
		}

		public AndConstraint<XDocumentAssertions> NotHaveElementWithValue(string unexpectedElement, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			return NotHaveElementWithValue(XNamespace.None + unexpectedElement, unexpectedValue, because, becauseArgs);
		}

		public AndConstraint<XDocumentAssertions> NotHaveElementWithValue(XName unexpectedElement, string unexpectedValue, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedElement, "unexpectedElement");
			Guard.ThrowIfArgumentIsNull(unexpectedValue, "unexpectedValue");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect {context:subject} to have an element {0} with value {1}{reason}, ", unexpectedElement, unexpectedValue, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).FailWith("but the element itself is <null>.").Then.ForCondition(!base.Subject.Root.Elements(unexpectedElement).Any((XElement e) => e.Value == unexpectedValue)).FailWith("but the element {0} does have this value.", unexpectedElement);
			});
			return new AndConstraint<XDocumentAssertions>(this);
		}
	}
}
