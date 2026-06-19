using System.Xml.Serialization;

namespace Origin.Data
{
	public class UnblockUserT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong UserIdToUnblock;
	}
}
