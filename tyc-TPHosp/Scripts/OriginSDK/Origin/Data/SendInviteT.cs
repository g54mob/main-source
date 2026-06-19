using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class SendInviteT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Invitation;

		[XmlElement]
		public List<ulong> Invitees;
	}
}
