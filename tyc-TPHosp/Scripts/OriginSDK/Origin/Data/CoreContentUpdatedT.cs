using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class CoreContentUpdatedT
	{
		[XmlElement(ElementName = "Game")]
		public List<GameT> Games;
	}
}
