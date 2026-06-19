using System.Xml.Serialization;

namespace Origin.Data
{
	public class AcceptFriendInviteT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong OtherId;
	}
}
