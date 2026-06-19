using System.Xml.Serialization;

namespace Origin.Data
{
	public class MultiplayerInviteT
	{
		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public string GroupName;

		[XmlAttribute]
		public string multiplayerId;

		[XmlAttribute]
		public bool initial;

		[XmlAttribute]
		public ulong from;

		[XmlElement]
		public string SessionInformation;
	}
}
