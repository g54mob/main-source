using System.Xml.Serialization;

namespace Origin.Data
{
	public class FriendStatusT
	{
		[XmlAttribute]
		public ulong FriendId;

		[XmlAttribute]
		public FriendStateT State;
	}
}
