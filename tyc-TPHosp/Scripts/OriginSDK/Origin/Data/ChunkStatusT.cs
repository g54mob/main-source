using System.Xml.Serialization;

namespace Origin.Data
{
	public class ChunkStatusT
	{
		[XmlAttribute]
		public int ChunkId;

		[XmlAttribute]
		public string Name;

		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public ChunkTypeT Type;

		[XmlAttribute]
		public ChunkStateT State;

		[XmlAttribute]
		public float Progress;

		[XmlAttribute]
		public ulong Size;

		[XmlAttribute]
		public int ChunkETA;

		[XmlAttribute]
		public int TotalETA;
	}
}
