using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryChunkFilesT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public int ChunkId;
	}
}
