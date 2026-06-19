using System.Xml.Serialization;

namespace Origin.Data
{
	public class ChallengeResponseT
	{
		[XmlAttribute]
		public string response;

		[XmlAttribute]
		public string key;

		[XmlAttribute]
		public string securityKey;

		[XmlAttribute(AttributeName = "version")]
		public string ProtocolVersion;

		[XmlElement]
		public string ContentId;

		[XmlElement]
		public string Title;

		[XmlElement]
		public string MultiplayerId;

		[XmlElement]
		public string Language;

		[XmlElement(ElementName = "Version")]
		public string SdkVersion;
	}
}
