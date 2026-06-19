using System.Xml.Serialization;

namespace Origin.Data
{
	public class CreateGroupT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string GroupName;

		[XmlAttribute]
		public GroupTypeT GroupType;
	}
}
