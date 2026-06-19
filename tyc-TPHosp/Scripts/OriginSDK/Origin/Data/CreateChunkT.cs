using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class CreateChunkT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlElement]
		public List<string> Files;
	}
}
