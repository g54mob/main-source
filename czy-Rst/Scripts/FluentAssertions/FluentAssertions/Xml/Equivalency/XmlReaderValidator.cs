using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using FluentAssertions.Execution;

namespace FluentAssertions.Xml.Equivalency
{
	internal class XmlReaderValidator
	{
		private readonly AssertionChain assertionChain;

		private readonly XmlReader subjectReader;

		private readonly XmlReader expectationReader;

		private XmlIterator subjectIterator;

		private XmlIterator expectationIterator;

		private Node currentNode = Node.CreateRoot();

		public XmlReaderValidator(AssertionChain assertionChain, XmlReader subjectReader, XmlReader expectationReader, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			this.assertionChain = assertionChain;
			assertionChain.BecauseOf(because, becauseArgs);
			this.subjectReader = subjectReader;
			this.expectationReader = expectationReader;
		}

		public void Validate(bool shouldBeEquivalent)
		{
			Failure failure = Validate();
			if (shouldBeEquivalent && failure != null)
			{
				assertionChain.FailWith(failure.FormatString, failure.FormatParams);
			}
			if (!shouldBeEquivalent && failure == null)
			{
				assertionChain.FailWith("Did not expect {context:subject} to be equivalent{reason}, but it is.");
			}
		}

		private Failure Validate()
		{
			if (subjectReader == null && expectationReader == null)
			{
				return null;
			}
			Failure failure = ValidateAgainstNulls();
			if (failure != null)
			{
				return failure;
			}
			subjectIterator = new XmlIterator(subjectReader);
			expectationIterator = new XmlIterator(expectationReader);
			while (!subjectIterator.IsEndOfDocument && !expectationIterator.IsEndOfDocument)
			{
				if (subjectIterator.NodeType != expectationIterator.NodeType)
				{
					string text = ((expectationIterator.NodeType == XmlNodeType.Text) ? ("content \"" + expectationIterator.Value + "\"") : $"{expectationIterator.NodeType} \"{expectationIterator.LocalName}\"");
					string text2 = ((subjectIterator.NodeType == XmlNodeType.Text) ? ("content \"" + subjectIterator.Value + "\"") : $"{subjectIterator.NodeType} \"{subjectIterator.LocalName}\"");
					return new Failure("Expected " + text + " in {context:subject} at {0}{reason}, but found " + text2 + ".", currentNode.GetXPath());
				}
				switch (expectationIterator.NodeType)
				{
				case XmlNodeType.Element:
					failure = ValidateStartElement();
					if (failure != null)
					{
						return failure;
					}
					currentNode = currentNode.Push(expectationIterator.LocalName);
					failure = ValidateAttributes();
					if (expectationIterator.IsEmptyElement)
					{
						currentNode = currentNode.Parent;
					}
					if (subjectIterator.IsEmptyElement && !expectationIterator.IsEmptyElement)
					{
						expectationIterator.MoveToEndElement();
					}
					else if (expectationIterator.IsEmptyElement && !subjectIterator.IsEmptyElement)
					{
						subjectIterator.MoveToEndElement();
					}
					break;
				case XmlNodeType.EndElement:
					currentNode.Pop();
					currentNode = currentNode.Parent;
					break;
				case XmlNodeType.Text:
					failure = ValidateText();
					break;
				default:
					throw new NotSupportedException($"{expectationIterator.NodeType} found at {currentNode.GetXPath()} is not supported for equivalency comparison.");
				}
				if (failure != null)
				{
					return failure;
				}
				subjectIterator.Read();
				expectationIterator.Read();
			}
			if (!expectationIterator.IsEndOfDocument)
			{
				return new Failure("Expected {0} in {context:subject}{reason}, but found end of document.", expectationIterator.LocalName);
			}
			if (!subjectIterator.IsEndOfDocument)
			{
				return new Failure("Expected end of document in {context:subject}{reason}, but found {0}.", subjectIterator.LocalName);
			}
			return null;
		}

		private Failure ValidateAttributes()
		{
			IList<AttributeData> attributes = expectationIterator.GetAttributes();
			IList<AttributeData> subjectAttributes = subjectIterator.GetAttributes();
			foreach (AttributeData subjectAttribute in subjectAttributes)
			{
				AttributeData attributeData = attributes.SingleOrDefault((AttributeData ea) => ea.NamespaceUri == subjectAttribute.NamespaceUri && ea.LocalName == subjectAttribute.LocalName);
				if (attributeData == null)
				{
					return new Failure("Did not expect to find attribute {0} in {context:subject} at {1}{reason}.", subjectAttribute.QualifiedName, currentNode.GetXPath());
				}
				if (subjectAttribute.Value != attributeData.Value)
				{
					return new Failure("Expected attribute {0} in {context:subject} at {1} to have value {2}{reason}, but found {3}.", subjectAttribute.LocalName, currentNode.GetXPath(), attributeData.Value, subjectAttribute.Value);
				}
			}
			if (subjectAttributes.Count != attributes.Count)
			{
				AttributeData attributeData2 = attributes.First((AttributeData ea) => !subjectAttributes.Any((AttributeData sa) => ea.NamespaceUri == sa.NamespaceUri && sa.LocalName == ea.LocalName));
				return new Failure("Expected attribute {0} in {context:subject} at {1}{reason}, but found none.", attributeData2.LocalName, currentNode.GetXPath());
			}
			return null;
		}

		private Failure ValidateStartElement()
		{
			if (subjectIterator.LocalName != expectationIterator.LocalName)
			{
				return new Failure("Expected local name of element in {context:subject} at {0} to be {1}{reason}, but found {2}.", currentNode.GetXPath(), expectationIterator.LocalName, subjectIterator.LocalName);
			}
			if (subjectIterator.NamespaceUri != expectationIterator.NamespaceUri)
			{
				return new Failure("Expected namespace of element {0} in {context:subject} at {1} to be {2}{reason}, but found {3}.", subjectIterator.LocalName, currentNode.GetXPath(), expectationIterator.NamespaceUri, subjectIterator.NamespaceUri);
			}
			return null;
		}

		private Failure ValidateText()
		{
			string value = subjectIterator.Value;
			string value2 = expectationIterator.Value;
			if (value != value2)
			{
				return new Failure("Expected content to be {0} in {context:subject} at {1}{reason}, but found {2}.", value2, currentNode.GetXPath(), value);
			}
			return null;
		}

		private Failure ValidateAgainstNulls()
		{
			if (expectationReader == null != (subjectReader == null))
			{
				return new Failure("Expected {context:subject} to be equivalent to {0}{reason}, but found {1}.", subjectReader, expectationReader);
			}
			return null;
		}
	}
}
