using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class SendGroupGameInviteT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Message;

		[XmlElement]
		public List<ulong> Invitees;
	}
}
