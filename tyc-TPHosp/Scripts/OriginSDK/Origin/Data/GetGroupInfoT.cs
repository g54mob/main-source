using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetGroupInfoT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string GroupId;
	}
}
