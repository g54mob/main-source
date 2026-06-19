using System.Xml.Serialization;

namespace Origin.Data
{
	public enum ProfileStateChangeT
	{
		[XmlEnum("EAID")]
		EAID = 0,
		[XmlEnum("AVATAR")]
		AVATAR = 1,
		[XmlEnum("SUBSCRIPTION")]
		SUBSCRIPTION = 2
	}
}
