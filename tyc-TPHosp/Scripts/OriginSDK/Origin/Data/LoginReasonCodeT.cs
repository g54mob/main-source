using System.Xml.Serialization;

namespace Origin.Data
{
	public enum LoginReasonCodeT
	{
		[XmlEnum("UNDEFINED")]
		UNDEFINED = 0,
		[XmlEnum("USER_INITIATED")]
		USER_INITIATED = 1,
		[XmlEnum("ALREADY_ONLINE")]
		ALREADY_ONLINE = 2,
		[XmlEnum("NETWORK_ERROR")]
		NETWORK_ERROR = 3,
		[XmlEnum("INVALID_CREDENTIALS")]
		INVALID_CREDENTIALS = 4,
		[XmlEnum("ACCESSTOKEN_REFRESH_ERROR")]
		ACCESSTOKEN_REFRESH_ERROR = 5
	}
}
