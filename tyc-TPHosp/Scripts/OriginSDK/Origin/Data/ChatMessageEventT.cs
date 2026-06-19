using System.Xml.Serialization;

namespace Origin.Data
{
	public class ChatMessageEventT
	{
		[XmlAttribute]
		public ulong FromId;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public string Thread;

		[XmlAttribute]
		public string Message;
	}
}
