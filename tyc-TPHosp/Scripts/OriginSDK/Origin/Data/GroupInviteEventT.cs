using System.Xml.Serialization;

namespace Origin.Data
{
	public class GroupInviteEventT
	{
		[XmlAttribute]
		public string GroupName;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public GroupTypeT GroupType;

		[XmlAttribute]
		public ulong FromId;
	}
}
