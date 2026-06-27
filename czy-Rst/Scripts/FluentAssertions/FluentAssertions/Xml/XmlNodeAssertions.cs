using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions.Xml.Equivalency;

namespace FluentAssertions.Xml
{
	[DebuggerNonUserCode]
	public class XmlNodeAssertions : XmlNodeAssertions<XmlNode, XmlNodeAssertions>
	{
		public XmlNodeAssertions(XmlNode xmlNode, AssertionChain assertionChain)
			: base(xmlNode, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class XmlNodeAssertions<TSubject, TAssertions> : ReferenceTypeAssertions<TSubject, TAssertions> where TSubject : XmlNode where TAssertions : XmlNodeAssertions<TSubject, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "XML node";

		public XmlNodeAssertions(TSubject xmlNode, AssertionChain assertionChain)
			: base(xmlNode, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> BeEquivalentTo(XmlNode expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlNodeReader subjectReader = new XmlNodeReader(base.Subject))
			{
				using XmlNodeReader expectationReader = new XmlNodeReader(expected);
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: true);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo(XmlNode unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			using (XmlNodeReader subjectReader = new XmlNodeReader(base.Subject))
			{
				using XmlNodeReader expectationReader = new XmlNodeReader(unexpected);
				new XmlReaderValidator(assertionChain, subjectReader, expectationReader, because, becauseArgs).Validate(shouldBeEquivalent: false);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
