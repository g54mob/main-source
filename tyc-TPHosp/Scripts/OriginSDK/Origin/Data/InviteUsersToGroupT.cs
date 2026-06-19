using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class InviteUsersToGroupT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlElement]
		public List<ulong> FriendId;
	}
}
