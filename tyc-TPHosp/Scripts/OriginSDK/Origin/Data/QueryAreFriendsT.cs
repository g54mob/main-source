using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryAreFriendsT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlElement]
		public List<ulong> Friends;
	}
}
