using System.Xml.Serialization;

namespace Origin.Data
{
	public class MultiplayerInvitePendingT
	{
		[XmlAttribute]
		public string GroupName;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public string MultiplayerId;

		[XmlAttribute]
		public ulong from;
	}
}
