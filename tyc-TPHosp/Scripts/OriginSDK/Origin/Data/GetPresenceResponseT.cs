using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetPresenceResponseT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public PresenceT Presence;

		[XmlAttribute]
		public string Title;

		[XmlAttribute]
		public string TitleId;

		[XmlAttribute]
		public string MultiplayerId;

		[XmlAttribute]
		public string RichPresence;

		[XmlAttribute]
		public string GamePresence;

		[XmlAttribute]
		public string SessionId;

		[XmlAttribute]
		public string Group;

		[XmlAttribute]
		public string GroupId;
	}
}
