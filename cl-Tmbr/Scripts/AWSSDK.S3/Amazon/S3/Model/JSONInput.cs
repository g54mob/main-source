using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public class JSONInput
	{
		public JsonType JsonType { get; set; }

		internal bool IsSetType()
		{
			return JsonType != null;
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			if (IsSetType())
			{
				xmlWriter.WriteElementString("Type", S3Transforms.ToXmlStringValue(JsonType.Value));
			}
			xmlWriter.WriteEndElement();
		}
	}
}
