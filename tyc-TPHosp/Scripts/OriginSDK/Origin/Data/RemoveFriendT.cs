using System.Xml.Serialization;

namespace Origin.Data
{
	public class RemoveFriendT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong UserToRemove;
	}
}
