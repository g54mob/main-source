using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryContentResponseT
	{
		[XmlElement(ElementName = "Game")]
		public List<GameT> Content;
	}
}
