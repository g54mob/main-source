using System.Xml.Serialization;

namespace Origin.Data
{
	public class SendChatMessageT
	{
		[XmlAttribute]
		public ulong FromId;

		[XmlAttribute]
		public ulong ToId;

		[XmlAttribute]
		public string Thread;

		[XmlAttribute]
		public string Message;

		[XmlAttribute]
		public string GroupId;
	}
}
