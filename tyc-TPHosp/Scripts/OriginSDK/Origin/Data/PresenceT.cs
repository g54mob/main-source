using System.Xml.Serialization;

namespace Origin.Data
{
	public enum PresenceT
	{
		[XmlEnum("UNKNOWN")]
		UNKNOWN = -1,
		[XmlEnum("OFFLINE")]
		OFFLINE = 0,
		[XmlEnum("ONLINE")]
		ONLINE = 1,
		[XmlEnum("INGAME")]
		INGAME = 2,
		[XmlEnum("BUSY")]
		BUSY = 3,
		[XmlEnum("IDLE")]
		IDLE = 4,
		[XmlEnum("JOINABLE")]
		JOINABLE = 5,
		[XmlEnum("JOINABLE_INVITE_ONLY")]
		JOINABLE_INVITE_ONLY = 6
	}
}
