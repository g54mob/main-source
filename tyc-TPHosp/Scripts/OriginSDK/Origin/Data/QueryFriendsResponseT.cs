using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryFriendsResponseT
	{
		[XmlElement(ElementName = "Friend")]
		public List<FriendT> Friends;
	}
}
