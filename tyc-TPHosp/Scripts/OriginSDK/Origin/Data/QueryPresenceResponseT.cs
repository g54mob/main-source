using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryPresenceResponseT
	{
		[XmlElement(ElementName = "Friend")]
		public List<FriendT> Friends;
	}
}
