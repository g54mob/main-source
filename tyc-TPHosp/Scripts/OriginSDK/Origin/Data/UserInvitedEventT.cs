using System.Xml.Serialization;

namespace Origin.Data
{
	public class UserInvitedEventT
	{
		[XmlAttribute]
		public ulong UserId;
	}
}
