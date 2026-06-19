using System.Xml.Serialization;

namespace Origin.Data
{
	public class ChatStateUpdateEventT
	{
		[XmlAttribute]
		public ChatStateT State;

		[XmlAttribute]
		public ulong UserId;
	}
}
