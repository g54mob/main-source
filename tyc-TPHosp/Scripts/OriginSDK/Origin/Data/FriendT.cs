using System.Xml.Serialization;

namespace Origin.Data
{
	public class FriendT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;

		[XmlAttribute]
		public string Persona;

		[XmlAttribute]
		public string AvatarId;

		[XmlAttribute]
		public string Group;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public PresenceT Presence;

		[XmlAttribute]
		public FriendStateT State;

		[XmlAttribute]
		public string TitleId;

		[XmlAttribute]
		public string Title;

		[XmlAttribute]
		public string MultiplayerId;

		[XmlAttribute]
		public string RichPresence;

		[XmlAttribute]
		public string GamePresence;
	}
}
