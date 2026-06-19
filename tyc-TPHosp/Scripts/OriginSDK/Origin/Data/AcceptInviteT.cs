using System.Xml.Serialization;

namespace Origin.Data
{
	public class AcceptInviteT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong OtherId;
	}
}
