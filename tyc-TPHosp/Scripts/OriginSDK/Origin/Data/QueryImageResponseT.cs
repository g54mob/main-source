using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryImageResponseT
	{
		[XmlAttribute]
		public int Result;

		[XmlElement(ElementName = "Image")]
		public List<ImageT> Images;
	}
}
