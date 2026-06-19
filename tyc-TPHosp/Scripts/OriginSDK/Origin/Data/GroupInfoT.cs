using System.Xml.Serialization;

namespace Origin.Data
{
	public class GroupInfoT
	{
		[XmlAttribute]
		public string GroupName;

		[XmlAttribute]
		public string GroupId;

		[XmlAttribute]
		public GroupTypeT GroupType;

		[XmlAttribute]
		public bool CanInviteNewMembers;

		[XmlAttribute]
		public bool CanRemoveMembers;

		[XmlAttribute]
		public bool CanSendGameInvites;

		[XmlAttribute]
		public int MaxGroupSize;
	}
}
