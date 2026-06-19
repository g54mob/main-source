using System.Xml.Serialization;

namespace Origin.Data
{
	public enum FriendStateT
	{
		[XmlEnum("NONE")]
		NONE = 0,
		[XmlEnum("MUTUAL")]
		MUTUAL = 1,
		[XmlEnum("INVITED")]
		INVITED = 2,
		[XmlEnum("DECLINED")]
		DECLINED = 3,
		[XmlEnum("REQUEST")]
		REQUEST = 4
	}
}
