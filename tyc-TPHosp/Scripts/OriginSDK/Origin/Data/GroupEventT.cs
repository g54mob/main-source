using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class GroupEventT
	{
		[XmlElement(ElementName = "Friend")]
		public List<FriendT> Members;
	}
}
