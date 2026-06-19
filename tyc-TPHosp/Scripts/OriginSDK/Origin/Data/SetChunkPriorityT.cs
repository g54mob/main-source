using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class SetChunkPriorityT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlElement]
		public List<int> ChunkIds;
	}
}
