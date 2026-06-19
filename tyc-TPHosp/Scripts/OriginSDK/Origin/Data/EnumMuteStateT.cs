using System.Xml.Serialization;

namespace Origin.Data
{
	public enum EnumMuteStateT
	{
		[XmlEnum("NONE")]
		NONE = 0,
		[XmlEnum("UNMUTED")]
		UNMUTED = 1,
		[XmlEnum("MUTED_LOCALLY")]
		MUTED_LOCALLY = 2,
		[XmlEnum("MUTED_REMOTELY")]
		MUTED_REMOTELY = 3,
		[XmlEnum("MUTED_LOCALLY_AND_REMOTELY")]
		MUTED_LOCALLY_AND_REMOTELY = 4
	}
}
