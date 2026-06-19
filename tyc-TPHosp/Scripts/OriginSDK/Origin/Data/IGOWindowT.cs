using System.Xml.Serialization;

namespace Origin.Data
{
	public enum IGOWindowT
	{
		[XmlEnum("LOGIN")]
		LOGIN = 1,
		[XmlEnum("PROFILE")]
		PROFILE = 2,
		[XmlEnum("RECENT")]
		RECENT = 3,
		[XmlEnum("FEEDBACK")]
		FEEDBACK = 4,
		[XmlEnum("FRIENDS")]
		FRIENDS = 5,
		[XmlEnum("FRIEND_REQUEST")]
		FRIEND_REQUEST = 6,
		[XmlEnum("CHAT")]
		CHAT = 7,
		[XmlEnum("COMPOSE_CHAT")]
		COMPOSE_CHAT = 8,
		[XmlEnum("INVITE")]
		INVITE = 9,
		[XmlEnum("ACHIEVEMENTS")]
		ACHIEVEMENTS = 10,
		[XmlEnum("STORE")]
		STORE = 11,
		[XmlEnum("CODE_REDEMPTION")]
		CODE_REDEMPTION = 12,
		[XmlEnum("CHECKOUT")]
		CHECKOUT = 13,
		[XmlEnum("BLOCKED")]
		BLOCKED = 14,
		[XmlEnum("BROWSER")]
		BROWSER = 15,
		[XmlEnum("FIND_FRIENDS")]
		FIND_FRIENDS = 16,
		[XmlEnum("CHANGE_AVATAR")]
		CHANGE_AVATAR = 17,
		[XmlEnum("GAMEDETAILS")]
		GAMEDETAILS = 18,
		[XmlEnum("BROADCAST")]
		BROADCAST = 19,
		[XmlEnum("UPSELL")]
		UPSELL = 20
	}
}
