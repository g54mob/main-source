using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryContentT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string MultiplayerId;

		[XmlAttribute]
		public int ContentType;

		[XmlElement(ElementName = "MasterTitleId")]
		public List<string> GameId;
	}
}
