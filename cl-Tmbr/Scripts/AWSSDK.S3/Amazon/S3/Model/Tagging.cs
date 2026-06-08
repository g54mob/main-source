using System.Collections.Generic;
using System.Xml;

namespace Amazon.S3.Model
{
	public class Tagging
	{
		private List<Tag> tagSet = (AWSConfigs.InitializeCollections ? new List<Tag>() : null);

		public List<Tag> TagSet
		{
			get
			{
				return tagSet;
			}
			set
			{
				tagSet = value;
			}
		}

		internal void Marshall(string memberName, XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(memberName);
			xmlWriter.WriteStartElement("TagSet");
			if (tagSet != null)
			{
				foreach (Tag item in tagSet)
				{
					item.Marshall("Tag", xmlWriter);
				}
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
	}
}
