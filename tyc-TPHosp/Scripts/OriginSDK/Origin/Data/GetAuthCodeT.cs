using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetAuthCodeT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string ClientId;

		[XmlAttribute]
		public string Scope;

		[XmlAttribute]
		public bool AppendAuthSource;
	}
}
