using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class AreChunksInstalledResponseT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public bool Installed;

		[XmlElement]
		public List<int> ChunkIds;
	}
}
