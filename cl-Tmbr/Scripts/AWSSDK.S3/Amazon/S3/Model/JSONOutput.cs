using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public class JSONOutput
	{
		public string RecordDelimiter { get; set; }

		internal bool IsSetRecordDelimiter()
		{
			return RecordDelimiter != null;
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			if (IsSetRecordDelimiter())
			{
				xmlWriter.WriteElementString("RecordDelimiter", S3Transforms.ToXmlStringValue(RecordDelimiter));
			}
			xmlWriter.WriteEndElement();
		}
	}
}
