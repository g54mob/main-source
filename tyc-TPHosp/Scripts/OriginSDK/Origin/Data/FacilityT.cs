using System.Xml.Serialization;

namespace Origin.Data
{
	public enum FacilityT
	{
		[XmlEnum("EALS")]
		EALS = -2,
		[XmlEnum("EbisuSDK")]
		EbisuSDK = -1,
		[XmlEnum("SDK")]
		SDK = 0,
		[XmlEnum("PROFILE")]
		PROFILE = 1,
		[XmlEnum("PRESENCE")]
		PRESENCE = 2,
		[XmlEnum("FRIENDS")]
		FRIENDS = 3,
		[XmlEnum("COMMERCE")]
		COMMERCE = 4,
		[XmlEnum("RECENTPLAYER")]
		RECENTPLAYER = 5,
		[XmlEnum("IGO")]
		IGO = 6,
		[XmlEnum("MISC")]
		MISC = 7,
		[XmlEnum("LOGIN")]
		LOGIN = 8,
		[XmlEnum("UTILITY")]
		UTILITY = 9,
		[XmlEnum("XMPP")]
		XMPP = 10,
		[XmlEnum("CHAT")]
		CHAT = 11,
		[XmlEnum("IGO_EVENT")]
		IGO_EVENT = 12,
		[XmlEnum("EALS_EVENTS")]
		EALS_EVENTS = 13,
		[XmlEnum("LOGIN_EVENT")]
		LOGIN_EVENT = 14,
		[XmlEnum("INVITE_EVENT")]
		INVITE_EVENT = 15,
		[XmlEnum("PROFILE_EVENT")]
		PROFILE_EVENT = 16,
		[XmlEnum("PRESENCE_EVENT")]
		PRESENCE_EVENT = 17,
		[XmlEnum("FRIENDS_EVENT")]
		FRIENDS_EVENT = 18,
		[XmlEnum("COMMERCE_EVENT")]
		COMMERCE_EVENT = 19,
		[XmlEnum("CHAT_EVENT")]
		CHAT_EVENT = 20,
		[XmlEnum("DOWNLOAD_EVENT")]
		DOWNLOAD_EVENT = 21,
		[XmlEnum("PERMISSION")]
		PERMISSION = 22,
		[XmlEnum("RESOURCES")]
		RESOURCES = 23,
		[XmlEnum("BLOCKED_USERS")]
		BLOCKED_USERS = 24,
		[XmlEnum("BLOCKED_USER_EVENT")]
		BLOCKED_USER_EVENT = 25,
		[XmlEnum("GET_USERID")]
		GET_USERID = 26,
		[XmlEnum("ONLINE_STATUS_EVENT")]
		ONLINE_STATUS_EVENT = 27,
		[XmlEnum("ACHIEVEMENT")]
		ACHIEVEMENT = 28,
		[XmlEnum("ACHIEVEMENT_EVENT")]
		ACHIEVEMENT_EVENT = 29,
		[XmlEnum("BROADCAST_EVENT")]
		BROADCAST_EVENT = 30,
		[XmlEnum("PROGRESSIVE_INSTALLATION")]
		PROGRESSIVE_INSTALLATION = 31,
		[XmlEnum("PROGRESSIVE_INSTALLATION_EVENT")]
		PROGRESSIVE_INSTALLATION_EVENT = 32,
		[XmlEnum("CONTENT")]
		CONTENT = 33
	}
}
