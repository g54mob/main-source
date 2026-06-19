using System.Xml.Serialization;

namespace Origin.Data
{
	public class SetPresenceT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public PresenceT Presence;

		[XmlAttribute]
		public string RichPresence;

		[XmlAttribute]
		public string GamePresence;

		[XmlAttribute]
		public string SessionId;
	}
}
