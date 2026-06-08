using System.Xml;

namespace Amazon.S3.Model
{
	public class ParquetInput
	{
		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			xmlWriter.WriteEndElement();
		}
	}
}
