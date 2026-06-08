using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model.Internal
{
	internal class IntelligentTieringPredicateVisitor : IIntelligentTieringPredicateVisitor
	{
		private readonly XmlWriter xmlWriter;

		public IntelligentTieringPredicateVisitor(XmlWriter xmlWriter)
		{
			this.xmlWriter = xmlWriter;
		}

		public void Visit(IntelligentTieringPrefixPredicate intelligentTieringPrefixPredicate)
		{
			if (intelligentTieringPrefixPredicate != null)
			{
				xmlWriter.WriteElementString("Prefix", "http://s3.amazonaws.com/doc/2006-03-01/", S3Transforms.ToXmlStringValue(intelligentTieringPrefixPredicate.Prefix));
			}
		}

		public void Visit(IntelligentTieringTagPredicate intelligentTieringTagPredicate)
		{
			if (intelligentTieringTagPredicate != null)
			{
				xmlWriter.WriteStartElement("Tag", "http://s3.amazonaws.com/doc/2006-03-01/");
				if (intelligentTieringTagPredicate.Tag.IsSetKey())
				{
					xmlWriter.WriteElementString("Key", "http://s3.amazonaws.com/doc/2006-03-01/", S3Transforms.ToXmlStringValue(intelligentTieringTagPredicate.Tag.Key));
				}
				if (intelligentTieringTagPredicate.Tag.IsSetValue())
				{
					xmlWriter.WriteElementString("Value", "http://s3.amazonaws.com/doc/2006-03-01/", S3Transforms.ToXmlStringValue(intelligentTieringTagPredicate.Tag.Value));
				}
				xmlWriter.WriteEndElement();
			}
		}

		public void Visit(IntelligentTieringAndOperator intelligentTieringAndOperatorPredicate)
		{
			if (intelligentTieringAndOperatorPredicate == null)
			{
				return;
			}
			xmlWriter.WriteStartElement("And", "http://s3.amazonaws.com/doc/2006-03-01/");
			foreach (IntelligentTieringFilterPredicate operand in intelligentTieringAndOperatorPredicate.Operands)
			{
				operand?.Accept(this);
			}
			xmlWriter.WriteEndElement();
		}
	}
}
