using System.Xml.Serialization;

namespace Origin.Data
{
	public class BlockUserT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong UserIdToBlock;
	}
}
