using System.Xml;
using Amazon.S3.Model.Internal.MarshallTransformations;

namespace Amazon.S3.Model
{
	public class ScanRange
	{
		private long? start;

		private long? end;

		public long? Start
		{
			get
			{
				return start;
			}
			set
			{
				start = value;
			}
		}

		public long? End
		{
			get
			{
				return end;
			}
			set
			{
				end = value;
			}
		}

		internal bool IsSetStart()
		{
			return start.HasValue;
		}

		internal bool IsSetEnd()
		{
			return end.HasValue;
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			if (IsSetStart())
			{
				xmlWriter.WriteElementString("Start", S3Transforms.ToXmlStringValue(Start.Value));
			}
			if (IsSetEnd())
			{
				xmlWriter.WriteElementString("End", S3Transforms.ToXmlStringValue(End.Value));
			}
			xmlWriter.WriteEndElement();
		}
	}
}
