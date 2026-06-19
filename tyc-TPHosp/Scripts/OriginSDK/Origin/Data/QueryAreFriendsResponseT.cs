using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryAreFriendsResponseT
	{
		[XmlElement(ElementName = "FriendStatus")]
		public List<FriendStatusT> Users;
	}
}
