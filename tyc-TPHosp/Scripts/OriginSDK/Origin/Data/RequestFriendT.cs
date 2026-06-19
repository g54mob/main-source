using System.Xml.Serialization;

namespace Origin.Data
{
	public class RequestFriendT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong UserToAdd;
	}
}
